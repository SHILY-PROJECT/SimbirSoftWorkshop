﻿namespace DataAccess.Entities;

public class BookDb
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid AuthorId { get; set; }
    public AuthorDb Author { get; set; }
}