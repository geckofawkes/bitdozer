// Improved upon the original... There were... Problems with the original..
// Original was great to get the basics done though which was what he was shooting for!
// In Your Service,
// - Gecko Fawkes
//
/****************************************************************************

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

-- Copyright 2009 Terence Tsang
-- admin@shinedraw.com
-- http://www.shinedraw.com
-- Your Flash vs Silverlight Repositry

****************************************************************************/


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
using System.Windows.Threading;

namespace MatrixTextEffect
{
    /*
    *   Title: A Matrix Text Effect Demonstration in C#
    *   Author: Terence Tsang	
    *   http://www.shinedraw.com
    *   Your Flash vs Silverlight Repositry
    */	

    public partial class TextColumn : UserControl
    {
        public event EventHandler<EventArgs> Completed;

		private const double DROP_SPEED  = 21;           // text drop speed
		private const int TIMER_SPAN = 10;             // time to wait for changing the character
		private const double TEXT_HEIGHT  = 100;         // text height
        private const int FONT_SIZE = 16;               // text font size
        private const string FONT_FAMILY = "WingDings";   // font family
        private Color initColor = Color.FromArgb(255, 0, 255, 0);
        private const int FADE_DURATION = 777;         // fade out duration
        private const int FPS = 30;                     // FPS

        private Random arrrImAPirate = null; 

		private DispatcherTimer _timer;						// user time to clone animation
		private TextBlock _textAnimation;		// text animation
		private double _columnHeight ;				// column height
		private int _charCode = 112;				// first character
        private int _charCount = 0;

        private bool gadgetGirl = false;  // true or false, yes or no.
        private bool matrix = true;

        // I dream in color.
        public bool TechnicolorYawn()                                                   // Me not working hard?
        {                                                                               // Yea right picture that with a kodak
            return gadgetGirl || !matrix;                                               // And better yet, go to times square
        }                                                                               // Take a picture of me with a kodak    
                                                                                        // Took my life from negative to positive
                                                                                        // And I just want y'all know that
        public TextColumn(Random rRandom, double columnHeight, bool gg, bool m)         // And tonight, let's enjoy life
        {                                                                                  // - Pitbull, "Give Me Everything"
            InitializeComponent();
            arrrImAPirate = rRandom;
            gadgetGirl = gg;
            matrix = m;

            // this is the year 2011, we can do color and not just monochrome green ;)
            // final release will is set to monochrome green however for props to GadgetGirl and the Matrix
            // Cr4ck T3H C0d3 will enable users to toggle this setting.  

            if (TechnicolorYawn())
                RandomizeInitColor();       // I dream... in colour.

            _columnHeight = columnHeight;

            createFirstCharacter();
			
			// add timer
        	_timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, TIMER_SPAN);
        	_timer.Tick +=new EventHandler(_timer_Tick);
        	_timer.Start();
        	
        	// add handler
        	CompositionTarget.Rendering +=new EventHandler(CompositionTarget_Rendering);
            Application.Current.Host.Settings.MaxFrameRate = FPS;
		}
                                                                                        //My eyes have seen you         //My eyes have seen you 
        public void RandomizeInitColor()                                                //My eyes have seen you         //My eyes have seen you
        {                                                                               //My eyes have seen you         //My eyes have seen you
            byte alpha = 0;                                                             //Stand in your door            //Free from disguise 
            while (alpha == 0)                                                          //When we meet inside           //Gazing on a city under
            {                                                                           //Show me some more             //Television skies
                alpha = (byte)arrrImAPirate.Next(255);                                  //Show me some more             //Television skies 
                if (alpha < 128)                                                        //Show me some more             //Television skies  
                    alpha = 0;
            }                                                                           //My eyes have seen you         //My eyes have seen you 
            byte red = (byte)arrrImAPirate.Next(255);                                   //My eyes have seen you         //My eyes have seen you 
            byte green = (byte)arrrImAPirate.Next(255);                                 //My eyes have seen you         //Eyes have seen you
            byte blue = (byte)arrrImAPirate.Next(255);                                  //Turn and stare                //Let them photograph your soul 
                                                                                        //Fix your hair                 //Memorize your alleys
            initColor = Color.FromArgb(alpha, red, green, blue);                        //Move upstairs                 //On an endless roll 
        }                                                                               //Move upstairs                 //Endless roll [x 15]
                                                                                        //Move upstairs                 //Endless roll 
        /////////////////////////////////////////////////////                                                           //Endless roll 
        // Handlers                                                                                                     //Endless roll 
        /////////////////////////////////////////////////////	                                                        //Endless roll 
                                                                                                                        //Endless roll 
        // Enter Frame Event                                                            //  -The Doors                  //Endless roll 
        void  CompositionTarget_Rendering(object sender, EventArgs e)                   //     My Eyes Have Seen You    //Endless roll 
        {                                                                                                               //Endless roll 
            double y = (double) _textAnimation.GetValue(Canvas.TopProperty);                                            //Endless roll 
            _textAnimation.SetValue(Canvas.TopProperty, y + DROP_SPEED);                                                //Endless roll 
                                                                                                                        //Endless roll     
            if (y > _columnHeight + TEXT_HEIGHT)                                                                        //Endless roll 
            {                                                                                                           //Endless roll 
				// clear all listeners                                                                                  //Endless roll 
                CompositionTarget.Rendering -= new EventHandler(CompositionTarget_Rendering);
                _timer.Stop();                      // Indian, Indian, what did you die for? Indian says, "nothing at all."

				// remove text animation
				if(LayoutRoot.Children.Contains (_textAnimation)){
                    LayoutRoot.Children.Remove(_textAnimation);
                    _textAnimation = null;
				}
                                                            // Flying Arabian Wicked Moose (FAWM) EP | Dr. Noise
                // reduce our character count
                _charCount--;
				
				// check complete
				checkComplete();
			}
		}
		
		// create a new text animation                                                      

        void  _timer_Tick(object sender, EventArgs e)                           // I’m loose                    - JLo & Pitbull
        {                                                   //  And everybody knows I get off the train             'Get On The Floor'
            try
            {
                if (_textAnimation != null)	                                  // Baby it’s the truth
                {
                    _charCode--;                                        //  I’m like inception I play with your brain
                    _charCode = Math.Max(_charCode, 25);                                // So I don’t sleep I snooze
                    _textAnimation.Text = Convert.ToChar(_charCode).ToString();     //  I don’t play no games so don’t get it confused no
                    // clone a new one                                                   // Cos you will lose yeah
                    cloneCharacter();                                     //  Now pump it up
                }
                else
                    _timer.Stop();
            }
            catch (Exception err)
            {
                // Suppress this exception
                _timer.Stop(); // and stop the timer so it doesnt throw this crap any more
            }
        }                                                                    // And back it up like a Tonka truck
                                                        //  That badonka donk is like a trunk full of bass on an old school Chevy
 
        // Tonight we gonna be gettin on the floor. vvv Legacy code from the original!  Be original, Drink 7-Up.		
    /*
		private voi on_complete(e : Event):void{
			var textAnimation : TextAnimation = e.target as TextAnimation;	
			if(contains(textAnimation)){
				removeChild(textAnimation);	
				checkComplete();	
			}
		}*/

		/////////////////////////////////////////////////////        
        // Private Methods
        /////////////////////////////////////////////////////	
        
        // create first text animation
        private void createFirstCharacter()
        {
            // create new text animation                                            
            _textAnimation = new TextBlock();
            _textAnimation.Text = Convert.ToChar(_charCode).ToString();
            _textAnimation.Foreground = new SolidColorBrush(initColor);
            _textAnimation.FontSize = FONT_SIZE;
            _textAnimation.FontFamily = new FontFamily(FONT_FAMILY);
            _textAnimation.SetValue(Canvas.TopProperty, -TEXT_HEIGHT);

            LayoutRoot.Children.Add(_textAnimation);
        }
            
        // clone a new animation
        private void cloneCharacter()
        {                              // All I need is some vodka and some… coke
            TextBlock textAnimation = new TextBlock();          //  And watch… get donkey konged
            textAnimation.Text = Convert.ToChar(_charCode).ToString();      // … if you’re ready for things to get heavy
            textAnimation.Foreground = new SolidColorBrush(initColor);  //  I get on the floor and act a fool if you let me
            textAnimation.FontSize = FONT_SIZE;                 // Don’t believe me just vet me
            textAnimation.FontFamily = new FontFamily(FONT_FAMILY);             //  My name ain’t Keith but I see why you Sweat me
            textAnimation.SetValue(Canvas.LeftProperty, _textAnimation.GetValue(Canvas.LeftProperty));          // L.A. Miami New York
            textAnimation.SetValue(Canvas.TopProperty, _textAnimation.GetValue(Canvas.TopProperty));        // Say no more get on the floor

			//textAnimation.addEventListener(Event.COMPLETE, on_complete);
			LayoutRoot.Children.Add(textAnimation);

// Lord…
// Lord…
// Lord…
// …where do we get such men?
// Lord…
// Lord…
// Lord…
// Lord…
// …where do we get such men?
// Citizens of Grenada, military forces from neighbouring Caribbean nations and the United States have arrived in ???Grenada??? to protect lives and restore order. Your cooperation will ensure that peace and democracy are restored in the near future…
// So what happens now? 
                                                    // - Art Of Noise, A Time To Fear (Who's Afraid?)

            // add a new story board to fade out the text color                             // Military forces…
            Storyboard moveStoryboard = new Storyboard();                                           // Military forces…
                                                                        // Military forces…                                                                                    
            // remove the item once finished                                                                            // Military forces…
            moveStoryboard.Completed += delegate(object sender, EventArgs e)                // Military forces…
            {                                                                                                   // Military forces…
                if (LayoutRoot.Children.Contains(textAnimation))                // …of neighbouring Caribbean nations and the…
                {                                                   // Citizens of Grenada, military forces from neighbouring Caribbean nations and the United States have arrived in ???Grenada??? to protect lives and restore order. 
                    LayoutRoot.Children.Remove(textAnimation);              // Your cooperation will ensure that peace and democracy are restored in the near future…
                    textAnimation = null;                                                       // So what happens now?
                    checkComplete();    
                }
            };

            ColorAnimation colorAnimation = new ColorAnimation();
            colorAnimation.To = Colors.Black;
            colorAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, FADE_DURATION));

            Storyboard.SetTarget(colorAnimation, textAnimation);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            moveStoryboard.Children.Add(colorAnimation);
            moveStoryboard.Begin();

        }
        
        // dispatch complete event if no resources left
        private void checkComplete(){
            if (LayoutRoot.Children.Count == 0)
            {
                if (Completed != null)
                {
                    Completed(this, new EventArgs());
                }
            }
        }
    }
}
