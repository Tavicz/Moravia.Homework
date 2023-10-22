namespace Moravia.Homework.Interfaces
{
    public interface IDocumentStorage
    {
        string Read(string path);
        void Write(string path, string content);
    }
}
