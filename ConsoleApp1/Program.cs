using System;
using System.Linq;

class Triangle
{
    protected int a, b, c;
    protected int color;

    public Triangle(int sideA, int sideB, int sideC, int color)
    {
        if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
        {
            a = sideA;
            b = sideB;
            c = sideC;
            this.color = color;
        }
        else
        {
            throw new ArgumentException("Неможливо створити трикутник з такими сторонами!");
        }
    }

    public int A
    {
        get => a;
        set
        {
            if (value + b > c && value + c > b && b + c > value)
                a = value;
            else
                throw new ArgumentException("Неможливо встановити таке значення для a!");
        }
    }

    public int B
    {
        get => b;
        set
        {
            if (a + value > c && a + c > value && value + c > a)
                b = value;
            else
                throw new ArgumentException("Неможливо встановити таке значення для b!");
        }
    }

    public int C
    {
        get => c;
        set
        {
            if (a + b > value && a + value > b && b + value > a)
                c = value;
            else
                throw new ArgumentException("Неможливо встановити таке значення для c!");
        }
    }

    public int Color => color;

    public void PrintInfo()
    {
        Console.WriteLine($"Сторони: {a}, {b}, {c}");
        Console.WriteLine($"Периметр: {a + b + c}");
        double p = (a + b + c) / 2.0;
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine($"Площа: {area:F2}");
        Console.WriteLine($"Колір: {color}\n");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
    }
}

class Employee : Person
{
    public string Position { get; set; }
    public Employee(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override void Show()
    {
        Console.WriteLine($"Службовець - {Name}, Вік: {Age}, Посада: {Position}");
    }
}

class Worker : Person
{
    public string WorkType { get; set; }
    public Worker(string name, int age, string workType) : base(name, age)
    {
        WorkType = workType;
    }

    public override void Show()
    {
        Console.WriteLine($"Робітник - {Name}, Вік: {Age}, Тип роботи: {WorkType}");
    }
}

class Engineer : Person
{
    public string Specialty { get; set; }
    public Engineer(string name, int age, string specialty) : base(name, age)
    {
        Specialty = specialty;
    }

    public override void Show()
    {
        Console.WriteLine($"Інженер - {Name}, Вік: {Age}, Спеціалізація: {Specialty}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть варіант:");
        Console.WriteLine("1 - Робота з трикутниками");
        Console.WriteLine("2 - Робота з людьми");
        Console.Write("Ваш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Скільки трикутників створити? ");
                int count = int.Parse(Console.ReadLine());
                Triangle[] triangles = new Triangle[count];

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\nВведіть дані для трикутника {i + 1}:");
                    Console.Write("Сторона a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Сторона b: ");
                    int b = int.Parse(Console.ReadLine());
                    Console.Write("Сторона c: ");
                    int c = int.Parse(Console.ReadLine());
                    Console.Write("Колір трикутника (число): ");
                    int color = int.Parse(Console.ReadLine());

                    try
                    {
                        triangles[i] = new Triangle(a, b, c, color);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        i--; // Повторний ввід для поточного індексу
                    }
                }

                Console.WriteLine("\nІнформація про трикутники:");
                foreach (var triangle in triangles)
                {
                    triangle.PrintInfo();
                }
                break;

            case 2:
                Person[] people =
                {
                    new Employee("Олег", 35, "Менеджер"),
                    new Worker("Андрій", 28, "Зварювальник"),
                    new Engineer("Марина", 40, "Електроніка"),
                    new Worker("Іван", 30, "Будівельник"),
                    new Engineer("Світлана", 45, "Механіка")
                };

                Console.WriteLine("Список до сортування:");
                foreach (var person in people) person.Show();

                Console.WriteLine("\nСписок після сортування за віком:");
                foreach (var person in people.OrderBy(p => p.Age)) person.Show();
                break;

            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }
}
 