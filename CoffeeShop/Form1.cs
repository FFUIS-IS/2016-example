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
        public Form1()
        {
            InitializeComponent();

            Item tea = ItemRepository.GetById(1);

            itemsDataGridView.Rows.Add(new object[] { tea.Id, tea.Name, tea.Price });
        }

        private void citizenDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine(e.Row.Cells[0]);
        }
    }
}
