using System.Collections.Generic;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Domain.Models;
using AutoMapper;
using Api.Resources;
using Api.Extensions;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesTypeController:Controller
    {
        private readonly ICategoryTypeService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesTypeController(ICategoryTypeService categoryService ,IMapper mapper)
        {
            _categoryService=categoryService;
            _mapper=mapper;
        }

        [HttpGet ]
        public async Task<IEnumerable<TypeResource>>GetAllAsync(){
            var categories =await _categoryService.ListAsync();
            var resources=_mapper.Map<IEnumerable<CategoriesType>,IEnumerable<TypeResource>>(categories);
            return resources;

        }




        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveTypeResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category=_mapper.Map<SaveTypeResource,CategoriesType>(resource);
            var resault= await _categoryService.SaveAsync(category);
            if(!resault.Success)
                return BadRequest(resault.Message);

            var CategoryResource=_mapper.Map<CategoriesType,TypeResource>(resault.CategoriesType);
            return Ok(CategoryResource);        
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetByIdAsync(Guid id)
        {
            var resault =await _categoryService.GetByIdAsync(id);
            if(!resault.Success)
                return BadRequest(resault.Message);
            var CategoryResource=_mapper.Map<CategoriesType,TypeResource>(resault.CategoriesType);
                return Ok(CategoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id,[FromBody]SaveTypeResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category=_mapper.Map<SaveTypeResource,CategoriesType>(resource);
            var resault= await _categoryService.UpdateAsync(id,category);
            if(!resault.Success)
                return NotFound(resault.Message);

            var CategoryResource=_mapper.Map<CategoriesType,TypeResource>(resault.CategoriesType);
            return Ok(CategoryResource);        
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id){
            var resault =await _categoryService.DeleteAsync(id);
            if(!resault.Success)
                return BadRequest(resault.Message);
            var CategoryResource=_mapper.Map<CategoriesType,TypeResource>(resault.CategoriesType);
                return Ok(CategoryResource);
        }

    }



}


