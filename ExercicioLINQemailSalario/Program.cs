
using ExercicioLINQemailSalario.Entities;

Console.Write("Enter the full file path: ");
string path = Console.ReadLine();

List<Employee> list = new List<Employee>();

using (StreamReader sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string[] line = sr.ReadLine().Split(',');
        string partName = line[0];
        string partEmail = line[1];
        double partSalary = double.Parse(line[2]);

        list.Add(new Employee(partName, partEmail, partSalary));
    }
}

Console.Write("Enter the salary: ");
double salary = double.Parse(Console.ReadLine());

var emailSalary = list.Where(p => p.Salary > salary).Select(p => p.Email);
foreach (string mail in emailSalary)
{
    Console.WriteLine(mail);
}

var sumSalary = list.Where(p => p.Name[0] == 'M').Select(p => p.Salary).DefaultIfEmpty(0).Sum();

Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumSalary);
