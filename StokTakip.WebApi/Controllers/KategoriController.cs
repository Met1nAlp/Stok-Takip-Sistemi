using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<IActionResult> TumKategorileriGetir()
        {
            var kategoriler = await _kategoriService.GetAllCategoriesAsync();
            return Ok(kategoriler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> KategoriDetayGetir(int id)
        {
            var kategori = await _kategoriService.GetCategoryByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return Ok(kategori);
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle([FromBody] KategoriEkleDto kategoriEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniKategori = await _kategoriService.AddCategoryAsync(kategoriEkleDto);

            return CreatedAtAction(nameof(KategoriDetayGetir), new { id = yeniKategori.KategoriID }, yeniKategori);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> KategoriGuncelle(int id, [FromBody] KategoriGuncelleDto kategoriGuncelleDto)
        {
            if (id != kategoriGuncelleDto.kategoriID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenKategori = await _kategoriService.UpdateCategoryAsync(id, kategoriGuncelleDto);
            if (guncellenenKategori == null)
            {
                return NotFound();
            }

            return Ok(guncellenenKategori);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> KategoriSil(int id)
        {
            var basariliMi = await _kategoriService.DeleteCategoryAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}