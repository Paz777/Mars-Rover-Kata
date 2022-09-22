# Mars Rover Kata

## Mars Rover Kata using TDD and C#

As part of the Tech Returners training Programme, I am learning and utilising the skills of Test Driven Development and C# for the Mars Rover Kata.

## Setting the Scene

Working in an Engineering Squad for the Melody Mars Mission, I am tasked with designing software to manage robots and cool vehicles for space exploration! Rovers navigate the Plateau so they can use their special cameras and robot arms to collect samples back to Planet Earth.

## Project Brief

The Plateau is divided into a grid. "5 5" represents the width and height. A Rover’s position is represented by x and y co-ordinates and the letters N, S, W, E to represent North, South, West, East respectively. "0 0 N" means the Rover is at the bottom-left corner facing in the North direction. 

To move a Rover around the Plateau, a string of letters is sent to a Rover. 

Here are the letters and their resultant action:
 
* L - Spins the Rover 90 degrees Left without moving from the current  coordinate point
* R - Spins the Rover 90 degrees Right without moving from the current  coordinate point
* M - Moves the Rover forward by one grid point, maintaining the same  heading (i.e. from where the Rover is facing (its orientation)). Assume that the square directly North from (x, y) is (x, y+1).

Inputs into the program are given by string.

A move instruction "LMLMLMLMM" would move a rover at position "1 2 N" to position "1 3 N".

## Project Setup

The solution has 2 projects. The main implementation is seperated into model, interface, exception and validator. The test project has been split into mission control tests, rover tests and validator tests.

The Mission Control class takes the input as a string and allows a Plateau and Rovers to be added. It takes instructions and moves the Rovers around the Plateau.

## Project Development

The project allowed me to develop my TDD skills using AAA (Arrange, Act and Assert) and Red, Green, Refactor approach which evolved the code base for the Plateau and Rover classes. Initially there was an association between Rover and Plateau which then evolved by not having the association as it was managed by the Mission Control class. Validations also evolved which moved from Rover, then to Mission Control and finally to a separate class for validations which uses specific Exceptions based on what is being validated.

## Additional Considerations

Consideration for validation has been taken into account such as:

* Position and Plateau can not be negative.
* Can not do anything with a Rover if it is not on the Plateau.
* Rover can not be placed outside the Plateau.
* If the move instructions given to a Rover results in the Position being outside the Plateau the move is aborted.

Exceptions implemented

* PositionException
* MoveException
* PlateauException

## Updates

* More validations for simple tests such as null, incorrect string format still need to be completed.
* Though Rovers returned from Mission Control is readonly it can be modified from outside the class. Accessors needs to be correctly implemented.
* Plateau's that need to be different shapes rather than a square can be done by holding a list of points and calculating the shape of the Plateau accordingly.

## Future Development

As an extension to the project I'm looking to develop this into the Mars Rover Hunger Games.

* The BattleRover would extend Rover and will be able to Dig for Mars Rocks, throw Mars Rocks to a specific position, land hits on other Rovers, limit the no of move instructions, pick up Items found on the Plateau.
* The Plateau can have hidden Items such as Super Sensors. When a Rover uses the Super Sensor it can get back information based on a certain radius, of what positions Items, Rovers and other Vehicles are at.
* Rovers would need to be placed at a random position.








