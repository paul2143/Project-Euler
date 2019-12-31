using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace Practice
{
    /**
     * Class will contain Functionality that can be reused for later segments
     */
    public class CommonUtility
    {
        public static bool[] SieveOfEratosthenes(int n)
        {
            bool[] prime = new bool[n + 1];
            prime[0] = false;
            prime[1] = false;
            for(int i = 2; i < n; i++)
            {
                prime[i] = true;
            }
            for(int p = 2; p*p <= n; p++)
            {
                if(prime[p] == true)
                {
                    for(int i = p*p; i <= n; i += p)
                    {
                        prime[i] = false;
                    }
                }
            }
            return prime;
        }
        /**
         * This method was inspired by this post http://mathforum.org/library/drmath/view/57162.html
         * Considering originally I was brute forcing this is a lot faster!
         */
        public static bool IsTriangular(int n)
        {

            double squareRoot = Math.Sqrt(1 + (8 * n));
            if(squareRoot - Math.Floor(squareRoot) == 0)
            {
                return squareRoot % 2 == 1;
            } else
            {
                return false;
            }
        }
        /**
         * Check if a number is prime
         */
        public static bool isPrime(long n)
        {
            if (n == 2 || n == 3 || n == 5)
            {
                return true;
            }
            if (n <= 1 || n % 2 == 0)
            {
                return false;
            }
            int boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;

        }
        /**
         * Check if a number is a palindrome
         */
        public static bool PalindromeNumber(int n)
        {
            int temp = n;
            int rev = 0;
            while (temp / 1 != 0)
            {
                rev = rev * 10 + temp % 10;
                temp /= 10;
            }
            return rev == n;

        }
        /**
         * Sum all of the values in a list
         */
        public static int sumList(List<int> numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Count(); i++)
            {
                total += numbers[i];
            }
            return total;
        }
        /**
         * Get the list of divisors for a given int n
         */
        public static List<int> divisors(int n)
        {
            List<int> divisorList = new List<int>();
            int i = 1;
            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    divisorList.Add(i);
                    if (i != 1) divisorList.Add(n / i);
                }
                i++;
            }
            return divisorList;

        }
    }
    /**
     * Solutions to the exercises
     */
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public class Problem1
        {
            public static int SumOfMultiplesOfXAndYUpToMFormula(int x, int y, int m)
            {
                m -= 1;
                float n1 = m / x;
                float n2 = m / y;
                float n3 = m / (x * y);
                float an1 = x * n1;
                float an2 = y * n2;
                float an3 = (x * y) * n3;
                float sum1 = n1 / 2 * (x + an1);
                float sum2 = n2 / 2 * (y + an2);
                float sum3 = n3 / 2 * (x * y + an3);
                float total = sum1 + sum2 - sum3;
                return (int)total;

            }
            public static int SumOfMultiplesOfXAndYUpToMLoop(int x, int y, int m)
            {
                int total = 0;
                for (int i = 0; i < m; i++)
                {
                    int n1 = i % x;
                    int n2 = i % y;
                    if (n1 == 0 || n2 == 0)
                    {
                        total += i;
                    }
                    else if (n1 > 2 && n2 > 2)
                    {
                        i += ((n1 < n2) ? (n1 - 1) : (n2 - 1));
                    }
                }
                return total;
            }
        }
        public class Problem2
        {
            public static int SumOfEvenFibLoop()
            {
                int total = 0;
                int n1 = 1;
                int n = 2;
                while (n < 4000000)
                {
                    if (n % 2 == 0)
                    {
                        total += n;
                    }
                    n += n1;
                    n1 = n - n1;
                }
                return total;
            }
            public static int SumOfEvenFibOptimized()
            {

                int total = 10;
                int n = 8;
                int n1 = 2;
                while ((n * 4) + n1 < 4000000)
                {
                    int temp = n;
                    n = (n * 4) + n1;
                    total += n;
                    n1 = temp;
                }
                return total;

            }
        }
        public class Problem3
        {
            public static long LargestPrimeFactorBrute(long n)
            {

                var factorList = new List<long>();
                long i = 1;
                while (i * i <= n)
                {
                    if (n % i == 0)
                    {
                        if (CommonUtility.isPrime(i))
                        {
                            factorList.Clear();
                            factorList.Add(i);
                        }
                    }
                    i++;

                }
                return factorList[0];

            }

        }

        public class Problem4
        {


            public static string largestPalindrome()
            {
                int max = 0;
                int num1 = 0;
                int num2 = 0;
                for (int j = 999; j > 900; j--)
                {
                    for (int k = 999; k > 900; k--)
                    {
                        if (CommonUtility.PalindromeNumber(j * k) && j * k > max)
                        {
                            max = j * k;
                            num1 = j;
                            num2 = k;
                        }
                    }
                }
                return num1 + " " + num2 + " " + (num1 * num2);
            }
        }

        public class Problem5
        {
            public static int SmallestMultiple(int n)
            {
                float smallestMultiple = 1;
                for (int i = 2; i <= n; i++)
                {
                    smallestMultiple = leastCommonMultiple(i, smallestMultiple);
                }
                return (int)smallestMultiple;
            }

            public static float leastCommonMultiple(float number1, float number2)
            {
                return (number1 * number2) / greatestCommonDenominator(number1, number2);
            }

            public static float greatestCommonDenominator(float number1, float number2)
            {
                while (number2 != 0)
                {
                    float temp = number1;
                    number1 = number2;
                    number2 = temp % number2;
                }
                return number1;
            }
        }

        public class Problem6
        {
            public static double SumofSquares(int n)
            {
                return Math.Pow(n * (n + 1) / 2, 2) - (n * (n + 1) * (2 * n + 1) / 6);
            }
        }

        public class Problem7
        {
            public static int BruteForcePrime(int n)
            {
                int i = 3;
                while (n >= 0)
                {
                    if (CommonUtility.isPrime(i))
                        n--;
                    if (n == 1)
                    {
                        return i;
                    }
                    i += 2;
                }
                return 0;
            }
        }
        public class Problem8
        {
            public static long HighestValueInString(int n)
            {
                string test = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
                char[] list = test.ToCharArray();
                long max = 0;
                for (int i = n; i < test.Length; i++)
                {
                    long newMax = 1;
                    for (int j = 0; j < n; j++)
                    {
                        newMax *= Int64.Parse(list[i - j].ToString());
                    }
                    if (max < newMax)
                    {
                        max = newMax;
                    }
                }
                return max;
            }
        }

        public class Problem9
        {
            public static long PythagTripleProd()
            {
                for (int i = 1; i <= 500; i++)
                {
                    if (1000 * (500 - i) % (1000 - i) == 0)
                    {
                        return i * (1000 * (500 - i) / (1000 - i)) * (1000 - i - (1000 * (500 - i) / (1000 - i)));
                    }
                }
                return 0;

            }
        }

        public class Problem10
        {
            public static long SumOfPrimesBelowN(int n)
            {
                long total = 0;
                if (n <= 10)
                {
                    if (n < 1)
                    {
                        return 0;
                    }
                    else if (n == 2)
                    {
                        return 2;
                    }
                    else if (n == 3)
                    {
                        return 5;
                    }
                    else if (n <= 6)
                    {
                        return 10;
                    }
                    else
                    {
                        return 17;
                    }
                }
                else
                {
                    total += 17;
                }
                for (int i = 12; i < n; i += 6)
                {
                    if (CommonUtility.isPrime(i - 1))
                    {
                        total += i - 1;
                    }
                    if (CommonUtility.isPrime(i + 1))
                    {
                        total += i + 1;
                    }
                }
                return total;
            }
        }

        public class Problem11
        {
            public static long ProductOfFour()
            {
                int[,] grid = new int[20, 20];
                long max = 0;
                using (StreamReader sr = File.OpenText("test.txt"))
                {
                    string s;
                    int lineCount = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var parts = s.Split(' ');
                        for (int j = 0; j < 20; j++)
                        {
                            grid[lineCount, j] = int.Parse(parts[j]);
                        }
                        lineCount++;
                    }
                }
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        long newMax = 1;
                        //Right
                        if (i < 16)
                        {
                            newMax = grid[i, j] * grid[i + 1, j] * grid[i + 2, j] * grid[i + 3, j];
                            if (newMax > max)
                                max = newMax;
                        }
                        //Down
                        if (j < 16)
                        {
                            newMax = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3];
                            if (newMax > max)
                                max = newMax;
                        }
                        //Right down Diag
                        if (i < 16 && j < 16)
                        {
                            newMax = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3];
                            if (newMax > max)
                                max = newMax;
                        }
                        //Left down Diag
                        if (i > 3 && j < 16)
                        {
                            newMax = grid[i, j] * grid[i - 1, j + 1] * grid[i - 2, j + 2] * grid[i - 3, j + 3];
                            if (newMax > max)
                                max = newMax;
                        }
                        //Right up Diag
                        if (i < 16 && j > 3)
                        {
                            newMax = grid[i, j] * grid[i + 1, j - 1] * grid[i + 2, j - 2] * grid[i + 3, j - 3];
                            if (newMax > max)
                                max = newMax;
                        }
                        //Left up Diag
                        if (i > 3 && j > 3)
                        {
                            newMax = grid[i, j] * grid[i - 1, j - 1] * grid[i - 2, j - 2] * grid[i - 3, j - 3];
                            if (newMax > max)
                                max = newMax;
                        }
                    }
                }
                return max;
            }
        }
        public class Problem12
        {
            public static long TriangleNumberDivisors(int n)
            {
                long start = 1;
                long index = 1;
                while (true)
                {
                    index++;
                    start += index;
                    if (numberFactors(start) >= n)
                    {
                        return start;
                    }
                }
            }
            public static bool isTriangular(int num)
            {
                // Base case 
                if (num < 0)
                    return false;

                // A Triangular number must be 
                // sum of first n natural numbers 
                int sum = 0;

                for (int n = 1; sum <= num; n++)
                {
                    sum = sum + n;
                    if (sum == num)
                        return true;
                }
                return false;
            }
            public static int numberFactors(long n)
            {
                List<long> counts = new List<long>();
                List<long> factors = new List<long>();
                int count = 0;
                factors.Add(2);

                while (!(n % 2 > 0))
                {
                    n /= 2;
                    count++;
                }
                counts.Add(count);
                for (long i = 3; i <= n; i += 2)
                {
                    count = 0;
                    while (n % i == 0)
                    {
                        count++;
                        n /= i;
                    }
                    if (count > 0)
                    {
                        factors.Add(i);
                        counts.Add(count);
                    }
                }
                long total = 1;
                int index = 0;
                foreach (long number in factors)
                {
                    total *= (counts[index] + 1);
                    index++;
                }
                return (int)total;
            }
        }
        public class Problem13
        {
            public static long BottomTenDigits()
            {
                long total = 0;
                string[] numbers = new string[100];
                using (StreamReader sr = new StreamReader("50.100.txt"))
                {
                    string line;
                    int lineCount = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        numbers[lineCount] = line.Substring(40, 10);
                        total += Int64.Parse(numbers[lineCount]);
                        total %= 10000000000;
                        lineCount++;

                    }
                }


                return total;

            }

            public static string TopTenDigits()
            {
                BigInteger total = 0;
                using (StreamReader sr = new StreamReader("50.100.txt"))
                {
                    string line;
                    int lineCount = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        total += BigInteger.Parse(line);
                        lineCount++;

                    }
                }


                return total.ToString().Substring(0, 10);

            }

            public static String sum(String[] values, int numberOfDigits)
            {
                // best to take an overestimate
                int buffer = (int)Math.Ceiling(Math.Log10(values.Length)); // = 2 for 50
                int length = numberOfDigits + buffer;
                long result = 0;
                foreach (String value in values)
                {
                    result += Int64.Parse(value.Substring(0, length));
                }
                return result.ToString();
            }

        }

        public class Problem14
        {
            static Dictionary<long, int> cache = new Dictionary<long, int>();

            public static int longestChainMillion(int final)
            {
                int longest = 0;
                int max = 0;
                for (int i = 2; i < final; i++)
                {
                    int length = LongestCollatzSequence(i);
                    if (length > longest)
                    {
                        longest = length;
                        max = i;
                    }
                }
                return max;
            }

            public static int LongestCollatzSequence(long value)
            {
                if (value == 1) return 1;
                int longest;
                if (cache.TryGetValue(value, out longest)) return longest;
                else
                {
                    if (value % 2 == 0)
                    {
                        cache.Add(value, LongestCollatzSequence(value / 2) + 1);
                        if (cache.TryGetValue(value, out longest)) return longest;
                    }
                    else
                    {
                        cache.Add(value, LongestCollatzSequence(value * 3 + 1) + 1);
                        if (cache.TryGetValue(value, out longest)) return longest;
                    }
                }
                return longest;
            }
        }

        public class Problem15
        {
            public static long latticePaths(int n)
            {
                long[,] grid = new long[n + 1, n + 1];
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (i > 0 && j > 0)
                        {
                            grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
                        }
                        else if (i == 0 && j != 0)
                        {
                            grid[i, j] = 1;
                        }
                        else if (j == 0 && i != 0)
                        {
                            grid[i, j] = 1;
                        }
                    }
                }
                return grid[n, n];
            }
        }

        public class Problem16
        {
            public static long DigitValues(string value)
            {
                long total = 0;
                char[] arr = value.ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {
                    total += Int64.Parse(arr[i].ToString());
                }
                return total;
            }

            public static BigInteger Expo(BigInteger a, BigInteger b)
            {
                BigInteger result = 1;

                while (b > 0)
                {
                    if ((b & 1) != 0)
                    {
                        result *= a;
                    }
                    b >>= 1;
                    a *= a;
                }
                return result;
            }

        }

        public class problem17
        {


            public static int lengthOfWords(int n)
            {
                StringBuilder s = new StringBuilder();
                for (int i = 1; i <= n; i++)
                {
                    s.Append(ConvertToWords.convertToWords(i));
                }
                s.Replace(" ", "");
                s.Replace("-", "");
                return s.Length;

            }
            public static class ConvertToWords
            {
                private static Dictionary<int, string> numberToWord = new Dictionary<int, string>
                {
                    {0, "zero" },
                    {1, "one" },
                    {2, "two" },
                    {3, "three" },
                    {4, "four" },
                    {5, "five" },
                    {6, "six" },
                    {7, "seven" },
                    {8, "eight" },
                    {9, "nine" },
                    {10, "ten" },
                    {11, "eleven" },
                    {12, "twelve" },
                    {13, "thirteen" },
                    {14, "fourteen" },
                    {15, "fifteen" },
                    {16, "sixteen" },
                    {17, "seventeen" },
                    {18, "eighteen" },
                    {19, "nineteen" },
                    {20, "twenty" },
                    {30, "thirty" },
                    {40, "forty" },
                    {50, "fifty" },
                    {60, "sixty" },
                    {70, "seventy" },
                    {80, "eighty" },
                    {90, "ninety" },
                    {100, "hundred" },
                    {1000, "thousand" },
                    {1000000, "million" },
                    {1000000000, "billion" },

                };
                private const int OneThousand = 1000;
                private const int OneMillion = 1000000;
                private const int OneBillion = 1000000000;


                public static string convertToWords(int n)
                {
                    if (n < 0)
                    {
                        return "negative " + convertToWords(Math.Abs(n));
                    }
                    else if (n <= 20)
                    {
                        return numberToWord[n];
                    }
                    else if (n <= 99)
                    {
                        return processTens(n);
                    }
                    else if (n < OneThousand)
                    {
                        return processHundreds(n);
                    }
                    else if (n < OneMillion)
                    {
                        return processOverHundred(n, OneThousand);
                    }
                    else if (n < OneBillion)
                    {
                        return processOverHundred(n, OneMillion);
                    }
                    return "Must be less than One Billion";


                }
                private static string processOverHundred(int n, int bas)
                {
                    int baseU = n / bas;
                    int remainder = n % bas;
                    if (remainder > 0)
                    {
                        return numberToWord[baseU] + "-" + numberToWord[bas] + convertToWords(remainder);
                    }
                    else
                    {
                        return numberToWord[baseU] + "-" + numberToWord[bas];
                    }
                }
                private static string processHundreds(int n)
                {
                    int hundreds = n / 100;
                    int tens = n % 100;
                    if (tens > 0)
                    {
                        return numberToWord[hundreds] + "-" + numberToWord[100] + " and " + convertToWords(tens);
                    }
                    else
                    {
                        return numberToWord[hundreds] + "-" + numberToWord[100];
                    }
                }
                private static string processTens(int n)
                {
                    int tens = n / 10;
                    int ones = n % 10;
                    if (ones > 0)
                    {
                        return numberToWord[tens * 10] + "-" + numberToWord[ones];
                    }
                    else
                    {
                        return numberToWord[tens * 10];
                    }
                }

            }
        }

        public class Problem19
        {
            public static int numberOfSundaysOnFirst()
            {
                int total = 0;
                for (int i = 1901; i <= 2000; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        if ((new DateTime(i, j, 1).DayOfWeek) == DayOfWeek.Sunday) total++;
                    }
                }
                return total;
            }
        }

        public class Problem20
        {
            public static int factorialSum(int n)
            {
                BigInteger total = n;
                while (n > 1)
                {
                    n--;
                    total *= n;
                }

                return (int)Problem16.DigitValues(total.ToString());
            }
        }

        public class Problem21
        {
            public static int sumOfAmicableNumbers(int n)
            {
                int total = 0;
                for (int i = 1; i < n; i++)
                {
                    if (checkAmicable(i)) total += i;
                }
                return total;
            }
            public static bool checkAmicable(int n)
            {
                int temp = CommonUtility.sumList(CommonUtility.divisors(n));
                return CommonUtility.sumList(CommonUtility.divisors(temp)) == n && (temp != n);
            }



        }



        public class Problem18And67
        {
            public static int maxPathSum(string inputFile)
            {
                List<List<int>> grid = new List<List<int>>();
                //read the input values in
                using (StreamReader sr = File.OpenText(inputFile))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        List<int> row = new List<int>();
                        var parts = s.Split(' ');
                        for (int j = 0; j < parts.Length; j++)
                        {
                            row.Add(int.Parse(parts[j]));
                        }
                        grid.Add(row);
                    }
                }
                int absolute = 0;
                for (int i = 1; i < grid.Count(); i++)
                {
                    for (int j = 0; j < grid[i].Count(); j++)
                    {
                        int max = 0;
                        if (j == 0)
                        {
                            //Check the left
                            if (grid[i - 1][j] > max)
                            {
                                max = grid[i - 1][j];
                            }
                        }
                        else if (j == grid[i].Count() - 1)
                        {
                            //check the right
                            if (grid[i - 1][j - 1] > max)
                            {
                                max = grid[i - 1][j - 1];
                            }
                        }
                        else
                        {
                            //Check the left
                            if (grid[i - 1][j - 1] > max)
                            {
                                max = grid[i - 1][j - 1];
                            }
                            //check the right
                            if (grid[i - 1][j] > max)
                            {
                                max = grid[i - 1][j];
                            }
                        }
                        grid[i][j] += max;
                        if (grid[i][j] > absolute)
                        {
                            absolute = grid[i][j];
                        }
                    }

                }
                return absolute;
            }

        }

        public class Problem22
        {
            public static long SumOfAllNames()
            {
                string[] names = ReadInput("p022_names.txt");
                int position = 1;
                long total = 0;
                foreach (string name in names)
                {
                    total += sumOfName(position, name);
                    position++;
                }
                return total;
            }

            public static string[] ReadInput(string filename)
            {
                string input;
                string[] names;
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    input = sr.ReadToEnd();
                }
                names = input.Split(',');
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = names[i].Trim('"');
                }
                Array.Sort(names, comparer: StringComparer.InvariantCulture);
                return names;
            }
            public static int sumOfName(int position, string name)
            {
                int total = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    total += Convert.ToInt32(name[i] - 64);
                }
                return total * position;
            }
        }

        public class Problem23
        {
            public static long SumOfNumbersNotSumOfAbundant()
            {
                const int limit = 20162;
                List<int> abundant = FindAbundant(limit - 1);
                List<int> evenAbundant = new List<int>();
                List<int> oddAbundant = new List<int>();
                int[] numbers = new int[] { 24, 30, 32, 36, 38, 40, 42, 44, 48 };
                foreach (int number in abundant)
                {
                    if (number % 2 == 0)
                    {
                        evenAbundant.Add(number);
                    }
                    else
                    {
                        oddAbundant.Add(number);
                    }
                }
                abundant.Clear();
                int[] abundant_filter = new int[limit];
                for (int i = 0; i < limit; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (i > 48)
                        {
                            abundant_filter[i] = 1;
                        }
                        else if (numbers.Contains(i))
                        {
                            abundant_filter[i] = 1;
                        }

                    }
                }
                for (int i = 0; i < evenAbundant.Count(); i++)
                {
                    for (int j = 0; j < oddAbundant.Count(); j++)
                    {
                        int current = evenAbundant[i] + oddAbundant[j];
                        if (current < limit)
                        {
                            abundant_filter[current] = 1;
                        }
                    }
                }
                List<int> abundantSums = new List<int>();
                for (int i = 1; i < limit; i++)
                {
                    if (abundant_filter[i] == 1)
                    {
                        abundantSums.Add(i);
                    }
                }
                int sum = 20161 * (20162) / 2;

                return sum - CommonUtility.sumList(abundantSums);
            }
            public static List<int> FindAbundant(int limit)
            {
                List<int> abundant = new List<int>();
                for (int i = 1; i <= limit; i++)
                {
                    if (i % 2 != 0 && i % 3 != 0)
                    {
                        continue;
                    }
                    if (IsAbundant(i))
                    {
                        abundant.Add(i);
                    }
                }
                return abundant;
            }
            public static bool IsAbundant(int n)
            {
                int sum = 0;
                for (int i = 1; i < n; i++)
                    if (n % i == 0)
                        sum += i;
                if (sum > n)
                    return true;
                return false;
            }


        }

        public class Problem24
        {
            public static int Factor(int number)
            {
                if (number == 1 || number == 0)
                {
                    return 1;
                }
                int result = 1;
                while (number != 1)
                {
                    result *= number;
                    number--;
                }
                return result;

            }
            public static string Permutations()
            {
                int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int digitsCount = digits.Length;
                int count = digitsCount;
                string number = "";
                int combonationsRemaining = 1000000 - 1;
                List<int> numbers = Enumerable.Range(0, 10).ToList();
                for (int i = 0; i < digitsCount; i++)
                {
                    int j = combonationsRemaining / Factor(count - 1);
                    combonationsRemaining %= Factor(count - 1);
                    count--;
                    number += numbers[j];
                    numbers.RemoveAt(j);
                }
                return number;
            }

        }

        public class Problem25
        {
            //This is also easy to solve by hand
            public static int IndexOf1000DigitFib()
            {
                int count = 2;
                BigInteger limit = BigInteger.Pow(10, 999);
                BigInteger n = new BigInteger(1);
                BigInteger n1 = new BigInteger(1);
                while (n < limit)
                {
                    n += n1;
                    n1 = n - n1;
                    count++;

                }
                return count;
            }

        }

        public class Problem26
        {
            public static int ValueWithLongestRecurringCycle()
            {
                int max = 0;
                for (int i = 1000; i > 900; i--)
                {
                    if (CommonUtility.isPrime(i))
                    {
                        if (CheckCycleLength(i) > max)
                        {
                            max = CheckCycleLength(i);
                        }
                    }
                }
                return max + 1;
            }

            public static int CheckCycleLength(int n)
            {
                int divisor = 1;
                int count = 0;
                do
                {
                    divisor = divisor * 10 % n;
                    count++;
                } while (divisor != 1);
                return count;
            }
        }
        public class Problem27
        {
            public static int QuadraticPrimes()
            {
                bool[] primes = Problem357.Primes(100000);
                int aMax = 0, bMax = 0, nMax = 0;
                for (int a = -1000; a <= 1000; a++)
                {
                    for (int b = -1000; b <= 1000; b++)
                    {
                        int n = 0;
                        while (primes[Math.Abs(n * n + a * n + b)])
                        {
                            n++;
                        }
                        if (n > nMax)
                        {
                            aMax = a;
                            bMax = b;
                            nMax = n;
                        }
                    }
                }
                return aMax * bMax;

            }
        }

        public class Problem28
        {
            public static long NumberSpiralDiagonals(int number)
            {
                long total = 1;
                for (int i = 3; i <= number; i += 2)
                {
                    total += 4 * i * i - 6 * i + 6;

                }
                return total;
            }
        }
        public class Problem29
        {
            public static int DistinctPowers(int limit)
            {
                HashSet<double> distinct = new HashSet<double>();
                for (int i = 2; i <= limit; i++)
                {
                    for (int j = 2; j <= limit; j++)
                    {
                        distinct.Add(Math.Pow(i, j));
                    }
                }
                return distinct.Count();
            }
        }
        public class Problem30
        {
            public static int FifthPowers()
            {
                int sum = 0;
                int[] fifthPowers = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    fifthPowers[i] = (int)Math.Pow(i, 5);
                }
                //6 digits all a value of 9 6*9^5 = 354294
                for (int i = 10; i <= 354294; i++)
                {
                    int sumOfFifthPowers = 0;
                    int n = i;
                    while (n > 0)
                    {
                        int digit = n % 10;
                        n /= 10;
                        sumOfFifthPowers += fifthPowers[digit];
                    }
                    if (sumOfFifthPowers == i)
                    {
                        sum += i;
                    }

                }


                return sum;
            }
        }
        public class Problem31
        {
            public static int CoinSums()
            {
                int target = 200;
                const int numberCoins = 8;
                int[] coinSizes = { 1, 2, 5, 10, 20, 50, 100, 200 };
                int[,] table = new int[target + 1, numberCoins];
                for (int i = 0; i <= target; i++)
                {
                    table[i, 0] = 1;
                }
                for (int i = 0; i <= target; i++)
                {
                    for (int j = 1; j < numberCoins; j++)
                    {
                        table[i, j] = table[i, j - 1];
                        if (coinSizes[j] <= i)
                        {
                            table[i, j] += table[i - coinSizes[j], j];
                        }
                    }
                }
                return table[target, numberCoins - 1];
            }
        }
        public class Problem32
        {
            public static bool IsPandigital(string s)
            {
                if (s.Length != 9)
                {
                    return false;
                }
                return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5") && s.Contains("6") && s.Contains("7") && s.Contains("8") && s.Contains("9");


            }
            public static int PandigitalSums()
            {
                HashSet<int> products = new HashSet<int>();
                for (int i = 1; i <= 9; i++)
                {
                    for (int j = 1234; j <= 9876; j++)
                    {
                        int x = i * j;
                        string digits = "" + x + i + j;
                        if (IsPandigital(digits)) products.Add(x);
                    }
                }
                for (int i = 12; i <= 98; i++)
                {
                    for (int j = 123; j <= 987; j++)
                    {
                        int x = i * j;
                        string digits = "" + x + i + j;
                        if (IsPandigital(digits)) products.Add(x);
                    }
                }
                int total = 0;
                foreach (int product in products)
                {
                    total += product;
                }
                return total;
            }
        }
        public class Problem33
        {
            public static int DigitCancelFractions()
            {
                int denom = 0;
                return denom;
            }
        }
        public class Problem34
        {
            public static int DigitFactorials()
            {
                int[] digitFactorial = new int[10];
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    digitFactorial[i] = Problem24.Factor(i);
                }
                for (int i = 10; i <= 2540161; i++)
                {
                    int sumOfFactorial = 0;
                    int n = i;
                    while (n > 0)
                    {
                        int d = n % 10;
                        n /= 10;
                        sumOfFactorial += digitFactorial[d];
                    }
                    if (sumOfFactorial == i) sum += i;
                }
                return sum;
            }
        }
        public class Problem35
        {
            public static int CircularPrimesUnderN(int n)
            {
                //Get a list of all primes up to N
                bool[] prime = CommonUtility.SieveOfEratosthenes(n);
                List<int> circularPrimess = new List<int>();
                HashSet<int> primes = new HashSet<int>();
                int count = 0;
                //Generate a set of all primes
                for (int i = 0; i < n; i++)
                {
                    if (prime[i])
                    {
                        primes.Add(i);
                    }
                }
                //Loop through each number in primes
                foreach (int number in primes.ToList())
                {
                    int len = number.ToString().Length;
                    int i = 0;
                    bool circularPrime = true;
                    List<int> circularPrimes = new List<int>();
                    //Cannot assign to an the variable being iterated
                    int temp = number;
                    //Loop through each digit if each is a prime, or stop
                    while (i < len && circularPrime)
                    {
                        int digit = temp % 10;
                        temp /= 10;
                        temp = temp + digit * (int)Math.Pow(10, len - 1);
                        if (primes.Contains(temp))
                        {
                            if(!circularPrimes.Contains(temp))
                            {
                                circularPrimes.Add(temp);
                            }
                            
                        }
                        else
                        {
                            circularPrime = false;
                            foreach (int value in circularPrimes)
                            {
                                primes.Remove(value);
                            }
                        }
                        i++;
                    }

                    if (circularPrime)
                    {
                        count += circularPrimes.Count();
                        circularPrimess.AddRange(circularPrimes);
                        foreach (int value in circularPrimes)
                        {
                            primes.Remove(value);
                        }
                    }
                }
                return count;

            }

        }

        public class Problem36
        {
            public static bool isPalindrome(int n, int base1)
            {
                int reversed = 0;
                int temp = n;
                while (temp > 0)
                {
                    reversed = reversed * base1 + temp % base1;
                    temp /= base1;
                }
                return reversed == n;
            }


            public static int DoubleBasePalindromes()
            {
                int total = 0;
                for (int i = 1; i < 1000000; i++)
                {
                    if (isPalindrome(i, 10) && isPalindrome(i, 2))
                        total += i;
                }
                return total;
            }
        }


        public class Problem37
        {
            public static int TruncatablePrimes()
            {
                int sum = 0;


                return sum;
            }
        }

        public class Problem38
        {
            public static long PandigitMultiple()
            {
                long max = 0;
                for (int i = 9387; i >= 9234; i--)
                {
                    max = 100002 * i;
                    if (Problem32.IsPandigital(max.ToString())) return max;
                }
                return 0;
            }
        }

        public class Problem39
        {

        }

        public class Problem40
        {
            public static int Champ()
            {
                int value = 1;
                List<int> digits = new List<int>();
                int Integers = 1;
                while (digits.Count < 1000001)
                {
                    string number = Integers.ToString();
                    for(int i = 0; i < number.Length; i++)
                    {
                        
                        //digits.Add(Int32.Parse(number[i].ToString()));
                        //This second attempt is much faster
                        digits.Add((int)(Char.GetNumericValue(number[i])));
                    }
                    Integers++;
                }
                for(int i = 1; i <= 1000000; i *= 10)
                {
                    value *= digits[i - 1];
                }
                return value;
            }
        }
        public class Problem41
        {
            public static int PandigitalPrime()
            {
                for (int i = 7654321; i > 1000000; i--)
                {
                    if (IsPandigital(i.ToString()) && CommonUtility.isPrime(i))
                    {
                        return i;
                    }
                }
                return 0;
            }

            public static bool IsPandigital(string s)
            {
                if (s.Length == 9)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5") && s.Contains("6") && s.Contains("7") && s.Contains("8") && s.Contains("9");
                }
                else if (s.Length == 8)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5") && s.Contains("6") && s.Contains("7") && s.Contains("8");

                }
                else if (s.Length == 7)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5") && s.Contains("6") && s.Contains("7");
                }
                else if (s.Length == 6)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5") && s.Contains("6");
                }
                else if (s.Length == 5)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4") && s.Contains("5");
                }
                else if (s.Length == 4)
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3") && s.Contains("4");
                }
                else
                {
                    return s.Contains("1") && s.Contains("2") && s.Contains("3");
                }



            }
        }
        public class Problem42
        {
            public static int CodedTriangleNumbers(string inputFile)
            {
                int TriangleWords = 0;
                HashSet<int> TriangleNumbers = new HashSet<int>();
                Dictionary<char, int> LetterValue = new Dictionary<char, int>();
                for (int i = 1; i < 27; i++)
                {
                    char key = (char)(i + 64);
                    LetterValue.Add(key, i);
                }
                using (StreamReader sr = File.OpenText(inputFile))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var parts = s.Split(',');
                        foreach (string word in parts)
                        {
                            int count = 0;
                            string temp = word.Trim('"');
                            foreach (char c in temp.ToCharArray())
                            {
                                count += LetterValue[c];
                            }
                            if (CommonUtility.IsTriangular(count))
                            {
                                TriangleWords++;
                            }
                        }
                    }
                }
                return TriangleWords;
            }
        }
        public class Problem44
        {
            public static int PentagonNumbersDiff()
            {
                int diff = 0;
                int i = 1;
                while (true)
                {
                    i++;
                    //Generate the first pentagonal number
                    int numb = i * (3 * i - 1) / 2;
                    //loop through all prior pentagonal numbers
                    for (int j = i - 1; j > 0; j--)
                    {
                        //generate the previous pentagonal number
                        int numb2 = j * (3 * j - 1) / 2;
                        //check sum and difference pentagonal
                        if (Problem45.IsPentagonal(numb + numb2) && Problem45.IsPentagonal(numb - numb2))
                        {
                            diff = numb - numb2;
                            //return result
                            return diff;
                        }
                    }
                }
            }
        }
        public class Problem45
        {
            public static bool IsPentagonal(long n)
            {
                double number = (1 + Math.Sqrt(24 * n + 1)) / 6;
                return (number - (int)number) == 0;
            }
            public static long TriPentHex()
            {
                long result = 0;
                int index = 143;
                while (true)
                {
                    index++;
                    result = index * (2 * index - 1);
                    if (IsPentagonal(result)) return result;
                }

            }
        }
        public class Problem48
        {
            public static ulong modPow(ulong b, ulong exponent, ulong mod)
            {
                ulong result = 1;
                b %= mod;
                while (exponent > 0)
                {
                    if ((exponent & 1) == 1)
                    {
                        result = (result * b) % mod;
                    }
                    exponent = exponent >> 1;
                    b = (b * b) % mod;
                }
                return result % mod;
            }
            public static ulong SelfPowersBigInt(ulong n, ulong mod)
            {
                ulong sum = 0;
                for (BigInteger i = 1; i <= n; i++)
                {
                    sum += (ulong)BigInteger.ModPow(i, i, mod);
                }
                return sum % mod;
            }
        }
        public class Problem49
        {

            public static int FourDigitPrimePermutation()
            {
                int count = 0;
                bool[] primes = CommonUtility.SieveOfEratosthenes(10000);
                HashSet<int> FourDigitPrimes = new HashSet<int>();
                for(int i = 1000; i < 10000; i++)
                {
                    if (primes[i])
                    {
                        FourDigitPrimes.Add(i);
                    }
                }
                List<int> FinalPermutations = new List<int>();
                foreach(int number in FourDigitPrimes.ToList())
                {
                    List<int> Permutations = new List<int>();
                    int temp = number;
                    for (int i = 0; i < 3; i++)
                    {
                        int digit = number % 10;
                        temp = temp /= 10;
                    }
                }
                return count;
            } 
        }
        public class Problem76
        {
            public static int Summations()
            {
                int target = 100;
                const int numbers = 99;
                int[] coinSizes = Enumerable.Range(1, 99).ToArray();
                int[,] table = new int[target + 1, numbers];
                for (int i = 0; i <= target; i++)
                {
                    table[i, 0] = 1;
                }
                for (int i = 0; i <= target; i++)
                {
                    for (int j = 1; j < numbers; j++)
                    {
                        table[i, j] = table[i, j - 1];
                        if (coinSizes[j] <= i)
                        {
                            table[i, j] += table[i - coinSizes[j], j];
                        }
                    }
                }
                return table[target, numbers - 1];
            }
        }
        public class Problem357
        {
            public static bool test(int n, bool[] isPrime)
            {
                for (int i = 1; i <= (int)Math.Sqrt(n); i++)
                    if (n % i == 0 && !isPrime[i + n / i])
                        return false;
                return true;
            }
            public static bool[] Primes(int n)
            {
                bool[] Primes = new bool[n + 1];
                for (int i = 3; i <= n; i += 2)
                    Primes[i] = true;
                for (int i = 2; i <= n; i++)
                {
                    if (Primes[i])
                    {
                        for (int j = i * 2; j <= n; j += i)
                            Primes[j] = false;
                    }
                }
                return Primes;
            }

            public static long PrimeGeneratingIntegers()
            {
                long total = 0;
                int max = 100000000;
                bool[] isPrime = Primes(max + 1);
                for (int i = 0; i <= max; i++)
                {
                    if (isPrime[i + 1] && test(i, isPrime))
                    {
                        total += i;
                    }
                }

                return total + 1;
            }
        }
        public class Problem206
        {
            public static bool match(BigInteger number)
            {
                List<int> form = new List<int>();
                form.Add(0);
                //Add backwards such that we can compare starting at the least significant digit
                for (int i = 9; i > 0; i--)
                {
                    form.Add(i);
                }
                number *= number;
                for(int i = 0; i < 10; i++)
                {
                    if(number % 10 != form[i])
                    {
                        return false;
                    }
                    //Skip the digit you are on and the next one
                    number /= 100;
                }
                return true;

            }
            public static long ConcealedSquare()
            {
                //Square root 1020304050607080900
                long minimum = 1010101010;
                //Square root 1929394959697989990
                long maximum = 1389026623;
                for( long i = minimum; i <= maximum; i++)
                {
                    if (match(i))
                    {
                        return i;
                    }
                }
                return 0;
            }
        }
        public class Problem668
        {
            public static long LPrimeFactor(long n)
            {
                List<long> result = new List<long>();
                while (n % 2 == 0)
                {
                    result.Add(2);
                    n /= 2;
                }
                long factor = 3;
                while (factor * factor <= n)
                {
                    if (n % factor == 0)
                    {
                        result.Add(factor);
                        n /= factor;
                    }
                    else
                    {
                        factor += 2;
                    }
                }
                if (n > 1) result.Add(n);
                return result[result.Count - 1];
            }
            public static long SquareRootSmooth(long n)
            {
                long total = 2;
                for (long i = 3; i < n; i++)
                {
                    long factor = LPrimeFactor(i);
                    if (factor < Math.Sqrt(i)) total++;
                }
                return total;
            }

        }


    }
}

