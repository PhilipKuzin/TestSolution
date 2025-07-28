// using System.Globalization;
// using System;
// using System.IO;
//
// public class Person
// {
//     public string Name;
//     public int Age;
//     public string City;
//     public bool IsAlive;
//
//     public Person(string name, int age, string city, bool isAlive)
//     {
//         Name = name;
//         Age = age;
//         City = city;
//         IsAlive = isAlive;
//     }
// }
//
// public struct PersonStruct
// {
//     public string Name;
//     public int Age;
//     public string City;
//     public bool IsAlive;
//     public Data Id;
// }
//
// public class Data
// {
//     public string value;
//
//     public Data(string value)
//     {
//         this.value = value;
//     }
// }
//
// [Flags]
// public enum UserSystemRole : byte
// {
//     User = 0,
//     Admin  = 1 << 0,  
//     Guest  = 1 << 1,  
//     SuperUser = 1 << 2,  
//     BlockedUser = 1 << 3 
// }
//
//
// public class Program
// {
//     
//     public static void Main()
//     {
//         Person firstPerson = new Person("Philipp", 28, "Bryansk", true);
//         Person secondPerson = firstPerson;                                                                                                 
//         
//         ChangePersonCity(firstPerson, "Malang");
//         Console.WriteLine("Person 1 = " + firstPerson.Name + " " +  firstPerson.City + " " +  firstPerson.Age);
//         Console.WriteLine("Person 2 = " + secondPerson.Name + " " +  secondPerson.City + " " +  secondPerson.Age);
//         
//         Console.WriteLine("____________");
//         
//         ChangeOnlyOnePerson(ref firstPerson);
//         Console.WriteLine("Person 1 = " + firstPerson.Name + " " +  firstPerson.City + " " +  firstPerson.Age);
//         Console.WriteLine("Person 2 = " + secondPerson.Name + " " +  secondPerson.City + " " +  secondPerson.Age);
//         
//         Console.WriteLine("____________");
//         CreatePerson(out Person person);
//         Console.WriteLine("Person = " + person.Name + " " +  person.City + " " +  person.Age);
//         
//         Console.WriteLine("____________");
//         ChangePersonName(person, out _);
//         Console.WriteLine("Person = " + person.Name + " " +  person.City + " " +  person.Age);
//         
//         var ivan = CreatePersonByParameters("Ivan", 20);
//         var maria = CreatePersonByParameters("Maria", 21, "Moscow", true);
//         var petr = CreatePersonByParameters("Petr", 22, isAlive: true );
//         var foma = CreatePersonByParameters("Foma", 23, isAlive: true, city: "Karachev");
//         
//         Console.WriteLine("____________");
//         UserSystemRole parsedRole;
//         string role = "Admin";
//         TryParse(role, out parsedRole);
//         Console.WriteLine($"{parsedRole}");
//
//         UserSystemRole userRoles = UserSystemRole.User | UserSystemRole.SuperUser;
//         
//         Console.WriteLine("____________");
//         PersonStruct person1 = new PersonStruct { Name = "Pavel", Age = 20, City = "Grodno", IsAlive = true, Id = new Data("unassignedId") };
//         PersonStruct person2 = person1; 
//         Console.WriteLine(person1.Name); 
//         Console.WriteLine(person2.Name);
//         
//         Console.WriteLine("____________");
//         ChangeNameInPersonStruct(ref person1, "Semen");
//         Console.WriteLine(person1.Name); 
//         Console.WriteLine(person2.Name);
//         
//         Console.WriteLine("____________");
//         PersonStruct personStruct = new PersonStruct { Name = "Maxim", Age = 99, City = "Leningrad", IsAlive = false, Id = new Data("unassignedId")};
//
//         personStruct.Id.value = "particularId";
//
//         PersonStruct lightCopiedPersonStruct = LightCopy(personStruct);
//         PersonStruct deepCopiedPersonStruct = DeepCopy(personStruct);
//         
//         Console.WriteLine(lightCopiedPersonStruct.Id.value); 
//         Console.WriteLine(deepCopiedPersonStruct.Id.value);
//         
//         personStruct.Id.value = "particularIdAfterCopy";
//
//         Console.WriteLine(lightCopiedPersonStruct.Id.value);
//         Console.WriteLine(deepCopiedPersonStruct.Id.value);  
//     }
//     
//     private static void ChangePersonCity(Person person, string newCity)
//     {
//         person.City = newCity;
//     }
//     
//     private static void ChangeOnlyOnePerson(ref Person person)
//     {
//         person = new Person("Philipp", 28, "Bryansk", true);
//     }
//     
//     private static void CreatePerson(out Person person)
//     {
//         person = new Person ("Dmitry", 34, "Edmonton", true);
//     }
//     
//     private static void ChangePersonName(Person person, out string oldName)
//     {
//         oldName = person.Name;
//         person.Name = "Tatiana";
//     }
//     
//     private static Person CreatePersonByParameters(string name, int age, string city = "Unknown", bool isAlive = true)
//     {
//         return new Person (name, age, city, isAlive);
//     }
//     
//     private static bool TryParse(string roleName, out UserSystemRole role)
//     {
//         return Enum.TryParse(roleName, out role);
//     }
//     
//     private static void ChangeNameInPersonStruct(ref PersonStruct person, string newName)
//     {
//         person.Name = newName;
//     }
//     
//     private static PersonStruct LightCopy(PersonStruct original)
//     {
//         return original;
//     }
//     
//     public static PersonStruct DeepCopy(PersonStruct original) 
//     {
//         return new PersonStruct
//         {
//             Name = original.Name,
//             Age = original.Age,
//             City = original.City,
//             IsAlive = original.IsAlive,
//             Id = new Data(original.Id.value)
//         };
//     }
// }
//
//
