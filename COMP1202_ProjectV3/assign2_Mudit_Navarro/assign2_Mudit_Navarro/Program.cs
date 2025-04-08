using System.ComponentModel.Design;
using System.Text.Json;

namespace assign2_Mudit_Navarro
{
    internal class Program
    {
        static List<Student> studentList = new List<Student>();
        static void Save() {
            // Save the Students 
            string jsonStudents = JsonSerializer.Serialize(studentList, new JsonSerializerOptions { WriteIndented = true });
            if (File.Exists("students.json"))
            {
                File.WriteAllText("student.json", jsonStudents);
            } else
            { // **MUST** will have a problem when User loads and then saves. This will rewrite data twice
                File.AppendAllText("student.json", jsonStudents);
            }
        }
        static int Menu()
        {
            // Application Menu
            Console.WriteLine("\nCHOOSE AN OPTION\n");
            Console.WriteLine("1 - Add a new Student");
            Console.WriteLine("2 - Add a new Course");
            Console.WriteLine("3 - Register a Student to a Course");
            Console.WriteLine("4 - Display existing Students");
            Console.WriteLine("5 - Display existing Courses");
            Console.WriteLine("6 - Display Students with Registrations");
            Console.WriteLine("7 - Save current Session");
            Console.WriteLine("8 - Load previous Session");
            Console.WriteLine("9 - Exit Application");
            Console.Write("Enter a valid option: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            // Important variable declarations
            bool exit = false;
            int choice;

            while (!exit)
            {
                Console.WriteLine("========= Dummy College Institution Menu =========");
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        AddNewStudent();
                        break;
                    case 4:
                        Console.Clear();
                        if (studentList.Any()) 
                        {
                            // List is not empty
                            DisplayAllStudents();
                        }
                        else
                        {
                            Console.WriteLine("List Empty! Add students first.");
                        }
                        
                        break;
                    case 7:
                        Console.Clear();
                        Save();
                        Console.WriteLine("All Data for Current Session has been saved");
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("*Error: Please input a valid option!");
                        break;
                }
            }
        }

        private static void AddNewStudent()
        {
            // Important Variable Declarations
            Student student = new Student();

            // Implementation
            Console.Write("Student Name: ");
            student.Name = Console.ReadLine(); // **MUST** implement a validation for these
            Console.Write("Student Email Address: ");
            student.Email = Console.ReadLine();
            
            studentList.Add(student);

            // Return to Menu
            Console.Clear();
            Console.WriteLine($"Student {student.Name} added Successfully!");
        }
        private static void DisplayAllStudents()
        {
            Console.WriteLine("========= Existing Students =========");
            foreach (Student student in studentList)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
