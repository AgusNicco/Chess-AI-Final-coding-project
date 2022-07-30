For our final project we tried to create a Chess AI that was capable of finding the best moves in a given position using a brute-force approach. We were able to create a TicTacToc AI that used the technique but we failed to apply the logic on the Chess AI. We underestimated how much processing times this kind of a approach takes and we were unable to make the Chess AI work. As it was explained in the video, this tecnique combines two functions, GetPossibleMoves() and EvaluatePosition() to create a decision making tree. We were able to create the GetPossibleMoves() for the ChessAI but by the time we were done with that one we realised it was taking too much time, and we couldn't find a way to make a working EvaluatePosition() function. 

The TicTacToe AI is were all of the requiremens will be found, but We also included Chess AI in the submission to show the scope of our project. It has one of the three fundamental parts of a brute-force AI. The funcion is tested and works perfectly. 

This project put our problem-solving abilities to the test and we really enoyed doing it. When we have more time we are going to come back and attempt to finish the Chess AI, but for now, we are happy with the result we had.

The AI uses a brute force approach to determine what is the best move in a given position. It achives this by combining two fundamental functions, the GetPossibleMoves() function and the EvaluatePositionFunction(). The GetPossibleMoves() function is combined with the Node Class to create the decisio- making tree that stores all possible combination of moves. Once each Node has been created, the EvaluatePosition() is used to assing a number that represents how combinient a position is, with inifinity being the most convenient, and  -infinity being the least. Thereafter, a backpropagation process begins in which each nodes looks at the scores of the nodes it has ahead and pulls the corresponding score. If the next layer of nodes represents a move Played by the AI, it will pull back the highest score, if not, the lowest. Once the process is finished, the first node, the one in the layer 0 looks at the options it has and plays the move that has the most convenient score.

Documentation on the organization of the project as well as the purpose of each of it's elements can be found at the end.



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

4. Tests - 11 Tests can be found in the file Tests



Documentation on each Class, Member, and function and its purpose: (this information can also be found in comments in the code):

File Chess AI:
        Contains the only fraction that what we are able to effectively achieve of the chess AI. If we head to the File Game, line 202, we will find the GetLegalMoves() function that takes in a chess board and returns a list with all of the legal moves that are possible. It is one of the three fundamental elements of a brute-force AI.

File TicTacToe AI:

File Classes:
        Contains all of the files that contain either an interface or a class.
File Main:
        Contains the driver of the program
File Tests:
        Contains a test for each of the complex element of the program.


File Game: 

Interface Game:
        It contains every funtion and property that is required to play a game of TicTacToe. It receives user input, validates moves and displays the board.

Function IsMoveLegal():
        Is used to verify that the AI or  the player did not make an illegal move. It receives a Move and makes sure the coordinates of that move do not correspond to a cell that is full.
Function IsBoardFull():
        It is used to determine if a game has been drawn. It analyses each of the cells in the Board and verifies that there is at least one free cell. If this is not true, it returns true.
Function TranslateMove():
        It interacts with the user input. It takes in a string that it translatr to an integer from 1 to 9 and translates it into a Move class that is returned.
Function TranslateCoord():
        It interacts with the user input.  It takes in an integer from 1 to 9 and translates it into a Move class that is returned with the corresponding coords.
Function ExecuteMove():
        Is used while the Game is being played to verify that an input that the Player or AI provided is a legal move proceeds to execute it if true.
Function IsCheckMate():
        Is used to verify if checkmate has occured after a move was played. It will check every cell one by one and return true if any straight lines have been formed. Which can be vertically, horizontally, or diagonally.
Function PrintMap():
        Is used to print the map to the console so that the user can see it. 
Function CharArrayToList()
        Takes in a jagged array of characters and converts it into a List of arrays of caracters. It was created because the AI works better with lists. 
Function GetFreeCells():
        Takes in a jagged array of characters that will represent a TicTacToe board and returns a list with the coordinates of the cells that are empty.
Function IsInListOfPoints():
        Receives a list of points and a point and returns true if the point is in the list. It is used for input validation. 
Function StartGame():
        This function combines most of the functions above to create a game and receive and validate input from the player as well as the AI. It is in charge of displaying the game to the user.
Function EndGame()
        This function is in charge of ending the game and displaying the result to the user. It will take in an enumeration indicating if the Game ended in a draw, a won for the AI, or a won for the Player.



File AI:
        Holds the AI interface in which the Node class is nested.

Interface AI:
        It holds every function and property the AI needs in order to be able to receive a given postion and return the best move. 

Funtion SwitchDifficulty():
        Adjusts the SearDepth variable of the AI according to an enumeration that indicates the level of difficulty in which the user wants to play.
Function EvaluatePosition():
        Takes in a TicTacToe board in the form of a List of char arrays and returns an integer that represents how convenient the position is for the AI. A 3 would represent a winning position, a -3 would represent a losing position, and a 0 a draw or that no one has the advantage.
Function GetPossibleMoves();
        Takes in a TicTacToe board in the form of a List of char arrays and returns a list of moves with every legal move in the given position. It is used to create the decision-making tree.

Class Node:
        It is nested in the AI interface. It is used to create the decision-making tree. It takes in a position and uses recursion to create a tree with every possible combination of moves.
Function BruteDoMove():
        Takes in a TicTacToe board in the form of a List of char arrays and a Move,  and returns a Board in which the Move has been played. It returns a reference instrad of a clean copy, however.
Function DoMoveWithCleanCopy():
        Takes in a TicTacToe board in the form of a List of char arrays and a Move, and returns clean copy a Board in which the Move has been played.
Function GetBestMove():
        Takes in a TicTacToe board in the form of a List of char arrays and uses the Node class to find and return the best move in the position (from the AI's perspective).



File Move:
        Contais the Move class.

Class Move:
        Contains the coordinates of a given moves, a bolean that determines who played the move and an overriden method that validates the move.
Function Validate():
        Returns true if each of the coordinates x and y of a move respect the dimensions of a board of TicTacToe and if the cell that this coordinates represent is empty.



File Point:
        Contains the Point class

Class Point:
        Is used to create a Point that holds the coordinates of a given cell.
Function Validate():
        Returns true if each of the coordinates x and y of a move respect the dimensions of a board of TicTacToe.


