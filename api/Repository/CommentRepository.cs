using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfacses;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleyeAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == id);

            if (comment == null)
            {
                return null;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;

        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();

        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            return comment;

        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto updateComment)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.ID == id);

            if (commentModel == null)
            {
                return null;
            }

            commentModel.Title = updateComment.Title;
            commentModel.Content = updateComment.Content;

            await _context.SaveChangesAsync();
            return commentModel;

        }
    }
}