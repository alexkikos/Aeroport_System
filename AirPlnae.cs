using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirPlane
{
    class AirPlane
    {

        string airplane_name;
        string end_point;//маршрут окончания пути
        string current_city;//где мы сейчас
        float total_fluel;//количество топлива
        int total_passengers;//сколько пассажиров летит
        int total_personal_onboard;//сколько обслуживающего персонала
        DateTime end_point_time; //время прибытия в конечную точку
        DateTime time_to_go_from_start;//время отправления


        static int max__passengers;//максимальное количество вместимости пассажиров
        static float max_weigth_bags;//вместимость багажного отдела
        static DateTime current_time;//общее текущее время для всех самолетов
     


        #region Methods_For_work_with_class
        public void ShowInfo()
        {

            Console.WriteLine("Air Name: "+airplane_name);
            Console.WriteLine("End point: " + end_point);
            Console.WriteLine("Current city: "+ current_city);
            Console.WriteLine("Total fluel: "+total_fluel);
            Console.WriteLine("Total passengers: "+total_passengers);
            Console.WriteLine("Total personal on board: " +total_personal_onboard);
            Console.WriteLine("Departure start: " + time_to_go_from_start);
            Console.WriteLine("Arrival time: "+ end_point_time);

        }
        public void PhillInfoPlain()
        {
            Console.WriteLine("Air Name: ");
            airplane_name = Console.ReadLine();
            Console.WriteLine("End point: " );
            end_point = Console.ReadLine();
            Console.WriteLine("Current city: ");
            current_city = Console.ReadLine();
            Console.WriteLine("Total fluel: ");
            float.TryParse(Console.ReadLine(), out  total_fluel);
            Console.WriteLine("Total passengers: ");
            int.TryParse(Console.ReadLine(), out total_passengers);
            Console.WriteLine("Total personal on board: ");
            int.TryParse(Console.ReadLine(), out total_personal_onboard);

            Console.WriteLine("Departure start year: ");
            int.TryParse(Console.ReadLine(), out int years);
            Console.WriteLine("Departure start day: ");
            double.TryParse(Console.ReadLine(), out double days);        
            Console.WriteLine("Departure start month: ");
            int.TryParse(Console.ReadLine(), out int month);            
            Console.WriteLine("Departure start hour: ");
            int.TryParse(Console.ReadLine(), out int hour);
            Console.WriteLine("Departure start mins: ");
            int.TryParse(Console.ReadLine(), out int mins);
            DateTime a = new DateTime();//выделяю память посути с пустыми значениями, в документации сказано генерится пару микротиков, после выделения памяти заполняю своими данными
            time_to_go_from_start = a.AddDays(days).AddMonths(month).AddHours(hour).AddMinutes(mins).AddYears(years);           


            Console.WriteLine("Arrival: ");
            Console.WriteLine("Arrival year: ");
            int.TryParse(Console.ReadLine(), out  years);
            Console.WriteLine("Arrival  day: ");
            double.TryParse(Console.ReadLine(), out   days);        
            Console.WriteLine("Arrival month: ");
            int.TryParse(Console.ReadLine(), out   month);
            Console.WriteLine("Arrival hour: ");
            int.TryParse(Console.ReadLine(), out  hour);
            Console.WriteLine("Arrival mins: ");
            int.TryParse(Console.ReadLine(), out  mins);
            DateTime b = new DateTime();
            end_point_time = b.AddDays(days).AddMonths(month).AddHours(hour).AddMinutes(mins).AddYears(years);
        }
        public void SetEndPointTime(ref DateTime time)
        {
            //по условию задания надо передать свойства по ссылке
            end_point_time = time;
        }
        public void SetTimeToGo(ref DateTime time)
        {
            //по условию задания надо передать свойства по ссылке
            time_to_go_from_start = time;
        }     
        public void Save(BinaryWriter write)
        {
            write.Write(airplane_name);
            write.Write(end_point);
            write.Write(current_city);
            write.Write(total_fluel);
            write.Write(total_passengers);
            write.Write(total_personal_onboard);
            write.Write(end_point_time.ToString());
            write.Write(time_to_go_from_start.ToString());
            write.Write(max__passengers);
            write.Write(max_weigth_bags);
            write.Write(current_time.ToString());
        }
        public void Load(BinaryReader load)
        {
            airplane_name = load.ReadString();
            end_point = load.ReadString(); //маршрут окончания пути
            current_city = load.ReadString();//где мы сейчас
            total_fluel = load.ReadSingle();//количество топлива
            total_passengers=load.ReadInt32();//сколько пассажиров летит
            total_personal_onboard=load.ReadInt32();//сколько обслуживающего персонала
            string a = load.ReadString();
            end_point_time = DateTime.Parse(a); //время прибытия в конечную точку
            DateTime.TryParse(load.ReadString(), out time_to_go_from_start);
            int.TryParse(load.ReadInt32().ToString(), out max__passengers);
            float.TryParse(load.ReadSingle().ToString(), out max_weigth_bags);
            DateTime.TryParse(load.ReadString(), out current_time);
        }

        #endregion
        #region Methods_Gets
        //только гетеры, сетеры логика описана в свойствах
        public string GetAirName() { return airplane_name; }
        public int GetTotalPassengers() { return total_passengers; }
        public string GetEndPoint() { return end_point; }
        public string GetCurrentCity() { return current_city; }
        public float GetVolume() { return total_fluel; }
        public int GetTotalPersonal() { return total_personal_onboard; }
        public static int GetMaxPassengers() { return max__passengers; }
        public float GetMaxWeightBags() { return max_weigth_bags; }
        public void SetDateEndPoint(ref DateTime date)
        {
            //по факту тут реф не нужен, ибо классы все и так ссылочные, но по условию задания нужно сделать
            End_point_time = date;//ставлю через свойство
        }
        public void SetStartTime(ref DateTime date)//дата прибытия
        {
            Time_to_go_from_start = date;
        }
        public DateTime GetTImeEndPoint()
        {
            return end_point_time;
        }
        public DateTime GetTimeWhenStart()
        {
            return time_to_go_from_start;
        }


        #endregion
        #region Properties
        public int Total_personal_onboard { get { return total_personal_onboard; } set { if (value >= 0) total_personal_onboard = value; else Console.WriteLine("Incorrect value"); } }
        public string Airplane_name { get => airplane_name; set { if (value.Length > 0) airplane_name = value; else Console.WriteLine("Incorrect value"); } }
        public string End_point { get => end_point; set { if (value.Length > 0) end_point = value; else Console.WriteLine("Incorrect value"); } }
        public string Current_city { get => current_city; set { if (value.Length > 0) current_city = value; else Console.WriteLine("Incorrect value"); } }
        public float Total_fluel { get => total_fluel; set { if (value >= 0) total_fluel = value; else Console.WriteLine("Incorrect value"); } }
        public int Total_passengers { get => total_passengers; set { if (value >= 0) total_passengers = value; else Console.WriteLine("Incorrect value"); } }
        public DateTime End_point_time { get => end_point_time; set => end_point_time = value; }
        public DateTime Time_to_go_from_start { get => time_to_go_from_start; set => time_to_go_from_start = value; }
        public  int Max__passengers { get => max__passengers; }//статик свойство только для чтения
        public  float Max_weigth_bags { get => max_weigth_bags; } //статик свойство только для чтения
        public  DateTime Current_time { get => current_time;}

        #endregion
        #region Constructors
        public AirPlane(string airplane_name)
        {

            //2 конструктора перегруженных по условию задания делаю         
            this.airplane_name = airplane_name;
            this.end_point = "";
            this.current_city = "";
            this.total_fluel = 0;
            this.total_passengers = 0;
            this.total_personal_onboard = 0;
            end_point_time = DateTime.Now;
            time_to_go_from_start = DateTime.Now;
        }
        public AirPlane(DateTime end_point_time, DateTime start_point_time, string airplane_name = "", string current_city = "", string end_point = "", float volume_fluel = 0, int total_passengers = 0, int total_personal_onboard = 0)
        {
            //2 конструктора перегруженных по условию задания делаю
            this.airplane_name = airplane_name;
            this.end_point = end_point;
            this.current_city = current_city;
            this.total_fluel = volume_fluel;
            this.total_passengers = total_passengers;
            this.total_personal_onboard = total_personal_onboard;
            this.End_point_time = end_point_time;
            this.Time_to_go_from_start = time_to_go_from_start;
        }
        static AirPlane()
        {
          
            max__passengers = 100;
            max_weigth_bags = 1000.0f;
            current_time = DateTime.Now;
        }

        public AirPlane()
        {
            this.airplane_name = "";
            this.end_point = "";
            this.current_city = "";
            this.total_fluel = 0;
            this.total_passengers = 0;
            this.total_personal_onboard = 0;
            this.End_point_time = DateTime.Now;
            this.Time_to_go_from_start = DateTime.Now;
        }

        #endregion


    }
}
