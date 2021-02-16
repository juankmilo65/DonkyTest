using Xunit;
using DonkeyFilesBL.Interfaces;
using DonkeyFilesBL.Files;
using DonkeyFilesDAL.Models;

namespace DonkeyFilesTest
{
    public class FileDetailsShould
    {
        [Fact]
        public void ValidateFileDetailsExists()
        {
            //Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryReadRepository();
            repo.PostFileDetails(new FileDetailsModel {FileId =1, FileDate= string.Empty, FileName=string.Empty, FileSize= string.Empty });
            int fileId = 1;

            //Act
            bool isValid = repo.FileDetailsExists(fileId);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void ValidateFileDetailsNoExists()
        {
            //Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryReadRepository();
            int fileId = 1;

            //Act
            bool isValid = repo.FileDetailsExists(fileId);

            //Assert
            Assert.False(isValid);
        }
    }
}
