using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lab6._2_csh
{
    class Program
    {
        //Метод принимает в качестве параметров информацию о проверяемом свойстве «PropertyInfo checkType» 
        //и тип проверяемого атрибута «Type attributeType»
        //Если проверяемое свойство содержит атрибуты данного типа (метод checkType.GetCustomAttributes возвращает 
        //коллекцию isAttribute из более чем одного элемента), то метод возвращает истину,
        //а в выходной параметр метода «out object attribute» помещается первый элемент коллекции isAttribute
        //(в соответствии с определением, свойство NewAttribute может применяться к свойству не более одного раза).
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        static void Main(string[] args)
        {
            Type t = typeof(ForInspection);
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())            Console.WriteLine(x);
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())                 Console.WriteLine(x);
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())              Console.WriteLine(x);            
            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())                  Console.WriteLine(x);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(Attr), out attrObj))
                {
                    Attr attr = attrObj as Attr;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine("\nВызов метода:");
            //Создание объекта
            //ForInspection fi = new ForInspection();
            //Можно создать объект через рефлексию
            ForInspection fi = (ForInspection)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            //Параметры вызова метода
            object[] parameters = new object[] { 3, 2 };
            //Вызов метода
            //Метод InvokeMember класса Type позволяет выполнять динамические действия с объектами классов:
            //создавать объекты, вызывать методы, получать и присваивать значения свойств и др. 
            //Его особенность заключается в том, что имена свойств, классов передаются методу InvokeMember в виде строковых параметров. 
            object Result = t.InvokeMember("Mult", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Mult(3,2)={0}", Result);
            Console.ReadLine();
        }
    }
}
