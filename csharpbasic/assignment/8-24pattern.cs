public class Pattern
{
    internal void firstPattern()
    {
        Console.WriteLine("First pattern:\n");
        for(int i=0;i<=6;i++)
         {
             for(int j=0;j<=i;j++)
             {
                 Console.Write("#");
             }
             Console.WriteLine();
         }      

        Console.WriteLine("\nsecond pattern:\n");
         for(int i=1;i<=6;i++)
        {
            for(int j=1;j<=i;j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        } 
        Console.WriteLine("\nthird pattern:\n");
         for (int row = 1; row <= 5; row++)
        {
            for (int spc = 1; spc <= (5 - row); spc++) //hear j 
            {
                Console.Write(" ");
            }

            for (int pat = 1; pat < row * 2; pat++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nfourth pattern:\n");
        {
            for (int row = 1; row <= 5; row++)
        {
            for (int spc = 1; spc <= (5 - row); spc++) //hear j 
            {
                Console.Write(" ");
            }

            for (int pat = 1; pat < row * 2; pat++)
            {
                Console.Write(pat);
            }
            Console.WriteLine();
        }
        }
    }
    
}