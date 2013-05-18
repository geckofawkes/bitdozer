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
    public partial class CurrentAccount : UserControl
    {
        public CurrentAccount()
        {
            InitializeComponent();
        }

        public void SetAccount(String account, String address = "")
        {
            if (!String.IsNullOrEmpty(account))
                tbCurrentAccount.Text = account;
            else
                tbCurrentAccount.Text = "~~~";

            if (!String.IsNullOrEmpty(address))
                tbCurrentAccount.Text += " (" + address + ")";
        }
    }
}
