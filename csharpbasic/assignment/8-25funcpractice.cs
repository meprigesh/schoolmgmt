public class funcpract
{
    internal string fulName(string firstName,string lastName)
    {
        /*Console.WriteLine("Enter firt Name=");
        firstName=Console.ReadLine();
        Console.WriteLine("enter last name=");
        lastName= Console.ReadLine();*/
        string fullName=firstName+lastName;
        return fullName;
    }

    internal DateTime printdatentime()
    {
        return DateTime.Now;
    }

    internal string fulName(string firstName,string lastName,string middleName="",string salutation="Mr.")
    {
        /*System.Console.WriteLine("enter salutation=");
        salutation=Console.ReadLine();
        System.Console.WriteLine("enter first name=");
        firstName=System.Console.ReadLine();
        System.Console.WriteLine("Enetr middle name");
        middleName=Console.ReadLine();
        System.Console.WriteLine( "Enter last name=");
        lastName=Console.ReadLine();*/
        string fullName=salutation+firstName+middleName+lastName;
        return fullName;
    }
    
}


// Write a class as sensible as possible with 3 methods:

// Method 1 must take 2 parameters and returns string.
// Method 2 take no parameters and returns Datetime.
// Method 3 is overload of method 1 and takes 4 parameters.