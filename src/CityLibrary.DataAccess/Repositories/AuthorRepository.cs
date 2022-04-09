﻿using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.Domain.Models;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.Repositories;

public sealed class AuthorRepository : BaseRepository<Author, AuthorDb>, IAuthorRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public AuthorRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Authors, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await _context.Books
            .Where(book => book.AuthorId == authorId)
            .Include(book => book.Genre)
            .Include(book => book.Author)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(books);
    }
}