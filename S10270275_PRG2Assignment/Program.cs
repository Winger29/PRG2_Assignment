using PRG2Assignment;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;


Console.WriteLine("testing");
Terminal terminal = new Terminal("Changi Terminal 5");
// yuxuan qn1,4,7,8
void ListAllBoardingGates()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0,-12}{1,-10}{2,-10}{3,-10}", "Gate Name", "DDJB", "CFFT", "LWTT");

    foreach (var gate in terminal.boardingGates.Values)
    {
        Console.WriteLine("{0,-12}{1,-10}{2,-10}{3,-10}",
            gate.gateName,
            gate.supportsDDJB,
            gate.supportsCFFT,
            gate.supportsLWTT);
    }
}
void DisplayAirlineFlights()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0,-15}{1,-30}", "Airline Code", "Airline Name");

    foreach (var airline in terminal.Airlines.Values)
    {
        Console.WriteLine("{0,-15}{1,-30}", airline.Code, airline.Name);
    }

    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().ToUpper();

    if (terminal.Airlines.ContainsKey(airlineCode))
    {
        Airline selectedAirline = terminal.Airlines[airlineCode];
        Console.WriteLine("=============================================");
        Console.WriteLine($"List of Flights for {selectedAirline.Name}");
        Console.WriteLine("=============================================");
        Console.WriteLine("{0,-15}{1,-25}{2,-25}{3,-30}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");

        foreach (var flight in selectedAirline.Flights.Values)
        {
            Console.WriteLine("{0,-15}{1,-25}{2,-25}{3,-30}",
                flight.FlightNumber,
                selectedAirline.Name,
                flight.Origin,
                flight.Destination,
                flight.expectedTime);
        }
    }
    else
    {
        Console.WriteLine("Invalid Airline Code.");
    }
}
void ModifyFlightDetails()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0,-15}{1,-30}", "Airline Code", "Airline Name");

    foreach (var airline in terminal.Airlines.Values)
    {
        Console.WriteLine("{0,-15}{1,-30}", airline.Code, airline.Name);
    }

    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().ToUpper();

    if (terminal.Airlines.ContainsKey(airlineCode))
    {
        Airline selectedAirline = terminal.Airlines[airlineCode];
        Console.WriteLine("List of Flights for " + selectedAirline.Name);
        Console.WriteLine("{0,-15}{1,-25}{2,-25}{3,-30}", "Flight Number", "Origin", "Destination", "Expected Departure/Arrival Time");

        foreach (var flight in selectedAirline.Flights.Values)
        {
            Console.WriteLine("{0,-15}{1,-25}{2,-25}{3,-30}", flight.FlightNumber, flight.Origin, flight.Destination, flight.expectedTime);
        }

        Console.Write("Choose an existing Flight to modify or delete: ");
        string flightNumber = Console.ReadLine();

        if (selectedAirline.Flights.ContainsKey(flightNumber))
        {
            Console.WriteLine("1. Modify Flight");
            Console.WriteLine("2. Delete Flight");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Flight flight = selectedAirline.Flights[flightNumber];
                Console.WriteLine("1. Modify Basic Information");
                Console.WriteLine("2. Modify Status");
                Console.WriteLine("3. Modify Special Request Code");
                Console.WriteLine("4. Modify Boarding Gate");
                Console.Write("Choose an option: ");
                string modifyChoice = Console.ReadLine();

                if (modifyChoice == "1")
                {
                    Console.Write("Enter new Origin: ");
                    flight.Origin = Console.ReadLine();
                    Console.Write("Enter new Destination: ");
                    flight.Destination = Console.ReadLine();
                    Console.Write("Enter new Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
                    string dateTimeInput = Console.ReadLine();
                    DateTime newDateTime;

                    while (!DateTime.TryParseExact(dateTimeInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out newDateTime))
                    {
                        Console.Write("Invalid date format. Please enter in the format (dd/MM/yyyy HH:mm): ");
                        dateTimeInput = Console.ReadLine();
                    }

                    flight.expectedTime = newDateTime;
                }
                else if (modifyChoice == "2")
                {
                    Console.Write("Enter new Status: ");
                    flight.Status = Console.ReadLine();
                }
                else if (modifyChoice == "3")
                {
                    Console.Write("Enter new Special Request Code (CFFT/DDJB/LWTT/None): ");
                    string requestCode = Console.ReadLine().ToUpper();
                    flight.Status = requestCode;
                }
                else if (modifyChoice == "4")
                {
                    Console.Write("Enter new Boarding Gate: ");
                    string newGate = Console.ReadLine();
                    flight.Status = newGate;
                }
                Console.WriteLine("Flight updated!");
            }
            else if (choice == "2")
            {
                Console.Write("Are you sure you want to delete this flight? (Y/N): ");
                string confirm = Console.ReadLine().ToUpper();
                if (confirm == "Y")
                {
                    selectedAirline.Flights.Remove(flightNumber);
                    Console.WriteLine("Flight deleted successfully.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid Flight Number.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Airline Code.");
    }
}

// Kaiwen qn2,3,5,6,9

// template
foreach (string Line in File.ReadLines("flights.csv").Skip(1))
{
    String[] split = Line.Split(",");
}

void initairline(Terminal terminal)
{
    foreach (string Line in File.ReadLines("airlines.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        Airline airlinetemp = new Airline(split[0], split[1]);
        terminal.AddAirline(airlinetemp);
        Console.WriteLine("great success");
    }
}

void initboarding(Terminal terminal)
{
    foreach (string Line in File.ReadLines("boardinggates.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        BoardingGate boarding = new BoardingGate(null, split[0], Convert.ToBoolean(split[2]), Convert.ToBoolean(split[1]), Convert.ToBoolean(split[3]));
        terminal.AddBoardingGate(boarding);
    }
}

// qn2 
void initflight(Terminal terminal)
{
    foreach (string Line in File.ReadLines("flights.csv").Skip(1))
    {
        String[] split = Line.Split(",");
        String[] numsplit = split[0].Split(" ");
        Airline airline = terminal.Airlines[numsplit[0]];
        if (split[4] == "DDJB")
        {
            Flight ftemp = new DDJBFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 300);
            airline.AddFlight(ftemp);
            terminal.Flights[split[0]] = ftemp;
        }
        else if (split[4] == "CFFT")
        {
            Flight ftemp = new CFFTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 150);
            airline.AddFlight(ftemp);
            terminal.Flights[split[0]] = ftemp;
        }
        else if (split[4] == "LWTT")
        {
            Flight ftemp = new LWTTFlight(split[0], split[1], split[2], Convert.ToDateTime(split[3]), "Scheduled", 500);
            airline.AddFlight(ftemp);
            terminal.Flights[split[0]] = ftemp;
        }
        else
        {
            Flight ftemp = new NORMFlight(split[0], split[1], split[2], "Scheduled", Convert.ToDateTime(split[3]));
            airline.AddFlight(ftemp);
            terminal.Flights[split[0]] = ftemp;
        }
    }
}



//foreach (KeyValuePair<string, Flight> kvp in FlightDict)
//{
//    Console.WriteLine(kvp.Value.Status);
//}

// qn3 
void displayflight(Terminal terminal)
{
    Console.WriteLine("=============================================" + '\n' + "List of Flights for Changi Airport Terminal 5" + '\n' + "=============================================");
    Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}", "Flight number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
    foreach (KeyValuePair<string, Flight> flightkvp in terminal.Flights)
    {
        String[] splitkey = flightkvp.Key.Split(" ");
        Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-15}", flightkvp.Value.FlightNumber, terminal.Airlines[splitkey[0]].Name, flightkvp.Value.Origin, flightkvp.Value.Destination, flightkvp.Value.expectedTime);
    }
}
// qn5
void assigngate(Terminal terminal)
{
    Console.Write("Enter Flight Number: ");
    string Flightnum = Console.ReadLine();
    Console.Write("Enter Boarding Gate Name: ");
    string Boardingnum = Console.ReadLine();

    if (terminal.Flights.ContainsKey(Flightnum.ToUpper()) & (terminal.boardingGates.ContainsKey(Boardingnum.ToUpper())))
    {
        Console.WriteLine("Flight Number: {0}", terminal.Flights[Flightnum].FlightNumber);
        Console.WriteLine("Origin: {0}", terminal.Flights[Flightnum].Origin);
        Console.WriteLine("Expected Time: {0}", terminal.Flights[Flightnum].expectedTime);
        Console.WriteLine(Convert.ToString(terminal.Flights[Flightnum].GetType()));
        string type = Convert.ToString(terminal.Flights[Flightnum].GetType().Namespace);
        string[] typesplit = type.Split(".");
        if (terminal.Flights[Flightnum].GetType().Namespace == "CFFTFlight")
        {
            Console.WriteLine("Special Request Code: {0}", "CFFT");
        }
        else if (terminal.Flights[Flightnum].GetType().Namespace == "DDJBFlight")
        {
            Console.WriteLine("Special Request Code: {0}", "DDJB");
        }
        else if (terminal.Flights[Flightnum].GetType().Namespace == "LWTTFlight")
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
            List<string> statuslist = new List<string>() { "Delayed", "Boarding", "On Time" };
            Console.WriteLine("1.Delayed" + '\n' + "2.Boarding" + '\n' + "3.On Time");
            Console.Write("Please select the new status of the flight: ");
            int statusoption = Convert.ToInt32(Console.ReadLine());
            terminal.Flights[Flightnum].Status = statuslist[statusoption - 1];
            if (terminal.Flights[Flightnum].GetType().Namespace == "CFFTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new CFFTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption - 1], 150);
            }
            else if (terminal.Flights[Flightnum].GetType().Namespace == "DDJBFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new DDJBFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption - 1], 300);
            }
            else if (terminal.Flights[Flightnum].GetType().Namespace == "LWTTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new LWTTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, statuslist[statusoption - 1], 500);
            }
            else
            {
                terminal.boardingGates[Boardingnum].Flight = new NORMFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, statuslist[statusoption - 1], terminal.Flights[Flightnum].expectedTime);
            }
        }
        else if (option == "N")
        {
            if (terminal.Flights[Flightnum].GetType().Namespace == "CFFTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new CFFTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 150);
            }
            else if (terminal.Flights[Flightnum].GetType().Namespace == "DDJBFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new DDJBFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 300);
            }
            else if (terminal.Flights[Flightnum].GetType().Namespace == "LWTTFlight")
            {
                terminal.boardingGates[Boardingnum].Flight = new LWTTFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].expectedTime, terminal.Flights[Flightnum].Status, 500);
            }
            else
            {
                terminal.boardingGates[Boardingnum].Flight = new NORMFlight(Flightnum, terminal.Flights[Flightnum].Origin, terminal.Flights[Flightnum].Destination, terminal.Flights[Flightnum].Status, terminal.Flights[Flightnum].expectedTime);
            }
        }
        Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", Flightnum, Boardingnum);
    }
    else
    {
        Console.WriteLine("Error: wrong gate or wrong plane number, please retry again");
    }

}
// qn6
void createflight(Terminal terminal)
{
    try
    {
        Console.Write("Enter Flight Number: ");
        string flightnum = Console.ReadLine();
        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();
        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();
        Console.Write("Enter Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
        DateTime datetime = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
        string requestcode = Console.ReadLine();
        String[] split = flightnum.Split(" ");
        Airline airline = terminal.Airlines[split[0]];
        while (true)
        {
            if (new[] { "DDJB", "CFFT", "LWTT", "NONE" }.Contains(requestcode.ToUpper()))
            {
                if (requestcode == "CFFT")
                {
                    Flight CFFT = new CFFTFlight(flightnum, origin, destination, datetime, "Scheduled", 150);
                    terminal.Flights[flightnum] = CFFT;
                }
                else if (requestcode == "DDJBFlight")
                {
                    Flight DDJB = new DDJBFlight(flightnum, origin, destination, datetime, "Scheduled", 300);
                    terminal.Flights[flightnum] = DDJB;
                }
                else if (requestcode == "LWTTFlight")
                {
                    Flight LWTT = new LWTTFlight(flightnum, origin, destination, datetime, "Scheduled", 500);
                    terminal.Flights[flightnum] = LWTT;
                }
                else
                {
                    Flight NORM = new NORMFlight(flightnum, origin, destination, "Scheduled", datetime);
                    terminal.Flights[flightnum] = NORM;
                }
                Console.WriteLine("Flight {0} has been added!", flightnum);
                return;
            }
            else
            {
                Console.WriteLine("Invalid option, please choose one of these 4 CFFT/DDJB/LWTT/None");
                Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
                requestcode = Console.ReadLine();

            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}
// qn9
// find if flight number is in boarding gate, then it would put the boarding gate name instead otherwise it would put unassigned there
void displayschedule(Terminal terminal)
{
    List<Flight> flightslist = terminal.Flights.Values.ToList();
    flightslist.Sort();
    Console.WriteLine("=============================================" + '\n' + "List of Flights for Changi Airport Terminal 5" + '\n' + "=============================================");
    Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-25}{5,-20}{6,-20}", "Flight number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time", "Status", "Boarding Gate");
    foreach (Flight flight in flightslist)
    {
        String[] split = flight.FlightNumber.Split(" ");
        string gatenum = "unassigned";
        foreach (var gatedata in terminal.boardingGates)
        {
            if (gatedata.Value.Flight != null && gatedata.Value.Flight.FlightNumber == flight.FlightNumber)
            {
                gatenum = gatedata.Value.gateName;
            }
        }
        Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-25}{5,-26}{6,-20}", flight.FlightNumber, terminal.Airlines[split[0]].Name, flight.Origin, flight.Destination, flight.expectedTime, flight.Status, gatenum);
    }
}

//advanced questions 
// QN1 
void Processunassigned(Terminal terminal)
{
    foreach (var gates in terminal.boardingGates.Values)
    {
        Console.WriteLine("Gate: {0}", gates.gateName);
        Console.WriteLine("Supports CFFT: {0}", gates.supportsCFFT);
        Console.WriteLine("Supports LWTT: {0}", gates.supportsLWTT);
        Console.WriteLine("Supports DDJB: {0}", gates.supportsDDJB);
        Console.WriteLine("Flight Assigned: {0}", gates.Flight != null ? gates.Flight.FlightNumber : "None");
        Console.WriteLine("--------------------------------------");
    }
    Queue<Flight> unassignedflight = new Queue<Flight>();
    foreach (var flight in terminal.Flights.Values)
    {
        bool isassigned = false;
        foreach (var gates in terminal.boardingGates.Values)
        {
            if (gates.Flight != null && gates.Flight.FlightNumber == flight.FlightNumber)
            {
                isassigned = true;
                break;
            }
        }
        if (isassigned == false)
        {
            unassignedflight.Enqueue(flight);
            Console.WriteLine(flight.FlightNumber + "has been queued");
        }
    }
    Console.WriteLine("The total number of unassigned planes are: {0}", unassignedflight.Count());
    // goes through the list of queued flights and checks its code against the gates with the code and adds it to the gate it breaks to keep resetting to prevent same flight to take the other gates
    while (unassignedflight.Count() > 0)
    {
        Flight dequed = unassignedflight.Dequeue();
        if (dequed.GetType().Name != "NORMFlight")
        {
            if (dequed.GetType().Name == "CFFTFlight")
            {
                foreach (var gates in terminal.boardingGates.Values)
                {
                    if (gates.supportsCFFT == true && gates.Flight == null)
                    {
                        gates.Flight = dequed;
                        break;
                    }
                }
            }
            else if (dequed.GetType().Name == "LWTTFlight")
            {
                foreach (var gates in terminal.boardingGates.Values)
                {
                    if (gates.supportsLWTT == true && gates.Flight == null)
                    {
                        gates.Flight = dequed;
                        break;
                    }
                }
            }
            else if (dequed.GetType().Name == "DDJBFlight")
            {
                foreach (var gates in terminal.boardingGates.Values)
                {
                    if (gates.supportsDDJB == true && gates.Flight == null)
                    {
                        gates.Flight = dequed;
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (var gates in terminal.boardingGates.Values)
            {
                if (gates.supportsDDJB == false && gates.supportsCFFT == false && gates.supportsLWTT == false && gates.Flight == null)
                {
                    gates.Flight = dequed;
                    Console.WriteLine("Assigned flight {0} to gate {1}", dequed.FlightNumber, gates.gateName);
                    break;
                }
            }
        }
    }
    Console.WriteLine("=============================================" + '\n' + "List of Flights for Changi Airport Terminal 5" + '\n' + "=============================================");
    Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-25}{5,-20}{6,-20}", "Flight number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time", "Status", "Boarding Gate");
    foreach (var flight in terminal.Flights)
    {
        string gatenum = null;
        foreach (var gatedata in terminal.boardingGates)
        {
            if (gatedata.Value.Flight != null && gatedata.Value.Flight.FlightNumber == flight.Value.FlightNumber)
            {
                gatenum = gatedata.Value.gateName;
            }
        }
        Console.WriteLine("{0,-18}{1,-22}{2,-22}{3,-23}{4,-25}{5,-26}{6,-20}{7}", flight.Value.FlightNumber, terminal.Airlines[flight.Value.FlightNumber.Split(" ")[0]].Name, flight.Value.Origin, flight.Value.Destination, flight.Value.expectedTime, flight.Value.Status, gatenum, flight.Value.GetType().Name);
    }
}

// QN2
void airlinecost(Terminal terminal)
{
    foreach (var airline in terminal.Airlines.Values)
    {
        double total = 0;
        double discount = 0;
        double flightdiscount = 0;
        int count = 0;
        foreach (var flight in terminal.Flights.Values)
        {
            if (flight.FlightNumber.Split(" ")[0] == airline.Code)
            {
                count++;
                if (flight.Origin == "Singapore (SIN)")
                {
                    total += 800;
                }
                else if (flight.Destination == "Singapore (SIN)")
                {
                    total += 500;
                }
                if (flight.Origin == "Dubai (DXB)" | flight.Origin == "Bangkok (BKK)" | flight.Origin == "Tokyo (NRT)")
                {
                    discount += 25;
                }
                if (flight.expectedTime.Hour > 21 && flight.expectedTime.Hour < 9)
                {
                    discount += 110;
                }

                if (flight.GetType().Name == "NORMFlight")
                {
                    discount += 50;
                }

                if (flight.GetType().Name == "CFFTFlight")
                {
                    CFFTFlight CFFT = (CFFTFlight)flight;
                    total += CFFT.CalculateFees();
                }
                else if (flight.GetType().Name == "LWTTFlight")
                {
                    LWTTFlight LWTT = (LWTTFlight)flight;
                    total += LWTT.CalculateFees();
                }
                else if (flight.GetType().Name == "DDJBFlight")
                {
                    DDJBFlight DDJB = (DDJBFlight)flight;
                    total += DDJB.CalculateFees();
                }
                else if (flight.GetType().Name == "NORMFlight")
                {
                    NORMFlight NORM = (NORMFlight)flight;
                    total += NORM.CalculateFees();
                }
            }

        }
        if (count > 3)
        {
            int group = count / 3;
            discount += group * 350;
        }
        if (count > 7)
        {
            total = total * 0.97;
            Console.WriteLine("=============================================" + '\n' + "Total Cost" + $"Airline: {airline.Name}" + '\n' + $"total cost before discount: {total}" + '\n' + $"total discount: {discount}" + '\n' + $"total after discount: {total - discount}");
        }
        else
        {
            Console.WriteLine("=============================================" + '\n' + "Total Cost" + $"Airline: {airline.Name}" + '\n' + $"total cost before discount: {total}" + '\n' + $"total discount: {discount}" + '\n' + $"total after discount: {total - discount}");
        }
    }

}

initairline(terminal);
initboarding(terminal);
initflight(terminal);

void displaymenu()
{
    Console.WriteLine("=============================================" + '\n' + "Welcome to Changi Airport Terminal 5" + '\n' + "=============================================" + '\n' + "1. List All Flights" + '\n' + "2. List Boarding Gates" + '\n' + "3. Assign a Boarding Gate to a Flight" + '\n' + "4. Create Flight" + '\n' + "5. Display Airline Flights" + '\n' + "6. Modify Flight Details" + '\n' + "7. Display Flight Schedule" + '\n' + "8. Process all unassigned flights to boarding gates in bulk" + '\n' + "9. Display the total fee per airline for the day" + '\n' + "0. Exit" + '\n');
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
            displayflight(terminal);
        }
        else if (option == 2)
        {
            ListAllBoardingGates();
        }
        else if (option == 3)
        {
            assigngate(terminal);
        }
        else if (option == 4)
        {
            createflight(terminal);
        }
        else if (option == 5)
        {
            DisplayAirlineFlights();
        }
        else if (option == 6)
        {
            ModifyFlightDetails();
        }
        else if (option == 7)
        {
            displayschedule(terminal);
        }
        else if (option == 8)
        {
            Processunassigned(terminal);
        }
        else if (option == 9)
        {
            airlinecost(terminal);
        }
        else if (option == 0)
        {
            Console.WriteLine("Goodbye");
            return;
        }
        else
        {
            Console.WriteLine("Invalid option, please write the number of the above options");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}
