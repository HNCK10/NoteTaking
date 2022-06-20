using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {
        //Creating a data table
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instantiating the data table
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));
            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = dataGridView1.Width;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Clearing the TextBoxes
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Adding rows to the data table
            table.Rows.Add(txtTitle.Text, txtMessage.Text);
            //Clearing the text boxes
            txtTitle.Clear();
            txtMessage.Clear();

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //This tells us the current row selected
            int index = dataGridView1.CurrentCell.RowIndex;
            
            if(index>-1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //This tells us the current row selected
            int index = dataGridView1.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }
    }
}
