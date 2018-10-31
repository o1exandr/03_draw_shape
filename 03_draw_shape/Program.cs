/*
 3) Написати два методи для малювання фігур, що мають два  параметри(висота фігури,  колір фігури):
	DrawSquare - для малювання  квадрата
	DrawTriangle - для малювання прямокутного трикутника

 Створити екземпляр делегата(параметри - висота фігури та колір).
 Приєднати до делегату спочатку метод DrawSquare, 
	потім метод DrawTriangle 
Створити екземпляр багатоадресного  делегату
(deleg+=DrawSquare; deleg+= DrawTriangle ),
 який малює обидві фігури певного розміру  та певним  кольором.

Створити метод, який отримає кількість фігур, екземпляр делегату, висоту фігури і колір і викличе через делегат відповідний метод вказане число разів
 */


using System;

namespace _03_draw_shape
{
    class Program
    {
        delegate void DelegDraw(int height, ConsoleColor color);

        // DrawSquare - для малювання  квадрата
        static void DrawSquare(int height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                    Console.Write("O ");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        // DrawTriangle - для малювання прямокутного трикутника
        static void DrawTriangle(int height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            int rows = 0;
            for (int i = 0; i < height; i++)
            {
                ++rows;
                for (int j = 0; j < rows; j++)
                    Console.Write("O ");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        // Створити метод, який отримає кількість фігур, екземпляр делегату, висоту фігури і колір 
        // і викличе через делегат відповідний метод вказане число разів
        static void MethodDelegat(int count, DelegDraw dd, int height, ConsoleColor color)
        {
            for (int i = 0; i < count; i++)
                dd(height, color);
        }
    
        static void Main(string[] args)
        {

            DelegDraw dd = DrawSquare;
            dd(5, ConsoleColor.Magenta);

            dd = DrawTriangle;
            dd(7, ConsoleColor.Green);

            // екземпляр багатоадресного делегату
            dd = DrawSquare;
            dd += DrawTriangle;
            dd(4, ConsoleColor.Blue);

            DelegDraw delegat = DrawSquare;
            MethodDelegat(3, delegat, 6, ConsoleColor.Cyan);

            Console.ReadKey();
        }
    }
    
}
