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
    public String? DefaultValue { get; set; }

    public UIParam(String? name, String? defaultValue = null)
    { 
        Name = name;
        DefaultValue = defaultValue;
    }
}

public class UseCopy : Attribute
{
    public List<String> CopyFunctions { get; set; }

    public UseCopy(params String[] copyFunctions)
        => CopyFunctions = copyFunctions.ToList();
}

public class CopyRoutine : Attribute
{
    public String? Name { get; set; }

    public CopyRoutine(String? name)
        => Name = name;
}