/*=================
John Butler
ITSE 1430 Fall 2021
Lab 1 : Adventure Game
=================*/

using System;

namespace JohnButler.AdventureGame.ConsoleHost
{
    class Program
    {
        static int positionX = 1, positionY = -2;

        static void Main(string[] args)
        {
            PrintTitleScreen();
            int roomNumber = 9;
            SelectRoomNumber(roomNumber);
            bool quit = false;
            do
            {
                string input = GetCommand("What will you do?");
                switch (input)
                {
                    case "move":
                    {
                        string direction = GetDirection("Which direction do you want to move?");
                        roomNumber = MoveDirection(direction);
                        SelectRoomNumber(roomNumber);
                        break;
                    }
                    case "examine": SelectRoomNumber(roomNumber); break;
                    case "quit": quit = QuitGame("Are you sure you want to quit (Y/N)?"); break;
                    default:
                    {
                        if (String.IsNullOrEmpty(input))
                            DisplayError("Input is required.");
                        else
                            DisplayError("Invalid command, please try again.");
                        
                        break; 
                    }
                }

            } while (!quit);
        }

        static void PrintTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ITSE 1430 Adventure Game");
            Console.WriteLine("John Butler  Fall 2021");
            Console.WriteLine("[Help] to access the help menu.");
            Console.WriteLine("".PadLeft(35, '*'));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You were going for a jog in the woods along the country side.");
            Console.WriteLine("Deep in the woods you happen to see an old sign that says \"No Trespassing!\"");
            Console.WriteLine("Like any good citizen, you decided to ignore the sign and venture further through");
            Console.WriteLine("the narrow trail. After about a few dozen yards, you see an abandoned mansion,");
            Console.WriteLine("forgotten by time. The exterior is overtaken by a seige of vines and other small");
            Console.WriteLine("plants, most of the windows cracked or outright broken. Curious, you decided to see");
            Console.WriteLine("if the front doorwas locked or not. It was open and you entered...");
            Console.ResetColor();
        }

        static string GetCommand(string message)
        {
            Console.WriteLine(message);
            do
            {
                string command = Console.ReadLine().Trim().ToLower();

                if (command == "help")
                {
                    DisplayHelpMenu();
                    Console.WriteLine(message);
                }
                else
                    return command;

            } while (true);
        }

        static void SelectRoomNumber(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1: DisplayMasterBedroom(); break;
                case 3: DisplayDinningRoom(); break;
                case 4: DisplayFirePlace(); break;
                case 5: DisplayGuestRoom(); break;
                case 6: DisplayKitchen(); break;
                case 7: DisplayCellar(); break;
                case 8: DisplayBalcony(); break;
                case 9: DisplayEntrance(); break;
                case 11: DisplayArtGallery(); break;
                default: DisplayError("Unknown Error"); break;
            }
        }

        static string GetDirection(string message)
        {
            Console.WriteLine(message);
            string userDirection;
            do
            {
                userDirection = Console.ReadLine().Trim().ToLower();
                if (String.IsNullOrEmpty(userDirection))
                {
                    DisplayError("Input is required.");
                    continue;
                }

                while (userDirection != "north" && userDirection != "south" && userDirection != "east" && userDirection != "west")
                {
                    DisplayError("That's not a valid direction, please try again.");
                    userDirection = Console.ReadLine().Trim();
                }

                const int xMinimum = 0, xMaximum = 2, yMinimum = -2, yMaximum = 0;
                if ((userDirection == "north" && positionY + 1 > yMaximum) || (userDirection == "south" && positionY - 1 < yMinimum) ||
                    (userDirection == "east" && positionX + 1 > xMaximum) || (userDirection == "west" && positionX - 1 < xMinimum))
                    DisplayError("There is no door available in that direction. Please try a different door.");
                else
                    break;

            } while (true);

            return userDirection;
        }

        static int MoveDirection(string direction)
        {
            switch (direction)
            {
                case "north": positionY += 1; break;
                case "south": positionY -= 1; break;
                case "east": positionX += 1; break;
                case "west": positionX -= 1; break;
                default: DisplayError("Unknown Error"); break;
            }

            return (positionX * 2) + (-positionY * 3) + 1;
        }

        static void DisplayMasterBedroom()
        {                         
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The first thing that you notice entering the master bedroom is");
            Console.WriteLine("that there is an open coffen where a king sized bed should be!");
            Console.WriteLine("A sense of dread befalls you as you become curious if that had or has");
            Console.WriteLine("a purpose. There is also a large dresser that's filled with nothing");
            Console.WriteLine("but dust and spider webs. On the opposite wall, there is a fancy frame");
            Console.WriteLine("surrounded by shards of a broken mirror.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the East and South.");
        }

        static void DisplayDinningRoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Upon arriving, you can see that a broken table, crumbled chairs and");
            Console.WriteLine("candle holders on the ground are what's left of the dinning area.");
            Console.WriteLine("Underneath one of the broken chairs, there seems to be a kitchen knife");
            Console.WriteLine("with red marks covering the blade.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West, South, and East.");
        }

        static void DisplayGuestRoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("For a guest room, it's pretty spacious, you suppose it is a mansion");
            Console.WriteLine("afterall. It even has its own walk-in closet, for a breif moment, you");
            Console.WriteLine("feel like a star. That moment of hypothetical stardom is swept away at");
            Console.WriteLine("sight of the blanketless queen sized bed covered in dirt and dust.");
            Console.WriteLine("The windows are broken, allowing plants to crawl into the room.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West, South.");
        }

        static void DisplayFirePlace()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, -1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("This hall leads to an extravagant fire place, towering over two luxery");
            Console.WriteLine("chairs. You can't help but admire the craftmanship behinde the fireplace");
            Console.WriteLine("and the chairs. Each chair seems to have renissance era decorations and");
            Console.WriteLine("patterns as part of their design. The soot in the fire place makes it look");
            Console.WriteLine("like it's been used recently? It could use some maintenance though.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the South, North, and East.");
        }

        static void DisplayKitchen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, -1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The kitchen, the part of a house that real estate agents say will sell a");
            Console.WriteLine("house. This kitchen, however, looks like it won't be selling anything anytime");
            Console.WriteLine("soon. The floors are filthy, cooking utensils scattered everywhere, and no");
            Console.WriteLine("working oven. The fridge has food that expired ages ago, smells pretty bad.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West, North, East, and South.");
        }

        static void DisplayBalcony()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, -1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("There is a staircase that leads up to the outdoor balcony. Perhaps if");
            Console.WriteLine("the outdoor area wasn't overrun with vines, ivy, and other plants, there");
            Console.WriteLine("would be more to observe on the outside. You head back down the staircase.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West, North, and South.");
        }

        static void DisplayCellar()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, -2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("There is a staircase that descends into the cellar. At the bottom");
            Console.WriteLine("of the stairs, you are immediately greeted with three towering racks");
            Console.WriteLine("full of dusty wine barrels. A large black cauldron with mixing utinsil");
            Console.WriteLine("inside sits at the other end of the middle rack. The empty cauldron has");
            Console.WriteLine("intricate patterns eched into its metallic outter shell, giving it a");
            Console.WriteLine("rather sinister appearance.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the North and East.");
        }

        static void DisplayEntrance()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, -2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The hall of the entrance already commands your attention with its four");
            Console.WriteLine("breath-taking, grandiose renaissance era statues... or it would if the");
            Console.WriteLine("statues weren't broken. The floors have cracks all over them and is littered");
            Console.WriteLine("with dirt and debris. Seems like the nature's been claiming this property.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West, North, and East.");
        }

        static void DisplayArtGallery()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, -2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("This room has a seemingly infinite amount of paintings along the walls.");
            Console.WriteLine("You wonder how much each of these paintings cost, even the frames alone must cost");
            Console.WriteLine("a fortune. Upon closer inspection, you realize that these paintings have two common");
            Console.WriteLine("characteristics. First, despite the condition of the rest of this mansion, these");
            Console.WriteLine("paintings have been well kept and clean. Second, all of these paintings are an image");
            Console.WriteLine("of different individuals sitting in a chair. You try to see the eyes of the paintings");
            Console.WriteLine("follow you like in the movies, but alas, that does not seem to be the case...");
            Console.ResetColor();
            Console.WriteLine("There is a door to the West and North.");
        }

        static void DisplayHelpMenu ()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("** Help Menu **");
            Console.WriteLine("[Examine] ::= Examins the room you are currently in.");
            Console.WriteLine("[Move]    ::= Move to a different room.");
            Console.WriteLine("             You'll be prompted to choose between North, East, South, or West");
            Console.WriteLine("[Quit]    ::= Exits the game.");
            Console.ResetColor();
        }

        static bool QuitGame(string message)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                ConsoleKeyInfo answer = Console.ReadKey(true);
                switch (answer.Key)
                {
                    case ConsoleKey.Y:
                    {
                        Console.WriteLine("Ending game");
                        Console.ResetColor();
                        return true;
                    }
                    case ConsoleKey.N:
                    {
                        Console.WriteLine("Continuing game.");
                        Console.ResetColor();
                        return false;
                    }
                    default: DisplayError("Invalid answer, please try again."); break;
                }

            } while (true);
        }

        static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}