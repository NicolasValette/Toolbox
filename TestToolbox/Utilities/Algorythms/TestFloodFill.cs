using Toolbox.Utilities.Algorythms;

namespace TestToolbox.Utilities.Algorythms
{
    public class TestFloodFill
    {
        private char[][] _pictureSample1;
        private char[][] _pictureSample1Expected =
       {
            new char [] { '@', '#', '.', '.', '.'},
            new char [] { '@', '#', '.', '.', '.'},
            new char [] { '@', '#', '#', '#', '#'},
            new char [] { '@', '@', '@', '@', '@'},
            new char [] { '@', '@', '@', '@', '@'}
        };

        [SetUp]
        public void SetUp()
        {
            _pictureSample1 = new char[][]
            {
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '#', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
             };
        }

        [TearDown]
        public void TearDown()
        {
            _pictureSample1 = new char[1][]; // we allocate an empty tab;
        }


        [Test]
        public void FloodFillCharTest()
        {
            new FloodFill<char>().Flood(0, 0, ref _pictureSample1, '.', '@');
            Assert.That(_pictureSample1, Is.EqualTo(_pictureSample1Expected));
            
            _pictureSample1 = new char[][]
            {
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '#', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
            };
            char[][] pictureExpected = new char[][]
            {
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '#', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
            };
            new FloodFill<char>().Flood(0, 0, ref _pictureSample1, '#', '@');
            Assert.That(_pictureSample1, Is.EqualTo(pictureExpected));
           
            _pictureSample1 = new char[][]
            {
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '#', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
            };
            pictureExpected = new char[][]
            {
                new char[] { '.', '#', '@', '@', '@' },
                new char[] { '.', '#', '@', '@', '@' },
                new char[] { '.', '#', '#', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
            };
            new FloodFill<char>().Flood(0, 4, ref _pictureSample1, '.', '@');
            Assert.That(_pictureSample1, Is.EqualTo(pictureExpected));

            _pictureSample1 = new char[][]
            {
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '.', '.' },
                new char[] { '.', '#', '.', '#', '#' },
                new char[] { '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '.', '.', '.' }
            };
            pictureExpected = new char[][]
            {
                new char[] { '@', '#', '@', '@', '@' },
                new char[] { '@', '#', '@', '@', '@' },
                new char[] { '@', '#', '@', '#', '#' },
                new char[] { '@', '@', '@', '@', '@' },
                new char[] { '@', '@', '@', '@', '@' }
            };
            new FloodFill<char>().Flood(0, 3, ref _pictureSample1, '.', '@');
            Assert.That(_pictureSample1, Is.EqualTo(pictureExpected));
        }
        [Test]
        public void FloodFillIntTest()
        {
            int [][]_pictureSample = new int[][]
            {
                new int[] { 1, 0, 2, 2, 2 },
                new int[] { 1, 0, 2, 2, 2 },
                new int[] { 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1 }
            };
            int[][] _pictureExpected = new int[][]
            {
                new int[] { 3, 0, 2, 2, 2 },
                new int[] { 3, 0, 2, 2, 2 },
                new int[] { 3, 0, 0, 0, 0 },
                new int[] { 3, 3, 3, 3, 3 },
                new int[] { 3, 3, 3, 3, 3 }
            };
            new FloodFill<int>().Flood(0, 0, ref _pictureSample, 1, 3);
            Assert.That(_pictureSample, Is.EqualTo(_pictureExpected));
           
        }
    }
}
