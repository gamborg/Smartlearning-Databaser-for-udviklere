using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Models;
using Skoleinfo.Api.Repositories;
using System.Reflection;

namespace Skoleinfo.Api.Endpoints
{
    public static class SkoleinfoEndpoints
    {

        public static void MapSkoleinfoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            MapInstitionerEndpoints(endpoints);
        }

        public static void MapInstitionerEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/institutioner", async (ISkoleinfoRepository<Institutioner> repository) =>
            {
                var result = await repository.GetAllAsync();
                return Results.Ok(result);
            });

            endpoints.MapGet("/api/institutioner/{id}", async (Guid id, ISkoleinfoRepository<Institutioner> repository) =>
            {
                var entity = await repository.GetByIdAsync(id);
                return entity != null ? Results.Ok(entity) : Results.NotFound();
            });
        }
    }
}
