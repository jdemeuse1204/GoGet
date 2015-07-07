using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoGet.Tests
{
    public class MyClass
    {
        public MyClass()
        {
            MyField = new MyNestedClass();

            MyProperty = new MyNestedClass();
        }

        public MyNestedClass MyField;

        public MyNestedClass MyProperty { get; set; }
    }
}
