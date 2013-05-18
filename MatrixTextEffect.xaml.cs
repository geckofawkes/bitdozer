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
    public partial class MatrixTextEffect : UserControl
    {
        private static Random r = new Random((int)DateTime.Now.Ticks);
        private const int MAX_COLUMN = 64;      // Maximum text columns
		private const int TIMER_SPAN = 42;     // Time to wait for adding next column

        private DispatcherTimer _timer;
        private int _totalColumn = 0;

        private bool _gg = false;
        public bool gg
        {
            get 
            {
                return _gg;
            }
            set 
            {
                _gg = value;
            } 
        }

        private bool _matrix = true;
        public bool matrix
        {
            get
            {
                return _matrix;
            }
            set 
            {
                _matrix = value;
            }
        }

        public MatrixTextEffect()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////        
        // Handlers
        /////////////////////////////////////////////////////	
        	
       	// Add new Text Column	

        void _timer_Tick(object sender, EventArgs e)
        {
            addTextColumn();
        }


        void textColumn_Completed(object sender, EventArgs e)
        {
            TextColumn textColumn = sender as TextColumn;
            if (LayoutRoot.Children.Contains(textColumn))
            {
                LayoutRoot.Children.Remove(textColumn);
            }
            _totalColumn--;
        }

		/////////////////////////////////////////////////////        
        // Private Methods
        /////////////////////////////////////////////////////	
        
        // add new text column
        private void addTextColumn(){
        	if(_totalColumn < MAX_COLUMN){
	        	TextColumn textColumn  = new TextColumn(r, Height, gg, matrix);                
                textColumn.Completed += new EventHandler<EventArgs>(textColumn_Completed);
                textColumn.SetValue(Canvas.LeftProperty, r.NextDouble() * Width);
                LayoutRoot.Children.Add(textColumn);
	        	_totalColumn++;
        	}
		}


		/////////////////////////////////////////////////////        
        // Public Methods
        /////////////////////////////////////////////////////		
        
        // start the timer
        public void Start(){
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, TIMER_SPAN);
            _timer.Tick += new EventHandler(_timer_Tick);
        	_timer.Start();
		}

        public void Stop()
        {
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => { try { _timer.Stop(); } catch (Exception err) { /* suppress */ } });
            }
            catch (Exception err)
            {
                // Suppress this exception.
            }
        }

    }
}
