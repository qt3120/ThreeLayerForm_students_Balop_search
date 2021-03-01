using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeLayerForm.Core;

namespace ThreeLayerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StudentBUS sb = new StudentBUS();
            //Students s = sb.getStudentByID(txtSearchID.Text);
            DataTable table = sb.getStudentByName(txtSearchID.Text);
            if(table == null)
            {
                MessageBox.Show("There is no student", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = table;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
