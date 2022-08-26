public class EntryPoint
{
    public static void Main()
    {
        funcpract obj1 = new();
        string output1=obj1.fulName("prigsh ", "basnet ");
        System.Console.WriteLine(obj1.printdatentime()); 
        string output3= obj1.fulName(firstName:"sanam ",middleName:"jung ",lastName:"thapa ");
        System.Console.WriteLine(output1);
        System.Console.WriteLine(output3);

    }

}
