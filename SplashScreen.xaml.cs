// BitDozer.SplashScreen                                                     ....A desperate disease requires a dangerous remedy....
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
using System.Windows.Shapes;

using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;

using Bitdozer;
using MatrixTextEffect;

namespace Bitdozer
{
    //    I’ve been searching for gods all my life. 
    //    Now, I know them. 
    //    There is a meaning to life. 
    //    There are things worth believing in. 
    //    There are things worth being passionate about. 
    //
    //    All of this plays a part in trying to give a positive sense of something to believe in. 
    //    A positive crusade of thought, of meditation, and emotion that you can use to advance humanity tremendously, but that excises deliberately the god of war. 
    //
    //    When you find the gods inside yourself, you’ll find the god of war, and he will be one of the most powerful passions in you. 
    //    You have to freeze him inside his own private hell and make your positive gods the gods that take you over. 
    //
    //    And by the gods that take you over, I mean that you have to find those passions that are so much more powerful than you, 
    //    than anything you’ve been allowed to express in your life, and making those things the things that you work on, 
    //    not putting off until you’re 40 or 50 the things you feel passionate about at the age of 15 and 16, but going directly to those things and trying to implement them when you’re 20. 
    // 
    //    Pass go. Forget the $200. Go directly to Park Place, and put your life there — on the line, with all the emotion and power and passion and insight in you, and,
    //    Fuck the god of war.
    //
    //     - Leggo Beast, The New Deal; Intertubes says its Howard Bloom speaking.
    //
    public partial class SplashScreen : UserControl
    {
        private MatrixTextEffect.MatrixTextEffect _matrixTextEffect;

        Canvas overlay;

        public MediaElement Soundz;
        public bool SplashPlayed = false;

        public SplashScreen()
        {
            InitializeComponent();
           
            Soundz = meSoundz;

            _matrixTextEffect = new MatrixTextEffect.MatrixTextEffect();
            _matrixTextEffect.Height = this.Height;
            _matrixTextEffect.Width = this.Width;
            _matrixTextEffect.SetValue(Canvas.ZIndexProperty, 10);
            _matrixTextEffect.matrix = true;
            LayoutRoot.Children.Insert(1, _matrixTextEffect);
            
            overlay = new Canvas();
            overlay.Height = this.Height;
            overlay.Width = this.Width;
            overlay.Background = new SolidColorBrush(Colors.Transparent);
            overlay.SetValue(Canvas.ZIndexProperty, 20);
            overlay.MouseLeftButtonDown += new MouseButtonEventHandler(overlay_MouseLeftButtonDown);
            LayoutRoot.Children.Insert(1, overlay);
        }

        void overlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StopMatrix();
            if (!SplashPlayed)
            {
                SplashPlayed = true;
                meSoundz.AutoPlay = false;
                ((BitDozer)BitDozer.Current).CloseReward();
            }
            else
            {
                ((BitDozer)BitDozer.Current).CloseReward();
            }
        }

        ~SplashScreen()
        {
            
        }

        public void StartMatrix()
        {
            switch (((BitDozer)BitDozer.Current).WhoIsTheWalrus.ToLower())
            {
                case "anonymous":
                    ((BitDozer)BitDozer.Current).ssSplashScreen.PlayFile("Remember170A.mp3");            
                    break;
                default:
                    break;
            }

            _matrixTextEffect.Start();
        }

        public void StartMatrix(String walrus)
        {
            switch (walrus)
            {
                case "archangelmichael":
                    _matrixTextEffect.gg = true;
                    _matrixTextEffect.matrix = false;
                    break;
                case "alice":
                    _matrixTextEffect.gg = true;
                    _matrixTextEffect.matrix = false;
                    break;
                case "anonymous":
                    _matrixTextEffect.gg = true;
                    _matrixTextEffect.matrix = false;
                    break;
                case "coocoocaachoo":
                    _matrixTextEffect.gg = true;
                    _matrixTextEffect.matrix = false;
                    break;
                case "geckofawkes":
                    _matrixTextEffect.gg = true;
                    _matrixTextEffect.matrix = false;
                    break;
                default:
                    break;
            }
            StartMatrix();
        }

        public void StopMatrix()
        {
            _matrixTextEffect.Stop();
        }

        public void SetupOverlay()
        {
            // Just breathe.
            switch(((BitDozer)BitDozer.Current).WhoIsTheWalrus.ToLower())
            {
                case "anonymous":
                    ((BitDozer)BitDozer.Current).ssSplashScreen.PlayFile("Remember170A.mp3");            // What have they done to the earth? 
                    meSoundz.AutoPlay = true;
                    break;
                case "geckofawkes":
                    ((BitDozer)BitDozer.Current).ssSplashScreen.PlayFile("geckofawkes_character.mp3"); // Just because you are a character, does not mean you have character. - The Wolf, "Pulp Fiction"
                    meSoundz.AutoPlay = true;
                    break;
                default :
                    break;
            }

            DateTime dtNow = new DateTime(DateTime.Now.Ticks);      // What have they done to our fair sister? 
            DateTime dtEnd = dtNow.AddSeconds(10.0);                // Ravaged and plundered and ripped her and bit her 
        }                                                           // Stuck her with knives in the side of the dawn             

        public void Splash_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).StopMatrix(LayoutRoot);
            ((BitDozer)BitDozer.Current).CloseReward();
        }

        #region Soundz Bitches
        public void PlayFile(string fileName)
        {
            Uri uSound = new Uri( "Assets/" + fileName, UriKind.Relative);

            if (MediaPlayer.State != MediaState.Playing)
            {
                //meSoundz.Stop();
                meSoundz.Position = TimeSpan.Zero;
                meSoundz.Source = uSound;
                meSoundz.AutoPlay = true;
            }
        }

        void meSoundz_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MediaElement m = (MediaElement)sender;

            if (!SplashPlayed)
            {
                m.Source = new Uri(String.Empty);
                SplashPlayed = true;
                m.AutoPlay = false;
            }
            MessageBox.Show("Whoa! Matrix-fart.");
        }

        private void meSoundz_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaElement m = (MediaElement)sender;
            m.AutoPlay = false;
        }

        private void meSoundz_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement m = (MediaElement)sender;
            m.Stop();
            m.AutoPlay = false;

            if (!SplashPlayed)
            {
                //m.Source = new Uri(String.Empty);
                SplashPlayed = true;
                m.AutoPlay = false;
            }
        }
        #endregion 

    }
}
