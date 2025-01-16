using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Models;
using Skoleinfo.Api.Repositories;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Skoleinfo.Api.Repositories.Domain;

namespace Skoleinfo.Api.Endpoints
{
    public static class SkoleinfoEndpoints
    {
        public static void MapSkoleinfoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            MapInstitutionerEndpoints(endpoints);
            MapKaraktererEndpoints(endpoints);
        }

        public static void MapInstitutionerEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/institutioner", async (IUnitOfWork unitOfWork) =>
            {
                var result = await unitOfWork.Institutioner.GetInstitutionerWithKaraktererAsync();
                var dtoResult = result.Select(i => new InstitutionerDto
                {
                    Id = i.Id,
                    Nummer = i.Nummer,
                    Navn = i.Navn,
                    Kommunenummer = i.Kommunenummer,
                    Karakterers = i.Karakterers.Select(k => new KaraktererDto
                    {
                        Id = k.Id,
                        Institutionsnummer = k.Institutionsnummer,
                        Gennemsnit = k.Gennemsnit
                    }).ToList()
                });
                return Results.Ok(dtoResult);
            });

            endpoints.MapGet("/api/institutioner/{id}", async (Guid id, IUnitOfWork unitOfWork) =>
            {
                var entity = await unitOfWork.Institutioner.GetAsync(id);
                return entity != null ? Results.Ok(entity) : Results.NotFound();
            });
        }

        public static void MapKaraktererEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/karakterer", async (IUnitOfWork unitOfWork) =>
            {
                var result = await unitOfWork.Institutioner.GetAllAsync();
                return Results.Ok(result);
            });

            endpoints.MapGet("/api/karakterer/{id}", async (Guid id, IUnitOfWork unitOfWork) =>
            {
                var entity = await unitOfWork.Institutioner.GetAsync(id);
                return entity != null ? Results.Ok(entity) : Results.NotFound();
            });
        }

    }

    public class InstitutionerDto
    {
        public Guid Id { get; set; }
        public int Nummer { get; set; }
        public string Navn { get; set; }
        public int Kommunenummer { get; set; }
        public ICollection<KaraktererDto> Karakterers { get; set; }
    }

    public class KaraktererDto
    {
        public Guid Id { get; set; }
        public int? Institutionsnummer { get; set; }
        public decimal? Gennemsnit { get; set; }
    }

    public class TrivselDataDto
    {
        public Guid TrivselID { get; set; }
        public int Institutionsnummer { get; set; }
        public int? Koen { get; set; }
        public decimal? Vaerdi { get; set; }
        public string? SporgsmaalTekst { get; set; }
        public string? SvarTekst { get; set; }
    }


}
