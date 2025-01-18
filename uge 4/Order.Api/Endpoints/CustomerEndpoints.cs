using OrderApi.Models;
using OrderApi.Repository;

namespace OrderApi.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/api/customers", async (IUnitOfWork unitOfWork) =>
            {
                var customers = await unitOfWork.Customers.GetAllAsync();
                return Results.Ok(customers);
            })
            .WithName("GetCustomers");

            app.MapGet("/api/customers/{id}", async (IUnitOfWork unitOfWork, int id) =>
            {
                var customer = await unitOfWork.Customers.GetAsync(id);
                if (customer == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(customer);
            })
            .WithName("GetCustomerById");

            app.MapGet("/api/customers/{id}/orders", async (IUnitOfWork unitOfWork, int id) =>
            {
                var customer = await unitOfWork.Customers.GetWithOrdersAsync(id);
                if (customer == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(customer);
            })
            .WithName("GetCustomerOrdersByCustomerId");

            app.MapPost("/api/customers", async (IUnitOfWork unitOfWork, Customer customer) =>
            {
                await unitOfWork.Customers.AddAsync(customer);
                await unitOfWork.Complete();
                return Results.Created($"/api/customers/{customer.Id}", customer);
            })
            .WithName("CreateCustomer");

            app.MapPut("/api/customers/{id}", async (IUnitOfWork unitOfWork, int id, Customer customer) =>
            {
                if (id != customer.Id)
                {
                    return Results.BadRequest();
                }
                var existingCustomer = await unitOfWork.Customers.GetAsync(id);
                if (existingCustomer == null)
                {
                    return Results.NotFound();
                }

                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.City = customer.City;
                existingCustomer.Country = customer.Country;
                existingCustomer.Phone = customer.Phone;

                await unitOfWork.Complete();
                return Results.Ok(existingCustomer);
            })
            .WithName("UpdateCustomer");

            app.MapDelete("/api/customers/{id}", async (IUnitOfWork unitOfWork, int id) =>
            {
                var existingCustomer = await unitOfWork.Customers.GetAsync(id);
                if (existingCustomer == null)
                {
                    return Results.NotFound();
                }
                await unitOfWork.Customers.RemoveAsync(existingCustomer);
                await unitOfWork.Complete();
                return Results.NoContent();
            })
            .WithName("DeleteCustomer");
        }
    }
}
