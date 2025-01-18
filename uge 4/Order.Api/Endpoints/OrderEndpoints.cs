    using OrderApi.Models;
using OrderApi.Repository;

namespace OrderApi.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this WebApplication app)
        {
            app.MapGet("/api/orders", async (IUnitOfWork unitOfWork) =>
            {
                var orders = await unitOfWork.Orders.GetAllAsync();
                return Results.Ok(orders);
            })
            .WithName("GetOrders");
            app.MapGet("/api/orders/{id}", async (IUnitOfWork unitOfWork, int id) =>
            {
                var order = await unitOfWork.Orders.GetAsync(id);
                if (order == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            })
            .WithName("GetOrderById");

            app.MapPost("/api/orders", async (IUnitOfWork unitOfWork, Order order) =>
            {
                await unitOfWork.Orders.AddAsync(order);
                await unitOfWork.Complete();
                return Results.Created($"/api/orders/{order.Id}", order);
            })
            .WithName("CreateOrder");

            app.MapPut("/api/orders/{id}", async (IUnitOfWork unitOfWork, int id, Order order) =>
            {
                if (id != order.Id)
                {
                    return Results.BadRequest();
                }
                var existingOrder = await unitOfWork.Orders.GetOrderWithCustomerAsync(id);
                if (existingOrder == null)
                {
                    return Results.NotFound();
                }

                //existingOrder.Customer = order.Customer.Id;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.OrderNumber = order.OrderNumber;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.OrderItems = order.OrderItems;
                await unitOfWork.Complete();
                return Results.Ok(existingOrder);
            })
            .WithName("UpdateOrder");
            app.MapDelete("/api/orders/{id}", async (IUnitOfWork unitOfWork, int id) =>
            {
                var existingOrder = await unitOfWork.Orders.GetAsync(id);
                if (existingOrder == null)
                {
                    return Results.NotFound();
                }
                await unitOfWork.Orders.RemoveAsync(existingOrder);
                await unitOfWork.Complete();
                return Results.NoContent();
            })
            .WithName("DeleteOrder");
        }
    }
}
