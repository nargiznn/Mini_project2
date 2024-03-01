using Core.Entitiy;
using Data;
using Service;
using System.Text.RegularExpressions;

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
    HosbitalDbContext context= new HosbitalDbContext();
    PatientService patientService=new PatientService(); 
    switch (opt)
    {
        case "a":
            do
            {
                Console.WriteLine("======================PATIENT MENU===================================");
                Console.WriteLine("1. Patient creat");
                Console.WriteLine("2. Patient delete");
                Console.WriteLine("3. Patient edit");
                Console.WriteLine("4. Show all patient");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Opt");
                optPatient = Console.ReadLine();
                switch (optPatient)
                {
                    case "1":
                        //1.Patient creat
                        Console.WriteLine(" Patient creat");
                        Console.Write("FullName: ");
                        string fullname=Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        var newPatient = new Patient
                        {
                            Fullname = fullname,
                            Email = email,

                        };
                        patientService.Create(newPatient);
                        break;
                    case "2":
                        //2.Patient delete
                        Console.WriteLine(" Patient delete");
                        var patients2 = patientService.ShowAll();

                        foreach (var item in patients2)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " + "(" + item.Email + ")");
                        }
                        int deleteId= GetId();

                        try
                        {
                            patientService.Delete(deleteId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "3":
                        //3.Patient edit
                        var patients1 = patientService.ShowAll();

                        foreach (var item in patients1)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " + "(" + item.Email + ")");
                        }
                        int id = GetId();
                     var newpatient = GetPatient();
                        try
                        {
                            patientService.Update(id, newpatient);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "4":
                        //4.Show all patient
                        var patients = patientService.ShowAll();

                        foreach (var item in patients)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " +"("+ item.Email+")" );
                        }

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

int GetId(string inputName = "Id")
{
    string idStr;
    int id;
    do
    {
        Console.Write(inputName + ": ");
        idStr = Console.ReadLine();
    } while (!int.TryParse(idStr, out id));

    return id;
}
Patient GetPatient()
{
    Console.Write("Fullname: ");
    string fullname = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();


    var newpatient = new Patient
    {
       Fullname=fullname,
       Email=email 
    };
     
    return newpatient;

}
