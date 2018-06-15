using System;
using RestSharp.Extensions;


namespace tmapes_metro_consumption
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 4 && args[3].Equals("tests"))
            {
                Console.WriteLine(
                    $"Testing with arguments:\nBUS_ROUTE : {args[0]}\nBUS_STOP_NAME : {args[1]}\nDIRECTION: {args[2]}");
                Console.WriteLine(MetroApiScraper.GetNextDeparture(args[0], args[1], args[2]));
                Console.WriteLine("");

                Console.WriteLine("Testing BP Campus to TNC");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("Express - Target - Hwy 252 and 73rd Av P&R - Mpls",
                    "Target North Campus Building F", "south"));
                Console.WriteLine("");

                Console.WriteLine("Testing Lightrail to Target Field ");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("METRO Blue Line", "Target Field Station Platform 1",
                    "south"));
                Console.WriteLine("");

                Console.WriteLine("Testing Invalid Bus_Route");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("invalid_bus_route",
                    "Target North Campus Building F", "south"));
                Console.WriteLine("");

                Console.WriteLine("Testing Invalid Bus_Stop_Name");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("Express - Target - Hwy 252 and 73rd Av P&R - Mpls",
                    "invalid_bus_stop", "south"));
                Console.WriteLine("");

                Console.WriteLine("Testing Invalid Direction");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("Express - Target - Hwy 252 and 73rd Av P&R - Mpls",
                    "Target North Campus Building F", "east"));
                Console.WriteLine("");

                Console.WriteLine("Testing Nonreal Direction");
                Console.WriteLine(MetroApiScraper.GetNextDeparture("Express - Target - Hwy 252 and 73rd Av P&R - Mpls",
                    "Target North Campus Building F", "invalid_direction"));
            }
            else
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Not enough arguments specified");
                    return;
                }
                Console.WriteLine(MetroApiScraper.GetNextDeparture(args[0], args[1], args[2]));
            }
        }
    }
}
