using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoGet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new MyClass();

            var get = Go.Get(c, "ClassY.Name");
            var test = Go.GetProperty(get);
            var value = Go.GetPropertyValue<string>(test);
            var method = Go.GetMethod(c,"ClassY.WIN");

            if (get != null && test != null)
            {
            }
        }
    }

    public class MyClass
    {
        public MyClass()
        {
            ID = 1;
            ClassX = new ClassX();
            ClassY = new ClassX();
        }

        public int ID { get; set; }

        public ClassX ClassX { get; set; }

        public ClassX ClassY;
    }

    public class ClassX
    {
        public ClassX()
        {
            Name = "James";
        }

        public string Name { get; set; }

        public void WIN()
        {
            
        }
    }
}
