using System;
using System.Linq;
using System.Text;

namespace StringComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;

            
            Console.WriteLine("Enter the string Compare To:");
            str1 = Console.ReadLine();

            Console.WriteLine("Enter the string Compare With:");
            str2 = Console.ReadLine();

            Console.WriteLine("1.Is Equal");
            Console.WriteLine("2.Index of Deviation");
            Console.WriteLine("3.String Contains");
            
            Console.Write("Enter Choice(1-3):");
            int ch = Int32.Parse(Console.ReadLine());
            
            switch (ch)
            {
                case 1:
                    if (String.Equals(str1, str2))
                        Console.WriteLine($"{str1} and {str2} have same value.");
                    else
                        Console.WriteLine($"{str1} and {str2} are different.");
                    break;
                    
                case 2:
                    findFirstDifIndex(str1, str2);
                    break;
                case 3:

                    CommanCharacter(str1, str2);

                    break;
                
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.ReadKey();

        }
        private static void findFirstDifIndex(string s1, string s2)
        {
            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
                if (s1[i] != s2[i])
                {
                    Console.WriteLine($"{s1} and {s2} have an index of deviation at position {i}");
                    break;
                }

                else
                    Console.WriteLine($"{s1} and {s2} have an same value of length {s1.Length}");
            
                
        }
        private static void CommanCharacter(string str1, string str2)
        {
            var common = str1.Intersect(str2).OrderBy(c => c);

            StringBuilder strCommonChar = new StringBuilder();
            foreach (var c in common)
            {
                strCommonChar.Append(',').Append(c);

            }
            strCommonChar.Remove(0, 1);
            Console.WriteLine(strCommonChar);


        }

    }
}
