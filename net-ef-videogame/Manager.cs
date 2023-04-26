using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class Manager
    {
        //ADD VID TO DB
        public static void AddVideogame(dbVideogamesContext db)
        {
            try
            {
                Videogame v = Videogame.Create();
                db.Add(v);
                db.SaveChanges();
                Console.WriteLine("Videogioco aggiunto correttamente --SUCCESS!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}  --FAIL");
            }
        }
        //ADD SW TO DB
        public static void AddSoftwareHouse(dbVideogamesContext db)
        {
            try
            {
                SoftwareHouse s = SoftwareHouse.Create();
                db.Add(s);
                db.SaveChanges();
                Console.WriteLine("Software house aggiunta correttamente --SUCCESS!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}  --FAIL");
            }

        }
        //FIND BY ID
        public static void FindVideogame(dbVideogamesContext db)
        {
            string? vId = null;
            bool isValidId=false;

            while (!isValidId)
            {
                Console.WriteLine("inserisci l'id del videogame che vuoi trovare");
                vId = Console.ReadLine();
                isValidId = vId.Validatestring(false, true, false, null, null);
            }
            try
            {
                Videogame v = db.Videogames.Where(s => s.Id == Convert.ToInt32(vId)).First();
                Console.WriteLine($"VIDEOGAME N#: {v.Id} titolo: {v.Name} descrizione: {v.Overview} Data di rilascio: {v.ReleaseDate.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} Nessuna corrispondenza per l'id  ({vId})");
            }
        }
        //DELETE VIDEOGAME
        public static void DeleteVideogame(dbVideogamesContext db)
        {
            string? vId = null;
            bool isValidId = false;

            while (!isValidId)
            {
                Console.WriteLine("inserisci l'id del videogame che si desidera eliminare");
                vId = Console.ReadLine();
                isValidId = vId.Validatestring(false, true, false, null, null);
            }
            try
            {
                Videogame v = db.Videogames.Where(s => s.Id == Convert.ToInt32(vId)).First();
                Console.WriteLine($"VIDEOGAME N#: {v.Id} titolo: {v.Name} descrizione: {v.Overview} Data di rilascio: {v.ReleaseDate.ToString()}");

                string? confirm = null;
                bool isValidConfirm=false;

                while (!isValidConfirm)
                {
                    Console.WriteLine("digita (elimina) se desideri distruggere questo elemento ");
                    confirm = Console.ReadLine();
                    if (confirm == "elimina")
                    {
                        try
                        {
                            db.Remove(v);
                            db.SaveChanges();
                            Console.WriteLine("Videogame eliminato correttamente --SUCCESS");
                        }
                        catch (Exception ex) { Console.WriteLine($"{ex.Message} --ERRORE"); }

                    }
                    else Console.WriteLine("l'elemento è stato risparmiato");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} Nessuna corrispondenza per l'id {vId}");
            }
        }
        //FILTRA PER STRINGA
            public static void FilterVideogame(dbVideogamesContext db)
        {

            string? vString = null;
            bool isValidVString = false;

            while (!isValidVString)
            {
                Console.WriteLine("inserisci parte del titolo del videogame che stai cercando");
                vString = Console.ReadLine();
                isValidVString = vString.Validatestring(false, false, false,1, 255);
            }
            try
            {
                List<Videogame> filtredVideogames = db.Videogames.Where(s => s.Name.Contains(vString)).ToList<Videogame>();
                if (filtredVideogames.Count > 1)
                {
                    foreach (Videogame v in filtredVideogames)
                        Console.WriteLine($"VIDEOGAME N#: {v.Id} titolo: {v.Name} descrizione: {v.Overview}  Data di rilascio: {v.ReleaseDate.ToString()}");
                }
                else Console.WriteLine($"nessuna corrispondenza con ({vString})");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "  --FAIL");
            }
        }

        //GET ALL VID FROM SW
        public static void GetAllfromSoftwareHouse(dbVideogamesContext db)
        {
            string? sId = null;
            bool isValidId = false;

            while (!isValidId)
            {
                Console.WriteLine("inserisci l'id della software house e recupera la lista di tutti i videogame da essa prodotti");
                sId = Console.ReadLine();
                isValidId = sId.Validatestring(false, true, false, null, null);
            }
            try
            {
                SoftwareHouse SW = db.SoftwareHouses.Where(s => s.SoftwareHouseId == Convert.ToInt32(sId)).Include(v => v.Videogames).First();

                Console.WriteLine($" ({SW.Videogames.Count}) risultati per {SW.Name}:");
                foreach (Videogame v in SW.Videogames)
                Console.WriteLine($"VIDEOGAME N#: {v.Id} titolo: {v.Name} descrizione: {v.Overview}  Data di rilascio: {v.ReleaseDate.ToString()}");    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "  --FAIL");
            }

        }

        //QUIT CONNECTION
        public static void Quit(dbVideogamesContext db)
        {
            try
            {
                Console.WriteLine("sessione conclusa");
                //db.close
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "  --FAIL");
            }
        }
    }
}
