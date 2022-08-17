//Code to ask name
Console.Write("enter name=");
string name=Console.ReadLine();

//code to ask age
Console.WriteLine("enter age=");
var age=Console.ReadLine();
var Age=byte.Parse(age);

//code to ask weight
Console.Write("enter weight=");
short weight=Convert.ToInt16(Console.ReadLine());

//code to dispaly name age and weight
Console.WriteLine("name="+name);
Console.WriteLine("age="+Age);
Console.WriteLine("weight="+weight);


/*
Console.Write("enter gender=");
char? gender;
if(gender=='m'||gender=='M')
{
    Console.Write(gender);
}
else(gender =='f'||gender='F');
{
    Console.Write(gender);
}*/