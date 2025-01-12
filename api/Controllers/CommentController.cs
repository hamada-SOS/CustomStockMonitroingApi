using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfacses;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
                return BadRequest();

            var comments = await _commentRepo.GetAllAsync();
            var CommentDto = comments.Select(s => s.ToCommentDto());
            return Ok(CommentDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return null;
            }

            return Ok(comment.ToCommentDto());
        }


        [HttpPost("{stock_id:int}")]
        public async Task<IActionResult> Create([FromRoute] int stock_id, CreateCommentDto commentDto)
        {
            if (ModelState.IsValid)
                return BadRequest();

            if (!await _stockRepo.StoclExists(stock_id))
            {
                return BadRequest("Stock Not Found");
            }

            var commentModel = commentDto.ToCommentFromCreateDto(stock_id);

            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.ID }, commentModel.ToCommentDto());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var comment = await _commentRepo.DeleyeAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateComment)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var comment = await _commentRepo.UpdateAsync(id, updateComment);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());


        }
    }
}