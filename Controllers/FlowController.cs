using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Api.Extensions;
using Api.Domain.Models;
using Api.Domain.Services;
using Api.Resources;




namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {

        private readonly IMoneyFlowService moneyFlowServices;
        private readonly IMapper mapper;
        public FlowController(IMoneyFlowService moneyFlowServices, IMapper mapper)
        {
            this.moneyFlowServices = moneyFlowServices;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<FlowResources>> ListAsync()
        {
            var categories = await moneyFlowServices.ListAsync();
            var resource = mapper.Map<IEnumerable<MoneyFlow>, IEnumerable<FlowResources>>(categories);
            return resource;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> FindByIdAsync(Guid id)
        {
            var resault = await moneyFlowServices.FindByIdAsync(id);
            if (!resault.Success)
                return BadRequest(resault.Message);
            var categoryResource = mapper.Map<MoneyFlow, FlowResources>(resault.MoneyFlow);
            return Ok(categoryResource);
        }


        [HttpGet("Find-By-Category/{categoryId:Guid}")]
        
        public async Task<IActionResult> FindByCategoryAsync(Guid categoryId)
        {
            var categories = await moneyFlowServices.FindByCategoryAsync(categoryId);
            var resource = mapper.Map<IEnumerable<MoneyFlow>, IEnumerable<FlowResources>>(categories);
            return Ok(resource);
        }


        [HttpGet("Find-By-Category-Type/{categoryTypeId:Guid}")]

        public async Task<IActionResult> FindByCategoryTypeAsync(Guid categoryTypeId)
        {
            var categoryType = await moneyFlowServices.FindByCategoryTypeAsync(categoryTypeId);
            var resource = mapper.Map<IEnumerable<MoneyFlow>, IEnumerable<FlowResources>>(categoryType);
            return Ok(resource);
        }



        [HttpGet("{date:DateTime}")]
        public async Task<IActionResult> FindByDateAsync(DateTime date)
        {
            var categories = await moneyFlowServices.FindByDateAsync(date);
            var resource = mapper.Map<IEnumerable<MoneyFlow>, IEnumerable<FlowResources>>(categories);
            return  Ok(resource); 
            
        }




        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFlowResources resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = mapper.Map<SaveFlowResources, MoneyFlow>(resource);
            var resault = await moneyFlowServices.SaveAsync(category);
            if (!resault.Success)
                return BadRequest(resault.Message);
            var categoryResource = mapper.Map<MoneyFlow, FlowResources>(resault.MoneyFlow);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] SaveFlowResources resource, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = mapper.Map<SaveFlowResources, MoneyFlow>(resource);
            var resault = await moneyFlowServices.UpdateAsync(id, category);
            if (!resault.Success)
                return NotFound(resault.Message);
            var categoryResource = mapper.Map<MoneyFlow, FlowResources>(resault.MoneyFlow);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var resault = await moneyFlowServices.DeleteAsync(id);
            if (!resault.Success)
                return NotFound(resault.Message);
            var categoryResource = mapper.Map<MoneyFlow, FlowResources>(resault.MoneyFlow);
            return Ok(categoryResource);
        }
    }
}
