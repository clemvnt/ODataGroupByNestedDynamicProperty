using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataGroupByNestedDynamicProperty.Models;

namespace ODataGroupByNestedDynamicProperty.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ODataController
{
    private static readonly Customer[] customers = Enumerable.Range(1, 4)
        .Select(idx => new Customer
        {
            Id = idx,
            Address = new Address($"City {(idx % 2 == 0 ? 1 : 2)}")
        })
        .ToArray();

    [EnableQuery]
    public ActionResult Get()
    {
        return Ok(customers);
    }
}
