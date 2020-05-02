using System;
using System.IO;
using System.Linq;

namespace HR_CountingValleys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 = Counting Valleys");
            Console.WriteLine("2 = Jumping Clouds");
            Console.WriteLine("3 = Repeated String");
            Console.WriteLine("0 = Exit");
            int problema = int.Parse(Console.ReadLine());
            int n = 0;
            int result = 0;
            string s = string.Empty;
            long l = 0;

            Console.WriteLine("==============================");
            switch (problema)
            {
                case 1:
                    Console.WriteLine("Counting Valleys");
                    n = Convert.ToInt32(Console.ReadLine());
                    s = Console.ReadLine();
                    result = countingValleys(n, s);
                    Console.WriteLine(result);
                    break;

                case 2:
                    Console.WriteLine("Jumping Clouds");
                    n = Convert.ToInt32(Console.ReadLine());
                    int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
                    result = jumpingOnClouds(c);
                    Console.WriteLine(result);
                    break;

                case 3:
                    Console.WriteLine("Repeated String");
                    s = Console.ReadLine();
                    l = Convert.ToInt64(Console.ReadLine());
                    long longResult = repeatedString(s, l);
                    Console.WriteLine(longResult);
                    break;

                case 0:
                    break;

                default:
                    break;
            }

            
        }
        static long repeatedString(string s, long n)
        {
            Int64 stringLength = s.Length;
            var letters = s.ToCharArray();
            string substr = string.Empty;
            int arrayWithAs = letters.Where(x => x == 'a').Count();
            
            if (arrayWithAs == stringLength)
            {
                return n;
            }
            else
            {
                if (stringLength >= n)
                {
                    substr = s.Substring(0, Convert.ToInt32(n));
                    letters = substr.ToCharArray();
                    arrayWithAs = letters.Where(x => x == 'a').Count();
                    return arrayWithAs;

                }
                else
                {
                    Int64 factorLetters = (Convert.ToInt64(n) / stringLength);
                    Int64 missingLetters = n - (factorLetters * stringLength);
                    string missingString = s.Substring(0, Convert.ToInt32(missingLetters));
                    Int64 charsToComplete = missingString.Where(x => x == 'a').Count();

                    arrayWithAs = letters.Where(x => x == 'a').Count();
                    Int64 returnVal = (arrayWithAs * factorLetters) + charsToComplete;
                    return returnVal;
                }
            }
        }

        static int jumpingOnClouds(int[] c)
        {
            int steps = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (i + 2 < c.Length)
                {
                    if (c[i + 2] == 0)
                    {
                        i++;
                        steps++;
                        continue;
                    }
                }

                if (i + 1 < c.Length)
                {
                    if (c[i + 1] == 0)
                    {
                        steps++;
                        continue;
                    }
                }
            }
            return steps;
        }

        static int countingValleys(int n, string s)
        {

            int count = 0;
            char[] steps = s.ToCharArray();
            int level = 0;
            bool downcount = false;

            foreach (char c in steps)
            {
                if (c == 'D')
                {
                    if (level == 0)
                    {
                        downcount = true;
                    }
                    level--;
                }
                else
                {
                    if (level == 0)
                    {
                        downcount = false;
                    }
                    level++;
                }

                if (level == 0 && downcount)
                {
                    count++;
                }

            }
            return count;

        }
    }
}
