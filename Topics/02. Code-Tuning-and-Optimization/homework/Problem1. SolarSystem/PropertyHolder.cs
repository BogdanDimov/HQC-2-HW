using System.Windows;

namespace Surfaces
{
    public class PropertyHolder<PropertyType, HoldingType> where HoldingType : DependencyObject
    {
        public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            Property =
                DependencyProperty.Register(
                    name,
                    typeof(PropertyType),
                    typeof(HoldingType),
                    new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property { get; }

        public PropertyType Get(HoldingType obj)
        {
            return (PropertyType) obj.GetValue(Property);
        }

        public void Set(HoldingType obj, PropertyType value)
        {
            obj.SetValue(Property, value);
        }
    }
}