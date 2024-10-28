string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

var selectedPeople = new List<string>();

foreach (string person in people)
{

    if (person.ToUpper().StartsWith("T"))
        selectedPeople.Add(person);
}

selectedPeople.Sort();

foreach (string person in selectedPeople)
    Console.WriteLine(person);

Console.ReadLine();