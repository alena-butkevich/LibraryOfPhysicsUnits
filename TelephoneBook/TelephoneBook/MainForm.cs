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

namespace TelephoneBook
{
    public partial class MainForm : Form
    {
        SqlConnection connection1 = new SqlConnection
                           (
                           @"Data Source=NotePad;Initial Catalog=PhoneBook;Integrated Security=True"
           );

        public MainForm()
        {
            InitializeComponent();
        }

        public List<User> users = new List<User>();
        public User user = new User();
        public static int index;

        private void MainForm_Load(object sender, EventArgs e)
        {
            connection1.Open();
            
            string sql = "SELECT * FROM USERS";
            SqlCommand command1 = new SqlCommand(sql, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();


            while (dataReader1.Read())
            {
                users.Add(new User(dataReader1["Id"].ToString(), dataReader1["Name"].ToString()));
            }

            dataReader1.Close();

            for (int i = 0; i < users.Count; i++)
            {
                lbUsers.Items.Add(users[i].name);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FormForAdd form = new FormForAdd(users[0], index);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                users[index].contacts = new List<Contact>();
                foreach (Contact ct in form.list.contacts)
                {
                    users[index].contacts.Add(ct);
                }
            }

            form.list.contacts.Sort();

            dgUsers = createDataGridView();

            for (int i = 0; i < form.list.contacts.Count; i++)
            {
                dgUsers.Rows.Add();
                dgUsers.Rows[i].Cells[0].Value = form.list.contacts[i].surname + " " + form.list.contacts[i].name + " " + form.list.contacts[i].patronymic;
                StringBuilder sb = new StringBuilder();
                foreach (PhoneNumber number in users[index].contacts[i].numbers)
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
            FormForEdit form = new FormForEdit(users[0], contact);

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                 users[index] = form.list;
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
                newUser = user.Find(tbName.Text);
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

            user.contacts  = new List<Contact>();
            
            string sql = "SELECT * FROM CONTACTS WHERE Id_user =" + index;
            SqlCommand command1 = new SqlCommand(sql, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();
            List<PhoneNumber> p = new List<PhoneNumber>();


            while (dataReader1.Read())
            {
                Contact contact = new Contact(dataReader1["Id"].ToString(), dataReader1["Name"].ToString(), dataReader1["Surname"].ToString(),
                    dataReader1["Patronymic"].ToString());

                user.contacts.Add(contact);

            }
            dataReader1.Close();

            foreach (Contact ct in user.contacts)
            {

                string sql1 = "SELECT * FROM PHONENUMBER WHERE Id_contact =" + ct.id;
                SqlCommand command2 = new SqlCommand(sql1, connection1);
                SqlDataReader dr = command2.ExecuteReader();

                while (dr.Read())
                {
                    List<PhoneNumber> pn = new List<PhoneNumber>();
                    pn.Add(new PhoneNumber(dr["Number"].ToString(), dr["Label"].ToString()));
                    user.contacts[Int32.Parse(ct.id) -1].numbers = pn;
                }

                dr.Close();
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

