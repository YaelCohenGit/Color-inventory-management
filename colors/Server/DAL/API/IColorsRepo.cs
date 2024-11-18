using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public interface IColorsRepo
    {
        List<Color> GetAllColors();
        Color Get(int id);
        int AddColor(Color c);
        void UpdateColor(Color owner);
        bool DeleteColor(Color colorToDelete);
    }
}
