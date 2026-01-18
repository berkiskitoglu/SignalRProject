using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService FeatureService, IMapper mapper)
        {
            _featureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var featureList = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(featureList);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(feature);
            return Ok("Öne Çıkan Alan Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var itemToDelete = _featureService.TGetByID(id);
            _featureService.TDelete(itemToDelete);
            return Ok("Öne Çıkan Alan Silindi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var getFeatureById = _featureService.TGetByID(id);
            return Ok(getFeatureById);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _featureService.TGetByID(updateFeatureDto.FeatureID);
            if (feature == null)
            {
                return NotFound("Öne Çıkan Alan bulunamadı");
            }
            _mapper.Map(updateFeatureDto, feature);
            _featureService.TUpdate(feature);
            return Ok("Öne Çıkan Alan Güncellendi");
        }
    }
}
