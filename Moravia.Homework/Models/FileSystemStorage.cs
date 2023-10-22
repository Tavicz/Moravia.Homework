using Moravia.Homework.Interfaces;

namespace Moravia.Homework.Models
{
    public class FileSystemStorage : IDocumentStorage
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
