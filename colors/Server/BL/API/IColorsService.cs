using BL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IColorsService
    {
        public int AddColor(ColorDTO c);
        public List<ColorDTO> GetAllColors();
        public ColorDTO Get(int id);
        public void UpdateColor(Color c);
    }
}
