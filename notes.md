
# Notes

## Ch. 1

_delegate_ - a placeholder for a function, a variable that holds a reference to a function. Ex: swapping out which function is going to run based on your program's needs. 

_events_ - a way to broadcast and receive messages throughout an app or across apps or between app and OS. Events are based on delegates. 

- Event broadcasters
- Event listeners

_lambas_ - functionally the same as delegates but written in a more concise syntax. 

## Ch. 2

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
MyDelegate += f4; // adds another delegate to the chain
MyDelegate -= f1; // removes a delegate from the chain
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
