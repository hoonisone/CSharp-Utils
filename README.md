# CSharp-Utils
this is a package of library that gives very simple but effective functions

# 1.ValueContainer

## Function
1. Can apply any constraint to value
  - don't need to make a code of getter, setter
  - support type: MinVc, MaxVC, MinMaxVC


2. Can enroll value event
  - don't need to check the value event
  - by using ValueConatainer, we can subscribe some value events
  - Support Type: Get, Set, Changed

## Example
1. Constraint example
  - this is for MinMaxVC (FullName: MinMaxValueContainer)

~~~
  MinMaxVC<int> vc = new MinMaxVC<int>(10, 100, 30);
  vc.v = 0;  // => error
  vc.v = 10;  // => no problem
  vc.v = 50;  // => no problem
  vc.v = 100; // => no problem
  vc.v = 200; // => error
~~~
~~~
  MinMaxVC<int> vc = new MinMaxVC<int>(10, 100, 30, true);
  vc.v = 0;  // => autoHandling => v will be set by 10
  vc.v = 10;  // => no problem
  vc.v = 50;  // => no problem
  vc.v = 100; // => no problem
  vc.v = 200; // => autoHandling => v will be set by 100
~~~

2. Value event example
~~~
  MinMaxVC<int> vc = new MinMaxVC<int>(10, 100, 30, true);
  vc.onChanged += (before, after) => print(before + after);
  
  vc.v = 50; // => The result of 30+50 will be printed
~~~

