﻿// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

////TP1-Q7: Créer un objet de type Plane en utilisant le constructeur non paramétré
//Plane plane1 = new Plane();
//plane1.PlaneType = PlaneType.Airbus;
//plane1.Capacity = 200;
//plane1.ManufactureDate = new DateTime(2018, 11, 10);

////TP1-Q8: Créer un objet de type Plane en utilisant le constructeur paramétré
//Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);

////TP1-Q9: Créer un objet de type Plane en utilisant l'initialiseur d'objet
//Plane plane3 = new Plane
//{
//    PlaneType = PlaneType.Airbus,
//    Capacity = 150,
//    ManufactureDate = new DateTime(2015, 02, 03)
//};


//Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");
//Passenger p1 = new Passenger { FullName = new FullName { FirstName = "steave", LastName = "jobs" }, EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
//Console.WriteLine("La méthode CheckProfile:");
//Console.WriteLine(p1.CheckProfile("steave", "jobs"));
//Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail.com"));

//Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");
//Staff s1 = new Staff { FullName = new FullName { FirstName = "Bill", LastName = "Gates" }, EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };
//Traveller t1 = new Traveller { FullName  = new FullName { FirstName = "Mark", LastName = "Zuckerburg" }, EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };
//Console.WriteLine("La méthode PassengerType p1:");
//p1.PassengerType();
//Console.WriteLine("La méthode PassengerType s1:");
//s1.PassengerType();
//Console.WriteLine("La méthode PassengerType t1:");
//t1.PassengerType();





////TP2-Q5:Créer une instance de la classe ServiceFlight
//ServiceFlight sf = new ServiceFlight(new UnitOfWork(new AMContext(), typeof(GenericRepository<>)));
////TP2-Q5:Affecter listFlights à la propriété Flights de la classe ServiceFlight
////sf.Flights = TestData.listFlights;

//Console.WriteLine("************************************ GetFlightDates (string destination)  ****************************** ");
//Console.WriteLine("Flight dates to Madrid");
//foreach (var item in sf.GetFlightDates("Madrid"))
//    Console.WriteLine(item);

//Console.WriteLine("************************************ GetFlights(string filterType, string filterValue)  ****************************** ");
//sf.GetFlights("Destination", "Paris");


//Console.WriteLine("************************************ ShowFlightDetails(Plane plane)  ****************************** ");
//sf.ShowFlightDetails(TestData.Airbusplane);

//Console.WriteLine("************************************ ProgrammedFlightNumber(DateTime startDate)  ****************************** ");
//Console.WriteLine("Number of programmed flights in 01/01/2022 week: ");
//Console.WriteLine(sf.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));
//Console.WriteLine("************************************ DurationAverage(string destination) ****************************** ");
//Console.WriteLine("Duration average of flights to Madrid: " + sf.DurationAverage("Madrid"));
//Console.WriteLine("************************************ OrderedDurationFlights()  ****************************** ");
//foreach (var item in sf.OrderedDurationFlights())
//    Console.WriteLine(item);
//Console.WriteLine("************************************ SeniorTravellers(Flight flight) ****************************** ");
////foreach (var item in sf.SeniorTravellers(TestData.flight1))
////    Console.WriteLine(item);
//Console.WriteLine("************************************ DestinationGroupedFlights()  ****************************** ");
//sf.DestinationGroupedFlights();
//Console.WriteLine("************************************ Testing Delegates  ****************************** ");

//sf.FlightDetailsDel(TestData.BoingPlane);
//Console.WriteLine("Average duration of flight To Paris; " + sf.DurationAverageDel("Paris"));

//Console.WriteLine("************************************ Testing Extension methods  ****************************** ");
//p1.UpperFullName();
//Console.WriteLine("First Name: " + p1.FullName.FirstName + " Last Name: " + p1.FullName.LastName);



//AMContext ctx = new AMContext();
////instanciation des objets
//Plane plane1 = new Plane
//{
//    PlaneType = PlaneType.Airbus,
//    Capacity = 150,
//    ManufactureDate = new DateTime(2015, 02, 03)
//};

//Flight f1 = new Flight() 
//{ 
//    Departure = "Tunis", 
//    Airline = "Tunisair", 
//    FlightDate = new DateTime(2022, 02, 01, 21, 10, 10), 
//    Destination = "Paris", 
//    EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10), 
//    EstimatedDuration = 103, 
//    Plane = plane1
//};


////Ajouter des objets aux DBSET
////ctx.Planes.Add(plane1);
////ctx.Flights.Add(f1);


////persister les données
////ctx.SaveChanges();
//Console.WriteLine(f1.Plane.PlaneId +" "+ f1.Plane.Capacity);
//Console.WriteLine(plane1.PlaneId + " " + plane1.Capacity);


////Partie 6.1

////ServiceFlight service = new ServiceFlight(new GenericRepository<Flight>(ctx));
////service.Add(f1);

////ctx.SaveChanges();

////Partie 6.2

//ServiceFlight service = new ServiceFlight(new UnitOfWork(ctx, typeof(GenericRepository<>)));
//service.Add(f1);

//ctx.SaveChanges();

