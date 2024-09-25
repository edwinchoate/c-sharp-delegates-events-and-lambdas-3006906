
# Notes

## Ch. 1

_delegate_ - a placeholder for a function, a variable that holds a reference to a function. Ex: swapping out which function is going to run based on your program's needs. 

_events_ - a way to broadcast and receive messages throughout an app or across apps or between app and OS. Events are based on delegates. 

- Event broadcasters
- Event listeners

_lambas_ - functionally the same as delegates but written in a more concise syntax. 

## Ch. 2 - Delegates

`delegate` keyword

```C#
public delegate int MyDelegate (int i, string s);

int MyFunc (int i, string s) {...}

MyDelegate f = MyFunc;

f(10, "hello");
```

### Anonymous Delegates

_anonymous delegate_ - a small inline delegate that uses the `delegate` keyword instead of having to write a function name.

```C#
// anonymous delegate
MyDelegate f = delegate(int a) {...};
```

### Composable Delegates

_composable delegates_ - you can chain delegates together and each one will be called in the order in which it was added to the chain. 

```C#
public delegate int MyDelegate (int i, string s);

int d1 (int i, string s) {...}
int d2 (int i, string s) {...}
int d3 (int i, string s) {...}

MyDelegate f1 = d1, f2 = d2, f3 = d3;

// you chain delegates with '+'
MyDelegate all = f1 + f2 + f3;

all(5, "hi");
/*
is the equivalent of...
f1(5, "hi");
f2(5, "hi");
f3(5, "hi");
*/
```

You can use `+=` and `-=` to add and remove delegates from the call chain.

```C#
all += f4; // adds another delegate to the chain
all -= f1; // removes a delegate from the chain
```

* If an exception is thrown by a delegate in the calling chain, and the exception isn't handled within that delegate, then the delegate chain will be broken and all the remaining delegates in the chain will be skipped. 
* The return value returned to the original caller will be the return value of the last delegate of the chain

`ref` params are a nice way of passing data from delegate to delegate in the chain...

```C#
public delegate void MyDelegate(ref int x);

void square (ref int x) { x = x * x; }
void addFive (ref int x) { x = x + 5; }

MyDelgate d1 = square, d2 = addFive;
MyDelegate calc = d1 + d2;

int a = 10;
calc(ref a);

Console.WriteLine(a.ToString());
// Prints '105'
```

## Ch. 3 - Events

* Based on delegates
* Asynchronous
* Can be switched on and off

Defining an event:

```C#
// you use delegates to define the structure of events
public delegate void MyEventHandler(int i);

class MyClass 
{
	// you use the `event` keyword to create the event
	public event MyEventHandler myEvent;

	public void RaiseEvent () 
	{
		// you raise events by calling them like a function
		myEvent(123);
	}
}
```

Listening for an event:

```C#
void Main (string[] args) 
{
	MyClass obj = new MyClass();

	obj.myEvent += delegate (int i) {...}
}
```

### .NET Event Guidelines

The .NET Framework structures events with `sender` and `EventArgs` objects.

* `sender` is the object where the event originated
* `EventArgs e` contains data about the event 

```C#
public delegate void EventHandler (object sender, EventArgs e);
```

you define the event args with a subclass

```C#
class MyEventArgs : EventArgs
{
	public string data;
}
```

you use generics to associate the EventArgs subclass with the event delegate. 

```C#
public event EventHandler<MyEventArgs> eventHandler;
```

Note: [`EventHandler`](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler?view=net-8.0) is not an arbitrary name, it is the .NET delegate to use.

when you're raising the event, 

* You can use `this` to easily identify the object raising the event
* You create a new `EventArgs` object to pass in the data

```C#
eventHandler(this, new MyEventArgs() { data = "hello" });
```

### Naming Conventions

* Use the suffix `EventHandler` for delegates.
* Use the suffix `EventArgs` for subclasses of `EventArgs`.
* Use params `object sender` and `EventArgs e`.

Example: 

```C#
public delegate void ClickedEventHandler (object sender, ClickedEventArgs e);
```

## Ch. 4 - Lambda Functions

* A shorthand way of writing anonymous functions in C#.
* Based on delegates, usable anywhere where you can use delegates. 
* Small and compact. Useful for inline code. 
* Use the `=>` operator 

```C#
// define delegate the normal way 
public delegate int MyDelegate (int i);

// use `=>` operator to write an inline anonymous delegate 
MyDelegate f = x => x * x;
```

### Expression Lambdas

```C#
MyDelegate f = x => x * x; // Notice, `x * x` is not a full statement.
```

### Statement Lambdas

```C#
(x, y) => {
	f1(x); // Notice, `f1(x);` is a full statement.
	f2(y);
}
```


Using an anonymous lambda function to listen to an event:

```C#
obj.eventHandler += (x, y) => {...};
```