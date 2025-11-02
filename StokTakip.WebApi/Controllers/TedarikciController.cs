using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TedarikciController : ControllerBase
    {
        private readonly ITedarikciService _tedarikciService;

        public TedarikciController(ITedarikciService tedarikciService)
        {
            _tedarikciService = tedarikciService;
        }

        [HttpGet]
        public async Task<IActionResult> TumTedarikcileriGetir()
        {
            var tedarikciler = await _tedarikciService.GetAllAsync();
            return Ok(tedarikciler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TedarikciGetir(int id)
        {
            var tedarikci = await _tedarikciService.GetByIdAsync(id);
            if (tedarikci == null)
            {
                return NotFound();
            }
            return Ok(tedarikci);
        }

        [HttpGet("{id}/detay")]
        public async Task<IActionResult> TedarikciDetayGetir(int id)
        {
            var tedarikciDetay = await _tedarikciService.GetDetayByIdAsync(id);
            if (tedarikciDetay == null)
            {
                return NotFound();
            }
            return Ok(tedarikciDetay);
        }

        [HttpPost]
        public async Task<IActionResult> TedarikciEkle([FromBody] TedarikciEkleDto tedarikciEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniTedarikci = await _tedarikciService.AddAsync(tedarikciEkleDto);

            return CreatedAtAction(nameof(TedarikciGetir), new { id = yeniTedarikci.tedarikciID }, yeniTedarikci);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> TedarikciGuncelle(int id, [FromBody] TedarikciGuncelleDto tedarikciGuncelleDto)
        {
            if (id != tedarikciGuncelleDto.tedarikciID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenTedarikci = await _tedarikciService.UpdateAsync(id, tedarikciGuncelleDto);
            if (guncellenenTedarikci == null)
            {
                return NotFound();
            }

            return Ok(guncellenenTedarikci);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> TedarikciSil(int id)
        {
            var basariliMi = await _tedarikciService.DeleteAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}