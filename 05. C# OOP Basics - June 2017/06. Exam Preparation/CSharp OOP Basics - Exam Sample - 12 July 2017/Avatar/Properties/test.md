<div type="HEADER">

\

</div>

[Exercises]{lang="bg-BG"}: Polymorphism {#exercises-polymorphism .western align="CENTER"}
=======================================

This document defines the exercises for [["C\# OOP Basics" course @
Software
University](https://softuni.bg/trainings/1636/c-sharp-oop-basics-june-2017)]{lang="zxx"}.
Please submit your solutions (source code) of all below described
problems in
[[Judge](https://judge.softuni.bg/Contests/241/Polymorphism-Exercise)]{lang="zxx"}.

1.  Vehicles {#vehicles .western align="JUSTIFY"}
    --------

Write a program that models 2 vehicles (**Car** and **Truck**) and will
be able to simulate **driving** and **refueling** them. **Car** and
**truck** both have **fuel quantity**, **fuel consumption** **in
liters** **per km** and can be **driven given distance** and **refueled
with given liters.** But in the summer both vehicles use air conditioner
and their **fuel consumption** per km is **increased** by **0.9** liters
for the **car** and with **1.6** liters for the **truck**. Also the
**truck** has a tiny hole in his tank and when it gets **refueled** it
gets only **95%** of given **fuel**. The **car** has no problems when
refueling and adds **all given fuel to its tank.** If a vehicle cannot
travel the given distance its fuel **does not change.**

[**Input**]{lang="bg-BG"}

-   [[[On the
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[first
    line]{lang="en-US"}**]{lang="bg-BG"}[[[ - information about the car
    in format
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[{Car
    {fuel quantity} {liters per km}}]{lang="en-US"}**]{lang="bg-BG"}

-   [[[On the
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[second
    line]{lang="en-US"}**]{lang="bg-BG"}[[[ – info about the truck in
    format
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[{Truck
    {fuel quantity} {liters per km}}]{lang="en-US"}**]{lang="bg-BG"}

-   [[[On the third line -
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[number
    of commands N]{lang="en-US"}**]{lang="bg-BG"}[[[ that will be given
    on the next
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[N]{lang="en-US"}**]{lang="bg-BG"}[[[
    lines]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

-   [[[On the next
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[N
    ]{lang="en-US"}**]{lang="bg-BG"}[[[lines – commands in
    format]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

<!-- -->

-   [**[Drive Car {distance}]{lang="en-US"}**]{lang="bg-BG"}

-   [**[Drive Truck {distance}]{lang="en-US"}**]{lang="bg-BG"}

-   [**[Refuel Car {liters}]{lang="en-US"}**]{lang="bg-BG"}

-   [**[Refuel Truck {liters}]{lang="en-US"}**]{lang="bg-BG"}

[**Output**]{lang="bg-BG"}

[[[After each
]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[Drive
command]{lang="en-US"}**]{lang="bg-BG"}[[[ print whether the Car/Truck
was able to travel the given distance in the formats below. If it’s
successful:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car/Truck travelled {distance} km]{lang="en-US"}**]{lang="bg-BG"}

[[[Or if it is
not:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car/Truck needs refueling]{lang="en-US"}**]{lang="bg-BG"}

[[[Finally print the
]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[remaining
fuel]{lang="en-US"}**]{lang="bg-BG"}[[[ for both car and truck rounded
to ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[2
digits after the floating point]{lang="en-US"}**]{lang="bg-BG"}[[[ in
format:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car: {liters}]{lang="en-US"}**]{lang="bg-BG"}

[**[Truck: {liters}]{lang="en-US"}**]{lang="bg-BG"}

### Examples {#examples .western}

++
|  |
++
|  |
++
|  |
++

\
\

2.  Vehicles Extension {#vehicles-extension .western align="JUSTIFY"}
    ------------------

[]{#OLE_LINK2}[]{#OLE_LINK1} Use your solution of the previous task for
starting point and add more functionality. Add new vehicle – **Bus**.
Now every vehicle has **tank capacity** and fuel quantity **cannot
fall** **below 0** (If fuel quantity become less than 0 **print** on the
console **“Fuel must be a positive number”**).

[]{#OLE_LINK5}[]{#OLE_LINK4}[]{#OLE_LINK3} The **car** and the **bus**
**cannot be filled up** with **more** fuel **than their tank capacity**.
If you **try to put more fuel** in the tank than the **available
space,** print on the console **“Cannot fit fuel in tank”** and **do not
add any fuel** in vehicles tank.

Add **new command** for the bus. The **bus** can **drive** **with or
without people**. If the bus is driving **with people**, the
**air-conditioner** **is turned on** and its **fuel consumption** per
kilometer is **increased with 1.4 liters**. If there are **no people in
the bus** when driving the air-conditioner is **turned off** and **does
not increase** the fuel consumption.

### Input {#input .western}

-   On the first three lines you will receive information about the
    vehicles in format:

**Vehicle {initial fuel quantity} {liters per km} {tank capacity}**

-   [[[On fourth line -
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[number
    of commands N]{lang="en-US"}**]{lang="bg-BG"}[[[ that will be given
    on the next
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[N]{lang="en-US"}**]{lang="bg-BG"}[[[
    lines]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

-   [[[On the next
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[N
    ]{lang="en-US"}**]{lang="bg-BG"}[[[lines – commands in
    format]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

    -   [**[Drive Car {distance}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[Drive Truck {distance}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[Drive Bus {distance}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[DriveEmpty Bus {distance}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[Refuel Car {liters}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[Refuel Truck {liters}]{lang="en-US"}**]{lang="bg-BG"}

    -   [**[Refuel Bus {liters}]{lang="en-US"}**]{lang="bg-BG"}

### Output {#output .western}

-   [[[After each
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[Drive
    command]{lang="en-US"}**]{lang="bg-BG"}[[[ print whether the
    Car/Truck was able to travel given distance in format if it’s
    successful:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car/Truck/Bus travelled {distance}
km]{lang="en-US"}**]{lang="bg-BG"}

-   [[[Or if it is
    not:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car/Truck/Bus needs refueling]{lang="en-US"}**]{lang="bg-BG"}

-   [[[If given fuel
    is]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"} **≤
    0** print **“Fuel must be a positive number”.**

-   [[[If given fuel cannot fit in car or bus tank print
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[“Cannot
    fit in tank”]{lang="en-US"}**]{lang="bg-BG"}

-   [[[Finally print the
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[remaining
    fuel]{lang="en-US"}**]{lang="bg-BG"}[[[ for both car and truck
    rounded
    ]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}[**[2
    digits after floating point]{lang="en-US"}**]{lang="bg-BG"}[[[ in
    format:]{style="font-weight: normal"}]{lang="en-US"}]{lang="bg-BG"}

[**[Car: {liters}]{lang="en-US"}**]{lang="bg-BG"}

[**[Truck: {liters}]{lang="en-US"}**]{lang="bg-BG"}

[**[Bus: {liters}]{lang="en-US"}**]{lang="bg-BG"}

\
\

### Example {#example .western}

++
|  |
++
|  |
++

[]{#_GoBack}\
\

3.  Wild farm {#wild-farm .western align="JUSTIFY"}
    ---------

Your task is to create a class hierarchy like in the picture below. All
the classes **except** Vegetable, Meat, Mouse, Tiger, Cat & Zebra
**should be abstract**. Override method **ToString()**.

![](Polymorphism-Exercises_html_918d0546.png){width="695" height="464"}

Input should be read from the console. Every **odd** line will contain
information about the Animal in following format:

**{AnimalType} {AnimalName} {AnimalWeight} {AnimalLivingRegion}
\[{CatBreed}** *= Only if its cat***\]**

On the **even** lines you will receive information about the food that
you should give to the Animal. The line will consist of **FoodType** and
**quantity** separated by a whitespace.

**{FoodType} {Quantiy}**

You should build the logic to determine if the animal is going to eat
the provided food. The **Mouse** and **Zebra** should check if the food
is a **Vegetable**. If it is they will eat it - otherwise you should
print a message in the format:

[]{#OLE_LINK7}[]{#OLE_LINK6} **{AnimalType in plural} are not eating
that type of food!**

\

**Cats** eat **any** kind of food, but **Tigers** accept **only Meat**.
If **Vegetable** is provided to a **Tiger** message like the one above
should be printed on the console.

\

Override **ToString()** method to print the information about the animal
in format:

\

**{AnimalType}\[{AnimalName}, {CatBreed}, {AnimalWeight},
{AnimalLivingRegion}, {FoodEaten}\]**

After you read information about the Animal and Food then invoke the
**MakeSound()** method of the current animal and then feed it. At the
end print the whole object and proceed reading information about the
next animal/food. The input will continue until you receive “**End**”
for animal information.

Sounds produced by the animals:

-   []{#OLE_LINK13}[]{#OLE_LINK12} **Mouse – “SQUEEEAAAK!”**

-   **Zebra – “Zs”**

-   []{#OLE_LINK9}[]{#OLE_LINK8} **Cat – “Meowwww”**

-   []{#OLE_LINK11}[]{#OLE_LINK10} **Tiger – “ROAAR!!!”**

### Input {#input-1 .western}

You will receive lines on the Console until the command “End” is
received. On every odd line you will be provided with information about
an animal. On every even line you will receive the food which is given
to the animal.

### Output {#output-1 .western}

For each animal you have read, print two lines on the Console:

-   On the first line: the sound produced by the animal

-   On the second line: all the information about the animal in the
    format described above

### Example {#example-1 .western}

  --------------------------- ------------------------------------------
  Input                       Output

  Cat Gray 1.1 Home Persian   Meowwww
                              
  Vegetable 4                 Cat\[Gray, Persian, 1.1, Home, 4\]
                              
  End                         

  Tiger Typcho 167.7 Asia     ROAAR!!!
                              
  Vegetable 1                 Tigers are not eating that type of food!
                              
  End                         Tiger\[Typcho, 167.7, Asia, 0\]

  Zebra Doncho 500 Africa     Zs
                              
  Vegetable 150               Zebra\[Doncho, 500, Africa, 150\]
                              
  End                         

  Mouse Jerry 0.5 Anywhere    SQUEEEAAAK!
                              
  Vegetable 0                 Mouse\[Jerry, 0.5, Anywhere, 0\]
                              
  End                         
  --------------------------- ------------------------------------------

\
\

<div type="FOOTER">

![](Polymorphism-Exercises_html_8aaa23de.gif) [ ]{dir="LTR"
style="float: left; width: 0.62in; height: 0.22in; border: none; padding-top: 0in; padding-bottom: 0in; padding-left: 0.02in; padding-right: 0in; background: #ffffff"}

Follow us:

[ ]{dir="LTR"
style="float: left; width: 0.98in; height: 0.22in; border: none; padding: 0in; background: #ffffff"}
Page 4 of 4

[ ]{dir="LTR"
style="float: left; width: 5.5in; height: 0.56in; border: none; padding-top: 0.05in; padding-bottom: 0.02in; padding-left: 0.02in; padding-right: 0.02in; background: #ffffff"}
© Software University Foundation ([softuni.org](http://softuni.org/)).
This work is licensed under the
[CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/)
license.

![Software
University](Polymorphism-Exercises_html_8d4adb0.png){width="21"
height="21"} ![Software University
Foundation](Polymorphism-Exercises_html_9b2444bf.png){width="21"
height="21"} ![Software University @
Facebook](Polymorphism-Exercises_html_182676f0.png){width="21"
height="21"} ![Software University @
Twitter](Polymorphism-Exercises_html_e434ea96.png){width="21"
height="21"} ![Software University @
YouTube](Polymorphism-Exercises_html_420dff10.png){width="21"
height="21"} ![Software University @
Google+](Polymorphism-Exercises_html_b594ea43.png){width="21"
height="21"} ![Software University @
LinkedIn](Polymorphism-Exercises_html_90c3a09f.png){width="21"
height="21"} ![Software University @
SlideShare](Polymorphism-Exercises_html_dea8ce74.png){width="21"
height="21"} ![Software University @
GitHub](Polymorphism-Exercises_html_a11d9f7b.png){width="21"
height="21"} ![Software University: Email
Us](Polymorphism-Exercises_html_35cb98ce.png){width="21" height="21"}

[ ]{dir="LTR"
style="float: left; width: 1.71in; height: 0.56in; border: none; padding: 0.02in; background: #ffffff"}
![Software University Foundation -
logo](Polymorphism-Exercises_html_8db8252d.jpg){width="143" height="46"}

\

\

</div>
