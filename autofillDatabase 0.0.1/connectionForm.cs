using System;
using System.Drawing;
using System.Windows.Forms;

namespace autofillDatabase_0._0._1
{
    public partial class connectionForm : Form
    {
        public connectionForm()
        {
            InitializeComponent();
            optionButton.Select();
        }

        private void optionButton_Click(object sender, EventArgs e)
        {
            if ((IPTextBox.Text == "") || (IPTextBox.Text == "Введите IP-адрес")) //Проверка на ввод пустых данных в IPTextBox
            {
                MessageBox.Show("Введите IP-адрес", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((portTextBox.Text == "") || (portTextBox.Text == "Введите порт")) //Проверка на ввод пустых данных в portTextBox
            {
                MessageBox.Show("Введите порт", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                Storage.IPAddress = IPTextBox.Text;
                Storage.port = portTextBox.Text;

                
                this.Hide();
                enteringADocument newForm = new enteringADocument();
                newForm.Show();
            }

            catch
            {
                MessageBox.Show("Не удалось подключиться к выбранной базе данных. \nПроверьте правильность введенных данных.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void IPTextBox_KeyPress(object sender, KeyPressEventArgs e) // Ограничение на ввод символов до '0' - '9' и '.' в IPTextBox
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == 8) {}
            else e.Handled = true;
        }

        private void portTextBox_KeyPress(object sender, KeyPressEventArgs e) //Ограничение на ввод символов до '0' - '9' в portTextBox
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8) {}
            else e.Handled = true;
        }

        Point lastPoint;

        private void connectionForm_MouseMove(object sender, MouseEventArgs e) //Отсчет новых координат формы
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }          
        }

        private void connectionForm_MouseDown(object sender, MouseEventArgs e) //Запись новый координат в переменную
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e) //Проверка перед закрытием приложения
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res.ToString() == "Yes")
            {
                Application.Exit();
            }           
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) //Меняем фон и цвет closeButton 
        {
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.Red;

        }

        private void closeButton_MouseLeave(object sender, EventArgs e) //Возвращаем начальный вид closeButton
        {
            closeButton.ForeColor = Color.Black;
            closeButton.BackColor = Color.Transparent;
        }
    }
}
