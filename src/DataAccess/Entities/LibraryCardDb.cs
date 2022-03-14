﻿namespace DataAccess.Entities;

public class LibraryCardDb
{
    public Guid PersonId { get; set; }
    public PersonDb Person { get; set; }

    public Guid BookId { get; set; }
    public BookDb Book { get; set; }
}