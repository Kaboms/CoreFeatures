using System;

/// <summary>
/// Uses for auto resource load
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class ResourceAttribute : Attribute
{
    public readonly string Path;

    public ResourceAttribute(string path)
    {
        Path = path;
    }
}
