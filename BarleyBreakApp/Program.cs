using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreakApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(3);
            game.Print();

           
            int oper = 0;

            do
            {
                Console.WriteLine("1.Сделать след шаг");
                Console.WriteLine("2.Выход");

                oper = int.Parse(Console.ReadLine());

                switch (oper)
                {
                    case 1:
                        {
                            try
                            {
                                Console.WriteLine("Введите значение перемещаемого элемента ");
                                int val = int.Parse(Console.ReadLine());

                                game.Shift(val);

                                game.Print();
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            while (oper != 2);
        }
    }
}
