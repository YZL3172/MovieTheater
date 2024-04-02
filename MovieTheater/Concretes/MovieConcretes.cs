using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater.Concretes
{
    public class MovieConcretes : IMovie
    {
        MovieTheaterContext context = new MovieTheaterContext();

        public void AddMovie()
        {
            Movie m = new Movie();
            try
            {
            Console.WriteLine("Eklemek istediğiniz filmin ismi:");
            m.Title = Console.ReadLine();
            Console.WriteLine("Filmin açıklaması:");
            m.Description = Console.ReadLine();
            Console.WriteLine("Süresi:");
            m.Duration = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Raiting:");
            string rating = Console.ReadLine();
            if (!string.IsNullOrEmpty(rating))
            { m.Rating = Convert.ToInt32(rating); }

            Console.WriteLine("Kategori id:");
            string gId = Console.ReadLine();
            if (!string.IsNullOrEmpty(gId))
            { m.GenreId = Convert.ToInt32(gId); }
            context.Movies.Add(m);
            context.SaveChanges();
        }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


}

        public string GetMovie(int girilenId)
        {
            Movie m1 = context.Movies.Find(girilenId);
            if (girilenId != null)
            {
                return m1.Title;


            }
            else
            {
                return "Bulunamadı";

            }

        }

        public void RemoveMovie(int dId)
        { Movie m2 = context.Movies.Find(dId);
            if (dId != null)
            {
                context.Movies.Remove(m2);
                context.SaveChanges();
                
            }

        }

        public void UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
