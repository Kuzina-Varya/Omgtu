﻿using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Threading.Channels;
namespace польская_запись_через_стэк
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВОДИТЕ ВСЕ ОПЕРАЦИИ(УМНОЖЕНИЕ ТОЖЕ)");
            StringBuilder myStringBuilder = new StringBuilder(Console.ReadLine());
            myStringBuilder.Replace(",", "");
            myStringBuilder.Replace("(", "");
            myStringBuilder.Replace(")", "");
            Stack<int> values = new Stack<int>();
            int count = 0;
            for (int i = 0; i < myStringBuilder.Length; i++)
            {

                if (((myStringBuilder[i] != '/') && (myStringBuilder[i] != '*') && (myStringBuilder[i]) != '-') && (myStringBuilder[i] != '+') && (myStringBuilder[i] != '^') && (myStringBuilder[i] != ')') && (myStringBuilder[i] != '('))
                {
                    values.Push((int)(Char.GetNumericValue(myStringBuilder[i])));
                    count++;
                }
                else
                {




                    if ((values.Count >= 2))
                    {
                        int a = values.Pop();
                        int b = values.Pop();
                        switch (myStringBuilder[i])
                        {
                            case '/':
                                if (a == 0)
                                {
                                    Console.WriteLine(" Делить на ноль неприлично... ");
                                    break;
                                }
                                else if (a != 0)
                                {
                                    values.Push(b / a);

                                }


                                break;
                            case '*':
                                values.Push((b * a));
                                break;
                            case '-':
                                values.Push(b - a);
                                break;
                            case '+':
                                values.Push(b + a);
                                break;
                            case '^':
                                values.Push(Convert.ToInt32(Math.Pow(Convert.ToDouble(b), Convert.ToDouble(a))));
                                break;
                            default:
                                values.Push(b);
                                values.Push(a);
                                break;


                        }
                    }



                }

            }
            
            if (count - 1 == myStringBuilder.Length -count)
            {
                Console.WriteLine(values.Pop());

            }
            else
            {
                Console.WriteLine("Введено неверное количество значений или операций");
            }

        }
    }
}





