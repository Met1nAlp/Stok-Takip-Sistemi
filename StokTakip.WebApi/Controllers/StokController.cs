using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StokController : ControllerBase
    {
        private readonly IStokService _stokService;

        public StokController(IStokService stokService)
        {
            _stokService = stokService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StokGetir(int id)
        {
            var stok = await _stokService.GetByIdAsync(id);
            if (stok == null)
            {
                return NotFound();
            }
            return Ok(stok);
        }

        [HttpGet("urun/{urunId}")]
        public async Task<IActionResult> UrununStogunuGetir(int urunId)
        {
            var stok = await _stokService.GetStokByUrunIdAsync(urunId);
            if (stok == null)
            {
                return NotFound();
            }
            return Ok(stok);
        }

        [HttpPost]
        public async Task<IActionResult> StokEkle([FromBody] StokEkleDto stokEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniStok = await _stokService.AddAsync(stokEkleDto);

            return CreatedAtAction(nameof(StokGetir), new { id = yeniStok.stokID }, yeniStok);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> StokGuncelle(int id, [FromBody] StokGuncelleDto stokGuncelleDto)
        {
            if (id != stokGuncelleDto.stokID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenStok = await _stokService.UpdateAsync(id, stokGuncelleDto);
            if (guncellenenStok == null)
            {
                return NotFound();
            }

            return Ok(guncellenenStok);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> StokSil(int id)
        {
            var basariliMi = await _stokService.DeleteAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}