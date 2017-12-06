using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    //Делегаты - аналог процедурного типа в Паскале.     
    //Делегат - это не тип класса, а тип метода.     
    //Делегат определяет сигнатуру метода (типы параметров и возвращаемого значения).     
    //Если создается метод типа делегата, то у него должна быть сигнатура как у делегата.     
    //Метод типа делегата можно передать как параметр другому методу.      
    //Название делегата при объявлении указывается "вместо" названия метода     
    delegate int MultOrDiv(int p1, int p2);
    class Program
    {
        //Методы, реализующие делегат (методы "типа" делегата)
        static int Mult(int p1, int p2) { return p1 * p2; }
        static int Div(int p1, int p2) { return p1 / p2; }
        /// <summary>
        /// Использование обощенного делегата Func<> 
        /// </summary>         
        static void MultOrDivFunc(string str, int i1, int i2, Func<int, int, int> MultOrDivParam)
        {
            int Result = MultOrDivParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
            // Func<int, string, bool> - делегат принимает параметры типа int и string и возвращает bool                                  
            // Если метод должен возвращать void, то используется делегат Action            
            // Action<int, string> - делегат принимает параметры типа int и string и возвращает void             
            // Action как правило используется для разработки групповых делегатов, которые используются в событиях  
        }
        /// <summary> 
        /// Использование делегата  
        /// </summary>    
        // метод с делегатным параметром
        static void MultOrDivMethod(string str, int i1, int i2, MultOrDiv MultOrDivParam)
        {
            //вызов (имя параметра как функция)
            int Result = MultOrDivParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
        }
        static void Main(string[] args)
        {
            int i1 = 6; int i2 = 2;
            //вызов методов с делегатным параметром
            MultOrDivMethod("Умножение: ", i1, i2, Mult);
            MultOrDivMethod("Деление: ", i1, i2, Div);
            //Создание экземпляра делегата на основе метода (с помощью конструктора делегатного типа)
            MultOrDiv md1 = new MultOrDiv(Mult);
            MultOrDivMethod("Создание экземпляра делегата на основе метода: ", i1, i2, md1);
            //Создание экземпляра делегата на основе 'предположения' делегата  
            //Компилятор 'пердполагает' что метод Mult типа делегата        
            MultOrDiv md2 = Mult;
            MultOrDivMethod("Создание экземпляра делегата на основе 'предположения' делегата: ", i1, i2, md2);
            //Создание анонимного метода    
            MultOrDiv md3 = delegate (int param1, int param2)
            {
                return param1 * param2;
            };
            MultOrDivMethod("Создание экземпляра делегата на основе анонимного метода: ", i1, i2, md2);
            MultOrDivMethod("Создание экземпляра делегата на основе лямбдавыражения 1: ", i1, i2, (int x, int y) => { int z = x * y; return z; });
            MultOrDivMethod("Создание экземпляра делегата на основе лямбдавыражения 2: ", i1, i2, (x, y) => { return x * y; });
            MultOrDivMethod("Создание экземпляра делегата на основе лямбдавыражения 3: ", i1, i2, (x, y) => x * y);
            //////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nИспользование обощенного делегата Func<>");
            MultOrDivFunc("Создание экземпляра делегата на основе метода: ", i1, i2, Mult);
            string OuterString = "ВНЕШНЯЯ ПЕРЕМЕННАЯ";
            MultOrDivFunc("Создание экземпляра делегата на основе лямбдавыражения 1: ", i1, i2, (int x, int y) => { Console.WriteLine("Эта переменная объявлена вне лямбдавыражения: " + OuterString); int z = x * y; return z; });
            MultOrDivFunc("Создание экземпляра делегата на основе лямбдавыражения 2: ", i1, i2, (x, y) => { return x * y; });
            MultOrDivFunc("Создание экземпляра делегата на основе лямбдавыражения 3: ", i1, i2, (x, y) => x * y);
            //////////////////////////////////////////////////////////////          
            //Групповой делегат всегда возвращает значение типа void    
            Console.WriteLine("Пример группового делегата");
            Action<int, int> a1 = (x, y) => { Console.WriteLine("{0} * {1} = {2}", x, y, x * y); };
            Action<int, int> a2 = (x, y) => { Console.WriteLine("{0} / {1} = {2}", x, y, x / y); };
            Action<int, int> group = a1 + a2;
            group(6, 2);
            Action<int, int> group2 = a1; Console.WriteLine("Добавление вызова метода к групповому делегату");
            group2 += a2;
            group2(10, 5);
            Console.WriteLine("Удаление вызова метода из группового делегата");
            group2 -= a1;
            group2(20, 10);
            Console.ReadLine();
        }
    }
}