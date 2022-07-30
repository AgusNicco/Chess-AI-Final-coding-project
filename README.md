For our final project we tried to create a Chess AI that was capable of finding the best moves in a given position using a brute-force approach. We were able to create a TicTacToc AI that used the technique but we failed to apply the logic on the Chess AI. We underestimated how much processing times this kind of a approach takes and we were unable to make the Chess AI work. As it was explained in the video, this tecnique combines two functions, GetPossibleMoves() and EvaluatePosition() to create a decision making tree. We were able to create the GetPossibleMoves() for the ChessAI but by the time we were done with that one we realised it was taking too much time, and we couldn't find a way to make a working EvaluatePosition() function. 

The TicTacToe AI is were all of the requiremens will be found, but We also included Chess AI in the submission to show the scope of our project. It has one of the three fundamental parts of a brute-force AI. The funcion is tested and works perfectly. 

This project put our problem-solving abilities to the test and we really enoyed doing it. When we have more time we are going to come back and attempt to finish the Chess AI, but for now, we are happy with the result we had.


Requirements: 
All found in the TicTacToe AI. There are a lot of comments in the code indicating where a requirement was achieved. There is comments for every single class, interface or function that explains its purpose. Here is a list with their location and an explanation of why they were used:

1. a class definition - File AI - class Node in line 198
2. a second class definition - File Move, class Move in line 6
3. a third class definition - File Point, class Point in line 6
        We used Classes in these cases because they were going to be used to create serveral instances of themselves and we wanted them to be of reference type to avoid unnecesary coppying.

4. a struct definition - 
        We were unable to implement this one as there was no case in which implementing a struct would improve processing speed. As the book said, structs are 50 times less common than classes.

5. an enumerated type - File AI, lines 12 and 115
        We used an enumerated type here because there is a short number of cases in which the difficulty can be set. 

6. inherihtance - File Move, line 6
        We made the Move class inherit the Point Class because each move is also going to have a set of coordinates making it this way would save us time.

7. polymorphism - File Move, line 34
        The Move class inherited the Validate() method from the Point class but it was neccesary to override it so that it also checks if the Cell that it's coordinates correspond to is empty. 
        
8. a second example of polymorphism - 

9. throwing an exception and properly catching it - File Game, Line 94
        The IsCheckMateFunctions goes cell by cell and looks in every direction, up, down, left, and right, checking if the same character has been repeated 3 times. Under these circumnstances the function would try to check a cell that is outside of the range of the array and would throw and excepting. We would simply catch it and ignore it. If we did not do this the code would have had to be more complex like that in the EvaluatePositionFunction and exception handling saves us time here. 

10. definition of your own generic datatype - 

11. properties - File AI, lines 7 and 203
        We used these to create variables to store, and in some cases change, relevant information.
        
12. a static member function - file Game, line 48.
        EvaluatePosition() is used to analyse and grade a position depending on how convenient it is for the AI. The function is static because it must interact with static properties and is in an interface.

13. an interface - File Game, line 5
14. a second interface - File AI, line 4
        We used interfaces for Game and AI because the members of this two are going to be static and won't have an implementation. There will not be any instances of a Game or a Class. We also wanted the members of this classes to be abstract to the outside world by default, the outside world does not need to know how the members of this interfaces work unless otherwise indicated with a static keyword. 

15. use of at least two of the built-in generic collection types - File AI, line 231 
and file Tests, line 253
        We used Lists to store and pass a multidemansional array that contained a hypothetical position in the Node clas. Lists were benefitial because the information needed to be passed as value and the built in method .Add() of lists made them easier to create and copy their items one by one.
        We had to use IEnumerable on the Tests because we needed to iterate through a list of Moves and the Move class does not contain a definition for .GetEnumerator(). If we tried to do it with a foreach loop it would not work, we left some code that can be uncommented to verify this. 

Extra credit:

2. Recursion -  File AI, line 252
        The Node constructor uses recursion to call itself and create a Node for each possible move in the position and the uses a backpropagation process to pull the score from the nodes ahead.

3. Operator overloading - File Move, line 13
        We had to overload the '==' and '!=' operators in order to be able to compare moves with moves to verify that they are equal.

4. Tests - 11 Tests can be found in the File Tests