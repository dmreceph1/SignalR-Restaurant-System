using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Businesslayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _service;

        public SocialMediaController(ISocialMediaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _service.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Title = createDto.Title,
                Url = createDto.Url,
                Icon = createDto.Icon
            };
            _service.TAdd(socialMedia);
            return Ok("Sosyal medya başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _service.TGetByID(id);
            _service.TDelete(value);
            return Ok("Sosyal medya silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                SocialMediaID = updateDto.SocialMediaID,
                Title = updateDto.Title,
                Url = updateDto.Url,
                Icon = updateDto.Icon
            };
            _service.TUpdate(socialMedia);
            return Ok("Sosyal medya güncellendi");
        }
    }
}
