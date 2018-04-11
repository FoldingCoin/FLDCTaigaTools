namespace ConvertTaigaTasksToSprintBurnDown.Console
{
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            var converter = new TaigaConverter();
            var input = File.ReadAllText(@".\tasks.csv");
            var output = converter.Convert(input);

            var outputFileFormat = @".\SprintBurnDown{0}.csv";
            var outputFile = string.Format(outputFileFormat, string.Empty);
            var count = 0;

            while (File.Exists(outputFile))
            {
                count++;
                outputFile = string.Format(outputFileFormat, count);
            }

            File.WriteAllText(outputFile, output);
        }
    }
}