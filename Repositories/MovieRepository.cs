﻿using Microsoft.EntityFrameworkCore;
using MovieMania.Data;
using MovieMania.DTOs.Movie;
using MovieMania.Helpers;
using MovieMania.Interfaces.Repositories;
using MovieMania.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieMania.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _context;

        public MovieRepository(ApplicationDBContext context)
        {
            _context = context;
            
        }

        public async Task<Movie> CreateAsync(Movie movieModel)
        {
            await _context.Movie.AddAsync(movieModel);
            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var movieModel = await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
          if(movieModel == null)
            {
                return null;
            }

            _context.Movie.Remove(movieModel);
            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task<List<Movie>> GetAllAsync(QueryObject query)
        {
            var movies =   _context.Movie.Include(c => c.Comments).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(query.MovieName))
            {
                movies = movies.Where(s => s.MovieName.Contains(query.MovieName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Rating", StringComparison.OrdinalIgnoreCase))
                {
                    if ((bool)query.IsDescending)
                    {
                        movies = movies.OrderByDescending(s => s.Rating);
                    }
                    else
                    {
                        movies = movies.OrderBy(s => s.Rating);
                    }
                }


            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await movies.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }


        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movie.Include(c=>c.Comments).FirstOrDefaultAsync(i=> i.Id == id);
        }

        public async Task<bool> MovieExists(int id)
        {
            return await  _context.Movie.AnyAsync(s => s.Id == id);
        }

        public async Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movieDto)
        {
            var existingMovie = await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
            if(existingMovie == null)
            {
                return null;
            }

           existingMovie.MovieName = movieDto.MovieName;
           existingMovie.Rating = movieDto.Rating;
           existingMovie.ReleasedDate = movieDto.ReleasedDate;


            await _context.SaveChangesAsync();
            return existingMovie;

        }
    }
}
