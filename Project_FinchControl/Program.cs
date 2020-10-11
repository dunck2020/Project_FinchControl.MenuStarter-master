using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: This program will make the Finch
    // robot perform based on user input.             
    // Application Type: Console
    // Author: Dunckel, John
    // Dated Created: 9/30/2020
    // Last Modified: 10/09/2020
    // 
    // **************************************************

    class Program
    {

        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }



        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\td) Play Match the Frequency");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixItUp(myFinch);
                        break;
                    case "d":
                        GuessFrequency(myFinch);
                        break;
                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayLightAndSound(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);
            }
            myFinch.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Finch Dance                       *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch"></param>
        static void DisplayDance(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Finch Dance");

            Console.WriteLine("\tThe Finch robot will now perform a fabulous dance for you!");
            DisplayContinuePrompt();


            myFinch.wait(400);
            DisplayScreenHeader("The Stepper.");
            for (int theStepper = 0; theStepper < 5; theStepper++)
            {
                myFinch.setMotors(255, 255);
                myFinch.wait(400);
                myFinch.setMotors(-255, -255);
                myFinch.wait(400);
            }

            DisplayScreenHeader("Now Shake It!!");
            for (int theShake = 0; theShake < 5; theShake++)
            {
                myFinch.setMotors(0, 125);
                myFinch.wait(500);
                myFinch.setMotors(-125, 0);
                myFinch.wait(500);
                myFinch.setMotors(0, -125);
                myFinch.wait(500);
            }

            DisplayScreenHeader("How about a figure eight!");
            myFinch.setMotors(100, 100);
            myFinch.wait(500);
            myFinch.setMotors(0, 75);
            myFinch.wait(500);
            myFinch.setMotors(100, 100);
            myFinch.wait(2000);
            myFinch.setMotors(75, 0);
            myFinch.wait(4500);
            myFinch.setMotors(100, 100);
            myFinch.wait(2000);
            myFinch.setMotors(0, 75);
            myFinch.wait(4500);
            myFinch.setMotors(100, 100);
            myFinch.wait(2000);
            myFinch.setMotors(0, 0);
            DisplayFinchFinale(myFinch);
            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mix It Up                         *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch"></param>
        static void DisplayMixItUp(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Time to Mix It Up");

            Console.WriteLine("\tThe Finch robot will now mix it up!");
            DisplayContinuePrompt();
            DisplayScreenHeader("Finch will perform 'For Elise' (by Beethoven). Also moving to the music and showing off the LED technology.");

            int counter = 1;
            do
            {   //finch will perform sound, LED action, and movement
                counter++;
                myFinch.noteOn(1318);
                myFinch.setLED(150, 150, 150);
                myFinch.setMotors(20, 150);
                myFinch.wait(300);

                myFinch.noteOn(1244);
                myFinch.setLED(255, 150, 100);
                myFinch.wait(300);

                myFinch.noteOn(1318);
                myFinch.setLED(250, 100, 0);
                myFinch.wait(300);

                myFinch.noteOn(1244);
                myFinch.setLED(100, 100, 1000);
                myFinch.setMotors(150, 20);
                myFinch.wait(300);

                myFinch.noteOn(1318);
                myFinch.setLED(50, 0, 50);
                myFinch.wait(300);

                myFinch.noteOn(987);
                myFinch.setLED(40, 40, 0);
                myFinch.wait(300);

                myFinch.noteOn(1174);
                myFinch.setLED(0, 30, 30);
                myFinch.setMotors(100, 100);
                myFinch.wait(300);

                myFinch.noteOn(1046);
                myFinch.setLED(20, 0, 20);
                myFinch.wait(300);

                myFinch.noteOn(880);
                myFinch.setLED(80, 80, 0);
                myFinch.wait(600);

                myFinch.noteOn(523);
                myFinch.setLED(0, 200, 200);
                myFinch.setMotors(150, 20);
                myFinch.wait(300);

                myFinch.noteOn(659);
                myFinch.setLED(170, 0, 170);
                myFinch.wait(300);

                myFinch.noteOn(880);
                myFinch.setLED(210, 210, 0);
                myFinch.wait(300);

                myFinch.noteOn(987);
                myFinch.setLED(110, 0, 110);
                myFinch.setMotors(-20, -150);
                myFinch.wait(600);

                myFinch.noteOn(659);
                myFinch.setLED(0, 255, 255);
                myFinch.wait(300);

                myFinch.noteOn(739);
                myFinch.setLED(180, 0, 180);
                myFinch.wait(300);

                myFinch.noteOn(987);
                myFinch.setLED(0, 170, 170);
                myFinch.setMotors(80, 250);
                myFinch.wait(300);

                myFinch.noteOn(1046);
                myFinch.setLED(160, 160, 0);
                myFinch.wait(600);

                myFinch.noteOn(659);
                myFinch.setLED(5, 5, 5);
                myFinch.setMotors(0, 255);
                myFinch.wait(600);

            } while (counter < 3);
            //
            //turn of the Finch robots talents 
            //
            myFinch.noteOff();
            myFinch.setMotors(0, 0);

            DisplayFinchFinale(myFinch);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Guess Frequency                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch"></param>
        static void GuessFrequency(Finch myFinch)
        {
            //
            //finch will emith a frequency and user tries to guess
            //
            DisplayScreenHeader("Guess the frequency the Finch Robot emits");
            Console.WriteLine();
            Console.WriteLine("\t\tListen close!");
            DisplayContinuePrompt();
            myFinch.noteOn(880);
            myFinch.wait(500);
            myFinch.noteOff();

            bool menuResponse = false;
            do
            {
                //
                // get user response
                //
                Console.WriteLine("\tGuess what frequency you just heard:");
                Console.WriteLine("\ta) 880");
                Console.WriteLine("\tb) 987");
                Console.WriteLine("\tc) 1046");
                Console.WriteLine("\td) Listen again?");
                Console.Write("\t\tEnter Choice:");
                string userResponse = Console.ReadLine().ToLower();

                //
                //process user reponse
                //
                switch (userResponse)
                {
                    case "a":
                        Console.WriteLine("Terrific! You guessed correctly");
                        DisplayContinuePrompt();
                        menuResponse = true;
                        break;
                    case "b":
                        Console.WriteLine("Sorry, you guessed incorrectly, try again.");
                        DisplayContinuePrompt();
                        break;
                    case "c":
                        Console.WriteLine("Sorry, you guessed incorrectly, try again.");
                        DisplayContinuePrompt();
                        break;
                    case "d":
                        myFinch.noteOn(880);
                        myFinch.wait(500);
                        myFinch.noteOff();
                        DisplayContinuePrompt();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!menuResponse);
        }

        /// <summary>
        /// This is the finale
        /// </summary>
        /// <param name="myFinch"></param>
        static void DisplayFinchFinale(Finch myFinch)
        {

            for (int lights = 0; lights < 255; lights += 5)
                myFinch.setLED(lights - 10, lights - 50, lights);
            for (int lights = 255; lights > 0; lights -= 5)
                myFinch.setLED(lights - 10, lights - 50, lights);
            myFinch.setLED(0, 0, 0);
        }

        #endregion

        #region DATA RECORDER
        /// <summary>
        /// data recorder main menu screen
        /// </summary>
        /// <param name="myFinch"></param>
        static void DataRecorderDisplayMenuScreen(Finch myFinch)
        {
            int numberOfDataPoints = 0;

            double dataPointFrequency = 0;
            double[] temperatures = null;

            bool quitMenu = false;
            bool validDataPoint = false;
            bool validFrequency = false;
            bool validDataPresent = false;

            string menuChoice;

            Console.CursorVisible = true;

            do
                {
                    DisplayScreenHeader("Data Recorder Menu");

                    // get user menu choice
                    Console.WriteLine("\ta) Number of Data Points");
                    Console.WriteLine("\tb) Frequency of Data Points");
                    Console.WriteLine("\tc) Get Data");
                    Console.WriteLine("\td) Show Data");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    // process user menu choice

                    switch (menuChoice)
                    {
                        case "a":
                            //get number of data points form user
                            numberOfDataPoints = DataRecorderDisplayGetNumberOfPoints();
                            validDataPoint = true;
                            break;

                        case "b":
                            //get frequency in seconds from user
                            dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                            validFrequency = true;
                            break;

                        case "c":
                            //get information from finch based off user inputs
                            //also verify user has entered data
                            if (validDataPoint && validFrequency)
                            {
                                temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myFinch);
                                validDataPresent = true;
                            } 
                            else if (validDataPoint && !validFrequency)
                            {
                                Console.WriteLine("\tPlease enter a data frequency to proceed");
                                DisplayContinuePrompt();
                            }
                            else if (!validDataPoint && validFrequency)
                            {
                                Console.WriteLine("\tPlease enter a data point to proceed");
                                DisplayContinuePrompt();
                            }                                
                            else if (!validDataPoint && !validFrequency)
                            {
                                Console.WriteLine("\tPlease enter a data point and frequency to proceed");
                                DisplayContinuePrompt();
                            }
                                
                            break;
                        case "d":
                            //display data for user
                            //display message if no data has been gathered
                            if (validDataPresent)
                                DataRecorderDisplayData(temperatures);
                            else
                            {
                                Console.WriteLine("\tNo Data to Display");
                                DisplayContinuePrompt();
                            }
                                
                            break;
                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }

                } while (!quitMenu);
            
        }

        /// <summary>
        /// display data for user
        /// </summary>
        /// <param name="temperatures">display data</param>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayTable(temperatures);
            
            DisplayContinuePrompt();
        }

        /// <summary>
        /// organizes information into tables for display
        /// </summary>
        /// <param name="temperatures">Table display</param>
        static void DataRecorderDisplayTable(double[] temperatures)
        {
            
            // dispaly table headers
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );
  
            // display table data
            for (int counter = 0; counter < temperatures.Length; counter++)
            {
                double fahrenheit = DataRecorderConvertToFahrenheit(temperatures[counter]);
                Console.WriteLine(
                    (counter + 1).ToString().PadLeft(15) +
                    fahrenheit.ToString("n1").PadLeft(13) + (char)176 + "F"
                    );
            }
        }

        /// <summary>
        /// get data from finch robot
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="myFinch"></param>
        /// <returns></returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myFinch)
        {
            double[] temperatures = new double[numberOfDataPoints];
          

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"\tData Point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot is ready to begin recording temperature.");
            DisplayContinuePrompt();

            //finch will now be used to record the temperature and 
            //display for user
            for (int counter = 0; counter < numberOfDataPoints; counter++)
            {
                temperatures[counter] = myFinch.getTemperature();
                double fahrenheit = DataRecorderConvertToFahrenheit(temperatures[counter]);

                Console.WriteLine($"\tReading {counter + 1}: {fahrenheit.ToString("n1")}" + (char)176 + "F");
                int waitInSeconds = (int) (dataPointFrequency * 1000);
                myFinch.wait(waitInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("\tThe reading of data is now complete.");
            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");
            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();

            DataRecorderDisplayTable(temperatures);

            
            DisplayContinuePrompt();
            return temperatures;
 
        }

        /// <summary>
        /// converts readings to fahrenheit
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        static double DataRecorderConvertToFahrenheit(double temperatures)
        {
            double conversion = temperatures / 5 * 9 + 32;
            return conversion;
        }

        /// <summary>
        /// get data point frequency from user
        /// </summary>
        /// <returns>data point frequency</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency = 0;
            bool parseSuccess = false;

            while (!parseSuccess)
            {
                //will prompt the user until a numeric value it entered
                DisplayScreenHeader("Data Point Frequency");
                Console.Write("\tFrequency of Data Points (seconds): ");
                parseSuccess = double.TryParse(Console.ReadLine(), out dataPointFrequency);
                if (parseSuccess)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tFrequency Data Point entered: {dataPointFrequency}");
                }

                else
                {
                    Console.WriteLine("\tPlease enter a numeric value for data points.");
                    DisplayContinuePrompt();
                }
            }
            DisplayContinuePrompt();
            return dataPointFrequency;
        }

        /// <summary>
        /// get number of data points from user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfPoints()
        {
            int numberOfDataPoints = 0;
            bool parseSuccess = false;

            while (!parseSuccess)
            {
                //will prompt the user until valid data point entered
                DisplayScreenHeader("Number of Data Points");
                Console.Write("\tNumber of Data Points: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out numberOfDataPoints);
                if (parseSuccess)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tNumber of data points entered: {numberOfDataPoints}");
                }

                else
                {
                    Console.WriteLine("\tPlease enter an integer for data points.");
                    DisplayContinuePrompt();
                } 
            }
            DisplayContinuePrompt();
            return numberOfDataPoints;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT


        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch myFinch)
        {

            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");

            DisplayContinuePrompt();

            myFinch.disConnect();

            Console.WriteLine("\tThe Finch robot is disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch myFinch)
        {
            Console.CursorVisible = false;

            bool robotConnected;
            do
            {   //
                //loop to process until user has connection or opts out
                //
                DisplayScreenHeader("Connect Finch Robot");
                Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
                DisplayContinuePrompt();
                robotConnected = myFinch.connect();
                //
                //statement to determine if Finch robot connected 
                //
                if (robotConnected)
                    SuccessfulConnection(myFinch);
                else if (!robotConnected)
                    //
                    //Finch did not connect time to verify 
                    //
                    robotConnected = VerifyFinchConnected(robotConnected);
                
            } while (!robotConnected) ;

            // reset finch robot
            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            return robotConnected;
        }

        /// <summary>
        ///  Method verifies the user has connected the usb cable
        /// </summary>
        static bool VerifyFinchConnected(bool connectedRobot)
        {
            //
            //no connection get response from user
            //
            DisplayScreenHeader("Could not connect");
            Console.WriteLine("\tFinch did not connect, please verify USB is connected");
            Console.WriteLine("\tDo you want to try to connect again?");
            Console.WriteLine("\tY) To Try Again:");
            Console.WriteLine("\tN) Return to the Main Menu:");
            Console.Write("\t\tEnter Choice:");
            string userResponse = Console.ReadLine().ToLower();
            switch (userResponse)
            {
                case "y"://user is trying again connectRobot remains false
                    connectedRobot = false;
                    break;
                case "n"://user has opted out of trying to connect
                    connectedRobot = true;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter y or n.");
                    DisplayContinuePrompt();
                    break;
            }
            return connectedRobot;
        }

        /// <summary>
        /// Displays light and sound for a connection to Finch
        /// </summary>
        /// <param name="myFinch"></param>
        static void SuccessfulConnection(Finch myFinch)
        {   //
            //successful let user know with lights, sound and message
            //
            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel+= 10)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);

            }
            myFinch.setLED(0, 0, 0);
            DisplayScreenHeader("Successful Connection!");
            DisplayContinuePrompt();
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {


            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(myFinch);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(myFinch);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(myFinch);
                        break;

                    case "d":
                        DisplayUnderDevelopment();
                        break;

                    case "e":
                        DisplayUnderDevelopment();
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(myFinch);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(myFinch);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// display notification these modules are in development
        /// </summary>
        static void DisplayUnderDevelopment()
        {
            Console.WriteLine();
            Console.WriteLine("\tThis module is currently in development.");
            DisplayContinuePrompt();
        }
    }
}
        #endregion


