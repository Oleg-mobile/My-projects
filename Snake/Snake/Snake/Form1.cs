using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        // объекты головы и хвоста
        PictureBox head, tail;
        int x, y;  // для движения головы по форме (координаты верхнего левого угла)
        int x1, y1;
        int length = 0; // длина змейки и очки
        readonly Random random = new Random();  // для рандомного появления яблока
        bool eat = true;
        readonly PictureBox[] snake = new PictureBox[30];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // размер формы
            Width = 515;
            Height = 540;
            // пользователь не сможет изменить размер
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // при загрузке формы создаём голову
            head = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(50, 50),
                Location = new Point(250, 250)
            };
            // добавляем голову на форму
            Controls.Add(head);
            snake[length] = head;
        }

        // обработчик захвата событий нажатия кнопок клавиатуры
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)  { x = -50; y = 0; }
            if (e.KeyCode == Keys.Right) { x = 50; y = 0; }
            if (e.KeyCode == Keys.Up)    { x = 0; y = -50; }
            if (e.KeyCode == Keys.Down)  { x = 0; y = 50; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eat == true) Body();
            if (head.Location == tail.Location) 
            {
                length++;
                snake[length] = tail;
                tail.BackColor = Color.Yellow;
                tail.BorderStyle = BorderStyle.FixedSingle;
                eat = true;
                Text = "Очки - " + length;
            }
            if (length == 29)
            {
                timer1.Stop();
                MessageBox.Show("Ты победил", "Игра закончена");
            }
            for (int i = length; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            for (int i = 2; i < length; i++)
                if (snake[0].Location == snake[i].Location)
                {
                    timer1.Stop();
                    MessageBox.Show("Съел самого себя", "Игра закончена");
                }
            if (head.Left < 0 || head.Right > 515 || head.Top < 0 || head.Bottom > 540)
            {
                timer1.Stop();
                MessageBox.Show("Убежал за границы", "Игра закончена");
            }

            // меняем координаты верхнего левого угла
            head.Left += x;
            head.Top += y;
        }

        private void Body()
        {
            // поле условно 500х500, а объект 50х50. 50*10=500, поэтому от 1 до 10
            x1 = random.Next(1, 10);
            y1 = random.Next(1, 10);
            tail = new PictureBox();
            tail.Location = new Point(x1 * 50, y1 * 50);
            tail.Size = new Size(50, 50);
            tail.BackColor = Color.Green;
            Controls.Add(tail);
            eat = false;
        }
    }
}
