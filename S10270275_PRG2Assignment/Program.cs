using S10270275_PRG2Assignment;
using System.Collections.Generic;

Console.WriteLine("testing");
Terminal terminal = new Terminal("Changi Terminal 5");
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

void initairline()
{
    foreach (string Line in File.ReadLines("airlines.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        Airline airlinetemp = new Airline(split[0], split[1]);
        terminal.AddAirline(airlinetemp);
        Console.WriteLine("great success");
    }
}

void initboarding()
{
    foreach (string Line in File.ReadLines("boardinggates.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        BoardingGate boarding = new BoardingGate(null, split[0], Convert.ToBoolean(split[1]), Convert.ToBoolean(split[2]), Convert.ToBoolean(split[3]));
        terminal.AddBoardingGate(boarding);
    }
}

// qn2 
void initflight()
{
    foreach (string Line in File.ReadLines("flights.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        String[] numsplit = split[0].Split(" ");
        Airline airline = terminal.Airlines[numsplit[0]];
        if (split[4] == "DDJB")
        {
            Flight ftemp = new DDJBFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 300);
            terminal.Flights[split[0]] = ftemp;
        }
        else if (split[4] == "CFFT")
        {
            Flight ftemp = new CFFTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 150);
            terminal.Flights[split[0]] = ftemp;
        }
        else if (split[4] == "LWTT")
        {
            Flight ftemp = new LWTTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 500);
            terminal.Flights[split[0]] = ftemp;
        }
        else
        {
            Flight ftemp = new NORMFlight(split[0], split[1], split[2], "Scheduled", Convert.ToDateTime(split[3]));
            terminal.Flights[split[0]] = ftemp;
        }
    }
}



//foreach (KeyValuePair<string, Flight> kvp in FlightDict)
//{
//    Console.WriteLine(kvp.Value.Status);
//}

// qn3 
void displayflight()
{
    if (terminal.Flights.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }
    Console.WriteLine("=============================================" + '\n' +"List of Flights for Changi Airport Terminal 5" + '\n' +"=============================================");
    Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}","Flight number","Airline Name","Origin","Destination","Expected Departure/Arrival Time");
    foreach (KeyValuePair<string, Flight> flightkvp in terminal.Flights)
    {
        String[] splitkey = flightkvp.Key.Split(" ");
        Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}", flightkvp.Value.FlightNumber, terminal.Airlines[splitkey[0]].Name,flightkvp.Value.Origin, flightkvp.Value.Destination, flightkvp.Value.expectedTime);
    }
}
// qn5
void assigngate()
{

    Console.Write("Enter Flight Number: ");
    string Flightnum = Console.ReadLine();
    Console.Write("Enter Boarding Gate Name: ");
    string Boardingnum = Console.ReadLine();

    if (terminal.Flights.ContainsKey(Flightnum) & (terminal.boardingGates.ContainsKey(Boardingnum.ToUpper())))
    {
        Console.WriteLine("Flight Number: {0}", terminal.Flights[Flightnum].FlightNumber);
        Console.WriteLine("Origin: {0}", terminal.Flights[Flightnum].Origin);
        Console.WriteLine("Expected Time: {0}", terminal.Flights[Flightnum].expectedTime);
        Console.WriteLine(Convert.ToString(terminal.Flights[Flightnum].GetType()));
        string type = Convert.ToString(terminal.Flights[Flightnum].GetType());
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
        Console.WriteLine("Boarding Gate Name: {0}", terminal.boardingGates[Boardingnum].gateName);
        Console.WriteLine("Supports DDJB: {0}", terminal.boardingGates[Boardingnum].supportsDDJB);
        Console.WriteLine("Supports CFFT: {0}", terminal.boardingGates[Boardingnum].supportsCFFT);
        Console.WriteLine("Supports LWTT: {0}", terminal.boardingGates[Boardingnum].supportsLWTT);
        Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
        string option = Console.ReadLine();
        if (option == "Y")
        {
            List<string> statuslist = new List<string>() {"Delayed","Boarding","On Time"};
            Console.WriteLine("1.Delayed" + '\n' + "2.Boarding" + '\n' + "3.On Time");
            Console.Write("Please select the new status of the flight: ");
            int statusoption = Convert.ToInt32(Console.ReadLine());
            terminal.Flights[Flightnum].Status = statuslist[statusoption - 1];
            if (typesplit[1] == "CFFTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new CFFTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption -1], 150);
            }
            else if (typesplit[1] == "DDJBFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new DDJBFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption - 1], 300);
            }
            else if (typesplit[1] == "LWTTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new LWTTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption - 1], 500);
            }
            else
            {
                terminal.boardingGates[Boardingnum].Flight = new NORMFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, statuslist[statusoption - 1], terminal.Flights[Flightnum].expectedTime);
            }
            Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
            
        }
        else if (option == "N")
        {
            if (typesplit[1] == "CFFTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new CFFTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 150);
            }
            else if (typesplit[1] == "DDJBFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new DDJBFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 300);
            }
            else if (typesplit[1] == "LWTTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new LWTTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 500);
            }
            else
            {
                terminal.boardingGates[Boardingnum].Flight = new NORMFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].Status, terminal.Flights[Flightnum].expectedTime);
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
//void createflight(Dictionary<string, Flight> FlightDict)
//{

//}
// qn9


// running code for menu
initairline();
initboarding();
initflight();
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
            displayflight();
        }
        else if (option == 3)
        {
            assigngate();
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
