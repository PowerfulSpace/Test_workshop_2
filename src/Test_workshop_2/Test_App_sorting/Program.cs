
string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill"};


var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                     where p.ToUpper().StartsWith("T") //фильтрация по критерию
                     orderby p  // упорядочиваем по возрастанию
                     select p; // выбираем объект в создаваемую коллекцию

foreach (string person in selectedPeople)
    Console.WriteLine(person);
Console.ReadLine();