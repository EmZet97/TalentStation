using NUnit.Framework;
using TalentStation.Models.Helpers;

namespace Tests
{
    public class Sha256GeneratorTests
    {
        [Test]
        [TestCase("test_text_123")]
        [TestCase("qwertyuiopljhgfdsazxcvbnm")]
        [TestCase("1234")]
        [TestCase("qwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnm")]
        public void CreateHash_ResultShouldNotBeEqualToInputText(string inputText)
        {
            var hashedText = Sha256Generator.ComputeString(inputText);

            Assert.That(hashedText, Is.Not.EqualTo(inputText));
            Assert.That(hashedText.Length, Is.EqualTo(64));
        }
    }
}