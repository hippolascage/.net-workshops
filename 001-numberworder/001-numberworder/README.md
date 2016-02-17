NumberWorder
============

A console application (numberworder.exe) that expects a single numeric parameter. The application prints each character in the number as a word. 

E.g.

> numberworder.exe 1234
ONETWOTHREEFOUR

Invalid Input
=============

If the user executes the program incorrectly, feedback will be provided. 

E.g.

Run NumberWorder without arguments:
> numberworder.exe 
You didn't supply any arguments! Try again with one argument, please.

Run NumberWorder with too many arguments:
> numberworder.exe  1234 5678
You supplied too many arguments! Try again with one argument, please.

Run NumberWorder with invalid arguments:
> numberworder.exe  12!34
ONETWO>> "!" invalid character supplied. Integers only, please. <<THREEFOUR