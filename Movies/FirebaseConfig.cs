using Movies.Dtos;
using Movies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    internal class FirebaseConfig
    {
        public static async Task<List<MovieDTO>> GetMovies()
        {
            try
            {

                var client = new HttpClient();

                var response = await client.GetAsync("https://assignment-de170-default-rtdb.europe-west1.firebasedatabase.app/movies.json");
                var data = await response.Content.ReadAsStringAsync();

                List<MovieDTO> movies = JsonConvert.DeserializeObject<List<MovieDTO>>(data);

                return movies;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
