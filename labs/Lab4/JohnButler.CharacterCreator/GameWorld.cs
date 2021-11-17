/*========================
John Butler
ITSE 1430 Fall 2021
Lab 4
========================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnButler.AdventureGame
{
    /// <summary> Represents a wolrd of the game. </summary>
    public class GameWorld : World
    {
        /// <summary> Creates and adds the nine areas to the game. </summary>
        public void CreateGameWorld()
        {
            var areas = new[]
            {
                new Area() {
                    Id = 1,
                    Description = DisplayGuestRoom(),
                    AccessibleIds = new[] { 2, 4 },
                    HasItem = false,
                },
                new Area() {
                    Id = 2,
                    Description = DisplayDinningRoom(),
                    AccessibleIds = new[] { 1, 3, 5 },
                    HasItem = true,
                },
                new Area() {
                    Id = 3,
                    Description = DisplayMasterBedroom(),
                    AccessibleIds = new[] { 2, 6 },
                    HasItem = false,
                },
                new Area() {
                    Id = 4,
                    Description = DisplayFirePlace(),
                    AccessibleIds = new[] { 1, 5, 7 },
                    HasItem = false,
                },
                new Area() {
                    Id = 5,
                    Description = DisplayKitchen(),
                    AccessibleIds = new[] { 2, 6, 8, 4 },
                    HasItem = false,
                },
                new Area() {
                    Id = 6,
                    Description = DisplayBalcony(),
                    AccessibleIds = new[] { 3, 5, 9 },
                    HasItem = false,
                },
                new Area() {
                    Id = 7,
                    Description = DisplayArtGallery(),
                    AccessibleIds = new[] { 4, 8 },
                    HasItem = true,
                },
                new Area() {
                    Id = 8,
                    Description = DisplayEntrance(),
                    AccessibleIds = new[] { 7, 5, 9 },
                    HasItem = false,
                },
                new Area() {
                    Id = 9,
                    Description = DisplayCellar(),
                    AccessibleIds = new[] { 8, 6 },
                    HasItem = true,
                },
            };

            foreach (var area in areas)
                if (area != null)
                    AddArea(area);

            AddItems(areas);
        }

        private void AddItems( Area[] areas )
        {
            Item[] items = new[]
            {
                new Item() {
                    Name = "Knief",
                    Value = 16,
                    Weight = 2,
                },
                new Item() {
                    Name = "Hand Mirror",
                    Value = 24,
                    Weight = 1,
                },
                new Item() {
                    Name = "Book",
                    Value = 10,
                    Weight = 2,
                },
            };

            areas[1].SetItem(items[0]);
            areas[6].SetItem(items[1]);
            areas[8].SetItem(items[2]);
        }


        private string DisplayMasterBedroom ()
        {
            string description = "Current location: (3, 1) " +
            "The first thing that you notice entering the master bedroom is " +
            "that there is an open coffen where a king sized bed should be! " +
            "A sense of dread befalls you as you become curious if that had or has " +
            "a purpose. There is also a large dresser that's filled with nothing " +
            "but dust and spider webs. On the opposite wall, there is a fancy frame " +
            "surrounded by shards of a broken mirror. " +
            "There is a door to the West and South.";

            return description;
        }

        private string DisplayDinningRoom ()
        {
            string description = "Current location: (2, 1) " +
            "Upon arriving, you can see that a broken table, crumbled chairs and " +
            "candle holders on the ground are what's left of the dinning area. " +
            "Underneath one of the broken chairs. There is a door to the West, South, and East. ";

            return description;
        }

        private string DisplayGuestRoom ()
        {
            string description = "Current location: (1, 1) " +
            "For a guest room, it's pretty spacious, you suppose it is a mansion " +
            "afterall. It even has its own walk-in closet, for a breif moment, you " +
            "feel like a star. That moment of hypothetical stardom is swept away at " +
            "sight of the blanketless queen sized bed covered in dirt and dust. " +
            "The windows are broken, allowing plants to crawl into the room. " +
            "There is a door to the East and South.";

            return description;
        }

        private string DisplayFirePlace ()
        {
            string description = "Current location: (1, 2) " +
            "This hall leads to an extravagant fire place, towering over two luxery " +
            "chairs. You can't help but admire the craftmanship behinde the fireplace " +
            "and the chairs. Each chair seems to have renissance era decorations and " +
            "patterns as part of their design. The soot in the fire place makes it look " +
            "like it's been used recently? It could use some maintenance though. " +
            "There is a door to the South, North, and East.";

            return description;
        }

        private string DisplayKitchen ()
        {
            string description = "Current location: (2, 2) " +
            "The kitchen, the part of a house that real estate agents say will sell a " +
            "house. This kitchen, however, looks like it won't be selling anything anytime " +
            "soon. The floors are filthy, cooking utensils scattered everywhere, and no " +
            "working oven. The fridge has food that expired ages ago, smells pretty bad. " +
            "There is a door to the West, North, East, and South.";

            return description;
        }

        private string DisplayBalcony ()
        {
            string description = "Current location: (3, 2) " +
            "There is a staircase that leads up to the outdoor balcony. Perhaps if " +
            "the outdoor area wasn't overrun with vines, ivy, and other plants, there " +
            "would be more to observe on the outside. You head back down the staircase. " +
            "There is a door to the West, North, and South. ";

            return description;
        }

        private string DisplayCellar ()
        {
            string description = "Current location: (3, 3) " +
            "There is a staircase that descends into the cellar. At the bottom " +
            "of the stairs, you are immediately greeted with three towering racks " +
            "full of dusty wine barrels. A large black cauldron with mixing utinsil " +
            "inside sits at the other end of the middle rack. The empty cauldron has " +
            "intricate patterns eched into its metallic outter shell, giving it a " +
            "rather sinister appearance. " +
            "There is a door to the North and West. ";

            return description;
        }

        private string DisplayEntrance ()
        {
            string description = "Current location: (2 ,3) " +
            "The hall of the entrance already commands your attention with its four " +
            "breath-taking, grandiose renaissance era statues... or it would if the " +
            "statues weren't broken. The floors have cracks all over them and is littered " +
            "with dirt and debris. Seems like the nature's been claiming this property. " +
            "There is a door to the West, North, and East.";

            return description;
        }

        private string DisplayArtGallery ()
        {
            string description = "Current location: (1, 3) " +
            "This room has a seemingly infinite amount of paintings along the walls. " +
            "You wonder how much each of these paintings cost, even the frames alone must cost " +
            "a fortune. Upon closer inspection, you realize that these paintings have two common " +
            "characteristics. First, despite the condition of the rest of this mansion, these " +
            "paintings have been well kept and clean. Second, all of these paintings are an image " +
            "of different individuals sitting in a chair. You try to see the eyes of the paintings " +
            "follow you like in the movies, but alas, that does not seem to be the case... " +
            "There is a door to the East and North. ";

            return description;
        }
    }
}
