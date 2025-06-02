[AttributeUsage(AttributeTargets.Property)]
public class OrderAttribute : Attribute
{
    public int Index { get; }
    public OrderAttribute(int index) => Index = index;
}