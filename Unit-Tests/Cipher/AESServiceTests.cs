using ncrypt.Library.Cipher;
using System.Security.Cryptography;

namespace ncrypt.Library.UnitTests.Cipher;

[TestClass()]
public class AESServiceTests
{
    #region Encrypt

    [TestMethod()]
    public void EncryptTest()
    {
        // Arrange
        AESService aes = new(TestKeys.AESKey, CipherMode.CBC);
        String text = "54657374212048656c6c6f2c20576f726c64";
        String expected = 
            "8CC866D1CEC26E03A90B5D88B00B9ABB" +
            "F17BD76C38264E98A118D4217EC851AB";

        // Act
        String actual = aes.Encrypt(text, TestKeys.AESIV);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Decrypt

    [TestMethod()]
    public void DecryptTest()
    {
        // Arrange
        AESService aes = new(TestKeys.AESKey, CipherMode.CBC);
        String expected = "54657374212048656c6c6f2c20576f726c64" ;
        String text = 
            "8CC866D1CEC26E03A90B5D88B00B9ABB" +
            "F17BD76C38264E98A118D4217EC851AB";

        // Act
        String actual = aes.Decrypt(text, TestKeys.AESIV);

        // Assert
        Assert.AreEqual(expected, actual.ToLower());
    }

    #endregion
}
