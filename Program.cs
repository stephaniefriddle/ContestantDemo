using System;
using static System.Console;
//Stephanie Friddle
//3.17.21
//Final Project.
//References: https://www.tutorialsteacher.com/csharp/csharp-arraylist
//https://www.youtube.com/watch?v=GhQdlIFylQ8&list=PLCe2H3piSItlSafIqJBmuVCwSty8qvy4l
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields#:~:text=A%20private%20field%20that%20stores,lifetime%20of%20any%20single%20method.
//https://www.geeksforgeeks.org/object-and-dynamic-array-in-c-sharp/
//https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith?view=net-5.0#System_String_StartsWith_System_String_
//https://stackoverflow.com/questions/13257458/check-if-a-value-is-in-an-array-c
//https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count?view=net-5.0
//Farrell, J. (2018). Microsoft Visual C# 2017: An Introduction to Object-Oriented Programming, Seventh Edition. Mexico: Cengage.


namespace ContestantDemo
{
    class Contestant
    {
        public static readonly string[] talentDescriptions = { "Singing", "Dancing", "Musical Instrument", "Other"};
        public readonly static string[] validTalentCode = { "S", "D", "M", "O"};
        private string _talentCode;
        private string _talentDescription;

        public Contestant(string contestantName, string talentCode)
        {
            ContestantName = contestantName;
            TalentCode = talentCode;
        }
        public string ContestantName { get; set; }
        public string TalentDescription 
        { get
            {
                return _talentDescription;
            }
        }
        public string TalentCode 
        {
            get { return _talentCode; }
            set 
            {
                value = value.ToUpper();
                if (!Array.Exists(validTalentCode, t => t.Equals(value)))
                {
                    _talentCode = "I";
                    WriteLine("You did not provide a valid talent code, it is now set to Invalid.");
                }
                else
                    _talentCode = value;
                if (_talentCode.Equals("I"))
                {
                    _talentDescription = "Invalid";
                }
                else
                {
                    foreach(string talentDescription in talentDescriptions)
                    {
                        if (talentDescription.StartsWith(_talentCode))
                        {
                            _talentDescription = talentDescription;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
                return $"{ContestantName}'s talent is {TalentDescription}.";
        }
    }
    class ChildContestant : Contestant
    {
        public readonly int entryFee = 15;
        public ChildContestant(string contestantName, string talentCode, int age)
            : base(contestantName, talentCode)
        {
                Age = age;
        }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{ContestantName}'s talent is {TalentDescription}. {ContestantName} is {Age} and their entry fee is ${entryFee}.";
        }
    }
    class TeenContestant : Contestant
    {
        public readonly int entryFee = 20;
        public TeenContestant(string contestantName, string talentCode, int age)
             : base(contestantName, talentCode)

        {
                Age = age;
        }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{ContestantName}'s talent is {TalentDescription}. {ContestantName} is {Age} and their entry fee is ${entryFee}.";
        }

    }
    class AdultContestant : Contestant
    {
        public readonly int entryFee = 30;
        public AdultContestant(string contestantName, string talentCode, int age)
            : base(contestantName, talentCode)

        {
                Age = age;
        }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{ContestantName}'s talent is {TalentDescription}. {ContestantName} is {Age} and their entry fee is ${entryFee}.";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfContestants = 0;
            while (numberOfContestants <= 30 && numberOfContestants >= 0)
            {
                WriteLine("Please enter the number of contestants: ");
                int inputNumber;
                inputNumber = int.Parse(ReadLine());
                numberOfContestants = inputNumber;
                if(numberOfContestants <=30 && numberOfContestants >= 0)
                {
                    break;
                }
            }

            Contestant[] enteredContestant = new Contestant[numberOfContestants];
            for(int i = 0; i < enteredContestant.Length; i++)
            {
                WriteLine("Please enter the contestant's full name: ");
                string contestantName = ReadLine();

                foreach (var talentDescription in Contestant.talentDescriptions)
                {
                    WriteLine(talentDescription);
                }
                WriteLine("Please enter the contestant's talent code based on the first letter of the talent above: ");
                string _talentCode = ReadLine();
                WriteLine("Please enter the contestant's age: ");
                int age = Convert.ToInt32(ReadLine());

                if(age < 13)
                {
                    enteredContestant[i] = new ChildContestant(contestantName, _talentCode, age);
                }
                else if(age > 12 && age < 18)
                {
                    enteredContestant[i] = new TeenContestant(contestantName, _talentCode, age);
                }
                else
                {
                    enteredContestant[i] = new AdultContestant(contestantName, _talentCode, age);
                }
            }

            WriteLine("The contestants are:");
            foreach (var contestant in enteredContestant)
            {
                WriteLine(contestant.ToString());
            }
            int revenue = 0;
            foreach(var contestant in enteredContestant)
            {
                if(contestant is ChildContestant)
                {
                    ChildContestant childContestant = contestant as ChildContestant;
                    revenue += childContestant.entryFee;
                }
                if (contestant is TeenContestant)
                {
                    TeenContestant teenContestant = contestant as TeenContestant;
                    revenue += teenContestant.entryFee;
                }
                if (contestant is AdultContestant)
                {
                    AdultContestant adultContestant = contestant as AdultContestant;
                    revenue += adultContestant.entryFee;
                }
            }
            WriteLine("The total expected revenue is $" + revenue);
        }
    }
}
