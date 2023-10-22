using Moravia.Homework.Interfaces;
using System.IO.Abstractions;

namespace Moravia.Homework.Models
{
    public class FileSystemStorage : IDocumentStorage
    {
        private readonly IFileSystem fileSystem;

        public FileSystemStorage() : this(new FileSystem()) { }

        public FileSystemStorage(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public string Read(string path)
        {
            return fileSystem.File.ReadAllText(path);
        }

        public void Write(string path, string content)
        {
            fileSystem.File.WriteAllText(path, content);
        }
    }
}
