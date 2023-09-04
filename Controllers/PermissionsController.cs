using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Context;
using Test.Data.Models;
using Test.DataAccess.Interfaces;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
       private readonly IRepositoryAsync<Permission> _repositoryAsync;

        public PermissionsController(IRepositoryAsync<Permission> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        [HttpGet]
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            return await _repositoryAsync.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Permission> GetPermission(int id)
        {
            return await _repositoryAsync.GetById(id);
        }

        [HttpPost]
        public async Task<Permission> PostPermission(Permission permission)
        {
            return await _repositoryAsync.Insert(permission);
        }

    }
}
