using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
            => Ok(_mapper.Map<List<ResultFeatureDto>>(await _featureService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            await _featureService.TAddAsync(feature);
            return Ok("Öne Çıkan Alan Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var itemToDelete = await _featureService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Öne Çıkan Alan bulunamadı");
            await _featureService.TDeleteAsync(itemToDelete);
            return Ok("Öne Çıkan Alan Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var feature = await _featureService.TGetByIDAsync(id);
            if (feature == null)
                return NotFound();
            var dto = _mapper.Map<ResultFeatureDto>(feature);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature(int id, UpdateFeatureDto updateFeatureDto)
        {
            var feature = await _featureService.TGetByIDAsync(id);
            if (feature == null)
                return NotFound("Öne Çıkan Alan bulunamadı");
            _mapper.Map(updateFeatureDto, feature);
            await _featureService.TUpdateAsync(feature);
            return Ok("Öne Çıkan Alan Güncellendi");
        }
    }
}