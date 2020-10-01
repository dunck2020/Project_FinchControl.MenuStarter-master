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
    // robot perform based on user input             
    // Application Type: Console
    // Author: Dunckel, John
    // Dated Created: 9/30/2020
    // Last Modified: 9/30/2020
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
                        DisplayUnderDevelopment();
                        DisplayContinuePrompt();
                        break;

                    case "d":
                        DisplayUnderDevelopment();
                        DisplayContinuePrompt();
                        break;

                    case "e":
                        DisplayUnderDevelopment();
                        DisplayContinuePrompt();
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
;
            int counter = 1;
            do
            {
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
                myFinch.setLED(100,100, 1000);
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
            myFinch.setMotors(0,0);
            myFinch.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
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

            bool robotConnected;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            robotConnected = myFinch.connect();

            if (robotConnected)
            { 
                myFinch.disConnect();
                Console.WriteLine("\tThe Finch robot is disconnected.");
            }
            else
            {
                Console.WriteLine("\tThe Finch robot is already disconnected.");
            }

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

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");

            DisplayContinuePrompt();

            robotConnected = myFinch.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

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
        }

    }
}
        #endregion
