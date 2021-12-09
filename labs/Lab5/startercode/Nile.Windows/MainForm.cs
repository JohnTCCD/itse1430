/*
 * ITSE 1430
 * Lab 5
 * John Butler
 * Fall 2021
 */

using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Nile.Stores.Sql;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
            _database = new SqlProductDatabase(GetConnectionString("ProductDatabase"));
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = true;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Add(child.Product);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Error");
            }
            
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
            e.SuppressKeyPress = true;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var child = new AboutBox();
            child.ShowDialog(this);
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                _database.Remove(product.Id);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Unable to delete product.");
            }
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Update(child.Product);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Unable to edit product.");
            }
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            try
            {
                var products = _database.GetAll();
                var sortedProducts = products.OrderBy(x => x.Name);
                _bsProducts.DataSource = sortedProducts;
            } catch(Exception ex)
            {
                DisplayError(ex.Message, "Unable to update list.");
            }
        }
        /// <summary> Displays an error message. </summary>
        /// <param name="message"> Error message to be displayed. </param>
        /// <param name="title"> Title of the window. </param>
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string GetConnectionString ( string name )
                => Program.Configuration.GetConnectionString(name);

        private IProductDatabase _database;
    }

    #endregion
}