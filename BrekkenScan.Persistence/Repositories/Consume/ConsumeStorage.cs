﻿using BrekkenScan.Business;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BrekkenScan.Persistence.Repositories.Consume
{
    public class ConsumeStorage : IConsumeStorage
    {
        private readonly ApplicationDbContext _database;

        public ConsumeStorage(ApplicationDbContext database)
        {
            _database = database;
        }

        public async Task Add(Domain.Models.Consume consume)
        {
            await _database.Consume.AddAsync(consume);
            await _database.SaveChangesAsync();
        }

        public async Task<Paginated<Domain.Models.ConsumeReading>> Get(Domain.ConsumeFilter filter)
        {
            var query = _database.Consume
                .AsQueryable()
                .Filter(filter);

            return new Paginated<Domain.Models.ConsumeReading>
            {
                Total = await query.CountAsync(),
                Result = (await query.ToListAsync()).Select(c => new ConsumeReading
                {
                    Id = c.Id,
                    Barcode = c.Barcode,
                    Product = GetBrand(c),
                    TimeStamp = c.TimeStamp
                }).ToList()
            };
        }

        public async Task<ConsumeReadModel> GetConsume(Domain.ConsumeFilter filter)
        {
            return new ConsumeReadModel
            {
                Total = await _database.Consume.CountAsync(),
                Tonight = _database.Consume
                    .Where(c => c.TimeStamp > DateTime.Now.AddHours(-13))
                    .ToList()
                    .Select(c => GetBrand(c))
                    .ToList()
            };
        }

        private string GetBrand(Domain.Models.Consume consume)
            => _database.Brand.FirstOrDefault(brand => brand.Barcode == consume.Barcode)?.Name ?? "Ukjent";
    }
}
