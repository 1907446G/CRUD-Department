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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var queryLast = (from x in context.Departments
                                 orderby x.DepartmentID descending
                                 select x.DepartmentID).FirstOrDefault();
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var newID = queryLast + 1;
                    this.Hide();
                    (new add(newID)).ShowDialog();
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Department ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Group Name";
            dataGridView1.Columns[3].Name = "Modified Date";
            Object[] rows = new Object[4];
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            using (var context = new AdventureWorks2017Entities())
            {
                var queryDepartment = (from x in context.Departments
                                       orderby x.DepartmentID
                                       select x);
                foreach (var item in queryDepartment)
                {
                    rows[0] = item.DepartmentID;
                    rows[1] = item.Name;
                    rows[2] = item.GroupName;
                    rows[3] = item.ModifiedDate;
                    dataGridView1.Rows.Add(rows);
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                this.Hide();
                (new edit(dID)).ShowDialog();
                this.Close();
                
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (var context = new AdventureWorks2017Entities())
            {
                var rowDelete = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                var deleting = (from x in context.Departments
                                where x.DepartmentID == rowDelete
                                select x).FirstOrDefault();
                context.Departments.Remove(deleting);
                context.SaveChanges();
                
                Form1_Load(null, null);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
