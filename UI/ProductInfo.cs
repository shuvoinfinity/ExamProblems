using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsInformationApp.BLL;
using ProductsInformationApp.DLL.DAO;

namespace ProductsInformationApp
{
    public partial class productInfoUI : Form
    {
        public productInfoUI()
        {
            InitializeComponent();
        }
        ProductBll aProductBll = new ProductBll();
     
        private List<Product> products;

        private void saveButton_Click(object sender, EventArgs e)
        {
           Product aProduct = new Product(codeTextBox.Text, nameTextbox.Text, Convert.ToInt32(quantityTextbox.Text));
            string mess = aProductBll.SaveProduct(aProduct);
            MessageBox.Show(mess);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            ShowProducts();
            totalQuantityTextBox.Text = GetTotalQuantity();
        }

        private string GetTotalQuantity()
        {
            string mess = aProductBll.GetTotalQuantity().ToString();

            return mess;

        }

        private void ShowProducts()
        {
            products = aProductBll.ShowProducts();
            productGridView.DataSource = products;
        }
    }
}
