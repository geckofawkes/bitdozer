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
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Bitdozer
{
    public partial class Dedications : UserControl
    {
        public Dedications()
        {
            InitializeComponent();
        }

        public void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (((MainPage)((BitDozer)BitDozer.Current).TheMainPage)._connected)
                ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).ApplicationBar.IsVisible = false;
            ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).StopMatrix(LayoutRoot);
            ((BitDozer)BitDozer.Current).CloseReward();
        }
    }
}
