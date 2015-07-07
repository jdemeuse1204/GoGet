# GoGet
project to traverse object by string paths

###Methods:
```C#
public static T GetPropertyValue<T>(object o, string path);

public static T GetPropertyValue<T>(GetInfo info);

public static GetInfo GetProperty(object o, string path);

public static GetInfo GetProperty(Get get);


public static T GetFieldValue<T>(object o, string path);

public static T GetFieldValue<T>(GetInfo info);

public static GetInfo GetField(object o, string path);

public static GetInfo GetField(Get get);


public static MethodInfo GetMethod(object o, string path);

public static MethodInfo GetMethod(Get get);


public static Get Get(object o, string path);
```

Examples:

```C#
public class MyClass
{
  public MyClass()
  {
    MyField = new MyNestedClass();
    
    MyProperty = new MyNestedClass();
  }
  
  public MyNestedClass MyField;
  
  public MyNestedClass MyProperty {get;set;}
}

public class MyNestedClass
{
  public void MyMethod()
  {
    MyNameProperty = "James";
    MyNameField = "Demeuse";
  }
  
  public string MyNameProperty {get;set;}
  
  public string MyNameField;
}
```

With the above model we can do the following

```C#
var myClass = new MyClass();

var myName = Go.GetPropertyValue<string>(myClass,"MyProperty.MyPropertyName");

// We can also do since the end result is a property

var myName = Go.GetPropertyValue<string>(myClass,"MyNameField.MyPropertyName");

// likewise we can do the same for fields

var myName = Go.GetPropertyValue<string>(myClass,"MyNameField.MyNameField");

var myName = Go.GetPropertyValue<string>(myClass,"MyProperty.MyNameField");

```
**NOTE: When retrieving a PropertyValue or FieldValue, if nothing is found, default(T) is returned
Mail To - james.demeuse@gmail.com
