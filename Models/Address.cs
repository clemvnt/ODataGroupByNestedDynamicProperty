namespace ODataGroupByNestedDynamicProperty.Models;

public class Address
{
  public string City { get; set; }

  public Dictionary<string, object> DynamicProperties { get; }

  public Address(string city)
  {
    City = city;
    DynamicProperties = new Dictionary<string, object>() { ["DynamicCity"] = city };
  }
}