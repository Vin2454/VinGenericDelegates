using System;
using System.Collections.Generic;

namespace VinGenericDelegates
{
    /// <summary>
    /// E.g: If we read data from an external api and do some mapping in Repo layer into List and again iterate through for each row and do some other mapping
    /// in Services layer. To avoid multiple inmemory iterations, we can pass service layer mapping function as a reference to Repo layer, so that mapping2 happens at the same time as mapping1
    /// Here are we are doing mapping in dataaccess only, while we are getting values and avoiding iteration in the dto mapper
    /// learn: https://stackoverflow.com/questions/20681960/use-of-generic-delegates
    /// </summary>
    class WithGenericDelegate
    {
        static void Main(string[] args)
        {
            FlightsService fs = new FlightsService();
            foreach (var item in fs.GetFlights(string.Empty))
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }

    public class FlightsService
    {
        public IEnumerable<FlightDtoModel> GetFlights(string departureStation)
        {
            List<FlightDtoModel> flightsDtoModel = new List<FlightDtoModel>();
            FlightsRepo fr = new FlightsRepo();

            flightsDtoModel = fr.GetFlights<FlightDtoModel>(string.Empty, FlightDbModelToDtoMapper);//Pasing callback function as a parameter here.
            return flightsDtoModel;
        }

        public FlightDtoModel FlightDbModelToDtoMapper(FlightDbModel flightDbModel)
        {
            return new FlightDtoModel
            {
                Number = flightDbModel.Number,
                Name = flightDbModel.Name
            };
        }
    }
    public class FlightsRepo
    {
        public List<T> GetFlights<T>(string departureStation, Func<FlightDbModel, T> factoryMethod)
        {
            return new List<T> {
                factoryMethod(new FlightDbModel { Number = 1, Name = "f1" }),
                factoryMethod(new FlightDbModel { Number = 2, Name = "f2" })
            };
        }
    }

    public class FlightDbModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class FlightDtoModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
