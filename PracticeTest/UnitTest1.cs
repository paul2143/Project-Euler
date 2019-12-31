using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace PracticeTest
{
    [TestClass]
    public class TestSieve
    {
        [TestMethod]
        public void testSieve()
        {
            bool[] prime = Practice.CommonUtility.SieveOfEratosthenes(100);
            Xunit.Assert.Equal(true, prime[2]);
            Xunit.Assert.Equal(true, prime[3]);
            Xunit.Assert.Equal(true, prime[5]);
            Xunit.Assert.Equal(true, prime[7]);
            Xunit.Assert.Equal(true, prime[11]);
            Xunit.Assert.Equal(true, prime[13]);
            Xunit.Assert.Equal(true, prime[17]);
            Xunit.Assert.Equal(true, prime[19]);
            Xunit.Assert.Equal(true, prime[23]);
            Xunit.Assert.Equal(true, prime[29]);
            Xunit.Assert.Equal(true, prime[31]);
            Xunit.Assert.Equal(true, prime[37]);
            Xunit.Assert.Equal(true, prime[41]);
            Xunit.Assert.Equal(true, prime[47]);
            Xunit.Assert.Equal(true, prime[53]);
            Xunit.Assert.Equal(true, prime[59]);
            Xunit.Assert.Equal(true, prime[61]);
            Xunit.Assert.Equal(true, prime[67]);
            Xunit.Assert.Equal(true, prime[71]);
            Xunit.Assert.Equal(true, prime[73]);
            Xunit.Assert.Equal(true, prime[79]);
            Xunit.Assert.Equal(true, prime[83]);
            Xunit.Assert.Equal(true, prime[89]);
            Xunit.Assert.Equal(true, prime[97]);
            Xunit.Assert.Equal(false, prime[21]);
        }
    }
    [TestClass]
    public class TestIsTriangular
    {
        [TestMethod]
        public void testTriangular()
        {
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(2));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(4));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(5));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(7));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(8));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(9));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(14));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(11));
            Xunit.Assert.False(Practice.CommonUtility.IsTriangular(54));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(1));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(3));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(6));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(10));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(15));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(21));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(28));
            Xunit.Assert.True(Practice.CommonUtility.IsTriangular(36));
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1Loop()
        {
            Xunit.Assert.Equal(23, Practice.Program.Problem1.SumOfMultiplesOfXAndYUpToMLoop(3, 5, 10));
            Xunit.Assert.Equal(233168, Practice.Program.Problem1.SumOfMultiplesOfXAndYUpToMLoop(3, 5, 1000));
        }
        [TestMethod]
        public void TestMethod1Formula()
        {
            Xunit.Assert.Equal(23, Practice.Program.Problem1.SumOfMultiplesOfXAndYUpToMFormula(3, 5, 10));
            Xunit.Assert.Equal(233168, Practice.Program.Problem1.SumOfMultiplesOfXAndYUpToMFormula(3, 5, 1000));
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2Loop()
        {
            Xunit.Assert.Equal(4613732, Practice.Program.Problem2.SumOfEvenFibLoop());
        }
        [TestMethod]
        public void TestMethodOptimized()
        {
            Xunit.Assert.Equal(4613732, Practice.Program.Problem2.SumOfEvenFibOptimized());
        }
    }

    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod3Brute()
        {
            Xunit.Assert.Equal(29, Practice.Program.Problem3.LargestPrimeFactorBrute(13195));
            Xunit.Assert.Equal(6857, Practice.Program.Problem3.LargestPrimeFactorBrute(600851475143));
        }
        [TestMethod]
        public void testIsPrime()
        {
            Xunit.Assert.False(Practice.CommonUtility.isPrime(35));
        }
    }

    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void testLargestPalin()
        {
            Xunit.Assert.True(Practice.CommonUtility.PalindromeNumber(9009));
            Xunit.Assert.Equal("993 913 906609", Practice.Program.Problem4.largestPalindrome());
        }
    }
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void testSmallestMultiple()
        {
            Xunit.Assert.Equal(2520, Practice.Program.Problem5.SmallestMultiple(10));
            Xunit.Assert.Equal(232792560, Practice.Program.Problem5.SmallestMultiple(20));
        }
        [TestMethod]
        public void leastCommonMultiple()
        {
            Xunit.Assert.Equal(2520, Practice.Program.Problem5.leastCommonMultiple(140, 72));
        }
        [TestMethod]
        public void greatestCommonDenominator()
        {
            Xunit.Assert.Equal(4, Practice.Program.Problem5.greatestCommonDenominator(140, 72));
        }
    }
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void SumofSquaresDiff()
        {
            Xunit.Assert.Equal(2640, Practice.Program.Problem6.SumofSquares(10));
            Xunit.Assert.Equal(25164150, Practice.Program.Problem6.SumofSquares(100));
        }
    }
    [TestClass]
    public class UnitTest7
    {
        [TestMethod]
        public void BruteForcePrime()
        {
            Xunit.Assert.Equal(13, Practice.Program.Problem7.BruteForcePrime(6));
            Xunit.Assert.Equal(104743, Practice.Program.Problem7.BruteForcePrime(10001));

        }
    }
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void LargestProductInSeries()
        {
            Xunit.Assert.Equal(5832, Practice.Program.Problem8.HighestValueInString(4));
            Xunit.Assert.Equal(23514624000, Practice.Program.Problem8.HighestValueInString(13));
        }
    }
    [TestClass]
    public class UnitTest9
    {
        [TestMethod]
        public void testPythag()
        {
            Xunit.Assert.Equal(31875000, Practice.Program.Problem9.PythagTripleProd());
        }
    }

    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void testPrime2Mill()
        {
            Xunit.Assert.Equal(17, Practice.Program.Problem10.SumOfPrimesBelowN(10));
            Xunit.Assert.Equal(1060, Practice.Program.Problem10.SumOfPrimesBelowN(100));
            Xunit.Assert.Equal(142913828922, Practice.Program.Problem10.SumOfPrimesBelowN(2000000));
        }
    }

    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void testAllGrid()
        {
            Xunit.Assert.Equal(70600674, Practice.Program.Problem11.ProductOfFour());
        }
    }
    [TestClass]
    public class UnitTest12
    {
        [TestMethod]
        public void testTriangle()
        {
            Xunit.Assert.True(Practice.Program.Problem12.isTriangular(55));
        }
        [TestMethod]
        public void testFactors()
        {
            Xunit.Assert.Equal(6, Practice.Program.Problem12.numberFactors(28));
            Xunit.Assert.Equal(9, Practice.Program.Problem12.numberFactors(196));
            Xunit.Assert.Equal(12, Practice.Program.Problem12.numberFactors(108));
        }
        [TestMethod]
        public void Finaltest()
        {
            Xunit.Assert.Equal(28, Practice.Program.Problem12.TriangleNumberDivisors(5));
            Xunit.Assert.Equal(76576500, Practice.Program.Problem12.TriangleNumberDivisors(500));
        }

    }
    [TestClass]
    public class UnitTest13
    {
        [TestMethod]
        public void SumOfFinalTen()
        {
            Xunit.Assert.Equal(5105355450, Practice.Program.Problem13.BottomTenDigits());
            Xunit.Assert.Equal("5537376230", Practice.Program.Problem13.TopTenDigits());
        }
    }


    [TestClass]
    public class UnitTest14
    {
        [TestMethod]
        public void LongestCollatzSequence()
        {
            Xunit.Assert.Equal(10, Practice.Program.Problem14.LongestCollatzSequence(13));
            Xunit.Assert.Equal(837799, Practice.Program.Problem14.longestChainMillion(1000000));

        }
    }
    [TestClass]
    public class UnitTest15
    {
        [TestMethod]
        public void testLattice()
        {
            Xunit.Assert.Equal(20, Practice.Program.Problem15.latticePaths(3));
            Xunit.Assert.Equal(6, Practice.Program.Problem15.latticePaths(2));
            Xunit.Assert.Equal(137846528820, Practice.Program.Problem15.latticePaths(20));
        }
    }

    [TestClass]
    public class UnitTest16
    {
        [TestMethod]
        public void testExo()
        {
            Xunit.Assert.Equal((BigInteger)32, Practice.Program.Problem16.Expo(2, 5));
            Xunit.Assert.Equal(BigInteger.Parse("10715086071862673209484250490600018105614048117055336074437503883703510511249361224931983788156958581275946729175531468251871452856923140435984577574698574803934567774824230985421074605062371141877954182153046474983581941267398767559165543946077062914571196477686542167660429831652624386837205668069376"), Practice.Program.Problem16.Expo(2, 1000));
            Xunit.Assert.Equal(1366, Practice.Program.Problem16.DigitValues("10715086071862673209484250490600018105614048117055336074437503883703510511249361224931983788156958581275946729175531468251871452856923140435984577574698574803934567774824230985421074605062371141877954182153046474983581941267398767559165543946077062914571196477686542167660429831652624386837205668069376"));
        }
    }

    [TestClass]
    public class UnitTest17
    {
        [TestMethod]
        public void testConvertWord()
        {
            Xunit.Assert.Equal("one-hundred and twenty-one", Practice.Program.problem17.ConvertToWords.convertToWords(121));
            Xunit.Assert.Equal("one-hundred and ten", Practice.Program.problem17.ConvertToWords.convertToWords(110));
            Xunit.Assert.Equal("twelve", Practice.Program.problem17.ConvertToWords.convertToWords(12));
        }

        [TestMethod]
        public void testTotalLength()
        {
            Xunit.Assert.Equal(19, Practice.Program.problem17.lengthOfWords(5));
            Xunit.Assert.Equal(21124, Practice.Program.problem17.lengthOfWords(1000));
        }
    }

    [TestClass]
    public class UnitTest18And67
    {
        [TestMethod]
        public void testTriangle()
        {
            Xunit.Assert.Equal(23, Practice.Program.Problem18And67.maxPathSum("p18Test.txt"));
            Xunit.Assert.Equal(1074, Practice.Program.Problem18And67.maxPathSum("p18.txt"));
            Xunit.Assert.Equal(7273, Practice.Program.Problem18And67.maxPathSum("p67.txt"));

        }
    }

    [TestClass]
    public class UnitTest19
    {
        [TestMethod]
        public void testSundays()
        {
            Xunit.Assert.Equal(171, Practice.Program.Problem19.numberOfSundaysOnFirst());
        }
    }

    [TestClass]
    public class UnitTest20
    {
        [TestMethod]
        public void testFactorialDigit()
        {
            Xunit.Assert.Equal(27, Practice.Program.Problem20.factorialSum(10));
            Xunit.Assert.Equal(648, Practice.Program.Problem20.factorialSum(100));
        }
    }

    [TestClass]
    public class UnitTest21
    {
        [TestMethod]
        public void testDivsors()
        {
            List<int> temp = new List<int>();
            temp.Add(1);
            temp.Add(2);
            temp.Add(4);
            temp.Add(5);
            temp.Add(10);
            temp.Add(11);
            temp.Add(20);
            temp.Add(22);
            temp.Add(44);
            temp.Add(55);
            temp.Add(110);
            List<int> temp2 = Practice.CommonUtility.divisors(220);
            temp2.Sort();
            for(int i = 0; i < temp.Count; i++)
            {
                Xunit.Assert.Equal(temp2[i], (temp[i]));
            }
        }
        [TestMethod]
        public void testSumList()
        {
            List<int> temp = new List<int>();
            temp.Add(1);
            temp.Add(2);
            temp.Add(4);
            temp.Add(71);
            temp.Add(142);
            Xunit.Assert.Equal(220, Practice.CommonUtility.sumList(temp));
        }
        [TestMethod]
        public void testAmicable()
        {
            Xunit.Assert.Equal(284, Practice.CommonUtility.sumList(Practice.CommonUtility.divisors(220)));
            Xunit.Assert.True(Practice.Program.Problem21.checkAmicable(220));
        }
        [TestMethod]
        public void testAmicableSum()
        {
            Xunit.Assert.Equal(31626, Practice.Program.Problem21.sumOfAmicableNumbers(10000));
        }
    }
    [TestClass]
    public class UnitTest22
    {
        [TestMethod]
        public void testName()
        {
            Xunit.Assert.Equal(49714, Practice.Program.Problem22.sumOfName(938, "COLIN"));
            Xunit.Assert.Equal(871198282, Practice.Program.Problem22.SumOfAllNames());
        }
    }
    [TestClass]
    public class UnitTest23
    {
        [TestMethod]
        public void TestAbundant()
        {
            Xunit.Assert.Equal(4179871, Practice.Program.Problem23.SumOfNumbersNotSumOfAbundant());
        }
    }
    [TestClass]
    public class UnitTest24
    {
        [TestMethod]
        public void testFactor()
        {
            Xunit.Assert.Equal(120, Practice.Program.Problem24.Factor(5));
        }
        [TestMethod]
        public void testPermutation()
        {
            Xunit.Assert.Equal("2783915460", Practice.Program.Problem24.Permutations());
        }
    }
    [TestClass]
    public class UnitTest25
    {
        [TestMethod]
        public void testBrute()
        {
            Xunit.Assert.Equal(4782, Practice.Program.Problem25.IndexOf1000DigitFib());
        }
    }

    [TestClass]
    public class UnitTest26
    {
        [TestMethod]
        public void testLargestCycle()
        {
            Xunit.Assert.Equal(983, Practice.Program.Problem26.ValueWithLongestRecurringCycle());
        }
    }
    [TestClass]
    public class UnitTest27
    {
        [TestMethod]
        public void TestQuadraticPrimes()
        {
            Xunit.Assert.Equal(-59231, Practice.Program.Problem27.QuadraticPrimes());
        }
    }
    [TestClass]
    public class UnitTest28
    {
        [TestMethod]
        public void testSpiralDiag()
        {
            Xunit.Assert.Equal(101, Practice.Program.Problem28.NumberSpiralDiagonals(5));
            Xunit.Assert.Equal(669171001, Practice.Program.Problem28.NumberSpiralDiagonals(1001));
        }
    }
    [TestClass]
    public class UnitTest29
    {
        [TestMethod]
        public void testDistinctPowers()
        {
            Xunit.Assert.Equal(15, Practice.Program.Problem29.DistinctPowers(5));
            Xunit.Assert.Equal(9183, Practice.Program.Problem29.DistinctPowers(100));
        }
    }
    [TestClass]
    public class UnitTest30
    {
        [TestMethod]
        public void TestFifthPowers()
        {
            Xunit.Assert.Equal(443839, Practice.Program.Problem30.FifthPowers());
        }
    }
    [TestClass]
    public class UnitTest31
    {
        [TestMethod]
        public void TestCoinSums()
        {
            Xunit.Assert.Equal(73682, Practice.Program.Problem31.CoinSums());
        }
    }
    [TestClass]
    public class UnitTest32
    {
        [TestMethod]
        public void TestPandigital()
        {
            Xunit.Assert.Equal(45228, Practice.Program.Problem32.PandigitalSums());
        }
    }
    [TestClass]
    public class UnitTest33
    {
        [TestMethod]
        public void TestDigitCancelFraction()
        {
            Xunit.Assert.Equal(100, Practice.Program.Problem33.DigitCancelFractions());
        }
    }
    [TestClass]
    public class UnitTest34
    {
        [TestMethod]
        public void TestDigitFactorials()
        {
            Xunit.Assert.Equal(40730, Practice.Program.Problem34.DigitFactorials());
        }
    }
    [TestClass]
    public class UnitTest35
    {
        [TestMethod]
        public void TestCircularPrimes()
        {
            Xunit.Assert.Equal(13, Practice.Program.Problem35.CircularPrimesUnderN(100));
            Xunit.Assert.Equal(55, Practice.Program.Problem35.CircularPrimesUnderN(1000000));
        }
    }
    [TestClass]
    public class UnitTest36
    {
        [TestMethod]
        public void testPalindromBinary()
        {
            Xunit.Assert.True(Practice.Program.Problem36.isPalindrome(585, 2));
            Xunit.Assert.Equal(872187, Practice.Program.Problem36.DoubleBasePalindromes());
        }
    }
    [TestClass]
    public class UnitTest38
    {
        [TestMethod]
        public void TestPandigitMultitple()
        {
            Xunit.Assert.Equal(932718654, Practice.Program.Problem38.PandigitMultiple());
        }
    }
    [TestClass]
    public class UnitTest40
    {
        [TestMethod]
        public void testChampernowne()
        {
            Xunit.Assert.Equal(210, Practice.Program.Problem40.Champ());
        }
    }
    [TestClass]
    public class UnitTest41
    {
        [TestMethod]
        public void TestPandigitPrime()
        {
            Xunit.Assert.Equal(7652413, Practice.Program.Problem41.PandigitalPrime());
        }
    }
    [TestClass]
    public class UnitTest42
    {
        [TestMethod]
        public void TestCodedTriangleNumbers()
        {
            Xunit.Assert.Equal(162, Practice.Program.Problem42.CodedTriangleNumbers("p042_words.txt"));
        }
    }
    [TestClass]
    public class UnitTest44
    {
        [TestMethod]
        public void TestPentagonalNumbers()
        {
            Xunit.Assert.Equal(5482660, Practice.Program.Problem44.PentagonNumbersDiff());
        }
    }
    [TestClass]
    public class UnitTest45
    {
        [TestMethod]
        public void TestTPH()
        {
            Xunit.Assert.Equal(1533776805, Practice.Program.Problem45.TriPentHex());
        }
    }
    [TestClass]
    public class UnitTest48
    {
        [TestMethod]
        public void testSelfPowers()
        {
            Xunit.Assert.Equal((ulong)0405071317, Practice.Program.Problem48.SelfPowersBigInt(10, 10000000000));
            Xunit.Assert.Equal((ulong)9110846700, Practice.Program.Problem48.SelfPowersBigInt(1000, 10000000000));
        }
        
    }
    [TestClass]
    public class UnitTest76
    {
        [TestMethod]
        public void TestSummations()
        {
            Xunit.Assert.Equal(190569291, Practice.Program.Problem76.Summations());
        }
    }
    [TestClass]
    public class UnitTest357
    {
        [TestMethod]
        public void TestPrimeGeneratingNumbers()
        {
            Xunit.Assert.Equal(1739023853137, Practice.Program.Problem357.PrimeGeneratingIntegers());
        }
    }
    [TestClass]
    public class UnitTest206
    {
        [TestMethod]
        public void TestConcealedSquare()
        {
            Xunit.Assert.Equal(1389019170, Practice.Program.Problem206.ConcealedSquare());
        }
    }
    [TestClass]
    public class UnitTest668
    {
        [TestMethod]
        public void TestSquareRootSmooth()
        {
            Xunit.Assert.Equal(7, Practice.Program.Problem668.LPrimeFactor((long)49));
            Xunit.Assert.Equal(29, Practice.Program.Problem668.SquareRootSmooth(100));
            //Xunit.Assert.Equal(2811077773, Practice.Program.Problem668.SquareRootSmooth(10000000000));
        }
    }






}
