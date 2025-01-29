using S10270275_PRG2Assignment;
using System.Collections.Generic;

Console.WriteLine("testing");

// yuxuan qn1,4,7,8

// qn1

// qn4

// qn7

// qn8



// Kaiwen qn2,3,5,6,9

// template
//foreach (string Line in File.ReadLines("flights.csv").Skip(1))
//{
//    String[] split = Line.Split(",");
//}
// qn1 temp
Dictionary<string, Airline> AirlineDict = new Dictionary<string, Airline>();
void initairlinedata(Dictionary<string, Airline> AirlineDict)
{
    foreach (string Line in File.ReadLines("airlines.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        AirlineDict.Add(split[1],new Airline(split[0], split[1]));
    }
}

Dictionary<string, BoardingGate> BoardingDict = new Dictionary<string, BoardingGate>();

void initboardingdata(Dictionary<string, BoardingGate> BoardingDict)
{
    foreach (string Line in File.ReadLines("boardinggates.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        BoardingDict.Add(split[0] ,new BoardingGate(null,split[0], Convert.ToBoolean(split[1]), Convert.ToBoolean(split[2]), Convert.ToBoolean(split[3])));
    }
}

// qn2 
Dictionary<string, Flight> FlightDict = new Dictionary<string, Flight>();

void initflightdata(Dictionary<string, Flight> FlightDict)
{
    foreach (string Line in File.ReadLines("flights.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        if (split[4] == "DDJB")
        {
            FlightDict.Add(split[0], new DDJBFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]),null ,300));
        }
        else if (split[4] == "CFFT")
        {
            FlightDict.Add(split[0], new CFFTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]),null ,150));
        }
        else if (split[4] == "LWTT")
        {
            FlightDict.Add(split[0], new LWTTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]),null ,500));
        }
        else
        {
            FlightDict.Add(split[0], new NORMFlight(split[0], split[1], split[2], null,Convert.ToDateTime(split[3])));
        }
    }
}


foreach (KeyValuePair<string, Flight> kvp in FlightDict)
{
    Console.WriteLine(kvp.Value.Status);
}

// qn3 
void displayflight(Dictionary<string, Flight> FlightDict, Dictionary<string, Airline> AirlineDict)
{
    Console.WriteLine("=============================================" + '\n' +"List of Flights for Changi Airport Terminal 5" + '\n' +"=============================================");
    Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}","Flight number","Airline Name","Origin","Destination","Expected Departure/Arrival Time");
    foreach (KeyValuePair<string, Flight> flightkvp in FlightDict)
    {
        String[] fnumsplit = flightkvp.Key.Split(" ");
        Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}", flightkvp.Value.FlightNumber, AirlineDict[fnumsplit[0]].Name,flightkvp.Value.Origin, flightkvp.Value.Destination, flightkvp.Value.expectedTime);
    }
}
// qn5
void assigngate(Dictionary<string, BoardingGate> BoardingDict, Dictionary<string, Flight> FlightDict)
{

    Console.Write("Enter Flight Number: ");
    string Flightnum = Console.ReadLine();
    Console.Write("Enter Boarding Gate Name: ");
    string Boardingnum = Console.ReadLine();

    if (FlightDict.ContainsKey(Flightnum) & (BoardingDict.ContainsKey(Boardingnum.ToUpper())))
    {
        Console.WriteLine("Flight Number: {0}", FlightDict[Flightnum].FlightNumber);
        Console.WriteLine("Origin: {0}", FlightDict[Flightnum].Origin);
        Console.WriteLine("Expected Time: {0}", FlightDict[Flightnum].expectedTime);
        Console.WriteLine(Convert.ToString(FlightDict[Flightnum].GetType()));
        string type = Convert.ToString(FlightDict[Flightnum].GetType());
        string[] typesplit = type.Split(".");
        if (typesplit[1] == "CFFTFlight")
        {
            Console.WriteLine("Special Request Code: {0}", "CFFT");
        }
        else if (typesplit[1] == "DDJBFlight")
        {
            Console.WriteLine("Special Request Code: {0}", "DDJB");
        }
        else if (typesplit[1] == "LWTTFlight")
        {
            Console.WriteLine("Special Request Code: {0}", "LWTT");
        }
        else
        {
            Console.WriteLine("Special Request Code: {0}", "None");
        }
        Console.WriteLine("Boarding Gate Name: {0}", BoardingDict[Boardingnum].gateName);
        Console.WriteLine("Supports DDJB: {0}", BoardingDict[Boardingnum].supportsDDJB);
        Console.WriteLine("Supports CFFT: {0}", BoardingDict[Boardingnum].supportsCFFT);
        Console.WriteLine("Supports LWTT: {0}", BoardingDict[Boardingnum].supportsLWTT);
        Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
        string option = Console.ReadLine();
        if (option == "Y")
        {
            Console.WriteLine("1.Delayed" + '\n' + "2.Boarding" + '\n' + "3.On Time");
            Console.Write("Please select the new status of the flight: ");
            string statusoption = Console.ReadLine();
            if (statusoption == "1")
            {
                FlightDict[Flightnum].Status = "Delayed";
                if (typesplit[1] == "CFFTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new CFFTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Delayed", 150);
                }
                else if (typesplit[1] == "DDJBFlight")
                {
                    BoardingDict[Boardingnum].Flight = new DDJBFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Delayed", 300);
                }
                else if (typesplit[1] == "LWTTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new LWTTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Delayed", 500);
                }
                else
                {
                    BoardingDict[Boardingnum].Flight = new NORMFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, "Delayed", FlightDict[Flightnum].expectedTime);
                }
                Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
            }
            else if (statusoption == "2")
            {
                FlightDict[Flightnum].Status = "Boarding";
                if (typesplit[1] == "CFFTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new CFFTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Boarding", 150);
                }
                else if (typesplit[1] == "DDJBFlight")
                {
                    BoardingDict[Boardingnum].Flight = new DDJBFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Boarding", 300);
                }
                else if (typesplit[1] == "LWTTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new LWTTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "Boarding", 500);
                }
                else
                {
                    BoardingDict[Boardingnum].Flight = new NORMFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, "Boarding", FlightDict[Flightnum].expectedTime);
                }
                Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
            }
            else if (statusoption == "3")
            {
                FlightDict[Flightnum].Status = "On time";
                if (typesplit[1] == "CFFTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new CFFTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "On Time", 150);
                }
                else if (typesplit[1] == "DDJBFlight")
                {
                    BoardingDict[Boardingnum].Flight = new DDJBFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "On Time", 300);
                }
                else if (typesplit[1] == "LWTTFlight")
                {
                    BoardingDict[Boardingnum].Flight = new LWTTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, "On Time", 500);
                }
                else
                {
                    BoardingDict[Boardingnum].Flight = new NORMFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, "On Time", FlightDict[Flightnum].expectedTime);
                }
                Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
            }
        }
        else if (option == "N")
        {
            if (typesplit[1] == "CFFTFlight")
            {
                BoardingDict[Boardingnum].Flight = new CFFTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, FlightDict[Flightnum].Status, 150);
            }
            else if (typesplit[1] == "DDJBFlight")
            {
                BoardingDict[Boardingnum].Flight = new DDJBFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, FlightDict[Flightnum].Status, 300);
            }
            else if (typesplit[1] == "LWTTFlight")
            {
                BoardingDict[Boardingnum].Flight = new LWTTFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].expectedTime, FlightDict[Flightnum].Status, 500);
            }
            else
            {
                BoardingDict[Boardingnum].Flight = new NORMFlight(Flightnum, FlightDict[Flightnum].Origin, FlightDict[Flightnum].Destination, FlightDict[Flightnum].Status, FlightDict[Flightnum].expectedTime);
            }
            Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
        }
    }
    else
    {
        Console.WriteLine("Flight number does not exist or you have typed wrongly please retry again");
    }
}
    // qn6

    // qn9


// running code for menu
initflightdata(FlightDict);
initairlinedata(AirlineDict);
initboardingdata(BoardingDict);
void displaymenu()
{
    Console.WriteLine("=============================================" + '\n' + "Welcome to Changi Airport Terminal 5" + '\n' + "=============================================" + '\n' + "1. List All Flights" + '\n' + "2. List Boarding Gates" + '\n' + "3. Assign a Boarding Gate to a Flight" + '\n' +"4. Create Flight" + '\n' +"5. Display Airline Flights" + '\n' +"6. Modify Flight Details"+'\n'+"7. Display Flight Schedule"+'\n'+"0. Exit" + '\n');
}



while (true)
{
    try
    {
        displaymenu();
        Console.Write("Please select your option:");
        int option = Convert.ToInt32(Console.ReadLine());
        if (option == 1)
        {
            displayflight(FlightDict, AirlineDict);
        }
        else if (option == 3)
        {
            assigngate(BoardingDict, FlightDict);
        }
        else if (option == 0)
        {
            return;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
