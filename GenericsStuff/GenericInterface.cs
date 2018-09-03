using System.Reflection;

namespace GenericsStuff
{
    public interface GenericInterface
    {
        string Name
        {
            get; set;
        }
        PropertyInfo PName { get; set; }
    }
}