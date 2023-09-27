using ApiTraining.Models;
using ApiTraining.Models.Dto;

namespace ApiTraining.Services
{
    public interface IPlaceServices
    {
        Task<List<Place>> GetAllAsync();

        Task<Place> GetbyIdAsync(Guid id);

        Task<Place> CreateAsync(Place place);

        Task<Place> UpdateAsync(Place place, PlaceCreateDto placeCreateDto);

        Task<Place> DeleteAsync(Place place);
    }
}
