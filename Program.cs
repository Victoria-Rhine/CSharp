using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnimalRescue
{
    /* Base class Animal
       Abstract class */
    public abstract class Animal
    {
        public static int NumOfAnimals = 0; // Static field attribute keeps count of total animals

        // Properties
        public string Name { get; set; }
        public double Age { get; set; }
        protected char Sex { get; set; }
        protected string Color { get; set; }
        public string Breed { get; set; }
        protected double Weight { get; set; }
        public double AdoptionFee { get; set; }
        protected string Traits { get; set; }
        protected int HappinessLevel { get; set; }
        public bool Adopted { get; set; }
        
        // Default constructor
        public Animal()
        {
            Name = "No Name";
            Age = 0;
            Sex = '?';
            Color = "No Color";
            Breed = "No Breed";
            Weight = 0;
            AdoptionFee = 0;
            Traits = "No Traits";
            HappinessLevel = 7;
            Adopted = false;

            NumOfAnimals++;
        }

        // Instance constructor
        public Animal(string name, double age, char sex, string color, 
            string breed, double weight, double adoptionFee, string traits)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Color = color;
            Breed = breed;
            Weight = weight;
            AdoptionFee = adoptionFee;
            Traits = traits; 
            HappinessLevel = 7;
            Adopted = false;

            NumOfAnimals++;
        }

        public static int getNumOfAnimals()
        {
            return NumOfAnimals;
        }

        /* Following three methods have virtual modifier which indicates
           to derived classes that they can override these methods */
        public virtual void HappySound()
        {
            Console.WriteLine("A generic happy sound...");
        }

        public virtual void UnhappySound()
        {
            Console.WriteLine("A generic unhappy sound...");
        }

        // Prints animal description
        public virtual void getDescription()
        {
            Console.WriteLine(Color + ", " + Sex + ", " + Age + " Years Old\nAdoption Fee: "
                + AdoptionFee.ToString("C", CultureInfo.CurrentCulture) + "\n" + Traits);
        }

        /* Various interactions available for animals
           Interactions increase or decrease animal's happiness */
        public void GiveTreat()
        {
            Console.WriteLine("You give " + Name + " a treat.");
            this.HappySound();
            Console.WriteLine("Happiness Level++");
            HappinessLevel++;
        }

        public void Pet()
        {
            Console.WriteLine("You pet " + Name + ".");
            this.HappySound();
            Console.WriteLine("Happiness Level++");
            HappinessLevel++;
        }

        public void Play()
        {
            Console.WriteLine("You play with " + Name + ".");
            this.HappySound();
            Console.WriteLine("Happiness Level++");
            HappinessLevel++;
        }

        public void Snuggle()
        {
            Console.WriteLine("You snuggle with " + Name + ".");
            this.HappySound();
            Console.WriteLine("Happiness Level++");
            HappinessLevel++;
        }

        public void Startle()
        {
            Console.WriteLine("You accidentally startle " + Name + "!");
            this.UnhappySound();
            Console.WriteLine("Happiness Level--");
            HappinessLevel--;
        }

        // Customer can adopt an animal when the animal's happiness reaches 10
        public bool Adopt()
        {
            if(this.Adopted == true)
            {
                Console.WriteLine("Sorry, this animal was recently adopted.");
                return false;
            }
            else if (HappinessLevel < 10)
            {
                this.UnhappySound();
                Console.WriteLine(this.Name + " isn't ready to leave with you. Try interacting more.");
                return false;
            }
            else
            {
                this.HappySound();
                Console.WriteLine(this.Name + " is ready to go home with you!");
                NumOfAnimals--;
                return true;
            }
        }
    }

    // Cat inherits from Animal
    public class Cat : Animal
    {
        // Properties
        private string IsFixed { get; set; }
        private string IsHousetrained { get; set; }

        // Cat constructor that assigns values to member variables
        public Cat(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee, 
            string traits, string isFixed, string isHousetrained)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits)
        {
            this.IsFixed = isFixed;
            this.IsHousetrained = isHousetrained;
        }

        /* Following three methods have an override modifier which allows
           methods to override the virtual method of its base class */
        public override void getDescription()
        {
            base.getDescription();
            Console.WriteLine("Fixed: " + IsFixed + ", Housetrained: " + IsHousetrained);
        }

        public override void HappySound()
        {
            Console.WriteLine("Meow!");
        }

        public override void UnhappySound()
        {
            Console.WriteLine("Hiss!");
        }
    }

    // DomesticShorthair inherits from Cat
    public class DomesticShorthair : Cat
    {
        public DomesticShorthair(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string isFixed, string isHousetrained)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits, isFixed, isHousetrained)
        {

        }

        public static void DomesticShorthairFacts()
        {
            Console.WriteLine("Friendly, playful, and agreeable are just a few of the words that describe my personality." +
                "\nWe're furry friends that are a welcome addition to busy and calm households alike.");
        }
    }

    // Siamese inherits from Cat
    public class Siamese : Cat
    {
        public Siamese(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string isFixed, string isHousetrained)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits, isFixed, isHousetrained)
        {

        }

        public static void SiameseFacts()
        {
            Console.WriteLine("I'm an outgoing, social cat and rely heavily on human companionship." +
                "\nThis is not a cat to have if you're not home often, as they get lonely and sad fairly easily.");
        }
    }

    // Dog inherits from Animal
    public class Dog : Animal
    {
        // Properties
        private string KidFriendly { get; set; }
        private string CatFriendly { get; set; }

        public Dog(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string kidFriendly, string catFriendly)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits)
        {
            this.KidFriendly = kidFriendly;
            this.CatFriendly = catFriendly;
        }

        /* Following three methods have an override modifier which allows
           methods to override the virtual method of its base class */
        public override void getDescription()
        {
            base.getDescription();
            Console.WriteLine("Kid-friendly: " + KidFriendly + "\nCat-Friendly: " + CatFriendly);
        }

        public override void HappySound()
        {
            Console.WriteLine("Woof!");
        }

        public override void UnhappySound()
        {
            Console.WriteLine("Grr...");
        }
    }

    // German Shephard inherits from Dog
    public class GermanShephard : Dog
    { 
        public GermanShephard(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string kidFriendly, string catFriendly)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits, kidFriendly, catFriendly)
        {

        }

        public static void GermanShephardFacts()
        {
            Console.WriteLine("I'm a large-sized breed belonging to the herding group of working dogs." +
                "\nI require an active lifestyle and make for an ideal companion and protector.");
        }
    }

    // Labrador Retriever inherits from Dog
    public class LabradorRetriever : Dog
    {
        public LabradorRetriever(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string kidFriendly, string catFriendly)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits, kidFriendly, catFriendly)
        {

        }

        public static void LabradorRetrieverFacts()
        {
            Console.WriteLine("I'm good-natured and hard working, and I'm America’s most popular breed." +
                "\nThese days Labs work as retrievers for hunters, assistance dogs to the handicapped, " +
                "\nshow competitors, and search and rescue dogs, among other canine jobs.");
        }
    }

    // Mixed Breed inherits from Dog
    public class MixedBreed : Dog
    {
        public MixedBreed(string name, double age, char sex,
            string color, string breed, double weight, double adoptionFee,
            string traits, string kidFriendly, string catFriendly)
            : base(name, age, sex, color, breed, weight, adoptionFee, traits, kidFriendly, catFriendly)
        {

        }

        public static void MixedBreedFacts()
        {
            Console.WriteLine("Mixed breed dogs have inherited a jumble of genes and characteristics from our parents.\n" +
                "Our personalities vary by dog so let's hang out and get to know each other to see if I'm right the right dog for you.");
        }
    }

    // Creates an employee at animal rescue
    public class AnimalRescueWorker
    {
        private string Name { get; set; }

        // Instance constructor
        public AnimalRescueWorker(string name)
        {
            Name = name;
        }

        // Random number generator
        static public int RandChoice(int min, int high)
        {
            Random rnd = new Random();
            int rndnumber = rnd.Next(min, high);
            return rndnumber;
        }

        // Generates a random greeting
        public void Greeting()
        {
            int rndnumber = RandChoice(1, 4);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> Hi, I'm " + Name + ". Welcome to Happy Friends Animal Rescue.");
            }
            else if (rndnumber == 2)
            {
                Console.WriteLine(">>> I'm " + Name + ". How can I help you today?");
            }
            else if (rndnumber == 3)
            {
                Console.WriteLine(">>> Hi, I'm " + Name + ". Look around to find the perfect pet for you.");
            }
        }

        // Generates a random good-bye after failed adoption
        public void DisappointedGoodbye()
        {
            int rndnumber = RandChoice(1, 4);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> That's okay, have a nice day!\n");
            }
            else if (rndnumber == 2)
            {
                Console.WriteLine(">>> Aww bummer. Maybe next time!\n");
            }
            else if (rndnumber == 3)
            {
                Console.WriteLine(">>> We're open until 6 if you change your mind!\n");
            }
        }

        // Generates a random good-bye after a successful adoption
        public void SuccessfulGoodbye()
        {
            int rndnumber = RandChoice(1, 4);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> Thank you for adopting an animal from Happy Friends Animal Rescue!\n");
            }
            else if (rndnumber == 2)
            {
                Console.WriteLine(">>> We hope you enjoy your new family member!\n");
            }
            else if (rndnumber == 3)
            {
                Console.WriteLine(">>> Congratulations on your new pet!\n");
            }
        }

        public void Question()
        {
                Console.WriteLine(">>> Are you ready to adopt an animal?");
        }
    }

    class AnimalRescueCustomer
    {
        private string Name { get; set; }

        // Instance constructor
        public AnimalRescueCustomer(string name)
        {
            Name = name;
        }

        // Randomly chooses an animal category
        public int Statement()
        {
            int rndnumber = AnimalRescueWorker.RandChoice(1, 3);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> Hi, I want to see available dogs.");
                return 1;
            }
            else
            {
                Console.WriteLine(">>> Hi, I want to see available cats.");
                return 2;
            }
        }

        // Randomly generates customer questions about dogs
        public int DogQuestions(Dog animalName)
        {
            Dog animal = animalName;

            int rndnumber = AnimalRescueWorker.RandChoice(1, 6);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> Tell me about " + animalName.Name + ".");
                return 1;
            }
            else if (rndnumber == 2)
            {
                Console.WriteLine(">>> Can you tell me more about the " + animal.Breed + " breed?");
                return 2;
            }
            else if (rndnumber == 3)
            {
                Console.WriteLine(">>> How old did you say " + animal.Name + " is again?");
                return 3;
            }
            else if (rndnumber == 4)
            {
                Console.WriteLine(">>> What is the adoption fee for " + animal.Name + "?");
                return 4;
            }
            else
            {
                Console.WriteLine(">>> How many animals do you have here?");
                return 5;
            }
        }

        // Randomly generates customer questions about cats
        public int CatQuestions(Cat animalName)
        {
            Cat animal = animalName;

            int rndnumber = AnimalRescueWorker.RandChoice(1, 6);
            if (rndnumber == 1)
            {
                Console.WriteLine(">>> Tell me about " + animalName.Name + ".");
                return 1;
            }
            else if (rndnumber == 2)
            {
                Console.WriteLine(">>> Can you tell me more about the " + animal.Breed + " breed?");
                return 2;
            }
            else if (rndnumber == 3)
            {
                Console.WriteLine(">>> How old did you say " + animal.Name + " is again?");
                return 3;
            }
            else if (rndnumber == 4)
            {
                Console.WriteLine(">>> What is the adoption fee for " + animal.Name + "?");
                return 4;
            }
            else
            {
                Console.WriteLine(">>> How many animals do you have here?");
                return 5;
            }
        }
    }

    class RunAnimalRescue
        {
        static void Main(string[] args)
        {
            Console.WriteLine("-----The Animal Rescue Program-----\n");

            // Creates an employee and customer
            Console.WriteLine("-Building employee, Marshall, and customer, Kayla-");
            AnimalRescueWorker Marshall = new AnimalRescueWorker("Marshall");
            AnimalRescueCustomer Kayla = new AnimalRescueCustomer("Kayla");

            // Creating available dogs
            Console.WriteLine("-Building 5 dogs and 5 cats-");
            GermanShephard Lika = new GermanShephard("Lika", 5.1, 'F', "Light Brown", "German Shephard",
                72, 190.00, "I am pretty active so I will need plenty of exercise and mental stimulation.", "Yes", "No");

            LabradorRetriever Sapphire = new LabradorRetriever("Sapphire", 9.1, 'F', "Black", "Labrador Retriever",
                55, 150.00, "I am a pretty easy going dog and am treat motivated.", "Yes", "Yes");

            LabradorRetriever Finn = new LabradorRetriever("Finn", 6, 'M', "Chocolate Brown", "Labrador Retriver",
                136, 115.00, "I will be a breeze to train and am excited to learn more tricks!", "Yes", "Yes");

            MixedBreed Hank = new MixedBreed("Hank", 2.11, 'M', "White and Brown", "Mixed Breed",
                44, 125.00, "I ADORE plushy toys and will entertain myself with them for hours.", "No", "No");

            MixedBreed Sunny = new MixedBreed("Sunny", 0.11, 'M', "White", "Mixed Breed", 50, 195.00,
                "I would love an active family that has the time to exercise me and knows the joys of dog training!", "Older Children okay", "No");

            // Creating available cats
            DomesticShorthair Daisy = new DomesticShorthair("Daisy", 6.2, 'F', "Black", "Domestic Shorthair", 6, 50.00,
                "I'm pretty fearless when it comes to living outdoors.", "Yes", "Yes");

            DomesticShorthair Dom = new DomesticShorthair("Dom", 9, 'M', "Black", "Domestic Shorthair", 8, 25.00,
                "I'm still unpacking, so I haven't had a chance to sit down for my blog interview yet.", "Yes", "Yes");

            DomesticShorthair Bathilda = new DomesticShorthair("Bathilda", 12.7, 'F', "Black", "Domestic Shorthair", 8, 25.00,
                "I have some things to overcome and work on but my foster mom says my potty skills are on point!", "Yes", "Yes");

            Siamese Benedict = new Siamese("Benedict", 1.7, 'M', "White", "Siamese", 8, 50.00, "I love playtime and batting around the jingly ball toys," +
                "\nrunning after the fabric mice, and playing with my brother, Benedict.", "Yes", "Yes");

            Siamese Tony = new Siamese("Tony", 1.7, 'M', "White", "Siamese", 8, 50.00, "My brother and I don't have to be adopted together but it sure would be great " +
                "\nto have a companion to play with while you're at school, work, or running errands." +
                "\nAnd if that happens to be with my brother, that would be terrific.", "Yes", "Yes");

            Console.WriteLine("-Putting dogs and cats into lists-");
            // Putting all dogs into a list
            List<string> AdoptableDogs = new List<string>
            {
                "Lika",
                "Sapphire",
                "Finn",
                "Hank",
                "Sunny"
            };

            // Putting all cats into a list
            List<string> AdoptableCats = new List<string>
            {
                "Daisy",
                "Dom",
                "Bathilda",
                "Benedict",
                "Tony"
            };

            int animalsAvailable = Animal.getNumOfAnimals();

            /* Will loop through program until 5 animals are adopted 
               Demonstrates randomization of program and various options */
            while (animalsAvailable > 5)
            {

                // Employee greets the customer and customer chooses to view dogs or cats
                Console.WriteLine("-Beginning interactions between employee, customer, and animals-\n");
                Marshall.Greeting();

                int customerInterest = Kayla.Statement();
                Console.WriteLine("");

                // Display available dogs or cats according to customer interest
                if (customerInterest == 1)
                {
                    foreach (string i in AdoptableDogs)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    foreach (string i in AdoptableCats)
                    {
                        Console.WriteLine(i);
                    }
                }

                Console.WriteLine("");

                // Placeholders until customer chooses specific dog or cat
                Dog dogChoice = Lika;
                Cat catChoice = Bathilda;
                bool foundAdoptableAnimal = false;

                // Get random numbers
                int numDog = AnimalRescueWorker.RandChoice(1, 6);
                int numCat = AnimalRescueWorker.RandChoice(1, 6);

                // Customer decides which animal they want within chosen category
                if (customerInterest == 1)
                {
                    while (foundAdoptableAnimal == false)
                    {
                        if (numDog == 1)
                        {
                            if (Lika.Adopted == false)
                            {
                                Console.WriteLine("Lika is available for adoption.\n");
                                dogChoice = Lika;
                                foundAdoptableAnimal = true;
                            }
                            else
                            {
                                Console.WriteLine("Lika was recently adopted. Choose another dog.\n");
                                numDog++;
                            }
                        }
                        else if (numDog == 2)
                        {
                            if (Sapphire.Adopted == false)
                            {
                                Console.WriteLine("Sapphire is available for adoption.\n");
                                dogChoice = Sapphire;
                                foundAdoptableAnimal = true;
                            }
                            else
                            {
                                Console.WriteLine("Sapphire was recently adopted. Choose another dog.\n");
                                numDog++;
                            }
                        }
                        else if (numDog == 3)
                        {
                            if (Finn.Adopted == false)
                            {
                                Console.WriteLine("Finn is available for adoption.\n");
                                dogChoice = Finn;
                                foundAdoptableAnimal = true;
                            }
                            else
                            {
                                Console.WriteLine("Finn was recently adopted. Choose another dog.\n");
                                numDog++;
                            }
                        }
                        else if (numDog == 4)
                        {
                            if (Hank.Adopted == false)
                            {
                                Console.WriteLine("Hank is available for adoption.\n");
                                dogChoice = Hank;
                                foundAdoptableAnimal = true;
                            }
                            else
                            {
                                Console.WriteLine("Hank was recently adopted. Choose another dog.\n");
                                numDog++;
                            }
                        }
                        else
                        {
                            if (Sunny.Adopted == false)
                            {
                                Console.WriteLine("Sunny is available for adoption.\n");
                                dogChoice = Sunny;
                                foundAdoptableAnimal = true;
                            }
                            else
                            {
                                Console.WriteLine("Sunny was recently adopted. Choose another dog.\n");
                                numDog = 1;
                            }
                        }
                    }
                }
                    if (customerInterest == 2)
                    {
                        while (foundAdoptableAnimal == false)
                        {
                            if (numCat == 1)
                            {
                                if (Daisy.Adopted == false)
                                {
                                    Console.WriteLine("Daisy is available for adoption.\n");
                                    catChoice = Daisy;
                                    foundAdoptableAnimal = true;
                                }
                                else
                                {
                                    Console.WriteLine("Daisy was recently adopted. Choose another dog.\n");
                                    numCat++;
                                }
                            }
                            else if (numCat == 2)
                            {
                                if (Dom.Adopted == false)
                                {
                                    Console.WriteLine("Dom is available for adoption.\n");
                                    foundAdoptableAnimal = true;
                                    catChoice = Dom;
                                }
                                else
                                {
                                    Console.WriteLine("Dom was recently adopted. Choose another dog.\n");
                                    numCat++;
                                }
                            }
                            else if (numCat == 3)
                            {
                                if (Bathilda.Adopted == false)
                                {
                                    Console.WriteLine("Bathilda is available for adoption.\n");
                                    catChoice = Bathilda;
                                    foundAdoptableAnimal = true;
                                }
                                else
                                {
                                    Console.WriteLine("Bathilda was recently adopted. Choose another dog.\n");
                                    numCat++;
                                }
                            }

                            else if (numCat == 4)
                            {
                                if (Benedict.Adopted == false)
                                {
                                    Console.WriteLine("Benedict is available for adoption.\n");
                                    catChoice = Benedict;
                                    foundAdoptableAnimal = true;
                                }
                                else
                                {
                                    Console.WriteLine("Benedict was recently adopted. Choose another dog.\n");
                                    numCat++;
                                }
                            }
                            else
                            {
                                if (Tony.Adopted == false)
                                {
                                    Console.WriteLine("Tony is available for adoption.\n");
                                    catChoice = Tony;
                                    foundAdoptableAnimal = true;
                                }
                                else
                                {
                                    Console.WriteLine("Tony was recently adopted. Choose another dog.\n");
                                    numCat = 1;
                                }
                            }
                        }
                    }
         
                int customerQuestion;

                // Customer asks a question about their animal of choice
                if (customerInterest == 1)
                {
                    customerQuestion = Kayla.DogQuestions(dogChoice);
                }
                else
                {
                    customerQuestion = Kayla.CatQuestions(catChoice);
                }


                // Answers the customer's question
                if (customerInterest == 1)
                {
                    switch (customerQuestion)
                    {
                        case 1:
                            dogChoice.getDescription();
                            break;
                        case 2:
                            if (dogChoice.Breed == "German Shephard")
                                GermanShephard.GermanShephardFacts();
                            else if (dogChoice.Breed == "Labrador Retriever")
                                LabradorRetriever.LabradorRetrieverFacts();
                            else
                                MixedBreed.MixedBreedFacts();
                            break;
                        case 3:
                            Console.WriteLine(dogChoice.Age);
                            break;
                        case 4:
                            Console.WriteLine(dogChoice.AdoptionFee.ToString("C", CultureInfo.CurrentCulture));
                            break;
                        case 5:
                            Console.WriteLine(Animal.getNumOfAnimals());
                            break;
                    }
                }
                else
                {
                    switch (customerQuestion)
                    {
                        case 1:
                            catChoice.getDescription();
                            break;
                        case 2:
                            if (catChoice.Breed == "Domestic Shorthair")
                                DomesticShorthair.DomesticShorthairFacts();
                            else
                                Siamese.SiameseFacts();
                            break;
                        case 3:
                            Console.WriteLine(catChoice.Age);
                            break;
                        case 4:
                            Console.WriteLine(catChoice.AdoptionFee.ToString("C", CultureInfo.CurrentCulture));
                            break;
                        case 5:
                            Console.WriteLine(Animal.getNumOfAnimals());
                            break;
                    }
                }

                Console.WriteLine("");

                /* Employee asks if customer is ready to adopt an animal
                   Customer either says no and leaves or yes and finishes the adoption process */
                Marshall.Question();

                int customerDecision = AnimalRescueWorker.RandChoice(1, 3);

                if (customerDecision == 1)
                {
                    Console.WriteLine(">>> No thanks, I've changed my mind.");
                    Marshall.DisappointedGoodbye();
                }
                else
                {
                    Console.WriteLine(">>> Yes!");
                    Console.WriteLine("");


                    // Customer will interact with animal until the happiness level is satisfactory
                    Random rnd = new Random();
                    int rndnumber = rnd.Next(1, 6);

                    if (customerInterest == 1)
                    {
                        bool readyToAdopt = dogChoice.Adopt();
                        while (readyToAdopt == false)
                        {
                            rndnumber = rnd.Next(1, 6);
                            if (rndnumber == 1)
                            {
                                dogChoice.GiveTreat();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 2)
                            {
                                dogChoice.Pet();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 3)
                            {
                                dogChoice.Play();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 4)
                            {
                                dogChoice.Snuggle();
                                Console.WriteLine("");
                            }
                            else
                            {
                                dogChoice.Startle();
                                Console.WriteLine("");
                            }
                            readyToAdopt = dogChoice.Adopt();
                        }
                    }
                    else
                    {
                        bool readyToAdopt = catChoice.Adopt();
                        while (readyToAdopt == false)
                        {
                            rndnumber = rnd.Next(1, 6);
                            if (rndnumber == 1)
                            {
                                catChoice.GiveTreat();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 2)
                            {
                                catChoice.Pet();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 3)
                            {
                                catChoice.Play();
                                Console.WriteLine("");
                            }
                            else if (rndnumber == 4)
                            {
                                catChoice.Snuggle();
                                Console.WriteLine("");
                            }
                            else
                            {
                                catChoice.Snuggle();
                                Console.WriteLine("");
                            }
                            readyToAdopt = catChoice.Adopt();
                        }
                    }

                    // Mark animal as adopted
                    if (customerInterest == 1)
                        dogChoice.Adopted = true;
                    else
                        catChoice.Adopted = true;

                    // Employee says good-bye to the customer and the program ends
                    Console.WriteLine("");
                    Marshall.SuccessfulGoodbye();
                }

                // Get current animal count
                animalsAvailable = Animal.getNumOfAnimals();
            }
            Console.ReadKey();
        }
        }
}