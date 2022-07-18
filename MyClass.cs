namespace HospitalSystem
{
    class Program
    {
        static int[] QueusLength = new int[21];
        static string[,] names = new string[21, 6];
        static int[,] statis = new int[21, 6];
        
        static void Menu ()
        {
                Console.WriteLine("1) Add a patient");
                Console.WriteLine("2) Print All patients");
                Console.WriteLine("3) Get Next Patient");
                Console.WriteLine("4) Exit");
        }
        static void ShiftLeft (int spec) // swaping 
        {
            for (int i = QueusLength[spec]; i >= 2; i--)
            {
                string x; int y; 
                if (statis[spec,i-1]!=1)
                {
                        x = names[spec, i-1];
                        names[spec, i-1] = names[spec, i];
                        names[spec, i] = x;
                    
                        y = statis[spec, i - 1];
                        statis[spec, i - 1] = statis[spec, i];
                        statis[spec, i] = y;
                }
            }
        }
        static void AddPatient()
        {
            Console.WriteLine("Please, Enter the specialization ");
            int spec = int.Parse(Console.ReadLine());
            if (QueusLength[spec]==5)
            {
                Console.WriteLine("Sorry, we can't accept more patients");
                return;
            }
            else
            {
                int x = ++QueusLength[spec];
                Console.WriteLine("Please, Enter the patient name");
                string str = Console.ReadLine();

                Console.WriteLine("Please, Enter the status either urgent or regular");
                int status = int.Parse(Console.ReadLine());

                if (status == 1)
                {
                    statis[spec, x] = 1;
                    names[spec, x] = str;
                    ShiftLeft(spec);
                }
                else
                {
                    statis[spec, x] = 0;
                    names[spec, x] = str;
                }

            }
            Console.WriteLine("Done! Please take a rest\n");
        }
        static void Print1SpecPatients(int spec)
        {
            if (QueusLength[spec]>=1)
              Console.WriteLine($"{QueusLength[spec]} Pateints in specilization {spec}: ");
          
            for (int i = 1; i <= QueusLength[spec]; i++)
            {
                Console.Write($"\t{names[spec,i]}\t");
                if (statis[spec,i] == 1)
                    Console.WriteLine("Urgent");
                else
                    Console.WriteLine("Regular");
            }
        }
        static void PrintAllPatient()
        {
            for (int spec = 1; spec < 21; spec++)
                Print1SpecPatients(spec);
        }
        
        static void ShiftRight(int spec)
        {
            for (int i = 1; i <= QueusLength[spec]; i++)
            {
                names[spec, i - 1] = names[spec, i];
                statis[spec, i - 1] = statis[spec, i];
            }
        }

        static void GetNextPatient ()
        {
            Console.WriteLine("Pleas, Enter the specilaization");
            int spec = int.Parse(Console.ReadLine());
            if (QueusLength[spec]==0)
            {
                Console.WriteLine("No patients at the moment, you can take a rest");
                return;
            }
            else
            {
                Console.WriteLine($"{names[spec, 1]} please go with the dr");
                ShiftRight(spec);
                -- QueusLength[spec];
            }
        }

        static void HospitalSystem ()
        {
            
            int choice = -1;
            while (choice == -1)
            {
                Menu();
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    AddPatient();
                else if (choice == 2)
                    PrintAllPatient();
                else if (choice == 3)
                    GetNextPatient();
                else if (choice == 4)
                    break;
                else
                    Console.WriteLine("Invalid choice. Try again"); ;

                choice = -1;
            }
            

        }
        

        static void Main (string[] args)
        {
            HospitalSystem();
        }
    }
}