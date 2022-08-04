using ncrypt.Library.Cipher;

namespace ncrypt.Library.UnitTests.Cipher;

[TestClass()]
public class RSAServiceTests
{
    #region GenerateKeyPair

    [TestMethod()]
    public void GenerateKeyPairPublicKeyTest()
    {
        // Arrange
        RSAService rsa = new();
        String expBegin = "-----BEGIN RSA PUBLIC KEY-----";
        String expEnd = "-----END RSA PUBLIC KEY-----";

        // Act
        String actual = rsa.GenerateKeyPair(1024);

        // Assert
        Assert.IsTrue(actual.Contains(expBegin));
        Assert.IsTrue(actual.Contains(expEnd));
    }

    [TestMethod()]
    public void GenerateKeyPairPrivateKeyTest()
    {
        // Arrange
        RSAService rsa = new();
        String expBegin = "-----BEGIN RSA PRIVATE KEY-----";
        String expEnd = "-----END RSA PRIVATE KEY-----";

        // Act
        String actual = rsa.GenerateKeyPair(1024);

        // Assert
        Assert.IsTrue(actual.Contains(expBegin));
        Assert.IsTrue(actual.Contains(expEnd));
    }

    #endregion

    #region Encrypt/Decrypt

    [TestMethod()]
    public void EncryptDecryptTest()
    {
        // Arrange
        RSAService rsa = new();
        String expText = "54657374212048656c6c6f2c20576f726c64";         

        // Act
        String cipherText = rsa.Encrypt(TestKeys.RSAPublicKey, expText);
        String actualText = rsa.Decrypt(TestKeys.RSAPrivateKey, cipherText);

        // Assert
        Assert.AreEqual(expText, actualText.ToLower());
    }

    #endregion

    #region Sign/Verify

    [TestMethod()]
    public void SignVerifyValidTest()
    {
        // Arrange
        RSAService rsa = new();
        var hashType = Hash.HashType.SHA1;
        String input = "54657374212048656c6c6f2c20576f726c64";
        String expected = "Valid";

        // Act
        String signature = rsa.Sign(TestKeys.RSAPrivateKey, input, hashType);
        String actualText = rsa.Verify(TestKeys.RSAPrivateKey, input, signature, hashType);

        // Assert
        Assert.AreEqual(expected, actualText);
    }

    [TestMethod()]
    public void SignVerifyInvalidTest()
    {
        // Arrange
        RSAService rsa = new();
        var hashType = Hash.HashType.SHA1;
        String input = "54657374212048656c6c6f2c20576f726c64";
        String falseInput = "54657374212048656c6c6f2c20576f726c65";
        String expected = "Invalid";

        // Act
        String signature = rsa.Sign(TestKeys.RSAPrivateKey, input, hashType);
        String actualText = rsa.Verify(TestKeys.RSAPrivateKey, falseInput, signature, hashType);

        // Assert
        Assert.AreEqual(expected, actualText);
    }

    #endregion
}
