using BL.API;
using BL.DTO;
using DAL;
using DAL.Implementation;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Implementation
{
    public class ColorsService : IColorsService 
    {
        ColorsRepo colors;
        public ColorsService(DalManager manager)
        {
            this.colors = manager.Colors;
        }
        public int AddColor(ColorDTO colorDTO)
        {
            Color c = new Color();
            c.ColorName = colorDTO.ColorName;
            c.Price = colorDTO.Price;
            c.IsInStock = colorDTO.IsInStock;
            c.presentationOrder = colorDTO.presentationOrder;
            return colors.AddColor(c);
        }
        public List<ColorDTO> GetAllColors()
        {
            List<Color> list = colors.GetAllColors();
            List<ColorDTO> result = new List<ColorDTO>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(new ColorDTO(list[i].colorId, list[i].ColorName, list[i].Price, list[i].IsInStock, list[i].presentationOrder));
            }
            return result;
        }
        public ColorDTO Get(int id)
        {
            Color c = colors.Get(id);
            if (c == null)
            {
                return null;
            }
            ColorDTO colorDTO = new ColorDTO(c.colorId, c.ColorName, c.Price, c.IsInStock, c.presentationOrder);
            return colorDTO;
        }
        public bool DeleteColor(Color colorToDelete)
        {
            return colors.DeleteColor(colorToDelete);
        }
        public void UpdateColor(Color color)
        {
            colors.UpdateColor(color);
        }
    }
}
