Console.WriteLine("enter a number=");
var num=Console.ReadLine();
var number=int.Parse(num);
if(number%2==0)
{
    Console.WriteLine("even number is "+number);
}
else
{
    Console.WriteLine("odd number="+number);
}