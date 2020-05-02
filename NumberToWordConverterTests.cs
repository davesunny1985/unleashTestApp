
using Xunit;

namespace unleashTest
{
    public class NumberToWordConverterTests
    {
        [Fact]
        public void ConvertToWords_InvalidEmpty_Result()
        {
            //Arrage
            string input = "";
            //Act
            string result = NumberToWordConverter.ConvertToWords(input);

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void ConvertToWords_Returns_Zero()
        {
            //Arrage
            string input = "0";
            //Act
            string result = NumberToWordConverter.ConvertToWords(input);

            //Assert
            Assert.Equal("Zero", result);
        }
    }
}
