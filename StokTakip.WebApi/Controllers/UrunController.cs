using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StokTakip.Core.DTOs;
using StokTakip.Core.IRepositories;
using StokTakip.Core.IServices;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UrunController : ControllerBase
    {

        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<IActionResult> TumUrunleriGetir()
        {
            var urunler = await _urunService.GetAllAsync();
            return Ok(urunler);
        }

        [HttpGet("{id}/detay")]
        public async Task<IActionResult> UrunDetayGetir(int urunId)
        {
            var urun = await _urunService.GetDetayByIdAsync(urunId);
            return Ok(urun);
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle([FromBody] UrunEkleDto urunEkleDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniUrun = await _urunService.AddAsync(urunEkleDto);
               
            return CreatedAtAction(nameof(UrunDetayGetir), new { id = yeniUrun.urunID }, yeniUrun);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UrunGuncelle(int id, [FromBody] UrunGuncelleDto urunGuncelleDto)
        {
            if (id != urunGuncelleDto.urunID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenUrun = await _urunService.UpdateAsync(id, urunGuncelleDto); 
            if (guncellenenUrun == null)
            {
                return NotFound();
            }

            return Ok(guncellenenUrun);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UrunSil(int id)
        {
            var basariliMi = await _urunService.DeleteAsync(id); 
            
            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
}
