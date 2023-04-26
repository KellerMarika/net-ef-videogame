﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public enum Options { AddVideogame, FindVideogame, FilterVideogame, DeleteVideogame,AddSoftwareHouse,GetVideogamesBySoftwareHouse, Quit }
    internal class Utilities
    {
        const string connectionString = "Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;";
        public static int GetUserChoice()
        {
            Console.WriteLine("Che operazione desideri eseguire a Database?");
            Console.WriteLine("premi (1) per inserire un videogioco");
            Console.WriteLine("premi (2) per ricercare un videogioco per id");
            Console.WriteLine("premi (3) per ricercare tutti i videogiochi in base a una stringa");
            Console.WriteLine("premi (4) per cancellare un videogioco");
            Console.WriteLine("premi (5) per inserire una software house");
            Console.WriteLine("premi (6) per ricercare tutti i videogiochi prodotti da una software house");
            Console.WriteLine("premi (7) per chiudere il programma");

            try
            {
                int choice = Convert.ToInt16(Console.ReadLine());
                if (Enum.IsDefined(typeof(Options), choice - 1)) return choice - 1;
                else throw new Exception($"({choice}) non è una scelta valida!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToUpper());
                return GetUserChoice();
            }
        }
    }
}
