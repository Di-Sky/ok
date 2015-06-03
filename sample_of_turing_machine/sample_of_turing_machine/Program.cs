using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine1
{
    class PlusOneToNum
    {
        //перегрузка PlusOne
        static string PlusOne(string Num)
        {
            Num = PlusOne(Num, "q1", "");
            return Num;
        }
        //собственно метод, который добавляет единицу к числу
        static string PlusOne(string Num, string States, string buffer)
        {
            #region switchblock for states
            switch (States)
            {
                case "q1":
                    States = "q0";
                    //меняем число в буфере
                    #region switchblock for q1
                    switch (Num[Num.Length - 1])
                    {
                        case '0':
                            buffer = buffer.Insert(0, "1");
                            break;
                        case '1':
                            buffer = buffer.Insert(0, "2");
                            break;
                        case '2':
                            buffer = buffer.Insert(0, "3");
                            break;
                        case '3':
                            buffer = buffer.Insert(0, "4");
                            break;
                        case '4':
                            buffer = buffer.Insert(0, "5");
                            break;
                        case '5':
                            buffer = buffer.Insert(0, "6");
                            break;
                        case '6':
                            buffer = buffer.Insert(0, "7");
                            break;
                        case '7':
                            buffer = buffer.Insert(0, "8");
                            break;
                        case '8':
                            buffer = buffer.Insert(0, "9");
                            break;
                        case '9':
                            buffer = buffer.Insert(0, "0");
                            States = "q1";
                            break;
                    }
                    #endregion
                    //убираем последнюю цифру в основном числе
                    Num = Num.Remove(Num.Length - 1);
                    //рекурсивно вызываем функцию обработки числа
                    Num = PlusOne(Num, States, buffer);
                    break;
                //при состоянии q0 добавляем последние числа из буфера и возвращаем число
                case "q0":
                    Num += buffer;
                    break;
            }
            #endregion
            return Num;
        }
        static void Main(string[] args)
        {
            string number;
            Console.WriteLine("Input number");
            number = Console.ReadLine();
            number = PlusOne(number);
            Console.WriteLine(number);
            Console.ReadKey();
        }
    }
}
