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

namespace OptimizationList
{
    public partial class Form1 : Form
    {
        double EPS;
        const double Ff = 1.6180339887498948482;
        int[] fibArray;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Половинного деления");
            listBox1.Items.Add("Золотого сечения");
            listBox1.Items.Add("Фибоначчи");
            listBox1.Items.Add("Квадратичная интерполяция");
        }

        int[] GetFibbonacci(int n)
        {
            List<int> list = new List<int>();
            int buf1 = 1;
            int buf2 = 2;
            list.Add(1);
            list.Add(2);
            for (int i = 0; i < n; i++)
            {
                buf2 = buf1 + buf2;
                buf1 = buf2 - buf1;
                list.Add(buf2);
            }
            return list.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusbar.Text = "";
            int method=0;
            double a=0, b=0;
            double result = 0;
            Stopwatch st = new Stopwatch();
            st.Start();
            try
            {
                EPS = double.Parse(textEPS.Text);
                a = double.Parse(textA.Text);                
                if (-1 == (method = listBox1.SelectedIndex))
                    throw new Exception("Выберите метод поиска");
                switch (method)
                {
                    case 0:
                        b = double.Parse(textB.Text);
                        result = BisectionMethod(a, b);
                        break;
                    case 1:
                        b = double.Parse(textB.Text);
                        result = GoldenSectionMethod(a, b);
                        break;
                    case 2:
                        b = double.Parse(textB.Text);
                        result = FibonacciMethod(a, b);
                        break;
                    case 3:
                        result = QuadraticInterpolation(a, 2 * EPS);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception eX)
            {
                statusbar.Text = "ОШИБКА ВВОДА!!!   " + eX.Message;
                return;
            }
            st.Stop();
            textXmin.Text = result.ToString();
            textYmin.Text = GetValue1(result).ToString();
            timestamp.Text = st.Elapsed.TotalMilliseconds.ToString();
        }
        double BisectionMethod(double a, double b)
        {            
            double l = b-a;
            while (l > EPS)
            {
                l = b - a;
                if (l < 0)
                    throw new Exception("На заданном отрезке нет единственной точки минимума");
                double xm = (a + b) / 2;
                double wm = GetValue1(xm);
                double x1 = a + l / 4, x2 = b - l / 4;
                if (GetValue1(x1) < wm)
                    b = x1;
                else
                    a = xm;
                if (GetValue1(x2) < wm)
                    a = x2;
                else
                    b = xm;
            }
            return a+ l/2;
        }

        double GoldenSectionMethod(double a, double b)
        {
            double x1=0, x2=0;
            while (b - a > EPS)
            {
                x1 = b - (b - a) / Ff;
                x2 = a + (b - a) / Ff;
                if (GetValue1(x1) <= GetValue1(x2))
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - (b - a) / Ff;
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + (b - a) / Ff;
                }
            }
            if (GetValue1(x1) > GetValue1(x2))
                return x2;
            else
                return x1;
        }
        double FibonacciMethod(double a, double b)
        {
            int counter = (int)EPS;
            int[] arr = GetFibbonacci(counter);
            double x1 = 0, x2 = 0;
            while (counter>2)
            {
                x1 = a + (b - a) * arr[counter-3]/ arr[counter-1];
                x2 = a + (b - a) *arr[counter-2]/arr[counter-1];
                if (GetValue1(x1) <= GetValue1(x2))
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + b -x2;
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = b - x1 + a;
                }
                counter--;
            }
            return x1;
        }
        double QuadraticInterpolation(double x1, double dx)
        {
            double x2 = x1 + dx, x3, f1, f2, f3, ff, fmin, xmin;
            if ((f1 = GetValue1(x1)) > (f2 = GetValue1(x2)))
                x3 = x1 + 2 * dx;
            else
                x3 = x1 - dx;
            f3 = GetValue1(x3);

            if (f1 <= f2 && f1 <= f3) { fmin = f1; xmin = x1; }
            if (f2 <= f3 && f2 <= f1) { fmin = f2; xmin = x2; }
            else fmin = f3; xmin = x3;
            double xx = (x2 + x1) / 2 -
                ((f2 - f1) / (x2 - x1)) / //a1
                (2 * (1 / (x3 - x2) * ((f3 - f1) / (x3 - x1) - (f2 - f1) / (x2 - x1))));//a2
            ff = GetValue1(xx);
            if (Math.Abs(ff - fmin) < EPS && Math.Abs(xx - xmin) < EPS)
                return xx;
            return QuadraticInterpolation(xx, dx);
        }
        double GetValue1(double x)
        {
            return Math.Pow(x, 3) - 12 * Math.Pow(x, 2) + 24 * x - 18;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 3)
                textB.Enabled = false;
            else
                textB.Enabled = true;
        }
    }
}
