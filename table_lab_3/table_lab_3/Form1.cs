using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace table_lab_3
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            bttn_NumOfPoints.Enabled = false;
        }

        private void txtbx_NumOfPoints_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbx_NumOfPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) // Вводятся только числа
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back && txtbx_NumOfPoints.SelectionStart != 0 &&
                txtbx_NumOfPoints.Text != "") // Удаление по нажатию backspace
            {
                txtbx_NumOfPoints.Text = txtbx_NumOfPoints.Text.Substring(0, txtbx_NumOfPoints.Text.Length - 1);
                txtbx_NumOfPoints.SelectionStart = txtbx_NumOfPoints.Text.Length;
            }
            
        }

        private void txtbx_NumOfPoints_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtbx_NumOfPoints.Text != "")
                bttn_NumOfPoints.Enabled = true; // Разблокировали кнопку
            else
                bttn_NumOfPoints.Enabled = false; // Заблокировали кнопку
        }
    }
}
