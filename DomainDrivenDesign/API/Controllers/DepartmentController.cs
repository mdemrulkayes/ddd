using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Departments;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(AddDepartmentResponse))]
        public async Task<IActionResult> Create([FromBody] AddDepartmentRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var dept = await _departmentService.CreateDepartment(request);
                return Ok(dept);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
