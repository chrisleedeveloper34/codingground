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
    
    public DebugInfo(int bug, string developer, string reviewed)
    {
        this.bugNo = bug;
        this.developer = developer;
        this.lastReviewed = reviewed;
    }
    public int BugNo 
    { 
        get { return this.bugNo;}
    }
    public string Developer
    {
        get { return this.developer; }
    }
    public string LastReviewed
    {
        get { return this.lastReviewed; }
    }
    public string Message
    {
        get { return this.message; }
        set { this.message = value; }
    }
}

[DebugInfo(4, "Chris", "2017-02-02", Message="Type mismatch")]
public class Rectangle
{
    protected double length;
    protected double width;
    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }
    
    [DebugInfo(12, "Pete", "2017-01-09", Message="type mismatch")]
    public double GetArea()
    {
        return this.length * this.width;
    }
    
    [DebugInfo(34, "Graham", "2017-02-03")]
    public void Display()
    {
        Console.WriteLine($"Length: {this.length}");
        Console.WriteLine($"Width: {this.width}");
        Console.WriteLine($"Area: {this.GetArea()}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Rectangle rect = new Rectangle(4.8, 3.2);
        rect.Display();
        Type rectType = typeof(Rectangle);
        
        foreach(var attribute in rectType.GetCustomAttributes(false))
        {
            if (attribute is DebugInfo)
            {
                DebugInfo dbi = attribute as DebugInfo;
                Console.WriteLine($"Bug Number: {dbi.BugNo}");
                Console.WriteLine($"Developer: {dbi.Developer}");
                Console.WriteLine($"Last Reviewed: {dbi.LastReviewed}");
                Console.WriteLine($"Message: {dbi.Message}");
            }
        }
        
        foreach(var mi in rectType.GetMethods())
        {
            foreach(var attribute in mi.GetCustomAttributes(true))
            {
                if (attribute is DebugInfo)
                {
                    DebugInfo dbi = attribute as DebugInfo;
                    Console.WriteLine($"Bug No: {dbi.BugNo} for Method: {mi.Name}");
                    Console.WriteLine($"Developer: {dbi.Developer}");
                    Console.WriteLine($"Last Reviewed: {dbi.LastReviewed}");
                    Console.WriteLine($"Message: {dbi.Message}");
                }
            }
        }
    }
}
