using CoffeeShop.Models;
using CoffeeShop.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Form1 : Form
    {
        List<Item> items;

        public Form1()
        {
            InitializeComponent();

            loadItems();
        }

        private void loadItems()
        {
            items = ItemRepository.GetAll();

            itemsDataGridView.Rows.Clear();

            foreach (Item item in items)
            {
                itemsDataGridView.Rows.Add(new object[] { item.Id, item.Name, item.Price });
            }
        }

        private void citizenDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine(e.Row.Cells[0]);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadItems();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
