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
    public class UsersController : ODataController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public UsersController()
        {
        }

        // GET: api/Users
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            var list = _unitOfWork.UserRepository.Get();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET: api/Users/5
        [EnableQuery]
        [HttpGet("{key}")]
        public async Task<IActionResult> GetById(int key)
        {
            var item = await _unitOfWork.UserRepository.GetByIDAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.UserRepository.Update(user);
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {

            try
            {
                await _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (IsExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Post", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIDAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private bool IsExists(int id)
        {
            var list = _unitOfWork.UserRepository.Get();
            return (list.ToList().Any(e => e.Id == id));
        }
    }
}
