namespace PersonNS;
internal class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private Func<DateTime> generateBirthDate = GenerateBirthDate();
    private readonly DateTime birthDate;

    public Person(string? firstName = null, string? lastName = null, int? age = null, DateTime? dateTime = null)
    {
        this.FirstName = firstName ?? "Niepodano Imienia";
        this.LastName = lastName ?? "Niepodano Nazwiska"; 
        this.birthDate = dateTime ?? this.generateBirthDate();
        this.Age = age ?? 0;
    }

    public string FirstName
    {
        get { return firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value >= 0)
                this.age = value;
            else
                Console.WriteLine("Wiek nie może być ujemny.");
        }
    }
    public static Func<DateTime> GenerateBirthDate()
    {
        DateTime start = new DateTime(1995, 1, 1);
        Random gen = new Random();
        int range = ((TimeSpan)(DateTime.Today - start)).Days;
        return () => start.AddDays(gen.Next(range));
    }

    public void ShowCardDetails()
    {
        Console.WriteLine($@"Informacje o {this.firstName} {this.lastName}");
        Console.WriteLine($@"Urodzono w dniu {this.birthDate.Day}.{this.birthDate.Month}.{this.birthDate.Year} ");
        Console.WriteLine($@"wiek:{this.age}");
    }
}