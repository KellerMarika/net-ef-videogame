using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    internal class Videogame:Timestamps
    {
        private string? user_SName;
        private string? user_STaxId;
        private string? user_SCity;
        private string? user_SCountry;

        [Key] [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        [Column("overview")]
        public string Overview { get; set; }


        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }


        //relations
        [Column("Software_house_id")]
        public int SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouseName { get; set; }



        public Videogame(string name, string overview, DateTime releaseDate, int softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }

        public static Videogame Create()
        {

            Console.WriteLine("CREA un nuovo videogame");

            string user_VName = null, user_VOverview = null, user_VReleaseDate = null, user_VSoftwareHouse = null;

            bool isValidName = false, isValidOverview = false, isValidReleaseDate = false, isValidSoftwareHouse = false;


            while (!isValidName)
            {
                Console.WriteLine("inserisci il nome");
                user_VName = Console.ReadLine();
                isValidName = user_VName.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidOverview)
            {
                Console.WriteLine("inserisci una descrizione");
                user_VOverview = Console.ReadLine();
                isValidOverview = user_VOverview.Validatestring(false, false, false, 1, 255);
            }
            while (!isValidReleaseDate)
            {
                Console.WriteLine("Inserisci la data di rilascio: dd/mm/YY");
                user_VReleaseDate = Console.ReadLine();
                isValidReleaseDate = user_VReleaseDate.Validatestring(false, false, true, null, null);
            }
            while (!isValidSoftwareHouse)
            {
                //dovrei aggiungere un controllo se quell'id esiste in tabella
                Console.WriteLine("inserisci l'id della casa produttrice");
                user_VSoftwareHouse = Console.ReadLine();
                isValidSoftwareHouse = user_VSoftwareHouse.Validatestring(false, true, false, 1, null);
            }

            return new Videogame(user_VName, user_VOverview, Convert.ToDateTime(user_VReleaseDate), Convert.ToInt16(user_VSoftwareHouse));
        }

    }
}
