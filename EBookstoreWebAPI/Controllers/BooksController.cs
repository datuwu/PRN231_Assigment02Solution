using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Repositories.UnitOfWork;

namespace EBookstoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ODataController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public BooksController()
        {
        }

        // GET: api/Books
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            var list = _unitOfWork.BookRepository.Get();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET: api/Books/5
        [EnableQuery]
        [HttpGet("{key}")]
        public async Task<IActionResult> GetById(int key)
        {
            var item = await _unitOfWork.BookRepository.GetByIDAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.BookRepository.Update(book);
                await _unitOfWork.SaveAsync();

                if (!IsExists(id))
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }



            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {

            try
            {
                await _unitOfWork.BookRepository.Insert(book);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (IsExists(book.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Post", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _unitOfWork.BookRepository.GetByIDAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private bool IsExists(int id)
        {
            var list = _unitOfWork.BookRepository.Get();
            return (list.ToList().Any(e => e.Id == id));
        }
    }
}

