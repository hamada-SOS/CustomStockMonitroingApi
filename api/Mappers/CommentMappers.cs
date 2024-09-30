using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment CommentModel)
        {
            return new CommentDto
            {
                ID = CommentModel.ID,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                StockID = CommentModel.StockID,
            };

        }

        public static CommentDto ToCommentFromCreateDto(this CreateCommentDto commentDto, int stock_id)
        {
            return new CommentDto
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockID = stock_id
            };

        }
    }
}