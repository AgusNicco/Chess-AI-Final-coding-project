
CheckPoint 1:
We made an AI that can play TicTacToe to make sure the technique we are going to use on the Chess AI works properly. Even though the rules of the games are different, we will use the exact same methods and members with similar functioning. The most relevant advancement we have made is the Node class (which is nested in the AI class). The AI is able to analyze the ~300 thousand (9!) possible games of TicTacToe and plays in 3 seconds and plays perfectly. 

Checkpoint 2:
We made a Game class that will hold the Board of the game as well as the coordinates for each of each player's pieces. We also created the GetLegalMoves()function, file Game, line 202. This funcion, along with EvaluatePostition() and the Node class is one of the most important elements of the program. Lastly, we added an struct on the file Game, line 533.


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