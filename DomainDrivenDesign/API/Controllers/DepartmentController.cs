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

        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<DepartmentResponse>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("{id:long}")]
        [ProducesDefaultResponseType(typeof(DepartmentResponse))]
        public async Task<IActionResult> Get(Int64 id)
        {
            return Ok(await _departmentService.GetDepartment(id));
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(DepartmentResponse))]
        public async Task<IActionResult> Create([FromBody] AddDepartmentRequest request)
        {
            var dept = await _departmentService.CreateDepartment(request);
            return Ok(dept);
        }


        [HttpPut("{id:long}")]
        [ProducesDefaultResponseType(typeof(DepartmentResponse))]
        public async Task<IActionResult> Update(Int64 id, [FromBody] AddDepartmentRequest request)
        {
            return Ok(await _departmentService.UpdateDepartment(id, request));
        }

        [HttpDelete("{id:long}")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<IActionResult> Delete(Int64 id)
        {
            return Ok(await _departmentService.DeleteDepartment(id));
        }
    }
}
