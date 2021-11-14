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
        int dirX, dirY;  // для движения головы по форме (координаты верхнего левого угла)
        int rndX, rndY;
        int length = 0;  // длина змейки и очки
        readonly int cell = 50; // сторона ячейки
        readonly Random random = new Random();  // для рандомного появления яблока
        bool canCreateApple = true;
        readonly PictureBox[] snake = new PictureBox[30];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // размер формы
            Width = 700;
            Height = 560;
            // пользователь не сможет изменить размер
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // рамка поля
            PictureBox upSide = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(cell*10 + 2, 1),
                Location = new Point(9, 9)
            };
            Controls.Add(upSide);

            PictureBox downSide = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(cell * 10 + 2, 1),
                Location = new Point(9, Height - 50)
            };
            Controls.Add(downSide);

            PictureBox leftSide = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(1, cell * 10 + 2),
                Location = new Point(9, 9)
            };
            Controls.Add(leftSide);

            PictureBox rightSide = new PictureBox
            {
                BackColor = Color.Black,
                Size = new Size(1, cell * 10 + 2),
                Location = new Point(Height - 50, 9)
            };
            Controls.Add(rightSide);

            // при загрузке формы создаём голову
            head = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(cell, cell),
                Location = new Point(cell*4 + 10, cell*4 + 10)
            };
            // добавляем голову на форму
            Controls.Add(head);
            // голова - нулевой элемент массива
            snake[length] = head;
        }

        // обработчик захвата событий нажатия кнопок клавиатуры
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)  { dirX = -cell; dirY =   0;   }
            if (e.KeyCode == Keys.Right) { dirX =  cell; dirY =   0;   }
            if (e.KeyCode == Keys.Up)    { dirX =   0;   dirY = -cell; }
            if (e.KeyCode == Keys.Down)  { dirX =   0;   dirY =  cell; }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (canCreateApple == true) CreateApple();
            // если поймали яблоко
            if (head.Location == tail.Location) 
            {
                length++;
                snake[length] = tail;
                tail.BackColor = Color.Yellow;
                // чёткие границы сигментов
                tail.BorderStyle = BorderStyle.FixedSingle;
                canCreateApple = true;  // флаг для создания нового яблока
                Text = "Очки - " + length;
            }
            // условие победы и ЧТОБЫ НЕ ПЕРЕПОЛНИТЬ МАССИВ
            if (length == 29)
            {
                timer1.Stop();
                MessageBox.Show("Ты победил", "Игра закончена");
                // или переход на другой уровень
                //timer1.Interval = 200;
            }
            // движение хвоста
            for (int i = length; i >= 1; i--)
                snake[i].Location = snake[i - 1].Location;
            // если съел себя
            for (int i = 2; i <= length; i++)  // т.к. 0-ой. элемент - голова 
                if (snake[0].Location == snake[i].Location)
                {
                    //timer1.Stop();
                    //MessageBox.Show("Съел самого себя", "Игра закончена");
                    // или так
                    for (int j = i; j <= length; j++)
                        Controls.Remove(snake[j]);
                    length = length - (length - i + 1);
                    Text = "Очки - " + length;
                }
            // проверка на выход за границы поля
            Reverse();

            // меняем координаты верхнего левого угла
            head.Left += dirX;
            head.Top  += dirY;
        }

        private void CreateApple()
        {
            // поле условно 500х500, а объект 50х50. 50*10=500, поэтому от 1 до 10
            rndX = random.Next(1, 10);
            rndY = random.Next(1, 10);
            tail = new PictureBox
            {
                Location = new Point(rndX * cell + 10, rndY * cell + 10),
                Size = new Size(cell, cell),
                BackColor = Color.Green
            };
            // добавляем хвост на форму
            Controls.Add(tail);
            canCreateApple = false;
        }

        private void Reverse()
        {
            if (head.Left < 10)
                dirX = 50;
            if (head.Right > Height - 50)
                dirX = -50;
            if (head.Top < 10)
                dirY = 50;
            if (head.Bottom > Height - 50)
                dirY = -50;
        }
    }
}
