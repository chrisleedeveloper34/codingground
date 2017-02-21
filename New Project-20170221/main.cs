using System.IO;
using System;

public class MessageArgument<T> : EventArgs
{
    public T Message {get; set;}
    public MessageArgument(T message)
    {
        Message = message;
    }
}

public interface IPublisher<T>
{
    event EventHandler<MessageArgument<T>> DataPublisher;
    void OnDataPublisher(MessageArgument<T> arguments);
    void PublishData(T data);
}

public class Publisher<T> : IPublisher<T>
{
    public event EventHandler<MessageArgument<T>> DataPublisher;
    public void OnDataPublisher(MessageArgument<T> arguments)
    {
        // Old way
        //var handler = DataPublisher;
        //if (handler != null)
        //{
        //    handler(this, arguments);
        //}
        
        // C# 6 way
        DataPublisher?.Invoke(this, arguments);
    }
    public void PublishData(T data)
    {
        MessageArgument<T> message = (MessageArgument<T>)Activator.CreateInstance(typeof(MessageArgument<T>), new object[] { data });
        OnDataPublisher(message);
    }
}

public class Subscriber<T> 
{
    public IPublisher<T> Publisher{get; private set;}
    public Subscriber(IPublisher<T> publisher)
    {
        Publisher = publisher;
    }
}

public class Client 
{
    private readonly IPublisher<int> IntPublisher;
    private readonly Subscriber<int> IntSubscriber1;
    private readonly Subscriber<int> IntSubscriber2;
    
    public Client()
    {
        IntPublisher = new Publisher<int>();
        IntSubscriber1 = new Subscriber<int>(IntPublisher);
        IntSubscriber1.Publisher.DataPublisher += publisher_DataPublisher1;
        
        IntSubscriber2 = new Subscriber<int>(IntPublisher);
        IntSubscriber2.Publisher.DataPublisher += publisher_DataPublisher2;
        
        IntPublisher.PublishData(10);
    }
    
    public void publisher_DataPublisher1(object sender, MessageArgument<int> message)
    {
        Console.WriteLine("Subscriber 1: " + message.Message);
    }
    
    public void publisher_DataPublisher2(object sender, MessageArgument<int> message)
    {
        Console.WriteLine("Subscriber 2: " + message.Message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Client client = new Client();
        
        //Your code goes here
        Console.WriteLine("Hello, world!");
    }
}
