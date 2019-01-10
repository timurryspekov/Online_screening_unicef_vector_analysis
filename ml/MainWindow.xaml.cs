using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Vector<T>
    {
        T[] array;
        public Vector()
        {
            array = new T[0];
        }
        public Vector(int count)
        {
            array = new T[count];
        }
        public T At(int index)
        {

            return array[index];
        }

        public T back
        {
            get
            {
                return array[array.Length - 1];
            }
            set
            {
                array[array.Length - 1] = value;
            }
        }
        public void isat(int index, T value)
        {

            array[index] = value;

        }
        public T Front
        {
            get
            {
                return array[0];
            }
            set
            {
                array[0] = value;
            }
        }
        public void Clear()
        {
            array = new T[0];
        }

        public void Insert(int pos, T item)
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > pos; i--)
                array[i] = array[i - 1];
            array[pos] = item;
        }
        public void push_back(T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }
        public void pop_back()
        {
            Array.Resize(ref array, array.Length - 1);

        }
        public void push_front(T item)
        {
            Insert(0, item);
        }
        public int Count
        {
            get
            {
                return array.Length;
            }
        }
        public T[] ToArray()
        {
            return array;
        }
    }
    public partial class MainWindow : Window
    {
        Vector<string[]> data = new Vector<string[]>();
        public MainWindow()
        {
            InitializeComponent();
            OpenFileDialog d = new OpenFileDialog();
            d.ShowDialog();
            System.IO.StreamReader b = new StreamReader(new FileStream(d.FileName, FileMode.Open, FileAccess.ReadWrite),
Encoding.UTF8);
            while (!b.EndOfStream)
            {
                var k = b.ReadLine().Split(';');
                if (k[0].Contains("1"))
                {
                    data.push_back(k);
                }
            }
        }
        int cof = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var k = new_d.Text.Split(';');
                Vector<double> res = new Vector<double>();
                for(int i = 0; i < k.Length; i++)
                {
                    double count = 0;
                    for(int j = 1; j < data.Count; j++)
                    {
                        if (data.At(j)[i + 1] == k[i])
                        {
                            count++;
                        }
                    }
                    if (count / data.Count > 0.75)
                    {
                        res.push_back(1);
                    }
                    else
                    {
                        res.push_back(0);
                    }
                }
                double result = 0;
                for(int i = 0; i < res.Count; i++)
                {
                    result += (res.At(i) * Convert.ToDouble(data.At(0)[i]));
                }
                MessageBox.Show(result.ToString());
                if (result >= cof)
                {
                    data.push_back(k);
                    MessageBox.Show("Подтверждено!");
                }

            }
            catch
            {

            }
        }
    }
}
