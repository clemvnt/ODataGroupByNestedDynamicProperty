namespace ODataGroupByNestedDynamicProperty.Models;

public class Customer
{
    public int Id { get; set; }

    public required Address Address { get; set; }
}
