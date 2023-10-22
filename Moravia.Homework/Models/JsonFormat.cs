using Moravia.Homework.Interfaces;
using Newtonsoft.Json;

namespace Moravia.Homework.Models
{
    public class JsonFormat : IDocumentFormat
    {
        public Document Parse(string content)
        {
            var deserializedObject = JsonConvert.DeserializeObject<Document>(content);

            if (deserializedObject is null)
            {
                throw new InvalidOperationException($"The JSON content could not be deserialized into a {nameof(Document)} object.");
            }

            if (string.IsNullOrEmpty(deserializedObject.Title) || string.IsNullOrEmpty(deserializedObject.Text))
            {
                throw new InvalidOperationException("The JSON content is missing required properties.");
            }

            return deserializedObject;
        }

        public string Serialize(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
}
