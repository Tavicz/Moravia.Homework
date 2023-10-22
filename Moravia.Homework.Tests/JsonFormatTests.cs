using Newtonsoft.Json;

namespace Moravia.Homework.Tests
{
    public class JsonFormatTests
    {
        [Fact]
        public void Parse_ValidJson_ReturnsDocument()
        {
            // Arrange
            var jsonFormat = new JsonFormat();
            var json = @"{""Title"":""Test Title"",""Text"":""Testing Text""}";

            // Act
            var document = jsonFormat.Parse(json);

            // Assert
            Assert.Equal("Test Title", document.Title);
            Assert.Equal("Testing Text", document.Text);
        }

        [Fact]
        public void Serialize_ValidDocument_ReturnsJson()
        {
            // Arrange
            var jsonFormat = new JsonFormat();
            var document = new Document { Title = "Test Title", Text = "Testing Text" };

            // Act
            var json = jsonFormat.Serialize(document);

            // Assert
            var parsedDocument = JsonConvert.DeserializeObject<Document>(json);
            Assert.Equal("Test Title", parsedDocument.Title);
            Assert.Equal("Testing Text", parsedDocument.Text);
        }
    }
}
