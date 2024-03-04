using Core.Entitiy;
using Data;
using Service;
using System.Globalization;
using System.Text.RegularExpressions;

static void DisplayFilteredAppointments(List<Appointment> filteredAppointments)
{
    Console.WriteLine("Filtered Appointments:");
    foreach (var appointment in filteredAppointments)
    {
        Console.WriteLine($"{appointment.Id}. Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}, Date: {appointment.StartDate}");
    }

    if (filteredAppointments.Count == 0)
    {
        Console.WriteLine("No appointments found.");
    }
}
string opt;
string optPatient;
string optDoctor;
string optAppointment;

try
{
    do
    {
        Console.WriteLine("=============================MENU===================================");
        Console.WriteLine("a. Patient ");
        Console.WriteLine("b. Doctor");
        Console.WriteLine("c. Appointment");
        Console.WriteLine("e. Exit");
        Console.WriteLine("Select Opt");

        opt = Console.ReadLine().ToLower();
        HosbitalDbContext context = new HosbitalDbContext();
        PatientService patientService = new PatientService();
        DoctorService doctorService = new DoctorService();
        AppointmentService appointmentService = new AppointmentService();
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
                            {
                                try
                                {
                                    // 1. Patient create
                                    Console.WriteLine("Patient create");
                                    Console.Write("FullName: ");
                                    string fullname = Console.ReadLine();

                                    string email;
                                    bool validEmail = false;

                                    do
                                    {
                                        Console.Write("Email: ");
                                        email = Console.ReadLine();

                                        if (IsValidEmail(email))
                                        {
                                            validEmail = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Email format is not true,please again try.");
                                        }
                                    } while (!validEmail);

                                    var newPatient = new Patient
                                    {
                                        Fullname = fullname,
                                        Email = email,
                                    };

                                    patientService.Create(newPatient);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error happen: " + ex.Message);
                                }
                            }
                            break;

                             static bool IsValidEmail(string email)
                            {
                                try
                                {
                                    var addr = new System.Net.Mail.MailAddress(email);
                                    return addr.Address == email;
                                }
                                catch
                                {
                                    return false;
                                }
                            }

                        case "2":
                            //2.Patient delete
                            Console.WriteLine(" Patient delete");
                            Console.WriteLine("All Patients");
                            var patients = patientService.ShowAll();
                            foreach (var patientInfo in patients)
                            {
                                Console.WriteLine(patientInfo);
                            }
                            int deleteId = GetId();

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

                            if (patients.Count!=0)
                            {
                                foreach (var patientInfo in patients)
                                {
                                    Console.WriteLine(patientInfo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No patients found.");
                            }
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
                            { 
                            try
                            {
                                Console.WriteLine(" Doctor creat");
                                Console.Write("FullName: ");
                                string fullname = Console.ReadLine();

                                string email;
                                bool validEmail = false;

                                do
                                {
                                    Console.Write("Email: ");
                                    email = Console.ReadLine();

                                    if (IsValidEmail(email))
                                    {
                                        validEmail = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Email format is not true,please again try.");
                                    }
                                } while (!validEmail);

                                var newdoctor1 = new Doctor
                                {
                                    Fullname = fullname,
                                    Email = email,
                                };

                                doctorService.Create(newdoctor1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error happen: " + ex.Message);
                            }
                    }
                    break;

                    static bool IsValidEmail(string email)
                    {
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(email);
                            return addr.Address == email;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                
                        case "2":
                            Console.WriteLine(" Edit doctor");
                            Console.WriteLine("All Doctors :");
                            var doctors1 = doctorService.ShowAll();
                            foreach (var item in doctors1)
                            {
                                Console.WriteLine(item);
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

                            Console.WriteLine("All Doctors ");
                            doctors1 = doctorService.ShowAll();
                            foreach (var item in doctors1)
                            {
                                Console.WriteLine(item);
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
                            doctors1 = doctorService.ShowAll();

                            if (doctors1.Count == 0)
                            {
                                Console.WriteLine("No doctors found.");
                            }
                            else
                            {
                                foreach (var item in doctors1)
                                {
                                    Console.WriteLine(item);
                                }
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
                            Console.WriteLine("All Doctors ");
                            var doctors3 = doctorService.ShowAll();
                            foreach (var item in doctors3)
                            {
                                Console.WriteLine(item);
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
                                Doctor doctor = doctorService.GetById(item.DoctorId);
                                Patient patient = patientService.GetById(item.PatientId);

                                Console.WriteLine($"{item.Id}. Doctor: {doctor.Fullname}, Patient: {patient.Fullname}, Date: {item.StartDate}");
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

                            if (appointmentAll.Count == 0)
                            {
                                Console.WriteLine("No appoinment found.");
                            }
                            else
                            {
                                foreach (var item in appointmentAll)
                                {
                                    Doctor doctor = doctorService.GetById(item.DoctorId);
                                    Patient patient = patientService.GetById(item.PatientId);

                                    Console.WriteLine($"{item.Id}. Doctor: {doctor.Fullname}, Patient: {patient.Fullname}, Date: {item.StartDate}");
                                }
                            }
                            break;

                        case "4":
                            Console.WriteLine(" Filter appointments (by doctor id or patientId or daterange)");
                            Console.WriteLine("1. Filter by Doctor ID");
                            Console.WriteLine("2. Filter by Patient ID");
                            Console.WriteLine("3. Filter by Date Range");
                            Console.WriteLine("0. Exit");
                            Console.Write("Select Opti: ");
                            string filterOption = Console.ReadLine();
                            switch (filterOption)
                            {
                                case "1":
                                    Console.WriteLine(" ShowAll doctors");
                                    var doctors1 = doctorService.ShowAll();
                                    foreach (var item in doctors1)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.Write("Enter DoctorId: ");
                                    int filterDoctorId;
                                    if (int.TryParse(Console.ReadLine(), out filterDoctorId))
                                    {
                                        var filteredAppointments = appointmentService.FilterByDoctor(filterDoctorId);
                                        DisplayFilteredAppointments(filteredAppointments);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong");
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("All Patients");
                                    patients = patientService.ShowAll();
                                    foreach (var patientInfo in patients)
                                    {
                                        Console.WriteLine(patientInfo);
                                    }
                                    Console.Write("Enter PatienId: ");
                                    int filterPatientId;
                                    if (int.TryParse(Console.ReadLine(), out filterPatientId))
                                    {
                                        var filteredAppointments = appointmentService.FilterByPatient(filterPatientId);
                                        DisplayFilteredAppointments(filteredAppointments);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong");
                                    }
                                    break;

                                case "3":
                                    Console.Write("Enter Start Date (yyyy/MM/dd): ");
                                    DateTime filterStartDate;
                                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out filterStartDate))
                                    {
                                        Console.Write("Enter End Date (yyyy/MM/dd): ");
                                        DateTime filterEndDate;
                                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out filterEndDate))
                                        {
                                            var filteredAppointments = appointmentService.FilterByDateRange(filterStartDate, filterEndDate);
                                            DisplayFilteredAppointments(filteredAppointments);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong");
                                    }
                                    break;

                                case "0":
                                    Console.WriteLine("Finish");
                                    break;

                                default:
                                    Console.WriteLine("wrong");
                                    break;
                            }

                            break;
                        case "0":
                            Console.WriteLine("Finished");
                            break;
                        default:
                            Console.WriteLine("Opt is wrong");
                            break;
                    }

                } while (optAppointment != "0");
                break;
            case "e":
                Console.WriteLine("Finish");
                break;
            default:
                Console.WriteLine("Opt is wrong");
                break;
        }


    } while (opt != "e");

}

catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(" Error happen: " + ex.Message);
}

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
