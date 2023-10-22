using System.IO.Abstractions.TestingHelpers;

namespace Moravia.Homework.Tests
{
    public class FileSystemStorageTests
    {
        [Fact]
        public void Write_ValidPath_WritesToFileSystem()
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            var storage = new FileSystemStorage(mockFileSystem);
            var content = "Test content";

            // Act
            storage.Write("/testfile.txt", content);

            // Assert
            Assert.True(mockFileSystem.File.Exists("/testfile.txt"));
            Assert.Equal(content, mockFileSystem.File.ReadAllText("/testfile.txt"));
        }

        [Fact]
        public void Read_ValidPath_ReadsFromFileSystem()
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            var storage = new FileSystemStorage(mockFileSystem);
            var content = "Test content";
            mockFileSystem.File.WriteAllText("/testfile.txt", content);

            // Act
            var readContent = storage.Read("/testfile.txt");
            
            // Assert
            Assert.Equal(content, readContent);
        }
    }
}
