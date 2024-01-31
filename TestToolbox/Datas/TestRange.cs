using Range = Toolbox.Datas.Range;

namespace TestToolbox.Datas
{
    public class TestRange
    {
        private Range rangePos;
        private Range rangeNeg;
        private Range rangeMix1;


        [SetUp]
        public void SetUp()
        {
            rangePos = new Range(2, 5);
            rangeNeg = new Range(-8, -4);
            rangeMix1 = new Range(-5, 1);
            
        }
        [Test]
        public void CreationTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(rangePos.MinValue, Is.EqualTo(2));
                Assert.That(rangePos.MaxValue, Is.EqualTo(5));
            });
            Assert.Multiple(() =>
            {
                Assert.That(rangeNeg.MinValue, Is.EqualTo(-8));
                Assert.That(rangeNeg.MaxValue, Is.EqualTo(-4));
            });
            Assert.Multiple(() =>
            {
                Assert.That(rangeMix1.MinValue, Is.EqualTo(-5));
                Assert.That(rangeMix1.MaxValue, Is.EqualTo(1));
            });
        }
        [Test]
        public void CountTest() 
        {
            Assert.That(rangePos.Count, Is.EqualTo(4L));
            Assert.That(rangeNeg.Count, Is.EqualTo(5L));
            Assert.That(rangeMix1.Count, Is.EqualTo(7L));
        }
        [Test]
        public void UpdtateRangeTest()
        {
            var tempRange = new Range(2, 4);
            Assert.Multiple(() =>
            {
                Assert.That(tempRange.MinValue, Is.EqualTo(2));
                Assert.That(tempRange.MaxValue, Is.EqualTo(4));
            });

            tempRange.UpdateRange(2, 3);
            Assert.Multiple(() =>
            {
                Assert.That(tempRange.MinValue, Is.EqualTo(2));
                Assert.That(tempRange.MaxValue, Is.EqualTo(3));
            });

            tempRange.UpdateRange(0, 3);
            Assert.Multiple(() =>
            {
                Assert.That(tempRange.MinValue, Is.EqualTo(0));
                Assert.That(tempRange.MaxValue, Is.EqualTo(3));
            });

            tempRange.UpdateRange(-25, 18);
            Assert.Multiple(() =>
            {
                Assert.That(tempRange.MinValue, Is.EqualTo(-25));
                Assert.That(tempRange.MaxValue, Is.EqualTo(18));
            });
        }
    }
}
