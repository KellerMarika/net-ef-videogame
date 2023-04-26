using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_house")]
    internal class SoftwareHouse:Timestamps
    {
            [Key][Column("id")]
            public int SoftwareHouseId { get; set; }
            [Column("name")]
            public string Name { get; set; }
            [Column("Tax_id")]
            public int TaxId { get; set; }
            [Column("city")]
            public string City { get; set; }
            [Column("country")]
            public string Country { get; set; }

            //relations
            public List<Videogame> Videogames { get; set; }

        //+timestamps

      public SoftwareHouse(string name, int taxId, string city, string country)
        {
            this.Name = name;
            this.TaxId = taxId;
            this.City = city;
            this.Country = country;
        }

        public static SoftwareHouse Create()
        {
            Console.WriteLine("CREA una nuova software house");

            string name = null,  taxId = null, city = null, country = null;

            bool isValidName = false, isValidTaxId = false, isValidCity = false, isValidCountry = false;


            while (!isValidName)
            {
                Console.WriteLine("inserisci il nome");
                name = Console.ReadLine();
                isValidName = name.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidTaxId)
            {
                Console.WriteLine("inserisci tax_id");
                taxId = Console.ReadLine();
                isValidTaxId =taxId.Validatestring(false, true, false, 1, 255);
            }

            while (!isValidCity)
            {
                Console.WriteLine("Inserisci la città");
                city = Console.ReadLine();
                isValidCity = city.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidCountry)
            {
                //dovrei aggiungere un controllo se quell'id esiste in tabella
                Console.WriteLine("inserisci il paese di provenienza");
                country = Console.ReadLine();
                isValidCountry = country.Validatestring(false, false, false, 1, 255);
            }
            return new SoftwareHouse (name,Convert.ToInt16(taxId), city, country);
        }

    }
}

