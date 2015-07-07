using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoGet.Tests
{
    public class MyNestedClass
    {
        public MyNestedClass()
        {
            MyNameProperty = "James";
            MyNameField = "Demeuse";
        }

        public void MyMethod()
        {

        }

        public string MyNameProperty { get; set; }

        public string MyNameField;
    }
}
