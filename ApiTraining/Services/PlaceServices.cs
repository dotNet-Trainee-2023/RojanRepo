using ApiTraining.Data;
using ApiTraining.Models;
using ApiTraining.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ApiTraining.Services
{
    public class PlaceServices : IPlaceServices
    {
        private readonly ApiDbContext _dbContext;
        public PlaceServices(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Place> CreateAsync(Place place)
        {

            await _dbContext.Places.AddAsync(place);
            await _dbContext.SaveChangesAsync();

            return place;
        }

        public async Task<Place> DeleteAsync(Place place)
        {
            _dbContext.Places.Remove(place);
            await _dbContext.SaveChangesAsync();
            return place;
        }

        public async Task<List<Place>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var places = _dbContext.Places;

            //for pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await places.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Place?> GetbyIdAsync(Guid id)
        {
            return _dbContext.Places.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Place> UpdateAsync(Place place, PlaceCreateDto placeCreateDto)
        {
            place.Location = string.IsNullOrEmpty(placeCreateDto.Location) ? place.Location : placeCreateDto.Location;
            place.Name = string.IsNullOrEmpty(placeCreateDto.Name) ? place.Name : placeCreateDto.Name;

            await _dbContext.SaveChangesAsync();

            return place;
        }
    }
}
