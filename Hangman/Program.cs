using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            Console.WriteLine(".:*~*:._.:*~*:.    The Hangman Game !!!        _.:*~*:._.:*~*:.");
            Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            Console.WriteLine("");
            Console.WriteLine("    Decode the hidden word to save Shrek from Death !!!!!!");

            Random random = new Random();

            string[] words = { "Vodka", "Whiskey", "Tequila", "Brandy", "Vermouth", "Gin",
                                    "Rum", "Fernet", "Cider", "Beer", "Wine", "Jaggermeister",
                                        "Amaretto", "Sake", "Bourbon", "Cognac", "Baijiu"};

            string wordToGuess = words[random.Next(0, words.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 5, points = 0;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            Console.WriteLine("           +---+");
            Console.WriteLine("           |   |");
            Console.WriteLine("               |");
            Console.WriteLine("               |");
            Console.WriteLine("               |");
            Console.WriteLine("               |");
            Console.WriteLine("       ===========");
            Console.WriteLine("");

            Console.WriteLine("   Current Word: " + displayToPlayer.ToString());
            Console.WriteLine("   Lives : " + lives);
            Console.WriteLine("   Points : " + points);
            Console.WriteLine("");
            Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");

            while (!won && lives > 0)
            {
                Console.WriteLine("");
                Console.Write("   Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine(" You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine(" You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                            points = points + 5;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine(" Nope, there's no '{0}' in it!", guess);
                    lives--;
                    points = points - 10;
                }
                Console.Clear();
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
                Console.WriteLine("");

                switch (lives)
                {
                    case 5:
                        Console.WriteLine("           +---+");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("       ===========");
                        Console.WriteLine("");
                        break;

                    case 4:
                        Console.WriteLine("           +---+");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("           O   |");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("       ===========");
                        Console.WriteLine("");
                        break;

                    case 3:
                        Console.WriteLine("           +---+");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("           O   |");
                        Console.WriteLine("          /|   |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("       ===========");
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("           +---+");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("           O   |");
                        Console.WriteLine("          /|\\  |");
                        Console.WriteLine("               |");
                        Console.WriteLine("               |");
                        Console.WriteLine("       ===========");
                        Console.WriteLine("");
                        break;

                    case 1:
                        Console.WriteLine("           +---+");
                        Console.WriteLine("           |   |");
                        Console.WriteLine("           O   |");
                        Console.WriteLine("          /|\\  |");
                        Console.WriteLine("          /    |");
                        Console.WriteLine("               |");
                        Console.WriteLine("       ===========");
                        Console.WriteLine("");
                        break;
                }

                Console.WriteLine("   Current Word: " + displayToPlayer.ToString());
                Console.WriteLine("   Lives : " + lives);
                Console.WriteLine("   Points : " + points);
                Console.WriteLine("");
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            }

            if (won)
            {
                Console.Clear();
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
                Console.WriteLine(".:*~*:._.:*~*:.    You won! Shrek is Safe !!    .:*~*:._.:*~*:.");
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
                Console.WriteLine("");
                Console.WriteLine("######################################################################################");
                Console.WriteLine("#                                                                                    #");
                Console.WriteLine("#                            ,.--------._                                            #");
                Console.WriteLine("#                           /            ''.                                         #");
                Console.WriteLine("#                         ,'                \\     |\"\\                /\\          /\\  #");
                Console.WriteLine("#              /\" |     /                   \\    | __\"              ( \\        // )  #");
                Console.WriteLine("#               \"_\"|    /           z#####z   \\  //                  \\ \\      // /   #");
                Console.WriteLine("#                 \\  #####        ##------\".  \\//                     \\_\\||||//_/    #");
                Console.WriteLine("#                  \\/-----\\     /          \".  \\                       \\/ _  _ \\     #");
                Console.WriteLine("#                   \\|      \\   |   ,,--..       \\                    \\/|(O)(O)|     #");
                Console.WriteLine("#                   | ,.--._ \\  (  | ##   \\)      \\                  \\/ |      |     #");
                Console.WriteLine("#                   |(  ##  )/   \\ `-....-//       |///////////////_\\/  \\      /     #");
                Console.WriteLine("#                     '--'.\"      \\                \\              //     |____|      #");
                Console.WriteLine("#                  /'    /         ) --.            \\            ||     /      \\     #");
                Console.WriteLine("#               ,..|     \\.________/    `-..         \\   \\       \\|     \\ 0  0 /     #");
                Console.WriteLine("#            _,##/ |   ,/   /   \\           \\         \\   \\       U    / \\_//_/      #");
                Console.WriteLine("#          :###.-  |  ,/   /     \\        /' \"\"\\      .\\        (     /              #");
                Console.WriteLine("#         /####|   |   (.___________,---',/    |       |\\=._____|  |_/               #");
                Console.WriteLine("#        /#####|   |     \\__|__|__|__|_,/             |####\\    |  ||                #");
                Console.WriteLine("#       /######\\   \\      \\__________/                /#####|   \\  ||                #");
                Console.WriteLine("#      /|#######`. `\\                                /#######\\   | ||                #");
                Console.WriteLine("#     /++\\#########\\  \\                      _,'    _/#########\\ | ||                #");
                Console.WriteLine("#    /++++|#########|  \\      .---..       ,/      ,'##########.\\|_||                #");
                Console.WriteLine("#   //++++|#########\\.  \\.              ,-/      ,'########,+++++\\_\\                 #");
                Console.WriteLine("#  /++++++|##########\\.   '._        _,/       ,'######,''++++++++\\                  #");
                Console.WriteLine("# |+++++++|###########|       -----.\"        _'#######'++++++++++ +\\                 #");
                Console.WriteLine("# |+++++++|############\\.     \\     //      /#######/++++++++++ +++\\                 #");
                Console.WriteLine("######################################################################################");
                Console.WriteLine("");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
                Console.WriteLine("");
                Console.WriteLine("           +---+");
                Console.WriteLine("           |   |");
                Console.WriteLine("           O   |");
                Console.WriteLine("          /|\\  |");
                Console.WriteLine("          / \\  |");
                Console.WriteLine("               |");
                Console.WriteLine("       ===========");
                Console.WriteLine("");
                Console.WriteLine("   You lost! The word was '{0}'", wordToGuess);
                Console.WriteLine("");
                Console.WriteLine("   Shrek is Dead =(");
                Console.WriteLine("");
                Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            }

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}