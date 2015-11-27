using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TelephoneBook.DataAccess;
using TelephoneBook.DataAccess.Models;

namespace TelephoneBook.GUI
{
    public partial class FormForUserAdd : Form
    {
        SqlConnection connection1 = BaseDataAccess.CreateConnection();

        public List<User> users = new List<User>();
        public FormForUserAdd(List<User> users)
        {
            foreach (User user in users)
            {
                this.users.Add(user);
            }
            InitializeComponent();
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" )
            {
                return;
            }
            else
            {   
                User user = new User(tbName.Text);
                users.Add(user);

                connection1.Open();
                BaseDataAccess.InsertIntoUsers(connection1, user);
                connection1.Close();

                this.Close();

            }
        }
    }
}
