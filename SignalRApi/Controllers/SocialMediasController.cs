﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService categoryService, IMapper mapper)
        {
            _socialMediaService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url
            });
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url
            });
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}
