using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreakApp
{
    public class Game
    {
        private int[,] _arr;
        private int _n;

        public int this[int x, int y]
        {
            get
            {
                return _arr[x, y];
            }
        }

        public void Print()
        {
            Console.WriteLine();

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Console.Write("{0}\t", _arr[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public Point GetLocation(int value)
        {
            int i_value = -1;
            int j_value = -1;

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (_arr[i,j] == value)
                    {
                        i_value = i;
                        j_value = j;
                    }
                }
            }

            if (i_value == -1)
                throw new Exception("Нет такого значения!");

            Point point = new Point(i_value, j_value);
            return point;
        }

        public void Shift(int value)
        {
            Point point = GetLocation(value);

            int i_val = point.X;
            int j_val = point.Y;

            if ((i_val != 0 && _arr[i_val - 1, j_val] == 0) || //проверяем соседа сверху
                (i_val != _n - 1 && _arr[i_val + 1, j_val] == 0) || //проверяем соседа снизу
                 (j_val != 0 && _arr[i_val, j_val - 1] == 0) || //проверяем соседа слева
                 (j_val != _n - 1 && _arr[i_val, j_val + 1] == 0)) //проверяем соседа справа
            {
                Point point0 = GetLocation(0);

                _arr[point0.X, point0.Y] = value;
                _arr[point.X, point.Y] = 0;
            }
            else
            {
                throw new Exception("Такой ход невозможен!");
            }
        }

        public Game(int n)
        {
            _arr = new int[n, n];
            _n = n;

            List<int> list = new List<int>(); //вспомогательная коллекция

            //заполняем рандомно игровое поле 
            Random rand = new Random();  

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool success = false;

                    do
                    {
                        int num = rand.Next(0, n * n);

                        if (!list.Contains(num))
                        {
                            list.Add(num);
                            _arr[i, j] = num;

                            success = true;
                        }
                    }
                    while (!success);
                }
            }
        }
    }
}
