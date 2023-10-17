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
    public class RolesController : ODataController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public RolesController()
        {
        }

        // GET: api/Roles
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            var list = _unitOfWork.RoleRepository.Get();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET: api/Roles/5
        [EnableQuery]
        [HttpGet("{key}")]
        public async Task<IActionResult> GetById(int key)
        {
            var item = await _unitOfWork.RoleRepository.GetByIDAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.RoleRepository.Update(role);
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(Role role)
        {

            try
            {
                await _unitOfWork.RoleRepository.Insert(role);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (IsExists(role.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Post", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIDAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _unitOfWork.RoleRepository.Delete(role);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private bool IsExists(int id)
        {
            var list = _unitOfWork.RoleRepository.Get();
            return (list.ToList().Any(e => e.Id == id));
        }
    }
}
