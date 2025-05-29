[AttributeUsage(AttributeTargets.Property)]
public class GroupAttribute : Attribute
{
    public string Name { get; }
    public GroupAttribute(string name) => Name = name;
}
