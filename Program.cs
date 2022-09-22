// Figgle NuGet som gör om stora ascii-art som tar upp utrymme till en simpel och kort Console.WriteLine.
using Figgle;
class Program
{
    private static void Main(string[] args)
    {
        // Massa grejer som behövs 
        string answer1;
        int points = 0;
        var random = new Random(2);
        bool endless = false;
        int QuestionNumber = 1;
        int Lives = 3;
        bool skipIntro = false;
        bool hackerMode = false;
        int choice = 0;


        // Function för när man har rätt svar så blinkar den grön och svart 3 gånger
        void correctAnswer()
        {
            // For loop där den sätter variabeln "m" till 0 och så länge den är under 3 så adderar den 1 till variabeln m.
            for (var m = 0; m < 3; m++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Task.Delay(250).Wait();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Task.Delay(250).Wait();
            }
        }

        // Function för när man har fel svar så blinkar den röd och svart 3 gånger
        void wrongAnswer()
        {
            // Samma som ovanför men tar bort ett liv om man kör i Endless Mode(tm)
            for (var m = 0; m < 3; m++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Task.Delay(250).Wait();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Task.Delay(250).Wait();
            }
            Lives--;
        }

        // Function för en av frågorna till quizet.
        void Question1()
        {
            Console.WriteLine("*                                            *");
            Console.WriteLine("*             How old is Nicolás?            *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("*       16            17            18       *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            answer1 = Console.ReadLine();
            // Om svaret är 16 så sätter den igång correctAnswer funktionen och blinkar grön och ger ett poäng.
            // Allt annat som är man skriver som inte är svaret så sätter den igång wrongAnswer funktionen och blinkar röd.
            if (answer1 == "16")
            {
                correctAnswer();
                Console.WriteLine("That is the correct answer!");
                points++;
                Task.Delay(2000).Wait();
            }
            // line 69 ( ͡° ͜ʖ ͡°)
            else
            {
                wrongAnswer();
                Console.WriteLine("That is not the correct answer.");
                Task.Delay(2000).Wait();
            }
        }

        // I princip samma sak som funktionen ovanför men en annorlunda fråga.
        void Question2()
        {
            Console.WriteLine("*                                            *");
            Console.WriteLine("*               What is 1 + 1?               *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("*          11          0          2          *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            answer1 = Console.ReadLine();
            if (answer1 == "2")
            {
                correctAnswer();
                Console.WriteLine("That is the correct answer!");
                points++;
                Task.Delay(2000).Wait();
            }
            else
            {
                wrongAnswer();
                Console.WriteLine("That is not the correct answer.");
                Task.Delay(2000).Wait();
            }
        }

        // En annan fråga men jag la till så svaret kommer automatiskt omvandlas till liten bokstav med hjälp av "ToLower".
        // answer1.Replace(" ", ""); tar bort alla mellanslag i svaret för att få bort misstag i sitt svar.
        void Question3()
        {
            Console.WriteLine("*                                            *");
            Console.WriteLine("*        Hur mycket väger 1 kilo ris?        *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("*       1kg       För mycket       29g       *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            answer1 = Console.ReadLine().ToLower();
            answer1 = answer1.Replace(" ", "");
            if (answer1 == "1kg" || answer1 == "1kilo")
            {
                correctAnswer();
                Console.WriteLine("That is the correct answer!");
                points++;
                Task.Delay(2000).Wait();
            }
            // Liten easter egg om man leker rolig och skriver 1kg fast i andra enheter som gram och nanogram etc.
            else if (answer1 == "ettkilo" || answer1 == "1000g" || answer1 == "1000000000µg" || answer1 == "1000000000000ng" || answer1 == "10hg")
            {
                correctAnswer();
                Console.WriteLine("Fan va jobbig du är genom att leka smart men du har tekniskt sätt rätt\nTa ditt jävla poäng");
                points++;
                Task.Delay(4500).Wait();
            }
            else
            {
                wrongAnswer();
                Console.WriteLine("That is not the correct answer.");
                Task.Delay(2000).Wait();
            }
        }

        // Frågar om man vill börja om. If-satsen checkar om sitt svar inte tillhör någon av de alternativen, om det är något annat än de 4 så stängs konsolen.
        // Om sitt svar är antingen y, yes, ja och sure så kommer den gå tillbaka till början av spelet.
        void PlayAgain()
        {
            Console.WriteLine("\nDo you want to play again?");
            string PlayAgain = Console.ReadLine().ToLower();
            if (PlayAgain != "y" && PlayAgain != "yes" && PlayAgain != "ja" && PlayAgain != "sure")
            {
                Environment.Exit(0);
            }
        }

        // När man är klar med quizet så kommer upp win screen där den ger olika endings beroende på antal poäng man har.
        void WinScreen()
        {
            Console.Clear();
            Console.WriteLine($"The quiz is over!\nYou got {points} out of 3 points!");
            if (points == 3)
            {
                Console.WriteLine("Congratulations! You got all the questions right and have now won the GRAND PRIZE!");
                Console.WriteLine(@"
                                      _______
                                     |       |
                                    (|  You  |)
                                     |  #1   |
                                      \     /
                                       `---'
                                       _|_|_");
                Console.WriteLine("\nWith your trophy you also win a million dollars!");
                Task.Delay(3000).Wait();
            }
            else if (points == 2)
            {
                Console.WriteLine("You almost had it! You were just one point away from winning the grand prize.");
                Task.Delay(2500).Wait();
                Console.WriteLine(@"I hope this whale makes you feel better.

                                   \    /
                                    \  /
                |\\  //|             ||
                 \ \/  /             ||
                  |   |              ||
                  |   |              ||
                   \   \------------------------\
                    \                       o    \
                     \-                           \
                      \                 \__________\
                       \-                          /        You did good lad.
                         \________________________/");
                Task.Delay(3000).Wait();
            }
            else if (points == 1)
            {
                Console.WriteLine("You only got 1 point which is very unfortunate. I hope you do better next time.");
                Task.Delay(3000).Wait();
            }
            else
            {
                // Om man är helt kass på quizet så kommer den "explodera din dator" genom att simulera en bomb med hjälp av Console.Beep och sen blinkande röd och gul.
                Console.WriteLine("All questions wrong? Wow, that's impressive.");
                Task.Delay(3000).Wait();
                Console.WriteLine("I am now gonna explode your computer for doing such a bad job! >:)");
                Task.Delay(2000).Wait();
                Console.WriteLine("5"); Console.Beep();
                Task.Delay(1000).Wait();
                Console.WriteLine("4"); Console.Beep();
                Task.Delay(1000).Wait();
                Console.WriteLine("3"); Console.Beep();
                Task.Delay(1000).Wait();
                Console.WriteLine("2"); Console.Beep();
                Task.Delay(1000).Wait();
                Console.WriteLine("1"); Console.Beep();
                Task.Delay(1000).Wait();
                for (var n = 0; n < 5; n++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Task.Delay(150).Wait();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Task.Delay(150).Wait();
                }
                Environment.Exit(0);
            }
            PlayAgain();
        }

        // Lose screen för när man kör endless mode och får slut på liv
        void LoseScreen()
        {
            QuestionNumber--;
            Console.Clear();
            Console.WriteLine(
                FiggleFonts.Modular.Render("GAME OVER"));
            Task.Delay(3000).Wait();
            Console.WriteLine($"You ran out of lives. The game is over! You got to question {QuestionNumber} and obtained {points} points!");
            Task.Delay(3500).Wait();
            PlayAgain();
        }

        // Om man skriver "help" i title screen så kommer den här öppnas upp som förklarar lite.
        void help()
        {
            Console.WriteLine("\n\n ************************* GAME HELP *************************");
            Console.WriteLine("\n .................... Very fun Quiz Game......................\n");
            Console.WriteLine("\n >> There will be a total of 3 questions");
            Console.WriteLine("\n >> You will be given 3 options and you have to answer correctly");
            Console.WriteLine("\n >> Each question will carry a point");
            Console.WriteLine("\n >> There is no negative marking for wrong answer");
            Console.WriteLine("\n >> Get all questions right and you win the Grand Prize!");
            Console.WriteLine("\n\n ************************* BEST OF LUCK **********************\n\n");
            Console.ReadLine();
            Console.Clear();
        }

        void SettingsMenu()
        {
            bool options = true;
            while (options)
            {
                if (hackerMode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Clear();
                Console.WriteLine($"  Skip Intro: {skipIntro}");
                Console.WriteLine($"  Enter Hacker Mode: {hackerMode}");
                Console.WriteLine("  Exit Settings");
                Console.SetCursorPosition(1, choice);
                Console.Write(">");

                // Den kollar på vilken tangentbordsknapp du trycker på
                var key = Console.ReadKey(true);
                // Kollar om input är lika med Up arrow och choice > 0 stoppar så man inte går out of bounds. Choice-- gör så man kan gå ner.
                if (key.Key == ConsoleKey.UpArrow && choice > 0) { choice--; }
                // Samma sak som ovan fast för när man går ner och choice++ stoppar så man inte kan gå hur långt ner som man vill.
                else if (key.Key == ConsoleKey.DownArrow && choice < 2) { choice++; }
                // Om input är enter på nån av alternativen så kommer den växla mellan på eller av som en spak.
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:
                            skipIntro = !skipIntro;
                            Console.Beep();
                            break;
                        case 1:
                            hackerMode = !hackerMode;
                            Console.Beep();
                            break;
                        case 2:
                            options = false;
                            Console.Beep();
                            break;
                    }
                }
            }
        }

    // Title screen där den checkar om man vill börja spelet direkt eller skriva help för att få information på hur spelet går till eller ändra inställningar.
    Start: // Jag vet goto är cringe men det här funkade bra
        Lives = 3;
        endless = false;
        Console.Clear();
        Console.WriteLine(
                FiggleFonts.Big.Render("* Quiz *"));
        Console.WriteLine("Type anything to start\nType help for information\nType settings to modify game");
        string result = Console.ReadLine();
        string resultLow = result.ToLower();

        if (resultLow == "help")
        {
            Console.Clear();
            help();
            goto Start;
        }
        // Easter egg för de som tror de är roliga och skriver "anything" när den säger "Type anything to start"
        else if (resultLow == "anything")
        {
            Console.Clear();
            Console.WriteLine("Very funny");
            Task.Delay(2000).Wait();
        }
        else if (resultLow == "settings")
        {
            Console.Clear();
            SettingsMenu();
            goto Start;
        }
        Console.Clear();
        Console.WriteLine("Do you want to play endless mode?\n1 for yes ----- Anything else for no\n(Endless mode is turned off by default)");
        if (Console.ReadLine() == "1")
        {
            endless = true;
        }

        while (true)
        {
            // Sätter sina poäng till 0 så det inte blir strul sen om man kör spelet en gång till och får över max poäng.
            points = 0;
            // Så frågan börjar om till 1 och inte fortsätter öka efter man har börjat om.
            QuestionNumber = 1;
            Console.Clear();
            // Det här är en setting som man växlas i setting menu för att skippa den här långa introt som jag har behövt gå igenom 10000 gånger varje gång jag har debuggat.
            if (!skipIntro)
            {
                Console.WriteLine("Welcome to the most fun quiz ever!");
                Task.Delay(3000).Wait();

                Console.WriteLine("Win 3 times to get the ");
                Task.Delay(2000).Wait();
                // Liten animation för ordet "GRAND PRIZE"
                for (var i = 0; i < 2; i++)
                {
                    Console.Write("G R A N D    P R I Z E");
                    Task.Delay(500).Wait();
                    // \r går tillbaka till början av raden och sen skriver ut så många mellanslag som terminalen är 
                    // bred och sen går tillbaka till början av raden för att sen printa "GRAND PRIZE" igen.
                    // -1 efter Console.WindowWidth är för att stanna på samma rad och inte hoppa över till nästa.
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    Task.Delay(500).Wait();
                }
                Console.WriteLine("G R A N D    P R I Z E");
                Task.Delay(1000).Wait();

                Console.WriteLine("Are you ready? Here we go!");
                Task.Delay(2000).Wait();
                Console.WriteLine("3");
                Task.Delay(1000).Wait();
                Console.WriteLine("2");
                Task.Delay(1000).Wait();
                Console.WriteLine("1");
                Task.Delay(1000).Wait();
            }
            Console.Clear();

            // Sätter rand till ett random tal
            Random rand = new Random();
            // Gör randomQuestion till en Array
            int[] randomQuestion = new int[3];
            // Randomizear frågorna så det är inte samma fråga varje gång man börjar spelet. Kollar om det finns värden som är likadan, om det finns så ger den 3 nya nummer tills den inte hittar sånna nummer.
            while (true)
            {
                while ((randomQuestion[0] == randomQuestion[1]) || (randomQuestion[1] == randomQuestion[2]) || (randomQuestion[0] == randomQuestion[2]))
                {
                    randomQuestion[0] = rand.Next(0, 3);
                    randomQuestion[1] = rand.Next(0, 3);
                    randomQuestion[2] = rand.Next(0, 3);
                }
                // Tar fram random fråga som inte får vara 2 samma frågor i rad.
                for (var k = 0; k < 3; k++)
                {
                    // Om man kör endless mode så får man se hur många liv man har kvar
                    if (endless)
                    {
                        Console.WriteLine($"You have {Lives} lives left\n");
                    }
                    if (randomQuestion[k] == 0)
                    {
                        Console.WriteLine($"******************Question {QuestionNumber}******************");
                        Question1();
                        Console.Clear();
                    }
                    else if (randomQuestion[k] == 1)
                    {
                        Console.WriteLine($"******************Question {QuestionNumber}******************");
                        Question2();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"******************Question {QuestionNumber}******************");
                        Question3();
                        Console.Clear();
                    }
                    QuestionNumber++;
                    // Om man har förlorat sina liv så går den till lose screen och om man vill spela igen så gör den en goto till början av spelet.
                    if (endless)
                    {
                        if (Lives < 1)
                        {
                            LoseScreen();
                            goto Start;
                        }
                    }
                }
                if (!endless)
                {
                    WinScreen();
                    goto Start;
                }
            }
        }
    }
}


// Tack Egil TE21B för hjälpen med de mer tekniska delarna i koden som att randomizea frågor.