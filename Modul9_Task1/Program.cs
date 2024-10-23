using System;

namespace Modul9_Task1
{
    internal class Program
    {
        static int Division(int a, int b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[]
            {
                new DivideByZeroException(),
                new ArgumentNullException(),
                new ArgumentException(),
                new IndexOutOfRangeException(),
                new MyException("Cвой тип исключения.")
            };

            foreach (Exception ex in exceptions) {
                try
                {
                    if (ex is MyException) {
                        throw ex;
                    }

                    if (ex is DivideByZeroException)
                    {
                        int result = Division(7, 0);
                    }

                    if (ex is ArgumentNullException)
                    {
                        string a = null;
                        int b = int.Parse(a);
                        int result = Division(7,b);
                    }

                    if (ex is ArgumentException)
                    {
                        throw ex;
                    }

                    if (ex is IndexOutOfRangeException)
                    {
                        throw exceptions[10];
                    }

                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Произошло деление на ноль!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Аргумент, передаваемый в метод — null!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Передан некорректный аргумент!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Выход за границы массива!");
                }
                catch (MyException)
                {
                    Console.WriteLine("Свое исключение: {0}", ex.Message);
                }
                //finally
                //{
                //   Console.WriteLine("Блок finally выполняется всегда.");
                //}
            }
        }
    }

    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
}
