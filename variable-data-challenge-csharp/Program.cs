string animalSpecies = "",
    animalID = "",
    animalAge = "",
    animalPhysicalDescription = "",
    animalPersonalityDescription = "",
    animalNickname = "";

string suggestedDonation = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0;

var ourAnimals = GenerateSampleEntries(maxPets, 7);

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
            string dogCharacteristic = "",
                dogDescription = "";
            bool hasNoMatch = true;

            while (dogCharacteristic == "")
            {
                Console.WriteLine($"\nEnter one desired dog characteristic to search for");
                readResult = Console.ReadLine();

                if (readResult != null)
                    dogCharacteristic = readResult.ToLower().Trim();
            }

            for (int i = 0; i < maxPets; i++)
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    dogDescription = $"{ourAnimals[i, 4]}\n{ourAnimals[i, 5]}";

                    if (dogDescription.Contains(dogCharacteristic))
                    {
                        hasNoMatch = false;

                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(dogDescription);
                    }
                }

            if (hasNoMatch)
                Console.WriteLine($"None of our dogs are a match found for: {dogCharacteristic}");

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
                suggestedDonation = "85.00";

                break;

            case 1:
                animalSpecies = "dog";
                animalID = "d2";
                animalAge = "9";
                animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                animalNickname = "gus";
                suggestedDonation = "49.99";

                break;

            case 2:
                animalSpecies = "cat";
                animalID = "c3";
                animalAge = "1";
                animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                animalPersonalityDescription = "friendly";
                animalNickname = "snow";
                suggestedDonation = "40.00";

                break;

            case 3:
                animalSpecies = "cat";
                animalID = "c4";
                animalAge = "3";
                animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                animalNickname = "Lion";
                suggestedDonation = "";

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

        if (!decimal.TryParse(suggestedDonation, out decimalDonation))
        {
            decimalDonation = 45.00m;
        }

        sampleAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
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
            for (int j = 0; j < 7; j++)
            {
                Console.WriteLine(pets[i, j]);
            }
        }
    }
}
