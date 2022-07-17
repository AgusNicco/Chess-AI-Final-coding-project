We made an AI that can play TicTacToe to make sure the technique we are going to use on the Chess AI works properly. Even though the rules of the games are different, we will use the exact same methods and members with similar functioning. The most relevant advancement we have made is the Node class (which is nested in the AI class). The AI is able to analyze the ~300 thousand (9!) possible games of TicTacToe and plays in 3 seconds and plays perfectly. 

1. a class definition - File Game, class Game in line 3
        This class is in charge of runnign the Game. It has function that validate the moves and check if the game is over.
2. a second class definition - File AI, class AI in line 
        This class controls the AI, it holds the decision-making tree as well as all the functions it needs to operate. 
3. a third class definition - File AI, class Node (nested in class AI) in line 78
        The node is the most important class in the program. It is used to create the decision-making, evaluate every possible outcome up to a certain depth, and chose the best move according to all possible outcomes.
4. a struct definition - pending
5. an enumerated type - pending
6. inheritance - pending
7. polymorphism - pending
8. a second example of polymorphism - pending
9. throwing an exception and properly catching it - File Game, Line 85
        This is used in the IsCheckMateFunction to make sure the program does not crash when the index is out of range.
10. definition of your own generic datatype - pending
11. properties - Files Game and AI, lines 6 and 6
        Every class has multiple properties. Most of them had were set to public for testing purposes.
12. a static member function - there are many, see lines 16 and 50 in AI to see important methods
        EvaluatePosition() is used to score the position in a range from -3 to 3, were 3 is a losing position, 3 a winning position and 0 a draw. (Assuming perfect play by the opponent)
13. an interface - pending
14. a second interface - pending
15. use of at least two of the built-in generic collection types - one pending, one done in file Game, line 83
        We used Lists to create multidimensianal arrays that are easier to modify and work with.

Additionals:
1. Recursion - File AI, line 122
        The Node constructor uses recursion to create a Node for each possible move in the position and the uses a backpropagation process to pull the score from the nodes ahead.
2. Record - File AI, line 214
        This record is used to create instances of moves. They are composed of the location where the move will be played and who is playing the move