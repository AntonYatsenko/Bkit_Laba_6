using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._2_csh
{
    class ForInspection
    {
        public ForInspection() { }
        public ForInspection(int i) { }
        public ForInspection(string str) { }
        public int Mult(int x, int y) { return x * y; }
        public int Div(int x, int y) { return x / y; }
        [Attr("Описание для property1")]
        public string property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        private string _property1;
        public int property2 { get; set; }
        [Attr(Description = "Описание для property3")]
        public double property3 { get; private set; }
        public int field1;
        public float field2;
    }
}
