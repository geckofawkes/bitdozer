// BitDozer.NewAddress                                                       ....A desperate disease requires a dangerous remedy....
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

using Bitnet.Client;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitdozer
{
    public partial class NewAddress : UserControl
    {
        private BitnetClient bitnet = null;
        private String account = String.Empty;
        private AccountDescriptorItem accountDescriptor = null;

        private String accountUsed = String.Empty;
        
        public NewAddress(BitnetClient bitnetClient, String szAccount)
        {
            InitializeComponent();

            account = szAccount;
            bitnet = bitnetClient;
            bitnet.ListAccounts(LoadAccounts, 0);
        }

        private object LoadAccounts(SLBTCPacket packet)
        {
            JObject obj = packet.result as JObject;

            List<AccountDescriptorItem> accounts = new List<AccountDescriptorItem>();
            foreach (KeyValuePair<string, JToken> kvp in obj)
            {
                AccountDescriptorItem adi = new AccountDescriptorItem(kvp);
                if (!String.IsNullOrEmpty(adi.Account))
                {
                    var matches = from a in accounts
                                  where a.Account.Equals(adi.Account)
                                  select a;
                    if (matches.Count() == 0)
                        accounts.Add(adi);
                }
            }            
            cbxAccount.ItemsSource = accounts;
            cbxAccount.SelectedItem = accounts[0];

            //AccountHighlighter lighter = new AccountHighlighter();
            //cbxAccount.Foreground = lighter.Convert(cbxAccount.SelectedItem, typeof(Brush), null, null) as Brush;

            return null;
        }

        private void btnCreateAddress_Click(object sender, RoutedEventArgs e)
        {
            accountUsed = ((AccountDescriptorItem)cbxAccount.SelectedItem).Account;
            bitnet.GetNewAddress(FinishNewAddress, accountUsed);
        }

        private object FinishNewAddress(SLBTCPacket packet)
        {
            String szNewAddress = packet.result as String;

            MessageBox.Show("Address" + Environment.NewLine + account + Environment.NewLine + "Created!");

            // England Dan & John Ford Coley
            ((BitDozer)BitDozer.Current).UseNewAddress(accountUsed, szNewAddress);  // And all alone I'm sitting here, remembering all the times I called for you.... Who's lonely now?  Who's lonely now-how? What goes up, must come down.

            // And through it all, you watched me go
            // You never even cared that I 
            //      NEEEEEEEEEEDEEEEEEED YOU
            // Who's lonely now?
            //                  Who's lonely now-how?
            // What goes up....
            //
            //
            // Must come down.

            return null;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ((MainPage)((BitDozer)BitDozer.Current).TheMainPage).ApplicationBar.IsVisible = true;
            ((BitDozer)BitDozer.Current).CloseSupport();  
        }
    }
}
