using Toolbox.Datas;

namespace TestToolbox.Datas
{
    public class TestCoord2D
    {
        private Coord2D<int> _coord0;
        private Coord2D<int> _coordPos1;
        private Coord2D<int> _coordPos2;
        private Coord2D<int> _coordNeg1;
        private Coord2D<int> _coordNeg2;
        private Coord2D<int> _coord1;
        private Coord2D<int> _coord2;

        private Coord2D<double> _coordD1;
        private Coord2D<double> _coordD2;

        [SetUp]
        public void SetUp()
        {
            _coord0 = new Coord2D<int>(0, 0);
            _coordPos1 = new Coord2D<int>(1, 3);
            _coordPos2 = new Coord2D<int>(2, 5);
            _coordNeg1 = new Coord2D<int>(-1, -2);
            _coordNeg2 = new Coord2D<int>(-5, -2);
            _coord1 = new Coord2D<int>(1, -2);
            _coord2 = new Coord2D<int>(-5, 7);

            _coordD1 = new Coord2D<double>(1d, 2.5d);
            _coordD2 = new Coord2D<double>(1d, Math.Sqrt(2d));
        }

        [Test]
        public void CreationCoordTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_coord0.X, Is.EqualTo(0));
                Assert.That(_coord0.Y, Is.EqualTo(0));
            });
            Assert.Multiple(() =>
            {
                Assert.That(_coordPos1.X, Is.EqualTo(1));
                Assert.That(_coordPos1.Y, Is.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(_coordNeg1.X, Is.EqualTo(-1));
                Assert.That(_coordNeg1.Y, Is.EqualTo(-2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(_coord1.X, Is.EqualTo(1));
                Assert.That(_coord1.Y, Is.EqualTo(-2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(_coordD2.X, Is.EqualTo(1d));
                Assert.That(_coordD2.Y, Is.EqualTo(Math.Sqrt(2d)));
            });

        }

        [Test]
        public void EqualityTest()
        {
            var temporaryCoordPos = new Coord2D<int>(1, 3);
            var temporaryCoordPosA = new Coord2D<int>(1, 2);
            var temporaryCoordPosB = new Coord2D<int>(2, 3);
            var temporaryCoordNeg = new Coord2D<int>(-5, -2);
            var temporaryCoordPos2 = new Coord2D<int>(5, 2);
            var temporaryCoordMix1 = new Coord2D<int>(1, -2);
            var temporaryCoordMix2 = new Coord2D<int>(-5, 7);
            var temporaryCoordDouble = new Coord2D<double>(1d, 2.5d);

            //Equality test
            Assert.That(_coordPos1 == temporaryCoordPos, Is.True);
            Assert.That(_coordPos2 == temporaryCoordPos, Is.False);
            Assert.That(temporaryCoordPosA == temporaryCoordPos, Is.False);
            Assert.That(temporaryCoordPosB == temporaryCoordPos, Is.False);

            Assert.That(_coordNeg2 == temporaryCoordNeg, Is.True);
            Assert.That(_coordPos1 == temporaryCoordNeg, Is.False);
            Assert.That(temporaryCoordPos2 == temporaryCoordNeg, Is.False);
            Assert.That(_coord1 == temporaryCoordMix1, Is.True);
            Assert.That(_coord2 == temporaryCoordMix2, Is.True);
            Assert.That(_coordD1 == temporaryCoordDouble, Is.True);
            Assert.That(_coordPos1.Equals(temporaryCoordPos), Is.True);
        }
        [Test]
        public void InequalityTest()
        {
            var temporaryCoordPos = new Coord2D<int>(1, 3);
            var temporaryCoordPosA = new Coord2D<int>(1, 2);
            var temporaryCoordPosB = new Coord2D<int>(2, 3);
            var temporaryCoordNeg = new Coord2D<int>(-5, -2);
            var temporaryCoordPos2 = new Coord2D<int>(5, 2);
            var temporaryCoordMix1 = new Coord2D<int>(1, -2);
            var temporaryCoordMix2 = new Coord2D<int>(-5, 7);
            var temporaryCoordDouble = new Coord2D<double>(1d, 2.5d);

            //Inequality test
            Assert.That(temporaryCoordPos != _coordPos1, Is.False);
            Assert.That(temporaryCoordPos != temporaryCoordPosA, Is.True);
            Assert.That(temporaryCoordPos != temporaryCoordPosB, Is.True);

            Assert.That(temporaryCoordPos != temporaryCoordNeg, Is.True);
            Assert.That(temporaryCoordPos2 != temporaryCoordNeg, Is.True);

            Assert.That(temporaryCoordPos2 != temporaryCoordMix1, Is.True);
            Assert.That(temporaryCoordPos2 != temporaryCoordMix2, Is.True);
            Assert.That(_coordD2 != temporaryCoordDouble, Is.True);
        }
        [Test]
        public void ToStringTest()
        {
            Assert.That(_coordPos1.ToString(), Is.EqualTo("(1,3)"));
            Assert.That(_coordNeg1.ToString(), Is.EqualTo("(-1,-2)"));
        }
    }
}
