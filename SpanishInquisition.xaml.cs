// BitDozer.SpanishInquisition                                               ....A desperate disease requires a dangerous remedy....
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

namespace Bitdozer
{
    // Nobody expects the Spanish Inquisition!  Get it.. its a dialog box? Oi. Go learn history and get a sense of humor! 
    public partial class SpanishInquisition : UserControl
    {
        public SpanishInquisition()                                             // Do you want to be the singer?
        {                                                                       // Do you want to be the song?
            InitializeComponent();                                              // Let me tell you something
        }                                                                       // You just couldn't be more wrong.

        private void bCrackTheCode_Click(object sender, RoutedEventArgs e)
        {
            string tehbird = tbAnswer.Text;
            switch (tehbird.ToLower())
            {
                case "god":
                    MessageBox.Show("Peace be with you.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "archangelmichael";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "angel":
                    MessageBox.Show("Do you want to be an angel?  Sorry, try again!");
                    break;
                case "star" :
                    MessageBox.Show("Do you want to be a star?  Sorry, try again!");
                    break;
                case "guitar" :
                    MessageBox.Show("Do you want to play some magic on my guitar?  Sorry, try again!");
                    break;
                case "poet" :
                    MessageBox.Show("Do you want to be a poet?  Sorry, try again!");
                    break;
                case "gnostic" :
                    MessageBox.Show("The gnostics were wrongly labeled heretics and excommunicated.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "archangelmichael";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;                   
                case "origen" :
                    MessageBox.Show("The end is always like the beginning: and, therefore, as there is one end to all things, so ought we to understand that there was one beginning; and as there is one end to many things, so there spring from one beginning many differences and varieties, which again, through the goodness of God, and by subjection to Christ, and through the unity of the Holy Spirit, are recalled to one end, which is like unto the beginning.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "archangelmichael";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "color":
                case "colour":
                    MessageBox.Show("Do you dream in colour?");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "coocoocaachoo";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "string" :
                    MessageBox.Show("Do you want to be my string?  Sorry, try again!");
                    break;
                case "anything" :
                    MessageBox.Show("You could be anything.  Sorry, try again!");
                    break;
                case "another" :
                    MessageBox.Show("Do you want to be the lover of another?  Sorry, try again!");
                    break;
                case "undercover" :
                    MessageBox.Show("Undercover?  You could even be the man on the moon.  Sorry, try again.");
                    break;
                case "player" :
                    MessageBox.Show("Do you want to be the player? Sorry, try again.");
                    break;
                case "try" :
                    MessageBox.Show("Do or do not.  There is no try.  Do again!");
                    break;
                case "wrong" :
                    MessageBox.Show("Two wrongs do not make a right, but three lefts do.  Try again.");
                    break;
                case "something" :
                    MessageBox.Show("It just don't mean a thing.  Sorry, try again.");
                    break;
                case "badger" :
                    MessageBox.Show("Badger! Badger! Badger! Badger! Sorry, try again.");
                    break;
                case "mushroom" :
                    MessageBox.Show("Mushroom! Mushroom! Sorry, try again.");
                    break;
                case "snake" :
                    MessageBox.Show("A snake! Oooo! It's a snake!  Sorry, try again.");
                    break;
                case "bird":
                    MessageBox.Show("Yes, the bird is the word. Unforunately its not t3h word. Try again.");                                                                                                        
                    break;
                case "lebowski":
                    MessageBox.Show("The dude abides... here's an occasional flashback.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "coocoocaachoo";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "go" :
                case "go!":
                case "ni" :
                case "ni!":
                    MessageBox.Show("Veeee vaaaant the shrubbery, Lebowski.");
                    break;
                case "moon":
                    MessageBox.Show("One of these days, Alice... BANG! ZOOM! Straight to the moon!  Sorry, try again.");
                    break;
                case "kisser":
                    MessageBox.Show("One of these days... POW!! Right in the kisser!  Sorry, try again.");
                    break;
                case "sheen":
                    MessageBox.Show("Winning!  Sorry, ninja warlock, try again.");
                    break;
                case "chesire":
                    MessageBox.Show("Can you stand on your head?");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "alice";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "alice":
                    MessageBox.Show("Is everything alright Alice?");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "alice";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "caterpillar":
                    MessageBox.Show("Stop.  That is not spoken correctically.  It goes:  How doth the little crocodile improve his shining tail.  And pour the waters of the Nile on every golden scale.  How cheerfully he seems to grinn, how neatly spreads his claws.  And welcomes little fishies in with gently smiling jaws.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "alice";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "gadgetgirl":                    
                    MessageBox.Show("Still... You turn me on.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "coocoocaachoo";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "moose":
                    MessageBox.Show("Moose bites can be very nasty.  It can get nasty in t3h ghetto too.");
                    break;
                case "ghetto":
                    MessageBox.Show("Theres nowhere to run, theres nowhere to hide from whats in your mind... it's a ghetto, better let go.");
                    break;
                case "marmot":
                case "squirrel":
                    MessageBox.Show("Fearless Leader: Have you liquidated Moose and Squirrel? Did you use the CDI? Are you talking to me? Are you talking to me? Then who else are you talking to? Are you talking to me? Well, I am the only one here, so you must be talking to me. And you are lying! Now catch Moose and Squirrel. And next time use the CDI on them.");
                    break;
                case "gospel":
                    MessageBox.Show("Gospel! That's some good news, Walter!");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "archangelmichael";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "occupy":
                    MessageBox.Show("What have you done to support the Occupy Movement?");
                    break;
                case "occupywallstreet":
                    MessageBox.Show("Please help end economic slavery.");
                    break;
                case "student":
                    MessageBox.Show("In 2010, the average college graduate had accumulated approximately $25,000 in student loan debt by graduation day.");
                    break;
                case "mad" :
                case "hatter" :
                    MessageBox.Show("Yes, yes. And when you come to the end.");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "alice";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "loans" :
                    MessageBox.Show("Americans have accumulated well over $900 billion in student loan debt. That figure is higher than the total amount of credit card debt in the United States.");
                    break;
                case "cowbell" :
                    MessageBox.Show("I have a fever, and the only prescription is MORE COWBELL! Try again!");
                    break;
                case "reaper" :
                    MessageBox.Show("Don't fear teh reaper!  Try again!");
                    break;
                case "fear" :
                    MessageBox.Show("Seasons don't fear the reaper, nor do the sun, the wind, or the rain.  We can be like they are.  Come on baby, don't fear the reaper.  Try again!");
                    break;
                case "zork" :
                    MessageBox.Show("You are in an open field west of a big white house with a boarded front door.\nThere is a small mailbox here.\n\n>");
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "zork";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "anonymous" :
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "anonymous";
                    ((BitDozer)BitDozer.Current).SplashReward();
                    break;
                case "trippy":                                                      // Has an advertiser ever offered to pay an open-source coder to put comments
                    ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "coocoocaachoo";      // in their code?  No, they'd rather give it to their friends while
                    ((BitDozer)BitDozer.Current).SplashReward();            // we slave to invent intellectual property that their cohorts then exploit to make millions while
                    break;                                          // we code 60+ hours a week and get fucked over when the big "executives" can't suck the corporate bondholders' cocks well enough
                default:                                                        // oh, whats that? someone didnt meet their numbers? better fire some workers.
                    MessageBox.Show("Bzzzt. Wrong Answer.  Maybe a little bird will tell you the word one day.  Better figure it out or the nihilists will come back and this time it wont be a marmot.  Nice marmot!");
                    break;
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            ((BitDozer)BitDozer.Current).CloseInquisition();
        }

        private void tbAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            tbAnswer.Text = String.Empty;
        }
    }
}
