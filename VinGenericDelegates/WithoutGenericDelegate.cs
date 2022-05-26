//using System;
//using System.Collections.Generic;

//namespace VinGenericDelegates
//{
//    class WithoutGenericDelegate
//    {
//        static void Main(string[] args)
//        {
//            FlightsService fs = new FlightsService();
//            foreach (var item in fs.GetFlights(string.Empty))
//            {
//                Console.WriteLine(item.Name);
//            }
//            Console.ReadLine();
//        }
//    }

//    public class FlightsService
//    {
//        public List<FlightDtoModel> GetFlights(string departureStation)
//        {
//            List<FlightDtoModel> flightsDtoModel = new List<FlightDtoModel>();
//            FlightsRepo fr = new FlightsRepo();
//            foreach (var flightDbModel in fr.GetFlights(string.Empty))
//            {
//                FlightDtoModel flightDtoModel = new FlightDtoModel();
//                flightDtoModel.Number = flightDbModel.Number;
//                flightDtoModel.Name = flightDbModel.Name;

//                flightsDtoModel.Add(flightDtoModel);
//            }
//            return flightsDtoModel;
//        }
//    }
//    public class FlightsRepo
//    {
//        public List<FlightDbModel> GetFlights(string departureStation)
//        {
//            return new List<FlightDbModel> { 
//                new FlightDbModel { Number = 1, Name = "f1" },
//                new FlightDbModel { Number = 2, Name = "f2" }
//            }; 
//        }
//    }

//    public class FlightDbModel
//    {
//        public int Number { get; set; }
//        public string Name { get; set; }
//    }

//    public class FlightDtoModel
//    {
//        public int Number { get; set; }
//        public string Name { get; set; }
//    }
//}
