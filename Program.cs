using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    class Program
    {
        static void Main(string[] args)
        {
            Aeroport aeroport = new Aeroport("Mikolaev");
            //aeroport.SetNewAiplane(DateTime.Now, DateTime.Now, "UT1", "Mikolaev", "Kiev", 100.25f, 42, 6); //данные грузятся из под бинарника
            //aeroport.SetNewAiplane(DateTime.Now, DateTime.Now, "UT2", "Mikolaev", "Zaporozhe", 101, 43, 7);
            //aeroport.SetNewAiplane(DateTime.Now, DateTime.Now, "UT3", "Mikolaev", "Kharkiv", 111, 41, 5);
            //aeroport.SetNewAiplane(DateTime.Now, DateTime.Now, "UT4", "Mikolaev", "Vinnice", 151, 44, 5);
            //aeroport.SetNewAiplane(DateTime.Now, DateTime.Now, "UT5", "Mikolaev", "Cherkasi", 131, 48, 8);
            aeroport.Menu();
        }
    }
}
