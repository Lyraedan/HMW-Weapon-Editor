[AttributeUsage(AttributeTargets.Property)]
public class GroupAttribute : Attribute
{
    public string Group { get; }
    public string SubGroup { get; }

    public GroupAttribute(string group)
    {
        Group = group;
        SubGroup = null;
    }

    public GroupAttribute(string group, string subGroup)
    {
        Group = group;
        SubGroup = subGroup;
    }
}
