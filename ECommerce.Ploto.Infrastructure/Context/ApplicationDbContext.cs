﻿using ECommerce.Ploto.Common.Dommin.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IMediator mediator): base(options)   
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents();
            try
            {
                return await base.SaveChangesAsync(cancellationToken);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        private async Task PublishDomainEvents()
        {
            var entitiesWithDomainEvens =
                this.ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());



            var domainEvents = entitiesWithDomainEvens
                .SelectMany(x=> x.Entity.DomainEvents)
                .ToList();

            entitiesWithDomainEvens.ToList()
                .ForEach(entity=> entity.Entity.ClearDomainEvents());

            var tasks = domainEvents.Select(async x => { await _mediator.Publish(x); });

            await Task.WhenAll(tasks);


        }

    }
}
