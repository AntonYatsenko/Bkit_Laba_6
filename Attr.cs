using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._2_csh
{
    //класс атрибута должен быть, в свою очередь, помечен атрибутом AttributeUsage, который принимает три параметра: 
    //параметр типа перечисление AttributeTargets, которое указывает, к каким элементам класса может применяться атрибут Attr (классам, свойствам, методам и т.д.); в данном случае только к свойствам (Property); 
    //логический параметр AllowMultiple, указывающий, может ли применяться к свойству несколько атрибутов NewAttribute; в данном случае это запрещено; 
    //логический параметр Inherited, указывающий, наследуется ли атрибут классами, производными от класса с атрибутами; обычно используется значение false. 
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class Attr: Attribute
    {
        //конструктор без параметров
        public Attr() { } 
        //конструктор с параметром
        public Attr(string DescriptionParam)
        {
            Description = DescriptionParam;
        }
        //автоопределяемое свойство Description
        public string Description { get; set; }
    }
}
