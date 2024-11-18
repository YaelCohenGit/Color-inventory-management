using BL;
using BL.API;
using BL.DTO;
using BL.Implementation;
using DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        ColorsService colorsService;
        public ColorsController(BLManager blManager)
        {
            this.colorsService = blManager.colorsService;
        }

        [HttpGet("getAllColors")]
        public List<ColorDTO> GetAllColors()
        {
            return colorsService.GetAllColors();
        }
        [HttpPost("addNewColor")]
        public int AddColor([FromBody] Color newColor)
        {
            ColorDTO c = new ColorDTO(newColor.colorId, newColor.ColorName, newColor.Price, newColor.IsInStock, newColor.presentationOrder);
            return colorsService.AddColor(c);
        }
        [HttpPost("deleteColor")]
        public bool DeleteColor([FromBody] Color colorToDelete)
        {
            return colorsService.DeleteColor(colorToDelete);
        }
        [HttpPost("editColor")]
        public void UpdateColor([FromBody] Color colorToUpdate)
        {
            colorsService.UpdateColor(colorToUpdate);
        }
    }
}
