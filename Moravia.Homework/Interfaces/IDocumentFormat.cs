using Moravia.Homework.Models;

namespace Moravia.Homework.Interfaces
{
    public interface IDocumentFormat
    {
        Document Parse(string content);
        string Serialize(Document document);
    }
}
