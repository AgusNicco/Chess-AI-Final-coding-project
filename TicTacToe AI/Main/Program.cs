using Classes;
using System.Diagnostics;
public class Program
{
    static void Main()
    {   
        Console.Clear();
      
        Console.WriteLine("Hello user. This program will let you play TicTacToe vs an AI. You will use circles and the AI will use crosses, the first one to move will be chosen at random.\n");
        Console.WriteLine("You will input your moves using integers. Here is a map of the values that refer to each cell, in order to place your move there, just input the number:\n");
        
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|1|2|3|");
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|4|5|6|");
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|7|8|9|");
        Console.WriteLine($"+-+-+-+\n");

        Console.Write("Press any key to start.");
        
        ConsoleKey key = Console.ReadKey(true).Key;

        // Game game = new Game();
        Game.StartGame();
        
        
        // Console.Clear();
        // Stopwatch stop = new Stopwatch();
        // stop.Start();

        // AI.Node Node = new AI.Node(Game.CharArrayToList(new char[3][] {
        // new char [] {' ',' ',' '},
        // new char [] {' ',' ',' '},
        // new char [] {' ',' ',' '}
        // }), true, null, 1);

        // stop.Stop();
        // Console.WriteLine(stop.Elapsed);
        // Console.WriteLine(AI.NumberOfNodes);
        
    }
}