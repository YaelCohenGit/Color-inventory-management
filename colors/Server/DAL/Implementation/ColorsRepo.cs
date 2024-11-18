using DAL.API;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class ColorsRepo : IColorsRepo
    {
        DBContext context;
        public ColorsRepo(DBContext context)
        {
            this.context = context;
        }
        public List<Color> GetAllColors()
        {
            return context.Colors.ToList();
        }
        public Color Get(int id)
        {
            try
            {
                return context.Colors.Where(c => c.colorId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception($"Error in getting single color {id} data");
            }
        }
        public int AddColorB(Color newColor)
        {
            try
            {
                var isExists = context.Colors.Any(c => c.ColorName == newColor.ColorName);
                if (!isExists)
                {
                    var result = context.Colors.Add(newColor);
                    context.SaveChanges();
                    return result.Entity.colorId;
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new color");
            }
        }
        public int AddColor(Color newColor)
        {
            try
            {
                var isExists = context.Colors.Any(c => c.ColorName == newColor.ColorName);
                if (!isExists)
                {
                    var result = context.Colors.Add(newColor);
                    context.SaveChanges();
                    return result.Entity.colorId;
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new color");
            }
        }
        public bool DeleteColor(Color colorToDelete)
        {
            var colorInDb = context.Colors.FirstOrDefault(c => c.colorId == colorToDelete.colorId);
            if (colorInDb != null)
            {
                context.Colors.Remove(colorInDb);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void UpdateColor(Color color)
        {
            var colorInDb = context.Colors.FirstOrDefault(c => c.colorId == color.colorId);
            if (colorInDb != null)
            {
                colorInDb.ColorName = color.ColorName;
                colorInDb.Price = color.Price;
                colorInDb.IsInStock = color.IsInStock;
                colorInDb.presentationOrder = color.presentationOrder;
                context.SaveChanges();
            }
        }
    }
}
