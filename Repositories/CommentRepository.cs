﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMania.Data;
using MovieMania.DTOs.Comments;
using MovieMania.Interfaces.Repositories;
using MovieMania.Models;

namespace MovieMania.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
   
        public CommentRepository(ApplicationDBContext context)

        {
            _context = context;
            
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await  _context.Comment.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;

        }

        public Task<Comment> CreateAsync(CommentDto commentModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
           
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

    
    }
}