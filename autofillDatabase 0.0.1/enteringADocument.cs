using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autofillDatabase_0._0._1
{
    public partial class enteringADocument : Form
    {
        public enteringADocument()
        {
            InitializeComponent();
   
        }


        OpenFileDialog ofd = new OpenFileDialog();

         
        private void openFileButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "XLS|*.xls";
            ofd.Filter = "XLSX|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                textBox2.Text = ofd.SafeFileName;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res.ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
            closeButton.BackColor = Color.Transparent;
        }

        Point lastPoint;
        private void enteringADocument_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void enteringADocument_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            connectionForm newForm = new connectionForm();
            newForm.Show();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
