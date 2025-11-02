using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FiyatController : ControllerBase
    {
        private readonly IFiyatService _fiyatService;

        public FiyatController(IFiyatService fiyatService)
        {
            _fiyatService = fiyatService;
        }

        [HttpGet]
        public async Task<IActionResult> TumFiyatlariGetir()
        {
            var fiyatlar = _fiyatService.GetAllAsync();

            return Ok(fiyatlar);
        }

        [HttpGet]
        public async Task<IActionResult> FiyatDetayGetir(int fiyatId)
        {
            var fiyat = _fiyatService.GetByIdAsync(fiyatId);

            return Ok(fiyat);
        }

        [HttpPost]
        public async Task<IActionResult> FiyatEkle([FromBody] FiyatEkleDto fiyatEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniFiyat = await _fiyatService.CreateAsync(fiyatEkleDto);

            return CreatedAtAction(nameof(FiyatDetayGetir), new { id = yeniFiyat.FiyatID }, yeniFiyat);
        }

        [HttpPut]
        public async Task<IActionResult> FiyatGuncelle(int id, [FromBody] FiyatGuncelleDto fiyatGuncelleDto)
        {
            if (id != fiyatGuncelleDto.fiyatID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenFiyat = await _fiyatService.UpdateAsync(id, fiyatGuncelleDto);
            if (guncellenenFiyat != null)
            {
                return NotFound();
            }

            return Ok(guncellenenFiyat);
        }

        public async Task<IActionResult> FiyatSil(int id)
        {
            var basariliMi = await _fiyatService.DeleteAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
