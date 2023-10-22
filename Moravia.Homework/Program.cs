using Moravia.Homework.Models;
using Moravia.Homework.Services;

namespace Moravia.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new DocumentService(new JsonFormat(), new FileSystemStorage(),
                new XmlFormat(), new FileSystemStorage());

            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            try
            {
                service.ConvertAndStore(sourceFileName, targetFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}