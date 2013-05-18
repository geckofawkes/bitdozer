// BitDozer                                                                  ....A desperate disease requires a dangerous remedy....
// Written by Gecko Fawkes                                                                        - Guy Fawkes, November 6, 1605
// Copyright (c) 2012 Tagelmoust LLC and Gecko Fawkes
//
// Released Under the Gecko~Fawkes~License (~GFL~):
//      This software is free to use provided you adhere to the following conditions :
//
//      1) You must reference you use or derive code licensed under the Gecko~Fawkes~License (~GFL~) visibly in your application
//      2) You must maintain the original comments included in this file and project
//      3) You must only use it to help better society, help the poor, repressed, enslaved (physically, mentally, emotionally, or economically), and
//         bring about peaceful revolution through technological innovation.
//      4) Gecko Fawkes and Tagelmoust LLC make absolutely no claim or guarantee or warrant that this software will in any way shape or form 
//         work properly or how you think it should, it has not been tested, and it may contain bugs and/or cause unintended consequences including 
//         loss of financial capital.  Under NO circumstances shall Gecko Fawkes or Tagelmoust LLC be responsible for damages or losses resulting from 
//         using this software.  Use this software at your own risk.  
//      5) If you use this software, derive code or knowledge from it, or generate revenues with it, 
//         please donate bitcoins to this address:   1792twiciBM3CXpMAsmmgo6YPYAByqE5sL
//
//      If you fail to adhere to these simple conditions, then "all your base belong to us", explicitly, all revenues gained by using this or any 
//      derivative software will be owed to Tagelmoust LLC and Tagelmoust LLC will acquire a fifty percent (50%) claim to any and all intellectual
//      property using or derived from this software.  You will also be held responsible for all legal costs required to enforce this agreement
//      and agree to allow summary judgement against you for violating this license in a United States of America court of law.
//
// Peace be with you.  
//
// Our Father who art in heaven, hallowed be thy name, thy kingdom come, thy will be done, on Earth as it is in heaven,
// Give us this day, our daily bread, and forgive us our trespasses as we forgive those who trespass against us,
// And lead us not into temptation but deliver us from evil, for thine is the power, the kingdom, and the glory.
// Now and forever. Amen.
//
// May this and all derivative works be consecrated to the Sacred Heart of Jesus. 
// 
// In Your Service,
// - Gecko Fawkes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

using MatrixTextEffect;

namespace Bitdozer
{
    public partial class BitDozer : Application
    {
        private static MainViewModel viewModel = null;

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        public String WhoIsTheWalrus = "anonymous";

        public MainPage TheMainPage;

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public BitDozer()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters
                Application.Current.Host.Settings.EnableFrameRateCounter = false;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are being GPU accelerated with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Standard Silverlight initialization
            InitializeComponent();
           
            // Phone-specific initialization
            InitializePhoneApplication();
        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            // Ensure that application state is restored appropriately
            if (!BitDozer.ViewModel.IsDataLoaded)
            {
                BitDozer.ViewModel.LoadData();
            }
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            // Ensure that required application state is persisted here.

// When the music's over 
// When the music's over 
// When the music's over 
// Turn out the lights 
// Turn out the lights 
// Turn out the lights 

// For the music is your special friend 
// Dance on fire as it intends 
// Music is your only friend 
// Until the end 
// Until the end 
// Until the end 

        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        public SplashScreen ssSplashScreen;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            ssSplashScreen = new SplashScreen();
            ssSplashScreen.SetupOverlay();
            RootVisual = ssSplashScreen;
            ssSplashScreen.StartMatrix();
            WaitForMatrixToFinish(DateTime.Now.AddSeconds(30));

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {   

        }

        // And tied her with fences and dragged her down 

        public void WaitForMatrixToFinish(DateTime dtSplashEnd)                // I hear a very gentle sound 
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>                                 // With your ear down to the ground 
                {
                    if ((dtSplashEnd > DateTime.Now) && (!ssSplashScreen.SplashPlayed))                     // We want the world and we want it... 
                    {
                        ThreadPool.QueueUserWorkItem((obj) => {
                            try
                            {
                                Thread.Sleep(10);
                                WaitForMatrixToFinish(dtSplashEnd);
                            }
                            catch (Exception err)
                            {
                                // Suppress the exception.
                            }
                        });                                                             // We want the world and we want it... 
                    }
                    else 
                    {
                        //ssSplashScreen.StopMatrix();                                    // Now 
                        CheckEULA();

                        //Deployment.Current.Dispatcher.BeginInvoke(() =>
                        //{
                        //    // Set the root visual to allow the application to render   
                        //    if (RootVisual != RootFrame)                                                            // Now? 
                        //        RootVisual = RootFrame;
                        //
                        //    RootFrame.Navigated -= CompleteInitializePhoneApplication;              // Now! 
                        //});
                    }
                });
        }

        public void BlockReward(DateTime dtSplashEnd)                
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>                                 
            {
                if (dtSplashEnd > DateTime.Now)
                {
                    ThreadPool.QueueUserWorkItem((obj) => {
                        try
                        {
                            Thread.Sleep(10);
                            BlockReward(dtSplashEnd);
                        }
                        catch (Exception err)
                        {
                            // Suppress the exception.
                        }
                    });                           
                }
                else
                {
                    ssSplashScreen.StopMatrix();                                    

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            if (((MainPage)((BitDozer)BitDozer.Current).TheMainPage)._connected)
                                ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).ApplicationBar.IsVisible = false;

                            // Set the root visual to allow the application to render   
                            if (RootVisual != RootFrame)
                                RootVisual = RootFrame;
                        }
                        catch (Exception err)
                        {
                            // Suppress the exception!
                        }
                    });
                }
            });
        }


        // i'm running down a dream.                                                                                                    R
        public void SplashReward()  // WAIT! We can't stop here! This is BAT COUNTRY!               - Hunter S Thompson,                I    
        {                                   // Here have a little of this sunshine acid.                Fear & Loathing in Las Vegas    P
            ssSplashScreen.SetupOverlay();          // How long do we have?                                                                             
            RootVisual = ssSplashScreen;                    // As your attorney.. I advise you to drive at the top speed possible, and 
            ssSplashScreen.StartMatrix(WhoIsTheWalrus);       // it'll be a goddamned miracle if we get there
            BlockReward(DateTime.Now.AddMinutes(3));  // before you t.t.turn into a wild animal.
        }                                               // It was going to be very close.                                                                     
                                                                
        public void CloseReward()
        {                                   // Ooooooo, oooooo baby.... Listen to this...
            ssSplashScreen.StopMatrix();       // Spy on me baby use satellite,  infrared to see me move through the night, aim gonna fire shoot me right, aim gonna like the way you fight, and i love the way you fight.
            CheckEULA();      // Now you found the secret code, I use to wash away my lonely blues well, so i cant deny or lie cause you a....                                
        }

        public void CheckEULA()
        {
            IsolatedStorageFile isfSettings = IsolatedStorageFile.GetUserStoreForApplication();
            if (isfSettings.FileExists("eula.bitdozer"))
                RootVisual = RootFrame; // S E X B O M B, S E X B O M B, you're a S E X B O M B. Uh. Huh.   -- Tom Jones, Sexbomb
            else
            {
                Eula e = new Eula();
                RootVisual = e;
            }
        }

        public void CloseEULA()
        {
            IsolatedStorageFile isfSettings = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isfs = isfSettings.CreateFile("eula.bitdozer");
            isfs.Close();

            RootVisual = RootFrame; // S E X B O M B, S E X B O M B, you're a S E X B O M B. Uh. Huh.   -- Tom Jones, Sexbomb
        }

        public void Quit()
        {
            
        }

        public void CloseInquisition()
        {
            if (((MainPage)((BitDozer)BitDozer.Current).TheMainPage)._connected)
                ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).ApplicationBar.IsVisible = false;
            RootVisual = RootFrame;
        }

        public void UseNewAccount(String szAccount)
        {
            TheMainPage.ApplicationBar.IsVisible = true;
            TheMainPage.CurrentAccount = szAccount;            
            RootVisual = RootFrame;         
        }

        public void UseNewAddress(String szAccount, String szAddress)
        {
            TheMainPage.ApplicationBar.IsVisible = true;
            TheMainPage.CurrentAccount = szAccount;
            RootVisual = RootFrame;         
        }

        public void CloseSupport()
        {
            RootVisual = RootFrame;         // We'll never have to say goodbye again
        }
#endregion                                              

        // Thank you to http://snipplr.com/view/41214/ for the code to determine the phone theme :)
        // Detecting the current theme.
        private static Color lightThemeBackground = Color.FromArgb(255, 255, 255, 255);
        private static Color darkThemeBackground = Color.FromArgb(255, 0, 0, 0);
        private static SolidColorBrush backgroundBrush;
        public static AppTheme CurrentTheme
        {
            get
            {
                if (backgroundBrush == null)
                    backgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;

                if (backgroundBrush.Color == lightThemeBackground)
                    return AppTheme.Light;
                else if (backgroundBrush.Color == darkThemeBackground)
                    return AppTheme.Dark;

                return AppTheme.Dark;
            }
        }    
    }

    // An enum to specify the theme.
    public enum AppTheme
    {
        Dark = 0,
        Light = 1
    }

}
