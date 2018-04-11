namespace ConvertTaigaTasksToSprintBurnDown.Tests
{
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class TestTaigaConverter
    {
        private IConverter systemUnderTest;

        [Test]
        public void Convert_WhenInvoked_ConvertsData()
        {
            var expected = GetExpectedOutput();
            var input = GetTestInput();
            var actual = systemUnderTest.Convert(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new TaigaConverter();
        }

        private string GetExpectedOutput()
        {
            return File.ReadAllText(@".\ExpectedOutput.csv");
        }

        private string GetTestInput()
        {
            return File.ReadAllText(@".\TestInput.csv");
        }
    }
}