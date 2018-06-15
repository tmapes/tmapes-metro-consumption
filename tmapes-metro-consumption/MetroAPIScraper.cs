using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using tmapes_metro_consumption.Models;

namespace tmapes_metro_consumption
{
    public class MetroApiScraper
    {

        public static string GetNextDeparture(string bus_route, string bus_stop_name, string direction)
        {
            var selectedRoute = GetRoutes().Find(model => model.Description.Contains(bus_route));
            if (selectedRoute == null) return "invalid bus route name";


            Direction selectedDirection;
            var isRealDirection = Direction.TryParse(direction, out selectedDirection);
            if(!isRealDirection)
                return "nonreal direction";
            var routeDirections = GetDirections(selectedRoute.Route);
            int isValidDirection = routeDirections.FindIndex(model => int.Parse(model.Value) == (int)selectedDirection);
            if (isValidDirection == -1)
                return "direction not valid for bus route";

            var selectedStop = GetStops(selectedRoute.Route, selectedDirection).Find(model => model.Text.Contains(bus_stop_name));
            if (selectedStop == null) return "invalid bus stop";

            return GetDepartureTime(selectedRoute.Route, selectedDirection,
                selectedStop.Value);
        }
        #region Data Processing
        private static readonly RestClient MetroRootClient = new RestClient("http://svc.metrotransit.org/NexTrip/");

        private static List<RouteModel> GetRoutes()
        {
            var routeRequest = new RestRequest("Routes", Method.GET);
            routeRequest.AddHeader("Accept", "application/json");
            var routeResponse = MetroRootClient.Execute<List<RouteModel>>(routeRequest);
            if (routeResponse.IsSuccessful)
            {
                return routeResponse.Data;
            }
            return null;
        }

        private static List<DirectionModel> GetDirections(string routeNumber)
        {
            var directionRequest = new RestRequest($"Directions/{routeNumber}", Method.GET);
            directionRequest.AddHeader("Accept", "application/json");
            var directionResponse = MetroRootClient.Execute<List<DirectionModel>>(directionRequest);
            if (directionResponse.IsSuccessful)
            {
                return directionResponse.Data;
            }
            return null;
        }

        private static List<StopModel> GetStops(string routeNumber, Direction dir)
        {
            var stopRequest = new RestRequest($"Stops/{routeNumber}/{(int)dir}", Method.GET);
            stopRequest.AddHeader("Accept", "application/json");
            var stopResponse = MetroRootClient.Execute<List<StopModel>>(stopRequest);
            if (stopResponse.IsSuccessful)
            {
                return stopResponse.Data;
            }
            return null;
        }

        private static string GetDepartureTime(string routeNumber, Direction direction, string stopNumber)
        {
            var departureRequest = new RestRequest($"{routeNumber}/{(int)direction}/{stopNumber}", Method.GET);
            departureRequest.AddHeader("Accept", "application/json");
            var departureResponse = MetroRootClient.Execute<List<TimepointDepartureModel>>(departureRequest);
            if (departureResponse.Data != null && departureResponse.Data.Count > 0)
            {
                return departureResponse.Data[0].DepartureText;
            }
            //Return an empty string if we cannot find any upcoming departures
            return string.Empty;
        }

        public enum Direction : int
        {
            South = 1,
            south = 1,
            East = 2,
            east = 2,
            West = 3,
            west = 3,
            North = 4,
            north = 4
        }
    }
    #endregion
}