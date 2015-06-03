using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galton_box
{
    class the_box
    {
        //Возвращает номер ячейки в которую упал шарик
        static int GalNumb(int pins, Random rnd)
        {
            int numb = pins - 1;
            //Цикл по количеству штырьков
            for (int i = 0; i < pins; i++)
            {
                if (rnd.Next(2) > 0)
                    if (numb < (pins * 2 - 1))
                        numb += 1;
                    else ;
                else
                    if (numb > 0)
                        numb -= 1;
            }
            return numb;
        }
        //Возвращает массив значений с количеством попаданий шариков в каждую из ячеек
        static int[] GalBox(int balls, int pins)
        {
            //создание массива
            int[] box = new int[pins * 2];
            for (int i = 0; i < pins * 2; i++)
                box[i] = 0;

            //цикл, заполняющий ячейки шариками
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < balls; i++)
            {
                box[GalNumb(pins, rand)]++;
            }
            return box;
        }

        //Вывод на экран
        static void WrBox(int[] gal)
        {
            Console.Write(gal[0]);
            Console.Write(" ");
            for (int i = 1; i < gal.Length; i += 2)
            {
                Console.Write(gal[i]);
                Console.Write(" ");
            }
            Console.Write('\n');
        }
        static void Main(string[] args)
        {
            int pins, balls;
            Console.WriteLine("Input number of pins");
            pins = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input number of balls");
            balls = Convert.ToInt32(Console.ReadLine());
            WrBox(GalBox(balls, pins));
            Console.ReadKey();
        }
    }
}
