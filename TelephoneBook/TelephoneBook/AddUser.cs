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

namespace TelephoneBook
{
    public partial class AddUser : Form
    {
        SqlConnection connection1 = new SqlConnection
                          (
                          @"Data Source=NotePad;Initial Catalog=PhoneBook;Integrated Security=True"
          );

        public List<User> users = new List<User>();
        public AddUser(List<User> users)
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
                string saveUser = "INSERT into USERS (Name) " +
                   " VALUES ('" + user.name + "');";

                SqlCommand querySaveStaff = new SqlCommand(saveUser, connection1);
                querySaveStaff.ExecuteNonQuery();

                connection1.Close();
                this.Close();

            }
        }
    }
}
