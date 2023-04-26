using Microsoft.Extensions.Options;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=localhost;Initial Catalog=db_MAGIC_videogames;Integrated Security=True;Trusted_Connection=True;";
            using (dbVideogamesContext db = new dbVideogamesContext())
            {
            

                int choiche = Utilities.GetUserChoice();
                switch (choiche)
                {
                    case (int)Options.AddVideogame:
                        Manager.AddVideogame(db);
                        break;
                    case (int)Options.FindVideogame:
                        Manager.FindVideogame(db);
                        break;
                    case (int)Options.FilterVideogame:
                        Manager.FilterVideogame(db);
                        break;
                    case (int)Options.DeleteVideogame:
                        Manager.DeleteVideogame(db);
                        break;
                    case (int)Options.AddSoftwareHouse:
                        Manager.AddSoftwareHouse(db);
                        break;
                    case (int)Options.GetVideogamesBySoftwareHouse:
                        Manager.GetAllfromSoftwareHouse(db);
                        break;
                    case (int)Options.Quit:
                        Manager.Quit(db);
                        break;
                    default:
                        break;

                }
            }
        }
    }
}