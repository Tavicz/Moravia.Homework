namespace Moravia.Homework.Tests
{
    public class DocumentServiceTests
    {
        [Fact]
        public void ConvertAndStore_ValidInput_Success()
        {
            // Arrange
            var mockInputFormat = new Mock<IDocumentFormat>();
            var mockInputStorage = new Mock<IDocumentStorage>();
            var mockOutputFormat = new Mock<IDocumentFormat>();
            var mockOutputStorage = new Mock<IDocumentStorage>();

            var testDocument = new Document { Title = "Test", Text = "Testing Text" };

            mockInputStorage.Setup(m => m.Read(It.IsAny<string>())).Returns("testContent");
            mockInputFormat.Setup(m => m.Parse("testContent")).Returns(testDocument);
            mockOutputFormat.Setup(m => m.Serialize(testDocument)).Returns("serializedTestContent");

            var service = new DocumentService(mockInputFormat.Object, mockInputStorage.Object,
                                              mockOutputFormat.Object, mockOutputStorage.Object);

            // Act
            service.ConvertAndStore("inputPath", "outputPath");

            // Assert
            mockInputStorage.Verify(m => m.Read("inputPath"), Times.Once());
            mockInputFormat.Verify(m => m.Parse("testContent"), Times.Once());
            mockOutputFormat.Verify(m => m.Serialize(testDocument), Times.Once());
            mockOutputStorage.Verify(m => m.Write("outputPath", "serializedTestContent"), Times.Once());
        }

        [Fact]
        public void ConvertAndStore_ErrorInReading_ThrowsException()
        {
            // Arrange
            var mockInputFormat = new Mock<IDocumentFormat>();
            var mockInputStorage = new Mock<IDocumentStorage>();
            var mockOutputFormat = new Mock<IDocumentFormat>();
            var mockOutputStorage = new Mock<IDocumentStorage>();

            mockInputStorage.Setup(m => m.Read(It.IsAny<string>())).Throws(new Exception("Read Error"));

            var service = new DocumentService(mockInputFormat.Object, mockInputStorage.Object,
                                              mockOutputFormat.Object, mockOutputStorage.Object);

            // Assert
            Exception ex = Assert.Throws<Exception>(() => service.ConvertAndStore("inputPath", "outputPath"));
            Assert.Equal("Read Error", ex.Message);
        }
    }
}