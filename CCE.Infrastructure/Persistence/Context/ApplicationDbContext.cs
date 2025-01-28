﻿using Microsoft.EntityFrameworkCore;

namespace CCE.Infrastructure.Persistence.Context;

public class ApplicationDbContext:DbContext
{  public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : 
        base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
}