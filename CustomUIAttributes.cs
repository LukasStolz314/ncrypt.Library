namespace ncrypt.Library;

public enum RenderClass
{
    Cipher,
    Format,
    Hash
}

public class RenderUI : Attribute 
{
    public RenderClass Class { get; set; }
}

public class UIParam : Attribute
{
    public String? Name { get; set; }

    public UIParam(String? name) 
        => Name = name;
}

public class UseCopy : Attribute
{
    public List<String> CopyFunctions { get; set; }

    public UseCopy(List<String> copyFunctions)
        => CopyFunctions = copyFunctions;

    public UseCopy(String copyFunction)
        => CopyFunctions = new() { copyFunction };
}