using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoGet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var myClass = new MyClass();

            var myName = Go.GetPropertyValue<string>(myClass, "MyProperty.MyNameProperty");

            Assert.IsTrue(myName == "James");

            // We can also do since the end result is a property

            myName = Go.GetPropertyValue<string>(myClass, "MyField.MyNameProperty");

            Assert.IsTrue(myName == "James");

            // likewise we can do the same for fields

            myName = Go.GetFieldValue<string>(myClass, "MyField.MyNameField");

            Assert.IsTrue(myName == "Demeuse");

            myName = Go.GetFieldValue<string>(myClass, "MyProperty.MyNameField");

            Assert.IsTrue(myName == "Demeuse");

            // Can also find methods if needed

            var myMethod = Go.GetMethod(myClass, "MyProperty.MyMethod");

            Assert.IsNotNull(myMethod);
        }
    }
}
