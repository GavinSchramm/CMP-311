// See https://aka.ms/new-console-template for more information
// These two lines just write out what is said
Console.WriteLine("Hello, World!");
Console.WriteLine("She's a beaut Clark.");

// These three lines print out the question lets the user write their name
Console.Write("What is your name? ");
string name = Console.ReadLine();
Console.WriteLine("Hi there " + name);

int number;
string inputPick = "";
do
{
    Console.Write("Pick a number between 1 and 10: Gavin's Version ");
    inputPick = Console.ReadLine();
    number = int.Parse(inputPick);
} while ((number < 0) || (number > 10));
Console.WriteLine(inputPick);

int theNumber;
do
{
    Console.Write("Pick a number between 1 and 10: Alec's Version ");
    theNumber = Int32.Parse(Console.ReadLine());
    if ((theNumber < 1) || (theNumber > 10))
    {
        Console.WriteLine("Invalid Number");
    }
} while((theNumber < 0) || (theNumber > 10));