using ApiTraining.Data;
using ApiTraining.Models;
using ApiTraining.Models.Dto;
using ApiTraining.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ApiTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApiDbContext _dbcontext;
        /*       public static List<Place> Places = new List<Place>
                   {
                       new Place{
                       Id = Guid.NewGuid(), // 6B29FC40-CA47-1067-B31D-00DD010662DA
                       Name = "Bishnudwar",
                       Location = "Shivapuri"
                       },
                   };
       */
    
        private readonly IPlaceServices _placeServices;
        private readonly IMapper _mapper;
        public PlacesController(ApiDbContext dbcontext, IPlaceServices placeServices, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
            _placeServices = placeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get from database
            var places = await _placeServices.GetAllAsync();

            //fetch from domain model and map to DTO.
            //var placeDto = new List<PlaceDto>();
            //foreach (var place in places)
            //{
            //    placeDto.Add(new PlaceDto
            //    {
            //        Id = place.Id,
            //        Name = place.Name,
            //        Location = place.Location,
            //    }
            //    );
            //}
            //automapper mapping to dto
            var placeDto = _mapper.Map<List<PlaceDto>>(places);
            //Return DTO
            return Ok(placeDto);
        }


        [HttpGet("{id}")]
        //[Route]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
         
            //fetch from db
            var place = await _placeServices.GetbyIdAsync(id);

          
                if (place == null)
                    return NotFound();

            //Map to DTO
            //var placeDto = new List<PlaceDto>
            //{
            //    new PlaceDto()
            //    {
            //        Id= place.Id,
            //        Name = place.Name,
            //        Location = place.Location,

            //    }
            //};
            var placeDto = _mapper.Map<PlaceDto>(place);
            //Return DTO
            return Ok(placeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlaceCreateDto placeCreateDto)
        {
          
                if (placeCreateDto == null)
                    return BadRequest();

            Place place2 = new Place
            {
                Id = Guid.NewGuid(),
                Name = placeCreateDto.Name,
                Location = placeCreateDto.Location,
            };

            var returnVal = await _placeServices.CreateAsync(place2);

            var placeNewDto = _mapper.Map<PlaceCreateDto>(returnVal);

            return Ok(placeNewDto);
        }

        [HttpPatch("{id:Guid}")]
        public IActionResult Patch([FromRoute] Guid id, [FromBody] JsonPatchDocument<Place> patchValue)
        {
            var place = _dbcontext.Places.FirstOrDefault(x => x.Id == id);

                if (place == null)
                    return BadRequest();

            patchValue.ApplyTo(place, ModelState);
            _dbcontext.SaveChanges();


            return Ok(place);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PlaceCreateDto placeCreateDto)
        {
           
                if (placeCreateDto == null)
                    return BadRequest();

    
            var place = await _placeServices.GetbyIdAsync(id);

                if (place == null)
                    return NotFound();


            var retVal = await _placeServices.UpdateAsync(place, placeCreateDto);

            var placeNewDto = _mapper.Map<PlaceDto>(retVal);

            return Ok(placeNewDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
  
            var place = await _placeServices.GetbyIdAsync(id);

          
                if (place == null)
                    return NotFound();

            var retVal = await _placeServices.DeleteAsync(place);


            var placeDto = _mapper.Map<PlaceDto>(retVal);

            return Ok(placeDto);
        }
    }
}
