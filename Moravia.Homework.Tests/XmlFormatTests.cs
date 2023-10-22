namespace Moravia.Homework.Tests
{
    public class XmlFormatTests
    {
        [Fact]
        public void Parse_ValidXml_ReturnsDocument()
        {
            // Arrange
            var xmlFormat = new XmlFormat();
            var xml = @"<document><title>Test Title</title><text>Testing Text</text></document>";

            // Act
            var document = xmlFormat.Parse(xml);

            // Assert
            Assert.Equal("Test Title", document.Title);
            Assert.Equal("Testing Text", document.Text);
        }

        [Fact]
        public void Serialize_ValidDocument_ReturnsXml()
        {
            // Arrange
            var xmlFormat = new XmlFormat();
            var document = new Document { Title = "Test Title", Text = "Testing Text" };

            // Act
            var xml = xmlFormat.Serialize(document);

            // Assert
            Assert.Contains("<title>Test Title</title>", xml);
            Assert.Contains("<text>Testing Text</text>", xml);
        }
    }
}
