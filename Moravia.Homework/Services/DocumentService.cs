using Moravia.Homework.Interfaces;

namespace Moravia.Homework.Services
{
    public class DocumentService
    {
        private readonly IDocumentFormat inputFormat;
        private readonly IDocumentStorage inputStorage;
        private readonly IDocumentFormat outputFormat;
        private readonly IDocumentStorage outputStorage;

        public DocumentService(IDocumentFormat inputFormat,
            IDocumentStorage inputStorage,
            IDocumentFormat outputFormat,
            IDocumentStorage outputStorage)
        {
            this.inputFormat = inputFormat ?? throw new ArgumentNullException(nameof(inputFormat));
            this.inputStorage = inputStorage ?? throw new ArgumentNullException(nameof(inputStorage));
            this.outputFormat = outputFormat ?? throw new ArgumentNullException(nameof(outputFormat));
            this.outputStorage = outputStorage ?? throw new ArgumentNullException(nameof(outputStorage));
        }

        public void ConvertAndStore(string inputPath, string outputPath)
        {
            var content = inputStorage.Read(inputPath);
            var document = inputFormat.Parse(content);

            var outputContent = outputFormat.Serialize(document);

            outputStorage.Write(outputPath, outputContent);

            Console.WriteLine("Conversion completed successfully.");
        }

    }
}
