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
        static int roomNumber = 8, positionX = 1, positionY = 0;
        static string direction;

        static void Main(string[] args)
        {
            PrintTitleScreen();
            SetRoom(roomNumber);
            string input;
            do
            {
                input = GetCommand("What will you do?");
                if (input == "Examin")
                    ExaminRoom(roomNumber);
                else if (input == "Move")
                {
                    direction = GetDirection("Which direction do you want to move?");
                    MoveDirection(direction);
                    SetRoom(roomNumber);
                } 
                else if (input == "Quit")
                {
                    if (QuitGame("Are you sure you want to quit (Y/N)?") == true)
                        break;
                } 
                else if (input == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a command.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command, please try again.");
                    Console.ResetColor();
                }

            } while (true);
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
            Console.WriteLine("Like any good citizen, you decided to venture further through the narrow trail.");
            Console.WriteLine("After about a few dozen yards, you see an abandoned mansion, forgotten by time.");
            Console.WriteLine("The exterior is overtaken by a seige of vines and other small plants, most of the");
            Console.WriteLine("windows cracked or outright gone. Curious, you decided to see if the front door");
            Console.WriteLine("was locked or not. It was open and you entered...");
            Console.ResetColor();
        }

        static string GetCommand(string message)
        {
            Console.WriteLine(message);
            string command = Console.ReadLine().Trim();
            while (command == "Help")
            {
                DisplayHelpMenu();
                Console.WriteLine(message);
                command = Console.ReadLine().Trim();
            }
            return command;
        }

        static void ExaminRoom(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1: DisplayRoom1(); break;
                case 2: DisplayRoom2(); break;
                case 3: DisplayRoom3(); break;
                case 4: DisplayRoom4(); break;
                case 5: DisplayRoom5(); break;
                case 6: DisplayRoom6(); break;
                case 7: DisplayRoom7(); break;
                case 8: DisplayRoom8(); break;
                case 9: DisplayRoom9(); break;
                default: Console.WriteLine("Unknown Error"); break;
            }
        }

        static void SetRoom(int roomNumber)
        {
            switch (roomNumber)
            {
                case 1: DisplayRoom1(); break;
                case 2: DisplayRoom2(); break;
                case 3: DisplayRoom3(); break;
                case 4: DisplayRoom4(); break;
                case 5: DisplayRoom5(); break;
                case 6: DisplayRoom6(); break;
                case 7: DisplayRoom7(); break;
                case 8: DisplayRoom8(); break;
                case 9: DisplayRoom9(); break;
                default: Console.WriteLine("Unknown Error"); break;
            }
        }

        static string GetDirection(string message)
        {
            int nextPositionX, nextPositionY;
            Console.WriteLine(message);
            do
            {
                nextPositionX = positionX;
                nextPositionY = positionY;
                direction = Console.ReadLine().Trim();
                while (direction != "North" && direction != "South" && direction != "East" && direction != "West")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a valid direction, please try again.");
                    Console.ResetColor();
                    direction = Console.ReadLine().Trim();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (direction == "North" && --nextPositionY < -2)
                    Console.WriteLine("There is no door available in that direction. Please try a different door.");
                else if (direction == "South" && ++nextPositionY > 0)
                    Console.WriteLine("There is no door available in that direction. Please try a different door.");
                else if (direction == "East" && ++nextPositionX > 2)
                    Console.WriteLine("There is no door available in that direction. Please try a different door.");
                else if (direction == "West" && --nextPositionX < 0)
                    Console.WriteLine("There is no door available in that direction. Please try a different door.");
                Console.ResetColor();
            } while (nextPositionY < -2 || nextPositionY > 0 || nextPositionX < 0 || nextPositionX > 2);
            return direction;
        }

        static void MoveDirection(string direction)
        {
            switch (direction)
            {
                case "North":
                positionY--;
                roomNumber -= 3;
                break;
                case "South":
                positionY++;
                roomNumber += 3;
                break;
                case "East":
                positionX++;
                roomNumber += 1;
                break;
                case "West":
                positionX--;
                roomNumber -= 1;
                break;
                default: Console.WriteLine("Unknown Error"); break;
            }
        }

        static void DisplayRoom1() //Master Bedroom
        {                         
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The first thing that you notice entering the master bedroom is");
            Console.WriteLine("that there is an open coffen where a king sized bed should be.");
            Console.WriteLine("A sense of dread befalls you as become curious if that had or has");
            Console.WriteLine("a purpose. There is also a large dresser with a frame surround with");
            Console.WriteLine("shards of a broken mirror. The dresser appears to be empty.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the east and south.");
        }

        static void DisplayRoom2() //Dinning Hall
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Upon arriving, you can see that a broken table, thrown chairs and");
            Console.WriteLine("candle holders on the ground are what's left of the dinning area.");
            Console.WriteLine("Underneath one of the broken chairs, there seems to be a kitchen knief");
            Console.WriteLine("with red marks covering the blade.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, south, and east.");
        }

        static void DisplayRoom3() //Guest Room
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 2)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("For a guest room, it's pretty spacious, you suppose it is a mansion");
            Console.WriteLine("afterall. It even has its own walk-in closet, for a breif moment, you");
            Console.WriteLine("feel like a star. That moment of hypothetical stardom is swept away at");
            Console.WriteLine("sight of the blanketless queen sized bed covered in dirt and dust.");
            Console.WriteLine("The windows are broken, allowing plants to crawl into the room.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, south.");
        }

        static void DisplayRoom4() //Fireplace
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (0, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("This hall leads to an extravagant fire place, towering over two luxery");
            Console.WriteLine("chairs. You can't help but admire the craftmanship behinde the fireplace");
            Console.WriteLine("and the chairs. Each chair seems to have renissance era decorations and");
            Console.WriteLine("patterns as part of their design. The soot in the fire place makes it look");
            Console.WriteLine("like it's been used recently? It could use some maintenance though.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the south, north, and east.");
        }

        static void DisplayRoom5() //Kitchen
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The kitchen, the part of a house that real estate agents say will sell a");
            Console.WriteLine("house. This kitchen, however, looks like it won't be selling anything anytime");
            Console.WriteLine("soon. The floors are filthy, cooking utensils scattered everywhere, and no");
            Console.WriteLine("working oven. The fridge has food that expired ages ago, smells pretty bad.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, east, and south.");
        }

        static void DisplayRoom6() //Balcanoy
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 1)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("There is a staircase that leads up to the outdoor balcony. Perhaps if");
            Console.WriteLine("the outdoor area wasn't overrun with vines, ivy, and other plants, there");
            Console.WriteLine("would be more to observe on the outside. You head back down the staircase.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, and south.");
        }

        static void DisplayRoom7() //Cellar
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: Cellar (0, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("There is a staircase that descends into the cellar. At the bottom");
            Console.WriteLine("of the stairs, you are immediately greeted with three towering racks");
            Console.WriteLine("full of dusty wine barrels. A large black cauldron with mixing utinsil");
            Console.WriteLine("inside sits at the other end of the walk way between racks. The empty");
            Console.WriteLine("cauldron has intricate patterns eched into its metallic exoskeleton, giving");
            Console.WriteLine("a rather sinister appearance.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the north and east.");
        }

        static void DisplayRoom8() //Entrance
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (1, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The hall of the entrance already commands your attention with its four");
            Console.WriteLine("breath-taking, grandiose renaissance era statues... or it would if the");
            Console.WriteLine("statues weren't broken. Oddly enough, two of them seem like they weren't");
            Console.WriteLine("broken, but sliced clean off. The floors have cracks all over them and is");
            Console.WriteLine("littered with dirt and debris.");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west, north, and east.");
        }

        static void DisplayRoom9() //Art Gallery
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current location: (2, 0)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("This room has a seemingly infinite amount of paintings along the walls.");
            Console.WriteLine("You wonder how much each of these paintings cost, even the frames alone must cost");
            Console.WriteLine("a fortune. Upon closer inspection, you realize that these paintings have two common");
            Console.WriteLine("characteristics. First, despite the condition of the rest of this mansion, these");
            Console.WriteLine("paintings have been well kept and clean. Second, all of these paintings are an image");
            Console.WriteLine("of different individuals sitting in a chair. You try to see the eyes of the paintings");
            Console.WriteLine("follow you like in the movies, but alas, that does not seem to be the case...");
            Console.ResetColor();
            Console.WriteLine("There is a door to the west and north.");
        }

        static void DisplayHelpMenu ()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("** Help Menu **");
            Console.WriteLine("\"Examin\" ::= Examins the room you are currently in.");
            Console.WriteLine("\"Move\"   ::= Move to a different room, you'll choose between North, East, South, or West");
            Console.WriteLine("\"Quit\"   ::= Exits the game.");
            Console.ResetColor();
        }

        static bool QuitGame(string message)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
                ConsoleKeyInfo answer = Console.ReadKey(true);
                switch (answer.Key)
                {
                    case ConsoleKey.Y: Console.WriteLine("Ending game"); return true;
                    case ConsoleKey.N: Console.WriteLine("Continuing game."); return false;
                    default: Console.WriteLine("Invalid answer, try again. (Y/N)"); break;
                }
            } while (true);
        }
    }
}