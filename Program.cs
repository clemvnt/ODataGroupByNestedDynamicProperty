using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataGroupByNestedDynamicProperty.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ODataModelBuilder modelBuilder = new();

EntityTypeConfiguration<Customer> customerType = modelBuilder.EntityType<Customer>();
customerType.HasKey(c => c.Id);
customerType.ComplexProperty(c => c.Address);

Type addressType = typeof(Address);
ComplexTypeConfiguration addressConfiguration = modelBuilder.AddComplexType(addressType);
addressConfiguration.AddProperty(addressType.GetProperty(nameof(Address.City)));
addressConfiguration.AddDynamicPropertyDictionary(addressType.GetProperty(nameof(Address.DynamicProperties)));

modelBuilder.EntitySet<Customer>("Customers");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        string.Empty,
        modelBuilder.GetEdmModel()));

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
