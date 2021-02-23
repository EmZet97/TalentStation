using NUnit.Framework;
using TalentStation.Models.Helpers;

namespace Tests
{
    public class StringEncryptorTests
    {
        readonly string testKey = "b14ca5898a4e4133bbce2ea2315a1916";

        [Test]
        [TestCase("test_text_123")]
        [TestCase("qwertyuiopljhgfdsazxcvbnm")]
        [TestCase("1234")]
        [TestCase("qwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnmqwertyuiopljhgfdsazxcvbnm")]
        public void EncryptAndThenDecryptText_ResultShouldBeEqualToInputText(string inputText)
        {
            var encryptedText = StringEncrypter.Encrypt(testKey, inputText);

            var decryptedText = StringEncrypter.Decrypt(testKey, encryptedText);

            Assert.That(encryptedText, Is.Not.EqualTo(inputText));
            Assert.That(decryptedText, Is.EqualTo(inputText));
        }
    }
}