using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnButler.AdventureGame.WinHost
{
    public partial class InventoryForm : Form
    {
        public InventoryForm ()
        {
            InitializeComponent();
        }

        /// <summary> Sets or gets player. </summary>
        public Player Player { get; set; }

        /// <summary> Initializes form when it loads. </summary>
        /// <param name="e"> Event Data. </param>
        protected override void OnLoad ( EventArgs e )
        {
            var inventory = Player.GetInventory();

            foreach(var items in inventory.GetAllItems())
            {
                lbItems.Items.Add($"Item: {items.Name}  Value: ${items.Value}  Weight: {items.Weight} lbs");
            }

            lbItems.Items.Add($"Total weight: {inventory.GetTotalWeight()} lbs");
        }
    }
}
