using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater.Interfaces
{
    public interface IMovie
    {
        public void AddMovie();
       public void RemoveMovie(int id);

        public void UpdateMovie(int id);

        public string GetMovie(int id);



    }
}
