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

        TextBox[,] linesMatrix = new TextBox[0, 0]; // матрица ребер

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

        private void bttn_NumOfPoints_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtbx_NumOfPoints.Text) > 15) // ограничение на кол-во вершин
            {
                MessageBox.Show("Вы ввели слишком большое число\nМаксимальное кол-во: 14", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < linesMatrix.GetLength(0); i++) // удаление предыдущих текстбоксов
                {
                    for (int j = 0; j < linesMatrix.GetLength(1); j++)
                    {
                        Controls.Remove(linesMatrix[i, j]);
                    }
                }

                int numOfPoints = Convert.ToInt32(txtbx_NumOfPoints.Text); // кол-во вершин

                linesMatrix = new TextBox[numOfPoints - 1, 2]; // матрица ребер

                int startX = 12; // левая граница по х
                int endX = 400; // правая граница по х

                int startY = 170; // верхняя граница по у
                int endY = 700; // нижняя граница по у

                int stepX = (endX - startX) / 2; // шаг по х
                int stepY = (endY - startY) / 14; // шаг по у

                int currX = startX;
                int currY = startY;

                // вывод текстбоксов
                for (int i = 0; i < linesMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < linesMatrix.GetLength(1); j++)
                    {
                        linesMatrix[i, j] = new TextBox();
                        linesMatrix[i, j].Location = new Point(currX, currY);
                        linesMatrix[i, j].Size = new Size(100, 30);
                        //matrix[i, j].Show();
                        Controls.Add(linesMatrix[i, j]);

                        if (j == 0)
                        {
                            currX += stepX;
                        }
                        else
                        {
                            currY += stepY;
                            currX = startX;
                        }
                    }
                }
            }

        }

        private void bttn_Start_Click(object sender, EventArgs e)
        {
            bool ok = true;
            for (int i = 0; i < linesMatrix.GetLength(0); i++)
            {
                if (ok)
                {
                    for (int j = 0; j < linesMatrix.GetLength(1); j++)
                    {
                        if (linesMatrix[i, j].Text == "")
                        {
                            ok = false;
                            break;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля были заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (ok)
            {
                //вызов функции
            }
        }

        private void txtbx_NumOfWorkers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) // Вводятся только числа
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back && txtbx_NumOfWorkers.SelectionStart != 0 &&
                txtbx_NumOfWorkers.Text != "") // Удаление по нажатию backspace
            {
                txtbx_NumOfWorkers.Text = txtbx_NumOfWorkers.Text.Substring(0, txtbx_NumOfWorkers.Text.Length - 1);
                txtbx_NumOfWorkers.SelectionStart = txtbx_NumOfWorkers.Text.Length;
            }
        }
    }
}
