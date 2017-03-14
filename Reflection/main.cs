using System.IO;
using System;

[AttributeUsage(AttributeTargets.Class |
AttributeTargets.Constructor |
AttributeTargets.Field |
AttributeTargets.Method |
AttributeTargets.Property,
AllowMultiple = true)]
public class DebugInfo : System.Attribute
{
    private int bugNo;
    private string developer;
    private string lastReviewed;
    public string message;
    
    public string Topic
    {
        get; set;
    }
    
    public DebufInfo(int bug, string developer, string reviewed)
    {
        this.bugNo = bug;
        this.developer = developer;
        this.lastReviewed = reviewed;
    }
    public int BugNo 
    { 
        get { return this.bugNo;}
        set { bugNo = value; }
    }
        
}

[HelpAttribute("This is a help attribute")]
public class MyClass
{
    
}

public class Program
{
    public static void Main(string[] args)
    {
        System.Reflection.MemberInfo info = typeof(MyClass);
        object[] attributes = info.GetCustomAttributes(true);
        //foreach(var attribute in attributes)
        for(int i = 0; i < attributes.Length; i++)
        {
            Console.WriteLine(attributes[i]);
        }
        
        //Your code goes here
        Console.WriteLine("Hello, world!");
    }
}
