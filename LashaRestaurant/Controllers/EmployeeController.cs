using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using LashaRestaurant.Business;
using LashaRestaurant.DataAccess.Models;
using LashaRestaurant.Models.Employee.Post;
using LashaRestaurant.Models.Employee.Put;
using Employee = LashaRestaurant.Models.Employee.Get.Employee;

namespace LashaRestaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<Employee>> Get()
        {
            var dbModels = await _service.GetAll();

            var viewModels = _mapper.Map<IList<Employee>>(dbModels);

            return viewModels;
        }

        [HttpPost]
        public async Task<Employee> Create(EmployeePost model)
        {
            var dbModel = _mapper.Map<LashaRestaurant.DataAccess.Models.Employee>(model);

            var response= await _service.Create(dbModel);

            var viewModels = _mapper.Map<Employee>(response);

            return viewModels;
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Update(EmployeePut model)
        {
            var dbModel = _mapper.Map<LashaRestaurant.DataAccess.Models.Employee>(model);

            var response = await _service.Update(dbModel);

            if (response == null)
            {
                return NotFound();
            }

            var viewModels = _mapper.Map<Employee>(response);

            return Ok(viewModels);
        }
    }
}
