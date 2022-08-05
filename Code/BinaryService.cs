using System.Text;

namespace ncrypt.Library.Code;

[RenderUI (Class = RenderClass.Format)]
public class BinaryService
{
    [RenderUI]
    public String Encode(String input)
    {
        StringBuilder sb = new ();
 
        foreach (Char c in input.ToCharArray())        
            sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));

        return sb.ToString();
    }

    [RenderUI]
    public String Decode(String input)
    {
        List<Byte> bytes = new ();
 
        for (Int32 i = 0; i < input.Length; i += 8)
            bytes.Add(Convert.ToByte(input.Substring(i, 8), 2));

        return Converter.ToString(bytes.ToArray(), ConvertType.ASCII);
    }
}
