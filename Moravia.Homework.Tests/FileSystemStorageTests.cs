namespace Moravia.Homework.Tests
{
    public class FileSystemStorageTests
    {
        private readonly string testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "testfile.txt");

        public FileSystemStorageTests()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Fact]
        public void Write_ValidPath_WritesToFileSystem()
        {
            // Arrange
            var storage = new FileSystemStorage();
            var content = "Test content";

            // Act
            storage.Write(testFilePath, content);

            // Assert
            Assert.True(File.Exists(testFilePath));
            Assert.Equal(content, File.ReadAllText(testFilePath));
        }

        [Fact]
        public void Read_ValidPath_ReadsFromFileSystem()
        {
            // Arrange
            var storage = new FileSystemStorage();
            var content = "Test content";
            File.WriteAllText(testFilePath, content);

            // Act
            var readContent = storage.Read(testFilePath);

            // Assert
            Assert.Equal(content, readContent);
        }

        ~FileSystemStorageTests()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}
