using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusteriController : ControllerBase
    {
        private readonly IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        [HttpGet]
        public async Task<IActionResult> TumMusterileriGetir()
        {
            var musteriler = await _musteriService.GetAllMusterilerAsync();
            return Ok(musteriler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MusteriDetayGetir(int id)
        {
            var musteri = await _musteriService.GetMusteriByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return Ok(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> MusteriEkle([FromBody] MusteriEkleDto musteriEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniMusteri = await _musteriService.AddMusteriAsync(musteriEkleDto);

            return CreatedAtAction(nameof(MusteriDetayGetir), new { id = yeniMusteri.musteriID }, yeniMusteri);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MusteriGuncelle(int id, [FromBody] MusteriGuncelleDto musteriGuncelleDto)
        {
            if (id != musteriGuncelleDto.musteriID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenMusteri = await _musteriService.UpdateMusteriAsync(id, musteriGuncelleDto);
            if (guncellenenMusteri == null)
            {
                return NotFound();
            }

            return Ok(guncellenenMusteri);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> MusteriSil(int id)
        {
            var basariliMi = await _musteriService.DeleteMusteriAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}