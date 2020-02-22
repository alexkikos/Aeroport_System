using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AirPlane
{
    class Aeroport
    {
        List<AirPlane> aeroport;
        string name_aeroport;
        
        #region WorkFunc
        public void Menu()
        {
            int choice = 0;
            while (choice != 7)
            {
                Console.WriteLine("1. Показать все активные рейсы");
                Console.WriteLine("2. Добавить рейс");
                Console.WriteLine("3. Удалить рейс");
                Console.WriteLine("4. Отредактировать рейс");
                Console.WriteLine("5. Сохранить");
                Console.WriteLine("6. Загрузить");
                Console.WriteLine("7. Выход");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:ShowAllAirPlanes(); break;
                        case 2: AddAirplane(); break;
                        case 3: RemoveAirplane();  break;
                        case 4: EditInfoAirplnae(); break;
                        case 5: Save();break;
                        case 6: Load(); break;
                        default:
                            break;
                    }
                }
            }
        }

        //методы ввсе закрытые, работаем через меню
        void EditInfoAirplnae()
        {
            Console.Clear();
            ShowAllAirPlanes();
            Console.Write("Edint number plain for edit: " );
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result >=0 && result <= aeroport.Count)
                {
                    aeroport[result - 1].PhillInfoPlain();
                    Console.WriteLine("done");
                }
                else Console.WriteLine("Cant find airplane");
            }

        }
        void AddAirplane()
        {
            Console.Clear();
            AirPlane a = new AirPlane();
            a.PhillInfoPlain();
            aeroport.Add(a);          
            Console.WriteLine("All done");
        }
        void RemoveAirplane()
        {
            Console.Clear();
            ShowAllAirPlanes();
            Console.Write("enter number airplane for remove: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result >= 0 && result <= aeroport.Count)     aeroport.RemoveAt(result-1);
                else Console.WriteLine("Wrong input");
            }
            else Console.WriteLine("error when parse");

        }
        void ShowAllAirPlanes()
        {
            int count = 1;
            Console.Clear();
            foreach (var item in aeroport)
            {
                
                Console.WriteLine("======================"+(count++).ToString()+"===================================");
                item.ShowInfo();
            }
            Console.WriteLine("=====================================================");
        }
        public void SetNewAiplane(DateTime end_point_time, DateTime start_point_time, string airplane_name = "", string current_city = "", string end_point = "", float volume_airplane = 0, int total_passengers = 0, int total_personal_onboard = 0)
        {
            AirPlane a = new AirPlane();            
            a.Airplane_name = airplane_name;
            a.End_point = end_point;
            a.Current_city = current_city;
            a.Total_fluel = volume_airplane;
            a.Total_passengers = total_passengers;
            a.Total_personal_onboard = total_personal_onboard;
            a.End_point_time = end_point_time;
            a.Time_to_go_from_start = start_point_time;
            aeroport.Add(a);
        }
        public void Save()
        {
            BinaryWriter write = new BinaryWriter(File.OpenWrite("db.bin"));      
            foreach (var item in aeroport)
            {
                item.Save(write);
            }
            write.Close();
        }
        public void Load()
        {

            if (File.Exists("db.bin"))
            {
                if (aeroport.Count > 0) aeroport.Clear();
                BinaryReader load = new BinaryReader(File.OpenRead("db.bin"));
                while (load.PeekChar() > 0)
                {
                    AirPlane a = new AirPlane();
                    a.Load(load);
                    aeroport.Add(a);
                }
                load.Close();
            }
            
        }



        #endregion
        #region Properties and Constructs
        public string Name_aeroport { get => name_aeroport; set { if (!string.IsNullOrEmpty(value)) name_aeroport = value; else Console.WriteLine("Wrng input"); }  }
        public Aeroport(string name)
        {
            this.aeroport = new List<AirPlane>();//проиницилизировал
            Name_aeroport = name;
            Load();
        }
        #endregion
    }
}
