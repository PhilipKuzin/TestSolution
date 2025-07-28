using System;
using System.Collections.Generic;
using System.Linq;

public class Temperature
{
    private const double ABSOLUTE_ZERO = -273.16;
    private double celsius;

    public double Celsius
    {
        get => celsius;
        set
        {
            if (value < ABSOLUTE_ZERO)
            {
                celsius = ABSOLUTE_ZERO;
                throw new ArgumentException("ИСКЛЮЧЕНИЕ! Температура не может быть ниже абсолютного нуля - устанавливаем минимально допустимое значение");
            }
            celsius = value;
        }
    }
}

public class CounterEntity
{
    public static int InstanceCount { get; private set; }

    public CounterEntity()
    {
        InstanceCount++;
    }
}

public class StringList
{
    private List<string> customList = new List<string>();

    public string this[int index]
    {
        get => customList[index];
        set => customList[index] = value;
    }
    
    public void Add(string item)
    {
        customList.Add(item);
    }
}

public class Geometry
{
    public static (double X, double Y, double Distance) GetFullСoordinatesBy(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);
        return (X: x, Y: y, Distance: distance);
    }
}

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double ExperienceYears { get; set; }
}

public class EmployeeController
{
    public static IEnumerable<(int Id, string FullName, double ExperienceYears)> GetResumes(List<Employee> employeesList)
    {
        return employeesList.Select(employee => 
        (
            Id: employee.Id,
            FullName: $"{employee.FirstName}___{employee.LastName}",
            ExperienceYears: employee.ExperienceYears
        ));
    }
}

public class Program
{
    public static void Main()
    {
        // задача №1
        Temperature temperature = new Temperature();

        try
        {
            Console.WriteLine("Установка корректной температуры");
            temperature.Celsius = 0;
            Console.WriteLine(temperature.Celsius);

            Console.WriteLine("Установка НЕкорректной температуры");
            temperature.Celsius = -280;
            Console.WriteLine(temperature.Celsius);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(temperature.Celsius);
        }
        Console.WriteLine("___________________________");
        
        // задача №2 
        CounterEntity first = new CounterEntity();
        CounterEntity second = new CounterEntity();
        CounterEntity third = new CounterEntity();
        Console.WriteLine($"Количество экземпляров класса = {CounterEntity.InstanceCount}");
        Console.WriteLine("___________________________");
        
        // задача №3
        StringList particularList = new StringList();
        particularList.Add("Александр");
        particularList.Add("Дмитрий");
        particularList.Add("Филипп");
        
        Console.WriteLine("Чтение по индексу 1");
        string firstIndexValue = particularList[1];
        Console.WriteLine(firstIndexValue);
        
        Console.WriteLine("Изменение по индексу 0");
        particularList[0] = "Александр [изменено]";
        
        Console.WriteLine("Чтение по индексу 0");
        Console.WriteLine(particularList[0]); 
        Console.WriteLine("___________________________");

        // задача №4
        Console.WriteLine("Получение координат точки");
        Console.WriteLine(Geometry.GetFullСoordinatesBy(2, 3));
        Console.WriteLine("___________________________");
        
        // задача №5
        var employeeList = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Александр", LastName = "Барышев", ExperienceYears = 3 },
            new Employee { Id = 2, FirstName = "Филипп", LastName = "Кузин", ExperienceYears = 1 },
            new Employee { Id = 3, FirstName = "Дмитрий", LastName = "Ефремов", ExperienceYears = 0.5 }
        };
        
        var resumes = EmployeeController.GetResumes(employeeList);
        Console.WriteLine("Вывод резюме");

        foreach (var resume in resumes)
        {
            Console.WriteLine(
                $"ID: {resume.Id}, " +
                $"ПОЛНОЕ ИМЯ: {resume.FullName}, " +
                $"Опыт: {resume.ExperienceYears}"
            );
        }
        Console.WriteLine("___________________________");
        
        // задача №6
        var eventsArray = new[]    // не получилось через список List 
        {
            new { EventName = "Новый год", Date = new DateTime(DateTime.Now.Year + 1, 1, 1) },
            new { EventName = "День знаний", Date = new DateTime(DateTime.Now.Year, 9, 1) },
            new { EventName = "Годовщина трудоустройства Кузина Ф.Д", Date = new DateTime(DateTime.Now.Year, 10, 8) }
        };
        
        var dictionaryOfEvents = eventsArray.ToDictionary(
            particularEvent => particularEvent.EventName,
            particularEvent => (int)(particularEvent.Date.Date - DateTime.Today).TotalDays
        );
        
        Console.WriteLine("Ожидание до мероприятий");
        foreach (var someEvent in dictionaryOfEvents)
        {
            Console.WriteLine($"{someEvent.Key}: {someEvent.Value} д.");
        }
        Console.WriteLine("___________________________");
        
        // задача №7
        var listOfProductsStats = new List<(string ProductName, int Sold, double Price)>
        {
            ("Булка хлеба", 100, 50),
            ("Колбаса", 100, 170),
            ("Ломоть сыра", 100, 180),
        };
        
        var items = listOfProductsStats.Select(statistic => new
        {
            statistic.ProductName,
            TotalSold = statistic.Sold,
            Revenue = statistic.Sold * statistic.Price
        });
        
        Console.WriteLine("Выручка по продукта");
        foreach (var item in items)
        {
            Console.WriteLine(
                $" Продукт: {item.ProductName}" + 
                $" Продано: {item.TotalSold}" +  
                $" Выручка: {item.Revenue}"   
            );
        }
        Console.WriteLine("___________________________");
    }
}


