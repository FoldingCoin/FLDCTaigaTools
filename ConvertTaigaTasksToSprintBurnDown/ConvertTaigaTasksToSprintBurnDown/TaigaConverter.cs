namespace ConvertTaigaTasksToSprintBurnDown
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using CsvHelper;

    public class TaigaConverter : IConverter
    {
        public string Convert(string input)
        {
            var tasks = ConvertToDto(input);
            return GetSprintBurnDown(tasks);
        }

        private TaigaTasks[] ConvertToDto(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);

            using (var memoryStream = new MemoryStream(inputBytes))
            {
                using (var streamReader = new StreamReader(memoryStream))
                {
                    using (var csvReader = new CsvReader(streamReader))
                    {
                        csvReader.Configuration.RegisterClassMap<TaigaTasksMap>();
                        return csvReader.GetRecords<TaigaTasks>().ToArray();
                    }
                }
            }
        }

        private string GetSprintBurnDown(TaigaTasks[] tasks)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    writer.WriteLine(
                        "status,assigned_to,ref,Work Item Type,subject,Original Estimate,Completed Work,Remaining Work,sprint");

                    using (var csvWriter = new CsvWriter(writer))
                    {
                        foreach (var task in tasks)
                        {
                            csvWriter.WriteField(task.Status);
                            csvWriter.WriteField(task.AssignedTo);
                            csvWriter.WriteField(task.Reference);
                            csvWriter.WriteField("Task");
                            csvWriter.WriteField(task.Subject);
                            csvWriter.WriteField(task.OriginalEstimate);
                            csvWriter.WriteField(task.CompletedWork);
                            csvWriter.WriteField(task.RemainingWork);
                            csvWriter.WriteField(task.Sprint);
                            csvWriter.NextRecord();
                        }

                        writer.Flush();
                        memoryStream.Position = 0;

                        using (var streamReader = new StreamReader(memoryStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}