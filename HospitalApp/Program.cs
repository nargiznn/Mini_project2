using Core.Entitiy;
using Data;
using Service;
using System.Globalization;
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
    DoctorService doctorService = new DoctorService();
    AppointmentService appointmentService=new AppointmentService();
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
                        Console.WriteLine("All Patients");
                        var patients = patientService.ShowAll();
                        foreach (var patientInfo in patients)
                        {
                            Console.WriteLine(patientInfo);
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
                        Console.WriteLine(" Patient edit");
                        Console.WriteLine("All Patients");
                        patients = patientService.ShowAll();
                        foreach (var patientInfo in patients)
                        {
                            Console.WriteLine(patientInfo);
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
                        Console.WriteLine("All Patients");
                        patients = patientService.ShowAll();
                        foreach (var patientInfo in patients)
                        {
                            Console.WriteLine(patientInfo);
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
                        Console.WriteLine(" Doctor creat");
                        Console.Write("FullName: ");
                        string fullname = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        var newDoctor = new Doctor
                        {
                            Fullname = fullname,
                            Email = email,
                        };
                        doctorService.Create(newDoctor);
                        break;
                    case "2":
                        Console.WriteLine(" Edit doctor");
                        Console.WriteLine("All Patients");
                        var doctors1 = doctorService.ShowAll();
                        foreach (var item in doctors1)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " + "(" + item.Email + ")");
                        }
                        int id = GetId();
                        var newdoctor = GetDoctor();
                        try
                        {
                            doctorService.Update(id, newdoctor);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        Console.WriteLine(" Delete doctor");
                        Console.WriteLine("All Doctors");
                        var doctors2 = doctorService.ShowAll();

                        foreach (var item in doctors2)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " + "(" + item.Email + ")");
                        }
                        var doctors = doctorService.ShowAll();
                        int deleteId = GetId();

                        try
                        {
                            doctorService.Delete(deleteId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine(" ShowAll doctors");
                        Console.WriteLine("All Doctors");
                        var doctors5 = doctorService.ShowAll();

                        foreach (var item in doctors5)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname + " " + "(" + item.Email + ")");
                        }
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
                        Console.WriteLine(" Make an appointment");
                        Console.WriteLine("All Doctors");
                        var doctors2 = doctorService.ShowAll();

                        foreach (var item in doctors2)
                        {
                            Console.WriteLine(item.Id + "." + item.Fullname );
                        }
                        Console.Write("DoctorId: ");
                        int doctorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("All Patients");
                        var patients = patientService.ShowAll();
                        foreach (var patientInfo in patients)
                        {
                            Console.WriteLine(patientInfo);
                        }
                        Console.Write("PatientId: ");
                        int patientId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Datetime (yyyy/MM/dd: ");
                        DateTime startDate;

                        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                        {
                            Console.WriteLine("Invalid date format. Enter the date in the correct format (yyyy/MM/dd): ");
                        }
                        var newappointment = new Appointment
                        {
                            DoctorId = doctorId,
                            PatientId = patientId,
                            StartDate = startDate,
                        };
                        appointmentService.Create(newappointment);
                        break;
                    case "2":
                        Console.WriteLine(" Cancel Appointment");
                        Console.WriteLine("All Appointment");
                        var appointment = appointmentService.ShowAll();

                        foreach (var item in appointment)
                        {
                            Console.WriteLine(item.Id + "." + item.DoctorId + " "+item.PatientId+" "+item.StartDate );
                        }
                        int deleteId = GetId();

                        try
                        {
                            appointmentService.Delete(deleteId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        Console.WriteLine(" Show all appointments");
                        var appointmentAll = appointmentService.ShowAll();

                        foreach (var item in appointmentAll)
                        {
                            Console.WriteLine(item.Id + "." + item.DoctorId + " " + item.PatientId + " " + item.StartDate);
                        }
                        break;
                    case "4":
                        Console.WriteLine(" Filter appointments (by doctor id or patientId or daterange)");
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
Doctor GetDoctor()
{
    Console.Write("Fullname: ");
    string fullname = Console.ReadLine();
    Console.Write("Email: ");
    string email = Console.ReadLine();
    var newdoctor = new Doctor
    {
        Fullname = fullname,
        Email = email
    };

    return newdoctor;

}
