﻿using Microsoft.EntityFrameworkCore;
using DataAccess.EntityConfigurations;
using DataAccess.Entities;

namespace DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        if (Database.CanConnect() is false)
        {
            Database.EnsureCreated();
        }
    }

    public DbSet<AuthorDb> Authors { get; set; }
    public DbSet<BookDb> Books { get; set; }
    public DbSet<PersonDb> Persons { get; set; }
    public DbSet<GenreDb> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}