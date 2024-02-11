﻿string animalSpecies = "",
    animalID = "",
    animalAge = "",
    animalPhysicalDescription = "",
    animalPersonalityDescription = "",
    animalNickname = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";

var ourAnimals = GenerateSampleEntries(maxPets, 6);

do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    ListMenu();

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // use switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            ListPets(ourAnimals);
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // Display all dogs with a specified characteristic
            Console.WriteLine("\nUNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");

string[,] GenerateSampleEntries(int length, int attributesCount)
{
    string[,] sampleAnimals = new string[length, attributesCount];

    for (int i = 0; i < length; i++)
    {
        switch (i)
        {
            case 0:
                animalSpecies = "dog";
                animalID = "d1";
                animalAge = "2";
                animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                animalNickname = "lola";
                break;

            case 1:
                animalSpecies = "dog";
                animalID = "d2";
                animalAge = "9";
                animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                animalNickname = "gus";
                break;

            case 2:
                animalSpecies = "cat";
                animalID = "c3";
                animalAge = "1";
                animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                animalPersonalityDescription = "friendly";
                animalNickname = "snow";
                break;

            case 3:
                animalSpecies = "cat";
                animalID = "c4";
                animalAge = "3";
                animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                animalNickname = "Lion";
                break;

            default:
                animalSpecies = "";
                animalID = "";
                animalAge = "";
                animalPhysicalDescription = "";
                animalPersonalityDescription = "";
                animalNickname = "";
                break;

        }

        sampleAnimals[i, 0] = "ID #: " + animalID;
        sampleAnimals[i, 1] = "Species: " + animalSpecies;
        sampleAnimals[i, 2] = "Age: " + animalAge;
        sampleAnimals[i, 3] = "Nickname: " + animalNickname;
        sampleAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
        sampleAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    }

    return sampleAnimals;
}
void ListMenu()
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
}
void ListPets(string[,] pets)
{
    for (int i = 0; i < maxPets; i++)
    {
        if (pets[i, 0] != "ID #: ")
        {
            Console.WriteLine();
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine(pets[i, j]);
            }
        }
    }
}
