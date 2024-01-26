using Toolbox.Utilities;

namespace TestToolbox.Utilities
{
    public class TestMathUtilities
    {
        [Test]
        public void PrimesTest()
        {
            List<long> expectedResultFor10 = new List<long> { 2, 3, 5, 7 };

            var resultFor10 = MathUtilities.Primes(10);
            var resultNegative = MathUtilities.Primes(-10);
            var resultZero = MathUtilities.Primes(0);

            Assert.Multiple(() =>
            {
                Assert.That(resultFor10.Count, Is.EqualTo(expectedResultFor10.Count), $"Primes must return list of {expectedResultFor10.Count} elements instead of {resultFor10.Count}");
                Assert.That(resultFor10[0], Is.EqualTo(expectedResultFor10[0]));
                Assert.That(resultFor10[1], Is.EqualTo(expectedResultFor10[1]));
                Assert.That(resultFor10[2], Is.EqualTo(expectedResultFor10[2]));
                Assert.That(resultFor10[3], Is.EqualTo(expectedResultFor10[3]));
            });

            Assert.That(resultNegative.Count, Is.EqualTo(0));

            Assert.That(resultZero.Count, Is.EqualTo(0));
        }

        [Test]
        public void FactorTest()
        {
            // 37 is prime
            var resultFor37 = MathUtilities.Factor(37);
            // 35478 = 2 x 3^5 x 73
            var resultFor35478 = MathUtilities.Factor(35478);
            var resultForNeg = MathUtilities.Factor(-1);

            Assert.Multiple(() =>
            {
                Assert.That(resultFor37.Count, Is.EqualTo(1));
                Assert.That(resultFor37[0].Item1, Is.EqualTo(37));
                Assert.That(resultFor37[0].Item2, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(resultFor35478.Count, Is.EqualTo(3));
                Assert.That(resultFor35478[0].Item1, Is.EqualTo(2));
                Assert.That(resultFor35478[0].Item2, Is.EqualTo(1));
                Assert.That(resultFor35478[1].Item1, Is.EqualTo(3));
                Assert.That(resultFor35478[1].Item2, Is.EqualTo(5));
                Assert.That(resultFor35478[2].Item1, Is.EqualTo(73));
                Assert.That(resultFor35478[2].Item2, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(resultForNeg.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void LCMTest()
        {
            var result1 = MathUtilities.LCM(new List<long>{ 2, 5});
            var result2 = MathUtilities.LCM(new List<long> { 3, 10 });
            var result4 = MathUtilities.LCM(new List<long> { 2, 7, 11 });
            var result5 = MathUtilities.LCM(new List<long> { 51, 135 });
            var result6 = MathUtilities.LCM(new List<long> { 78, 1257, 123654 });
            var result7 = MathUtilities.LCM(new List<long> { 3,4,5,6,7,8 });
            var result8 = MathUtilities.LCM(new List<long> { });
            var result9 = MathUtilities.LCM(new List<long> { 2 });
            var result10 = MathUtilities.LCM(new List<long> { 1, -5 });

            Assert.That(result1, Is.EqualTo(10));
            Assert.That(result2, Is.EqualTo(30));
            Assert.That(result4, Is.EqualTo(154));
            Assert.That(result5, Is.EqualTo(2295));
            Assert.That(result6, Is.EqualTo(673543338));
            Assert.That(result7, Is.EqualTo(840));

            Assert.That(result8, Is.EqualTo(0));
            Assert.That(result9, Is.EqualTo(5));

        }
    }


}
