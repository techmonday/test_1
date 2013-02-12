using System;


public class Program
{

    static void Main(string[] args)
    {
        Customer customer1 = new Customer(new BasicLogger());
        Customer customer2 = new Customer(new AdvancedLogger());

        customer1.WriteToLog("testing 1");
        customer2.WriteToLog("testing 2");

        Console.ReadKey();
    }
}

public class Customer
{
    ILogger Logger;

    public Customer(ILogger logger)
    {
        Logger = logger;
    }

    public void WriteToLog(string text)
    {
        Logger.WriteToLog(text);
    }
}

public interface ILogger // depen
{
    void WriteToLog(string text);
}

public class BasicLogger : ILogger
{
    public void WriteToLog(string text)
    {
        Console.WriteLine("BasicLogger {0}", text);
    }
}

public class AdvancedLogger : ILogger
{
    public void WriteToLog(string text)
    {
        Console.WriteLine("AdvancedLogger {0}", text);
    }
}