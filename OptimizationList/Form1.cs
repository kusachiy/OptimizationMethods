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
        delegate double Function(double arg);
        Function getValue;
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
            listBox2.Items.Add("X^3-12x^2+24x-18");
            listBox2.Items.Add("Sin(5*x^4+6*x^3)");
            listBox2.Items.Add("x^3-3x^2+(15/x)");
            getValue = GetValue1;
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
                #region               
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
                #endregion
                #region
                if (-1 == (method = listBox2.SelectedIndex))
                    throw new Exception("Выберите тестируемую функцию");
                switch (method)
                {
                    case 0:
                        getValue = GetValue1;
                        break;
                    case 1:
                        getValue = GetValue2;
                        break;
                    case 2:
                        getValue = GetValue3;
                        break;                    
                    default:
                        break;
                }
                #endregion
            }
            catch (Exception eX)
            {
                statusbar.Text = "ОШИБКА ВВОДА!!!   " + eX.Message;
                return;
            }
            st.Stop();
            textXmin.Text = result.ToString();
            textYmin.Text = getValue(result).ToString();
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
                double wm = getValue(xm);
                double x1 = a + l / 4, x2 = b - l / 4;                
                if(getValue(x1)>=wm)
                    a = x1;                
                if (getValue(x2) >= wm)
                    b = x2;
                if (getValue(x1) < wm)
                    b = xm;
                if (getValue(x2) < wm)
                    a = xm;
            }
            return a + l/2;
        }

        double GoldenSectionMethod(double a, double b)
        {
            double x1=0, x2=0;
            while (b - a > EPS)
            {
                x1 = b - (b - a) / Ff;
                x2 = a + (b - a) / Ff;
                if (getValue(x1) <= getValue(x2))
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
            if (getValue(x1) > getValue(x2))
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
                if (getValue(x1) <= getValue(x2))
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
            if ((f1 = getValue(x1)) > (f2 = getValue(x2)))
                x3 = x1 + 2 * dx;
            else
                x3 = x1 - dx;
            f3 = getValue(x3);

            if (f1 <= f2 && f1 <= f3) { fmin = f1; xmin = x1; }
            if (f2 <= f3 && f2 <= f1) { fmin = f2; xmin = x2; }
            else fmin = f3; xmin = x3;
            double xx = (x2 + x1) / 2 -
                ((f2 - f1) / (x2 - x1)) / //a1
                (2 * (1 / (x3 - x2) * ((f3 - f1) / (x3 - x1) - (f2 - f1) / (x2 - x1))));//a2
            ff = getValue(xx);
            if (Math.Abs(ff - fmin) < EPS && Math.Abs(xx - xmin) < EPS)
                return xx;
            return QuadraticInterpolation(xx, dx/2);
        }
        double GetValue1(double x) //X^3-12x^2+24x-18 Xmin = 6.82 
        {
            return Math.Pow(x, 3) - 12 * Math.Pow(x, 2) + 24 * x - 18;
        }
        double GetValue2(double x) //Sin(5*x^4+6*x^3) Xmin = -0.9
        {
            return Math.Sin(5 * x * x * x * x + 6 * x * x * x);
        }
        double GetValue3(double x) //x^3-3x^2+(15/x) Xmin = 2.32
        {
            return x*x*x - 3*x*x + (15 / x);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 3)
                textB.Enabled = false;
            else
                textB.Enabled = true;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
