
//Create C# class Employee with at least 5 fields and two methods in it.
// Instantiate Employee in differet class, assign object data and call methods to print output in console.internal class Employee
internal class Employee
{
    //Declaring veriable
    internal string? name;
    internal string? address;
    internal long? phone_number;
    internal float Salary;
    internal int Empid;
    //Function to get Salary
    internal float GetSalary()
    {
        Salary=2515.25f;
        return Salary;
    }
    //Function to get employee id
    internal int GetEmpid()
    {
        Empid=1;
        return Empid;
    }
    //Function to display data
    internal void Display()
    {
        Console.WriteLine(name);
        Console.WriteLine(address);
        Console.WriteLine(phone_number);
        Console.WriteLine(Salary);
        Console.WriteLine(Empid);
    } 
}
class access
{
    public static void Main()
    {
    Employee employee1=new Employee();  //Object Creation
    employee1.name="prigesh";   //Data input
    employee1.address="damak";  //Data input
    employee1.phone_number=9800000000;  //Data input
    employee1.GetSalary();  //Calling function with object
    employee1.GetEmpid();   //Calling function with object
    employee1.Display();    //Calling function with object
    }
}