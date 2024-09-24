
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

