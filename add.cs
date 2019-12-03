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
    public partial class add : Form
    {
        int dID = new Department().DepartmentID;
        public add(int department)
        {
            dID = department;
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {
            departmentID.Text = dID.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                context.Departments.Add(new Department()
                {
                    DepartmentID = Convert.ToInt16(dID),
                    Name = nameBox.Text,
                    GroupName = grpNameBox.Text,
                    ModifiedDate = DateTime.Now
                });
                context.SaveChanges();
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
                this.Close();
            }
        }
    }
}
