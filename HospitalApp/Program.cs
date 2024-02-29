string opt;
string optPatient;
string optDoctor;
string optAppointment;
do
{
    Console.WriteLine("=============================MENU===================================");
    Console.WriteLine("a. Patient ");
    Console.WriteLine("b. Doctor");
    Console.WriteLine("c. Appointment");
    Console.WriteLine("e. Exit");
    Console.WriteLine("Select Opt");
    opt =Console.ReadLine();

    switch (opt)
    {
        case "a":
            do
            {
                Console.WriteLine("======================PATIENT MENU===================================");
                Console.WriteLine("1. Patient creat");
                Console.WriteLine("2. Patient delte");
                Console.WriteLine("3. Patient edit");
                Console.WriteLine("4. Show all patient");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Opt");
                optPatient = Console.ReadLine();
                switch (optPatient)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        Console.WriteLine("Finish");
                        break;
                    default:
                        Console.WriteLine("Opt is wrong");
                        break;
                }

            } while (optPatient != "0");
            break;
        case "b":
            do
            {
                Console.WriteLine("====================DOCTOR  MENU===================================");
                Console.WriteLine("1. Create doctor");
                Console.WriteLine("2. Edit doctor");
                Console.WriteLine("3. Delete doctor");
                Console.WriteLine("4. ShowAll doctors");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Opt");
                optDoctor = Console.ReadLine();
                switch (optDoctor)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        Console.WriteLine("Finish");
                        break;
                    default:
                        Console.WriteLine("Opt is wrong");
                        break;
                }

            } while (optDoctor != "0");

            break;
        case "c":
            do
            {
                Console.WriteLine("=======================APPOOINTMENT  MENU===================================");
                Console.WriteLine("1. Make an appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. Show all appointments");
                Console.WriteLine("4. Filter appointments (by doctor id or patientId or daterange)");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Opt");
                optAppointment = Console.ReadLine();
                switch (optAppointment)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        Console.WriteLine("Finish");
                        break;
                    default:
                        Console.WriteLine("Opt is wrong");
                        break;
                }

            } while ( optAppointment != "0");
            break;
        case "e":
            Console.WriteLine("Finish");
            break;
       default:
            Console.WriteLine("Opt is wrong");
            break;
    }
    

}while(opt!="e");
//void ShowMenu()
//{
//    Console.WriteLine("=============================MENU===================================");
//    Console.WriteLine("1.1 Patient creat");
//    Console.WriteLine("1.2. Patient delte");
//    Console.WriteLine("1.3. Patient edit");
//    Console.WriteLine("1.4. Show all patient");
//    Console.WriteLine("2.1. Create doctor");
//    Console.WriteLine("2.2. Edit doctor");
//    Console.WriteLine("2.3 Delete doctor");
//    Console.WriteLine("2.4 ShowAll doctors");
//    Console.WriteLine("3.1. Make an appointment");
//    Console.WriteLine("3.2 Cancel Appointment");
//    Console.WriteLine("3.3 Show all appointments");
//    Console.WriteLine("3.4 Filter appointments (by doctor id or patientId or daterange)");
//    Console.WriteLine("0.Finish");
//    Console.WriteLine("====================================================================");

//}