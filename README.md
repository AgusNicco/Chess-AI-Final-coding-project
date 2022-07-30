For our final project we tried to create a Chess AI that was capable of finding the best moves in a given position using a brute-force approach. We were able to create a TicTacToc AI that used the technique but we failed to apply the logic on the Chess AI. We underestimated how much processing times this kind of a approach takes and we were unable to make the Chess AI work. As it was explained in the video, this tecnique combines two functions, GetPossibleMoves() and EvaluatePosition() to create a decision making tree. We were able to create the GetPossibleMoves() for the ChessAI but by the time we were done with that one we realised it was taking too much time, and we couldn't find a way to make a working EvaluatePosition() function. 

The TicTacToe AI is were all of the requiremens will be found, but We also included Chess AI in the submission to show the scope of our project. It has one of the three fundamental parts of a brute-force AI. The funcion is tested and works perfectly. 

This project put our problem-solving abilities to the test and we really enoyed doing it. When we have more time we are going to come back and attempt to finish the Chess AI, but for now, we are happy with what we have.


Requirements:

1. a class definition - File Classes class Game in line 3
        This class is in charge of runnign the Game. It will have a function that validate the moves and check if the game is over.
2. a second class definition - File Game, class Pomt in line 514
        This class is used to store the coordinates of the pieces that are on the board. 
3. a third class definition - File AI, class AI in line 3
         This class will control the AI, it will hold the decision-making tree as well as all the functions it needs to operate.
4. a struct definition - file Game, line 533.
        We used a struct because each move will be unequal to any other move and we need them to have a unique copy of their data/
5. an enumerated type - pending
         we will use one to define the three different states in which a game can end: player wins, AI wins or draw. 
6. inheritance - pending
        We will make the AI class inherit the Node class to create the tree of moves
7. polymorphism - pending
        We will create a method that gets all the legal moves the player can make with certain piece and the piece will override the method according to its type.
8. a second example of polymorphism - pending
9. throwing an exception and properly catching it - File Game, Line 84
        This is used in the IsCheck function to make sure the program does not crash when the index is out of range.
10. definition of your own generic datatype - pending
        We will to this when creating a class foreach type of piece.
11. properties - Files Game, class Game, line 5
        Every class has multiple properties. Most of them had were set to public for testing purposes.
12. a static member function - file Game, line 202.
        GetLegalMoves() is used to prvide the AI with all moves possible in a given position.
13. an interface - pending
        We will create one that holds the score of a given position.
14. a second interface - pending
        We will use one to store all of the pieces that have been captured.
15. use of at least two of the built-in generic collection types - one pending, one done in file Game, line 5
        We used Lists to create multidimensianal arrays that are easier to modify and work with.

Additionals:
1. Recursion - TicTactoe - File AI, line 122
        The Node constructor uses recursion to create a Node for each possible move in the position and the uses a backpropagation process to pull the score from the nodes ahead.
2. Record - TicTacToe - File AI, line 214
        This record is used to create instances of moves. They are composed of the location where the move will be played and who is playing the move