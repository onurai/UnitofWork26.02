using Mask.Dto;
using Mask.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Task.Data.Context;
using Task.Data.Entities;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IUnitOfWork unitOfWork, ILogger<AuthorController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted at {0}", DateTime.Now);
            var result = await _unitOfWork.authorRepository.GetAll().ToListAsync();
            _logger.LogWarning($"Request Successfully  completed at {DateTime.Now}, and result is {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorDto author)
        {
            if (ModelState.IsValid != true)
            {
                return BadRequest(ModelState);
            }
             
            Author auther = new()
            {
                AuthorName = author.AuthorName,
                Surname = author.Surname
            };
            await _unitOfWork.authorRepository.Add(auther);
            await _unitOfWork.Commit();

            return Ok(auther);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string authorName, string surname)
        {
            var author = await _unitOfWork.authorRepository.Find(id);

            author.AuthorName = authorName;
            author.Surname = surname;
            await _unitOfWork.authorRepository.Update(author);
            await _unitOfWork.Commit();
            return Ok(author);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var result = await _unitOfWork.authorRepository.Find(id);
                _logger.LogInformation($"Author got from db with Id of {id}");
                await _unitOfWork.authorRepository.Delete(result);
                _logger.LogDebug($"Author deleted from db with Id of {id}");
                await _unitOfWork.Commit();
                _logger.LogInformation($"Request is completed successfully, Author with ID of {id} and name of {result.AuthorName}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured when deleting the student ith id of {id}");
                throw ex;
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _unitOfWork.authorRepository.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
