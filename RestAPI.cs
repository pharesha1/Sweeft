using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SweeftTask
{
    public class RestAPI
    {

        public RestAPI() 
        {
            foreach (var country in GetCountries())
            {
                string filePath = "path/" + country.name;
                FileStream fileStream = File.Create(filePath);
                File.WriteAllText(filePath, string.Format("Region: {0}, Subregion: {1}, LatLng: {2}, Area: {3}, Population: {4}", 
                    country.region, country.subregion, country.latlng, country.area, country.population));
            }
        }

        public static List<Country> GetCountries()
        {
            List<Country> countriesList = new List<Country>();

            string url = "https://restcountries.eu/rest/v1/all";

            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string jsonResponse = null;

            jsonResponse = reader.ReadLine();

            if (jsonResponse != null)
            {
                List<Country> countryModel = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                IEnumerable<SelectListItem> countries = countryModel.Select(x => new SelectListItem() { Value = x.Name, Text = x.Name });
            }
            return countriesList;
        }
    }

    public class Country
    {
        public string name { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public string latlng { get; set; }
        public string area { get; set; }
        public string population { get; set; }
    }
}
