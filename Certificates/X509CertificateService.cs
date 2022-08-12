using ncrypt.Library.Hash;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ncrypt.Library.Certificates;

[RenderUI(Class = RenderClass.Certificate)]
public class X509CertificateService
{
    [RenderUI]
    public String Generate([UIParam("Name")] String name, [UIParam("Public Key")] String publicKey,
        [UIParam("Private Key")] String privateKey, [UIParam("Hash-Type")] HashType hash)
    {
        String asciiPublic = Converter.FromHex(publicKey, ConvertType.ASCII);
        String asciiPrivate = Converter.FromHex(privateKey, ConvertType.ASCII);
        String asciiName = Converter.FromHex(name, ConvertType.ASCII);

        RSA rsa = RSA.Create();
        rsa.ImportFromPem(asciiPublic.ToCharArray());
        rsa.ImportFromPem(asciiPrivate.ToCharArray());

        var req = new CertificateRequest(asciiName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

        var cert = req.CreateSelfSigned(DateTime.Now, DateTime.Now.AddDays(1));

        StringBuilder sb = new();
        sb.AppendLine("-----BEGIN CERTIFICATE AUTHORITY-----");
        sb.AppendLine(Convert.ToBase64String(cert.RawData));
        sb.AppendLine("-----END CERTIFICATE AUTHORITY-----");

        return Converter.ToHex(sb.ToString(), ConvertType.ASCII);
    }
}
