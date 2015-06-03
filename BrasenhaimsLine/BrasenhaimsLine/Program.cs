using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bresenhams_line
{
    class linepr
    {

        //Создание линии
        static char[,] BrLn(char[,] fld, int x1, int y1, int x2, int y2)
        {
            //Координаты точки с которой работаем
            int x = x1;
            int y = y1;

            //Булевая переменная, определяющая направление линии 
            //false -> по у, true -> по х
            bool vc = false;

            //Расчёт углового коэффициента
            double anglecf;
            if (x2 - x1 > y2 - y1)
            {
                vc = true;
                anglecf = (double)(y2 - y1) / (x2 - x1);
            }
            else anglecf = (double)(x2 - x1) / (y2 - y1);

            //Хранение значения ошибки
            double err = 0;

            //Счётчик 
            int sch = vc ? x2 - x1 : y2 - y1;

            //Просчёт точек
            fld[9 - y, x] = '0'; //начальная точка
            for (int i = 0; i < sch; i++)
            {
                err += anglecf;
                if (err > 0.5)
                {
                    err -= 1;
                    x += 1;
                    y += 1;
                }
                else if (vc) x += 1; else y += 1;
                fld[9 - y, x] = '0';
            }
            return fld;
        }

        //Вывод массива символов на экран
        static void Char_Wr(char[,] chms)
        {
            Console.Write('\n');
            for (int i = 0; i < chms.GetLength(0); i++)
            {
                for (int j = 0; j < chms.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write(9 - i);
                        Console.Write("|");
                    }
                    Console.Write(chms[i, j]);
                }
                Console.Write('\n');
            }
            Console.Write("  ");
            for (int i = 0; i < chms.GetLength(1); i++)
                Console.Write(i);
            Console.Write('\n');
        }

        //Инициализация массива символов
        static void Char_Init(char[,] chms)
        {
            for (int i = 0; i < chms.GetLength(0); i++)
                for (int j = 0; j < chms.GetLength(1); j++)
                    chms[i, j] = ' ';
        }

        static void Main(string[] args)
        {
            char[,] fld = new char[10, 10];
            Char_Init(fld);
            Console.WriteLine("Input x1,y1,x2,y2");
            int x1, x2, y1, y2;
            x1 = Convert.ToInt32(Console.ReadLine());
            y1 = Convert.ToInt32(Console.ReadLine());
            x2 = Convert.ToInt32(Console.ReadLine());
            y2 = Convert.ToInt32(Console.ReadLine());
            fld = BrLn(fld, x1, y1, x2, y2);
            Char_Wr(fld);
            Console.ReadKey();
        }
    }
}
