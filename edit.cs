using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Department
{
    public partial class edit : Form
    {
        short dID = new Department().DepartmentID;
        public edit(short department)
        {
            dID = department;
            InitializeComponent();
        }

        private void edit_Load(object sender, EventArgs e)
        {
            using(var context = new AdventureWorks2017Entities())
            {
                var queryInfo = (from x in context.Departments
                                 where x.DepartmentID == dID
                                 select x).First();
                departmentID.Text = dID.ToString();
                nameBox.Text = queryInfo.Name;
                grpNameBox.Text = queryInfo.GroupName;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var update = (from x in context.Departments
                              where x.DepartmentID == dID
                              select x).First();
                update.Name = nameBox.Text;
                update.GroupName = grpNameBox.Text;
                update.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
                this.Close();
                
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
