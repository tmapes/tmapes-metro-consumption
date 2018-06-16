# tmapes-metro-consumption
A .NET Core Console App to find the next bus departure given a route, specified stop, and the direction you're traveling.

## Running

### Installing & Running
1. Install [.NET Core SDK](https://www.microsoft.com/net/download)
2. Clone the repo
3. `cd tmapes-metro-consumption/tmapes-metro-consumption`
4. `dotnet restore`
5. `dotnet run "BUS_ROUTE" "BUS_STOP_NAME" "DIRECTION"`

This will then return either the next bus departure,  
or a blank line if all buses for that route/stop have left for the day.


[RestSharp](https://www.nuget.org/packages/RestSharp/) is the only external library present.  
It is used to handle the REST Requests

### Arguments
BUS_ROUTE The bus route you wish to take  
BUS_STOP_NAME The stop on the route you wish to stop at  
DIRECTION The direction you'll be heading on the trip (north,east,west,south)

Routes, and stops availabe at [MetroTransit](http://svc.metrotransit.org/)

### Example
`dotnet run "METRO Green Line" "Nicollet Mall Station" "east"`
### Unit 'Tests'
`dotnet run "METRO Green Line" "Nicollet Mall Station" "east" "tests"`  
Appending 'tests' as a fourth parameter will run the given arguments as well as a few tests,  
to make sure the logic checker still works.
  
## Sample Output
`"METRO Green Line" "Nicollet Mall Station" "east"` (At 8:29 PM CDT)  
`9 Minutes`  
`"METRO Green Line" "Nicollet Mall Station" "east" "tests"` (At 8:29 PM CDT)  
```Testing with arguments:  
BUS_ROUTE : METRO Green Line  
BUS_STOP_NAME : Nicollet Mall Station  
DIRECTION: east  
9 Minutes  
  
Testing BP Campus to TNC  
  
Testing Lightrail to Target Field  
7 Minutes  

Testing Invalid Bus_Route  
invalid bus route name  

Testing Invalid Bus_Stop_Name  
invalid bus stop  

Testing Invalid Direction  
direction not valid for bus route  

Testing Nonreal Direction  
nonreal direction
```
