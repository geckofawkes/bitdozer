// BitDozer.ItemViewModel                                                          ....A desperate disease requires a dangerous remedy....
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
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Bitdozer
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    NotifyPropertyChanged("LineOne");
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        private string _lineThree;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                if (value != _lineThree)
                {
                    _lineThree = value;
                    NotifyPropertyChanged("LineThree");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}