using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using TelephoneBook.DataAccess;
using TelephoneBook.DataAccess.Models;
using TelephoneBook.BusinessLogic;

namespace TelephoneBook.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public SqlConnection connection1;

        public List<User> users;
        public User user;
        public static int index;

        private void MainForm_Load(object sender, EventArgs e)
        {
            users = new List<User>();
            user = new User();

            connection1 = BaseDataAccess.CreateConnection();
            connection1.Open();

            users = BaseDataAccess.SelectFromUsers(connection1);

            for (int i = 0; i < users.Count; i++)
            {
                lbUsers.Items.Add(users[i].name);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FormForAdd form = new FormForAdd(user, index);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                user.contacts = new List<Contact>();
                foreach (Contact ct in form.list.contacts)
                {
                    user.contacts.Add(ct);
                }
            }

            form.list.contacts.Sort();

            dgUsers = createDataGridView();

            for (int i = 0; i < form.list.contacts.Count; i++)
            {
                dgUsers.Rows.Add();
                dgUsers.Rows[i].Cells[0].Value = form.list.contacts[i].surname + " " + form.list.contacts[i].name + " " + form.list.contacts[i].patronymic;
                StringBuilder sb = new StringBuilder();
                foreach (PhoneNumber number in user.contacts[i].numbers)
                {
                    sb.Append(number.ToString() + " ");
                }
                dgUsers.Rows[i].Cells[1].Value = sb;
            }
            
        }

        private void dgUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btEdit_Click(object sender, EventArgs e)
        {

            if (dgUsers.SelectedRows.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(dgUsers[0, dgUsers.CurrentRow.Index].Value.ToString() + ' ');
            sb.Append(dgUsers[1, dgUsers.CurrentRow.Index].Value.ToString());
            string[] result = sb.ToString().Split(' ');

            List<PhoneNumber> pn = new List<PhoneNumber>();
            for (int i = 3; i < result.Length-1; i+=2)
            {
                 pn.Add(new PhoneNumber(result[i], result[i+1]));
            }

            Contact contact = new Contact(result[0], result[1], result[2], pn);
            contact.id = (dgUsers.CurrentRow.Index + 1).ToString();
            FormForEdit form = new FormForEdit(user, contact);

            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                 user = form.list;
            }
            

            for (int i = 0; i < form.list.contacts.Count; i++)
            {
                dgUsers.Rows.Add();
                dgUsers.Rows[i].Cells[0].Value = form.list.contacts[i].surname + " " + form.list.contacts[i].name + " " + form.list.contacts[i].patronymic;
                StringBuilder s = new StringBuilder();
                foreach (PhoneNumber number in users[index].contacts[i].numbers)
                {
                    s.Append(number.ToString() + " ");
                }
                dgUsers.Rows[i].Cells[1].Value = s;
            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                return;
            }

            else
            {
                User newUser = new User();
                newUser = UserContactsProcessing.Find(user, tbName.Text);
                dgUsers.Rows.Clear();
                dgUsers = createDataGridView();

                for (int i = 0; i < newUser.contacts.Count; i++)
                {
                    dgUsers.Rows.Add();
                    dgUsers.Rows[i].Cells[0].Value = newUser.contacts[i].surname + " " + newUser.contacts[i].name + " " + newUser.contacts[i].patronymic;
                    StringBuilder sb = new StringBuilder();
                    foreach (PhoneNumber number in newUser.contacts[i].numbers)
                    {
                        sb.Append(number.ToString() + " ");
                    }
                    dgUsers.Rows[i].Cells[1].Value = sb;
                }
            }
        }
        public DataGridView createDataGridView()
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Name";
            nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            nameColumn.Resizable = DataGridViewTriState.False;
            nameColumn.ReadOnly = true;
            nameColumn.Width = 200;

            DataGridViewTextBoxColumn phonenumberColumn = new DataGridViewTextBoxColumn();
            phonenumberColumn.HeaderText = "Phone number";
            phonenumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            phonenumberColumn.Resizable = DataGridViewTriState.False;
            phonenumberColumn.ReadOnly = true;
            phonenumberColumn.Width = 263;

            dgUsers.Columns.Add(nameColumn);
            dgUsers.Columns.Add(phonenumberColumn);

            return dgUsers;
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbUsers_Click(object sender, EventArgs e)
        {
            index = lbUsers.SelectedIndex + 1;

            foreach (User us in users)
            {
                if (Int32.Parse(us.id) == index)
                {
                    this.user = us;
                }
            }

            dgUsers.Rows.Clear();

            user.contacts = BaseDataAccess.SelectFromContacts(connection1, index);

            foreach (Contact ct in user.contacts)
            {
                BaseDataAccess.SelectFromPhoneNumbers(connection1, user, ct);
            }
            
            dgUsers = createDataGridView();
            user.contacts.Sort();

            for (int i = 0; i < user.contacts.Count; i++)
            {
                dgUsers.Rows.Add();
                dgUsers.Rows[i].Cells[0].Value = user.contacts[i].surname + " " + user.contacts[i].name + " " + user.contacts[i].patronymic;
                StringBuilder sb = new StringBuilder();
                foreach (PhoneNumber number in user.contacts[i].numbers)
                 {
                     sb.Append(number.ToString() + " ");
                 }
                dgUsers.Rows[i].Cells[1].Value = sb;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection1.Close();
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            FormForUserAdd form = new FormForUserAdd(users);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                users = form.users;
            }
        }
    }
}

