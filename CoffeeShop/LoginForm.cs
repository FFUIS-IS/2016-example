using CoffeeShop.Models;
using CoffeeShop.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = new User(usernameTextbox.Text, passwordTextbox.Text);

            if (UserRepository.Login(user))
                Close();
            else
                MessageBox.Show("Pogrešno unijeto korisničko ime ili lozinka");
        }
    }
}
