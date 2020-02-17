using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace BullAndCow
{
    public partial class Form1 : Form
    {
        string num="";                        //Любые данные которые мы вносим
        int qty=0;                            //количество символов не более 4
        int FirstPlayNum = 0;                //Первое число первого игрока
        int SecondPlayNum = 0;                //Первое число второго игрока
        int IsNum = 0;                        //Последующие проверяемые числа
        int Turn = 0;                         //Ходы наших игроков
        bool Ready = false;                   //Отвечает за конец игры
        string logs;                          //Запоминает все логи данной программы
        int bull = 0, cow = 0;                //Счётчики с намёком
        int[] SpellOne = new int[4];          //Загаданное число первого игрока
        int[] SpellTwo = new int[4];          //Загаданное число второго игрока
        int[] SpellAns = new int[4];          //Ответ игрока(любого)



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CloseAllButton()
        {
            qty = num.Length;
            if (qty == 3)                               //подсчёт длины слова для закрытия кнопок после 4 нажатий
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button11.Enabled = false;
                //MessageBox.Show(qty.ToString());     // проверка работоспособности кода.
            }
        }

        public void AllKeyOpen()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "1";
            button1.Enabled = false;
            textBox1.Text = num;
        }

        private void обАвтрореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\Help.txt");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обАвтреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Сделано Мишиным Михаилом или же MiArteho",
                "Об авторе",
                MessageBoxButtons.OK// выводит в окне сообщения кнопку Ok и закрывает сообщение
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "2";
            button2.Enabled = false;
            textBox1.Text = num;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "3";
            button3.Enabled = false;
            textBox1.Text = num;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "4";
            button4.Enabled = false;
            textBox1.Text = num;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "5";
            button5.Enabled = false;
            textBox1.Text = num;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "6";
            button6.Enabled = false;
            textBox1.Text = num;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "7";
            button7.Enabled = false;
            textBox1.Text = num;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "8";
            button8.Enabled = false;
            textBox1.Text = num;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "9";
            button9.Enabled = false;
            textBox1.Text = num;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CloseAllButton();
            num = num + "0";
            button11.Enabled = false;
            textBox1.Text = num;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AllKeyOpen();
            Turn++;//+1 шаг или ход
            if (qty == 3)
            {
                if (FirstPlayNum == 0)
                {
                    richTextBox1.Text = "Первый игрок загадал число!";
                    FirstPlayNum = Convert.ToInt32(num);
                    num = "";
                    textBox1.Text = num;
                    //Из текстового значения в целое
                    int a = FirstPlayNum;                                                       //промежуточные или сквозные числа
                    int b = 0;
                    for (int i = 3; i >= 0; i--)                                     //Разбиение числа 1-го инрока на цифры
                    {
                        b = a % 10;
                        SpellOne[i] = b;
                        a = (a - b) / 10;
                    }
                }
                else
                {

                    if (SecondPlayNum == 0)
                    {
                        //
                        richTextBox1.Text = richTextBox1.Text + "\n" + "Второй игрок загадал число!";
                        SecondPlayNum = Convert.ToInt32(num);
                        num = "";
                        textBox1.Text = num;
                        int a = SecondPlayNum;                                                       //промежуточные или сквозные числа
                        int b = 0;
                        for (int i = 3; i >= 0; i--)                                     //Разбиение числа 1-го инрока на цифры
                        {
                            b = a % 10;
                            SpellTwo[i] = b;
                            a = (a - b) / 10;
                        }
                    }
                    else
                    {
                        bull = cow = 0;
                        IsNum = Convert.ToInt32(num);
                        num = "";
                        textBox1.Text = num;
                        if (IsNum != FirstPlayNum || IsNum != SecondPlayNum)
                        //while(IsNum != FirstPlayNum || IsNum != SecondPlayNum)             //Тут начинается основная логика игры
                        {

                            if (((Turn - 2) % 2) == 1)                                   //Обработка ходов 1 игрока 
                            {
                                int a = IsNum;                                                       //промежуточные или сквозные числа
                                int b = 0;
                                for (int i = 3; i >= 0; i--)                                     //Разбиение числа 1-го инрока на цифры
                                {
                                    b = a % 10;
                                    SpellAns[i] = b;
                                    a = (a - b) / 10;
                                }

                                for (int i = 0; i < 4; i++)
                                {
                                    if (SpellTwo[i] == SpellAns[i])                     //Пытаемся отгадать число второго игрока
                                    {
                                        bull++;
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        if (SpellTwo[i] == SpellAns[j])
                                        {
                                            cow++;
                                        }

                                    }
                                }
                                richTextBox1.Text = richTextBox1.Text + "\n" +"Игрок 1 "+ "Шаг: " + (Turn - 2) + "Число:" + IsNum + " б-" + bull + " к." + cow;

                            }
                            else                                                        //Обработка ходов 2 игрока 
                            {
                                if (((Turn - 2) % 2) == 0)                                   //Обработка ходов 2 игрока 
                                {
                                    int a = IsNum;                                                       //промежуточные или сквозные числа
                                    int b = 0;
                                    for (int i = 3; i >= 0; i--)                                     //Разбиение числа 2-го инрока на цифры
                                    {
                                        b = a % 10;
                                        SpellAns[i] = b;
                                        a = (a - b) / 10;
                                    }

                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (SpellOne[i] == SpellAns[i])                    //Пытаемся отгадать число первого игрока
                                        {
                                            bull++;
                                        }
                                    }
                                    for (int i = 0; i < 4; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (SpellOne[i] == SpellAns[j])
                                            {
                                                cow++;
                                            }
                                        }
                                    }
                                richTextBox1.Text = richTextBox1.Text + "\n" +"Игрок 2 "+ "Шаг: "+ ((Turn - 2) / 2)+"Число:"+IsNum+" б-" +bull+" к."+cow;
                                }


                            }
                            if (IsNum == FirstPlayNum && ((Turn - 2) % 2) == 0)
                            {
                                MessageBox.Show("Выиграл первый игрок! Всего шагов " + ((Turn - 2) / 2));
                            }
                            if (IsNum == SecondPlayNum && ((Turn - 2) % 2) == 1)
                            {
                                MessageBox.Show("Выиграл второй игрок! Всего шагов " + ((Turn - 2) / 2));
                            }
                        }
                    }

                    // сброс вводных данных данних
                    qty = 0;
                    num = "";
                    textBox1.Text = num;
                }
            }
            else
            {
                MessageBox.Show("Нужно ввести 4 цифры!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);           //запускает новый экземпляр приложения, то есть простой способ сброса данных
            this.Close();                                                           //закрывает текущее приложения
        }
    }
}
