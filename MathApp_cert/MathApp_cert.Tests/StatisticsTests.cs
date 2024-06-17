namespace MathApp_cert.Tests
{
    public class StatisticsTests
    {

        [Test]
        public void CheckingMemoryStatistics()
        {
            // arange
            var student01 = new StudentInMemory("Maciek", "Kowalski");
            student01.AddGrade(30);
            student01.AddGrade(10);
            student01.AddGrade(50);

            //act
            var statistics = student01.GetStatistics();
            var max = statistics.Max;
            var min = statistics.Min;
            var avg = statistics.Avg;

            //assert
            Assert.AreEqual(10, min);
            Assert.AreEqual(50, max);
            Assert.AreEqual(30, avg);
        }

        [Test]
        public void CheckingFileStatistics()
        {
            
            // arange
            var student01 = new StudentInFile("Maciek", "Kowalski");

            if (File.Exists(student01.FileName))
            {
                File.Delete(student01.FileName);
            }
            student01.AddGrade(30);
            student01.AddGrade(10);
            student01.AddGrade(50);

            

            //act
            var statistics = student01.GetStatistics();
            var max = statistics.Max;
            var min = statistics.Min;
            var avg = statistics.Avg;

            //assert
            Assert.AreEqual(10, min);
            Assert.AreEqual(50, max);
            Assert.AreEqual(30, avg);
        }
    }
}