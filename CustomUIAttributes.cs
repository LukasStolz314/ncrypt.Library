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