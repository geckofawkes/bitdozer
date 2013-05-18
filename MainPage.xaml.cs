// BitDozer.MainPage                                                         ....A desperate disease requires a dangerous remedy....
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
// Programming IS Art.  Programming IS Logic.  Programming IS Science.  Programming IS. 
//
// Bitcoins are Currency v2.0.  Bitcoins are the most important economic development since the stock market.  Bitcoins cannot be stopped.
// Bitcoins can end economic slavery.
//
// I cannot summarize it any better than BlueSky did when corresponding with Satoshi:
//
//     I must thank Satoshi for his work (although the groundwork was done during the 80's, algorythms etc. 
//     this is the first useful implementation and it's effects are profound).  
//     I live in PRChina, combining Freenet, Tor, I2P there is the framework for free,anonymous discussion 
//     and transfer of information(something that is prevented here, sometimes with serious penalties). 
//     Add to this BitCoin and we now have an underground market free from the tyrany and scrutinising eye 
//     of the state. This will allow an alternative, free China to develope under the nose of the state machinery.
//
// And so I release this in the hopes that it will help us all to create a better, freer, and more peaceful world to all to live in.
//
// In Your Service,
// - Gecko Fawkes
//
// Think for yourself and question authority. - Timothy Leary
// If you want to change the way people respond to you, change the way you respond to people. - Timothy Leary
//
//
#define RELEASE
using System;                                                   // Curses, Invocations
using System.Collections.Generic;                               // Weird bate-headed mongrels
using System.Linq;                                              // I keep expecting one of you to rise
using System.Net;                                               // Large buxom obese queen
using System.Windows;                                           // Garden hogs and cunt veterans
using System.Windows.Controls;                                  // Quaint cabbage saints
using System.Windows.Documents;                                 // Shit hoarders and individualists
using System.Windows.Input;                                     // Drag strip officials
using System.Windows.Media;                                     // Tight lipped losers and
using System.Windows.Media.Animation;                           // Lustful fuck salesman
using System.Windows.Shapes;                                    // My militant dandies
using Microsoft.Phone.Controls;                                 // All strange orders of monsters
using Microsoft.Phone.Shell;                                    // Hot on the tail of the woodvine
using System.Windows.Data;
using System.IO.IsolatedStorage; // Isolation, such a lonely thing, no man is an island!
using System.Text;                  // What are words but sequences of letters.
using Microsoft.Phone.Tasks;                // SMSexting baby. Sexxxy.

using Bitnet.Client;                                            // We welcome you to our procession
using Newtonsoft.Json;                                          // Here come the Comedians
using Newtonsoft.Json.Linq;                                     // Look at them smile
using MatrixTextEffect;                                         // Watch them dance an Indian mile           
using Bitdozer.ViewModels;                                      // Look at them gesture                

                                                                // How aplomb            

namespace Bitdozer                                              // So to gesture everyone                                
{                                                               // Words dissemble                            
    public partial class MainPage : PhoneApplicationPage        // Words be quick
    {                                                           // Words resemble walking sticks
        ApplicationBar appBar = null;                           // Plant them they will grow
                                                                // Watch them waver so
        BitnetClient bitnet = null;                             // I'll always be a word man
                                                                // Better then a bird man
        String defaultAddress = String.Empty;                   //                         - The Doors, RIP Jim Morrison
        String currentAddress = String.Empty;

// <3 <3 <3 <3
//      This one goes out to Gadget Girl for she is a fan of The Matrix!
        private MatrixTextEffect.MatrixTextEffect _matrixTextEffect;
        Canvas overlay = null;
// E> E> E> E>

        private String currentAccount = String.Empty;
        public String CurrentAccount
        {
            get
            {
                return currentAccount;
            }
            set
            {
                currentAccount = value;
            }
        }
        private AccountDescriptorItem currentAccountDescriptor = null;
        public AccountDescriptorItem CurrentAccountDescriptor
        {
            get
            {
                return currentAccountDescriptor;
            }
            private set
            {
                currentAccountDescriptor = value;
            }
        }

        internal bool _connected = false;


        // Constructor                              // http://www.youtube.com/watch?v=qdwzHBnm6mo
        public MainPage()                           // Emerson, Lake & Palmer, Still You Turn Me On
        {
            ((BitDozer)BitDozer.Current).TheMainPage = this;                        // Do you want to be an angel?
            // Do you want to be a star? 
            InitializeComponent();                                                  // Do you want to play some magic on my guitar?
            // Do you want to be a poet?
            // Set the data context of the listbox control to the sample data       // Do you want to be my string?
            DataContext = BitDozer.ViewModel;                                       // You could be anything.
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);                 // Do you want to be the lover of another

            caAccounts.SetAccount(null, currentAddress);

            SetupDefaultValues();                                                   // Undercover? You could even be the man on the moon.
        }

        private void SetupDefaultValues()
        {
            //acAds.ApplicationId = "test_client";
            //acAds.AdUnitId = "Image480_80";

#if RELEASE
            tbServerUrl.Text = "bitcoind.address.url:port";
            tbUserName.Text = "username";
            acAds.ApplicationId = "00000000-0000-0000-0000-00000000000";
            acAds.AdUnitId = "12345";
#else
            tbServerUrl.Text = "server.domain.url:8332";
            tbUserName.Text = "login";
            pbPassword.Password = "password";
            acAds.ApplicationId = "00000000-0000-0000-0000-00000000000";
            acAds.AdUnitId = "12345";
#endif
            ApplicationBar.Opacity = 0.5f;  
            if (BitDozer.CurrentTheme == AppTheme.Light)
            {
                //piAbout.Foreground = new SolidColorBrush(Colors.Black);
                piAboutHeader.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        // We are dealing with the best-educated generation in history. They are a hundred times better educated than their grandparents, and 
        // ten times more sophisticated. There has never been such an open-minded group. The problem is that no one is giving them anything fresh. 
        // They've got a brain dressed up with nowhere to go.  - Timothy Leary
        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        // =)  Hey Gen-X, Y, and Z.  This was said about the baby boomers and they didnt have the internet, distributed computing, MMORPGs, and
        //     instantaneous access to knowledge and communication.  Our better educated grandparents lied and screwed us over so we will be paying
        //     for their greed and corruption.  Do you really believe you are going to receive "Social Security" payments before the age of death?  
        //     So what are you going to do about it?  Are you going to work for 20+ years to pay off those student loans?  Oh yeah, you dont have jobs. 

        // Setup the Bitnet client
        public bool InitializeBitnet(string username, string password)
        {
            bool bRes = false;
            String szUrl = String.Empty;
            String szTest = tbServerUrl.Text.ToLower();
            if (!szTest.StartsWith("http://") || !szTest.StartsWith("https://"))
                szUrl = "http://";
            szUrl += tbServerUrl.Text;
            try
            {
                bitnet = new BitnetClient(szUrl);
                bitnet._errs = bitnetError;

                ICredentials creds = new NetworkCredential(username, password);
                bitnet.Credentials = creds;
                bitnet.Dispatcher = Deployment.Current.Dispatcher;
                bRes = true;
            }
            catch (Exception err)
            {                
                Notify("Invalid bitcoin server or credentials!  Please fix and try again!");
            }
            return bRes;
        }

        protected void bitnetError(String errMsg)
        {
            StopMatrix(LayoutRoot);
            Notify(errMsg);
        }

        private static bool bLoaded = false;
        private static Microsoft.Phone.Marketplace.LicenseInformation license = new Microsoft.Phone.Marketplace.LicenseInformation();

        // Cry Havoc and let loos the dogs of advertising!  Who? Wo? Who let the dogs out? I did.
        private void DogsOfAdvertising()
        {
            acAds.IsEnabled = true;
            acAds.Visibility = System.Windows.Visibility.Visible;
            spTrial.Visibility = System.Windows.Visibility.Visible;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!bLoaded)
            {
                bLoaded = true;

                bool bDevelopment = false;                                          // If the truth can be told so as to be believed,
                if (((license != null) && (license.IsTrial())) || bDevelopment)     //    it will be understood.  
                {                                                                   //              - Terence McKenna
                    // User's license says it is a trial mode app, unleash the dogs of advertising
                    DogsOfAdvertising();
                }
                else if ((license == null) && (!bDevelopment))
                {
                    // User does not even have a license, unleash the dogs of advertising
                    DogsOfAdvertising();
                }
            }

            if (!BitDozer.ViewModel.IsDataLoaded)
            {
                BitDozer.ViewModel.LoadData();

                btnConnect.BorderBrush = BitDozer.Current.Resources["HighlightBrush"] as SolidColorBrush;
                btnDisconnect.BorderBrush = BitDozer.Current.Resources["DimmedBrush"] as SolidColorBrush;
            }
        }

        #region Server Statistics
        private void GetServerStats(bool bForce, bool bSilent)
        {
            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try                                                                 // Remember, remember, the 5th of November
            {                                                                   // Gunpowder Treason and plot. 
                if ((_connected) || (bForce))                                   // I see of no reason why Gunpowder Treason
                {                                                               // Should ever be forgot. 
                    bitnet.GetDifficulty(UpdateDifficulty);                     // Guy Fawkes, Guy Fawkes,    
                    bitnet.GetConnectionCount(UpdateConnectionCount);           // 'Twas his intent.    
                    bitnet.GetBlockCount(UpdateBlockCount);                     // To blow up the King and the Parliament.    
                    bitnet.GetBlockNumber(UpdateBlockNumber);                   // Three score barrels of powder below.    
                    //bitnet.GetHashesPerSec(UpdateHashesPerSec);               // Poor old England to overthrow.    
                    bitnet.GetInfo(UpdateInfo);                                     // What a shame he got caught.
                }
                else if (!bSilent)
                {
                    StopMatrix(LayoutRoot);
                    Notify("Connect to server first.");
                }
            }
            catch (Exception err)
            {
                String szStatus = String.Empty;
                if (_connected)
                {
                    Disconnect();
                    szStatus = Environment.NewLine + "You are disconnected.";

                }
                StopMatrix(LayoutRoot);
                if (!bSilent)
                    Notify("An error occurred connecting to the server." + szStatus);                
            }
        }

        public object UpdateDifficulty(SLBTCPacket packet)
        {
            tbDifficulty.Text = packet.result.ToString();
            return null;
        }

        public object UpdateConnectionCount(SLBTCPacket packet)
        {
            tbConnections.Text = packet.result.ToString();
            return null;
        }

        private object UpdateBlockCount(SLBTCPacket packet)
        {
            tbCurrent.Text = packet.result.ToString();
            return null;
        }

        private object UpdateBlockNumber(SLBTCPacket packet)
        {
            tbBlocks.Text = packet.result.ToString();
            return null;
        }

        private object UpdateHashesPerSec(SLBTCPacket packet)
        {
            //tbHashes.Text = packet.result.ToString();

            return null;
        }

        private object _updateInfo(SLBTCPacket packet)
        {
            string balance = packet.responseObject["result"]["balance"].ToString() + " BTC";

            long version = packet.responseObject["result"]["version"].ToInt();
            tbVersion.Text = FormatVersion(version);

            //bool bTestNet = packet.responseObject["result"]["testnet"].ToString().Equals("true");
            //lTestNet.Text = bTestNet ? "Yes" : "No";

            float fPayTxFee = packet.responseObject["result"]["paytxfee"].ToFloat();
            lPayTxFee.Text = new BitcoinValueFormatter().Convert(((long)fPayTxFee * 10000000), typeof(Brush), null, null) as String;

            return null;
        }

        private object UpdateInfoMsg(SLBTCPacket packet)
        {
            _updateInfo(packet);

            GetAccounts(true);

            return null;
        }

        private object UpdateInfo(SLBTCPacket packet)
        {
            _updateInfo(packet);

            GetAccounts(false);

            return null;
        }

        private void GetAccounts(bool bMessage)
        {
            BTCClosure btcc = UpdateAccountsMsg;
            if (!bMessage)
                btcc = UpdateAccounts;
            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.ListAccounts(btcc, 0);
            }
            catch (Exception err)
            {
                StopMatrix(LayoutRoot);
                Notify("Error: " + err.Message);
            }
        }

        private object _updateAccounts(SLBTCPacket packet)                                                              
        {                                                                                                               
            JObject obj = packet.result as JObject;

            List<AccountDescriptorItem> accounts = new List<AccountDescriptorItem>();
            foreach (KeyValuePair<string, JToken> kvp in obj)
            {
                AccountDescriptorItem adi = new AccountDescriptorItem(kvp);

                if (((CurrentAccount == String.Empty) || (CurrentAccount == "Not Connected")) && (adi.IsDefaultAccount))
                {
                    CurrentAccount = adi.Account;
                    CurrentAccountDescriptor = adi;
                    Dispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            caAccounts.SetAccount(CurrentAccount, currentAddress);

                            XAccountHighlighter lighter = new XAccountHighlighter();
                            caAccounts.tbCurrentAccount.Foreground = lighter.Convert(adi, typeof(Brush), null, null) as Brush;
                        }
                        catch (Exception err)
                        {
                            // Suppress this exception.
                        }
                    });

                    accounts.Add(adi);
                }

                if (!String.IsNullOrEmpty(adi.Account))
                {
                    try
                    {
                        var matches = from a in accounts
                                      where a.Account.Equals(adi.Account)
                                      select a;
                        if (matches.Count() == 0)
                            accounts.Add(adi);
                    }
                    catch (Exception err)
                    {
                        // Suppress this exception
                    }
                }
            }

            AccountsListBox.ItemsSource = accounts;

            return null;
        }

        private object UpdateAccountsMsg(SLBTCPacket packet)
        {
            _updateAccounts(packet);

            GetAddresses(true);

            return null;
        }

        private object UpdateAccounts(SLBTCPacket packet)
        {
            _updateAccounts(packet);

            GetAddresses(false);

            return null;
        }

        // Ported from the utils.cpp from bitcoin source.  
        private String FormatVersion(long nVersion)
        {
            if (nVersion % 100 == 0)
                return String.Format("{0:d}.{1:d}.{2:d}", nVersion / 1000000, (nVersion / 10000) % 100, (nVersion / 100) % 100);
            else
                return String.Format("{0:d}.{1:d}.{2:d}.{3:d}", nVersion / 1000000, (nVersion / 10000) % 100, (nVersion / 100) % 100, nVersion % 100);
        }
        #endregion

        #region Accounts & Addresses
        private void GetAddresses(bool bMessage)
        {
            BTCClosure btcc = UpdateAddressesMsg;
            if (!bMessage)
                btcc = UpdateAddresses;
            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.ListReceivedByAddress(btcc, 0, true);
            }
            catch (Exception err)
            {
                StopMatrix(LayoutRoot);
                Notify("Error: " + err.Message);
            }
        }

        private String AddressOrderName(JToken jt)
        {
            string szResult = String.Empty;
            if (jt["account"] != null)
                szResult += jt["account"].ToString();
            szResult += jt["address"].ToString();
            return szResult;
        }

        private object _updateAddresses(SLBTCPacket packet)  // He had white horses and ladies by the score
        {                                                           // All dressed in satin and waiting by the door
            JArray addresses = packet.result as JArray;     // Oooooooo what a lucky man he was....

            Dictionary<string, string> distinctAddresses = new Dictionary<string, string>();    // Black lace and feathers, they made up his bed
            AddressesListBox.Tag = addresses;       // A gold covered mattress on which he was led... Ooooooo what a lucky man he was...

            Dispatcher.BeginInvoke(() =>
                {
                    try
                    {
                        var orderedAddresses = from a in addresses
                                               orderby AddressOrderName(a)
                                               select a;
                        orderedAddresses.Count();

                        AddressesListBox.Items.Clear();
                        //lbSendFromAccount.Items.Clear();
                        lbRecvAddress.Items.Clear();
                        foreach (JToken token in orderedAddresses)
                        {
                            string s_addr = token["address"].ToString();

                            if (!distinctAddresses.ContainsKey(s_addr))
                            {
                                BuildAddressListItem(AddressesListBox, token, s_addr);
                                //BuildAccountListItem(lbSendFromAccount, token, s_addr);
                                BuildAddressListItem(lbRecvAddress, token, s_addr);
                                distinctAddresses.Add(s_addr, String.Empty);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        // Suppress this exception.
                    }
                });

            return null;
        }

        private object UpdateAddressesMsg(SLBTCPacket packet)
        {
            _updateAddresses(packet);

            LoadAllTransactions(true);

            return null;
        }

        private object UpdateAddresses(SLBTCPacket packet)
        {
            _updateAddresses(packet);

            LoadAllTransactions(false);

            return null;
        }

        private void BuildAddressListItem(ListBox listBox, JToken token, String address)
        {
            ListBoxItem lbi = new ListBoxItem();
            lbi.Tag = token;

            if ((token["label"] != null) && (!token["label"].ToString().Equals(String.Empty)))
            {
                lbi.Content = token["label"];
            }
            else if ((token["account"] != null) && (!String.IsNullOrEmpty(token["account"].ToString())))
            {
                lbi.Content = token["account"] + " (" + address + ")";
            }
            else
            {
                if (defaultAddress.Equals(String.Empty))
                {
                    lbi.Content = "<default (" + address + ")>";

                    defaultAddress = address;
                    currentAddress = address;
                }
                else
                {
                    lbi.Content = address;
                }
            }

            listBox.Items.Add(lbi);
        }

        private void BuildAccountListItem(ListBox listPicker, JToken token, String address)
        {
            ListBoxItem lpi = new ListBoxItem();
            lpi.Tag = token;

            if ((token["label"] != null) && (!token["label"].ToString().Equals(String.Empty)))
            {
                if (address == currentAddress)
                {
                    lpi.Content = token["label"] + " * ";
                }
                else
                    lpi.Content = token["label"];
            }
            else if ((token["account"] != null) && (!token["account"].ToString().Equals(String.Empty)))
            {
                if (address == currentAddress)
                {
                    lpi.Content = token["account"] + " (" + address + ")" + " * ";
                }
                else
                    lpi.Content = token["account"] + " (" + address + ")";
            }
            else
            {
                if (address == currentAddress)
                {
                    lpi.Content = address + " * ";
                }
                else if (address == defaultAddress)
                {
                    lpi.Content = "<default (" + address + ")>";
                }
                else
                {
                    lpi.Content = address;
                }
            }
            listPicker.Items.Add(lpi);
            if (address == currentAddress)
                listPicker.SelectedItem = lpi;
        }
        #endregion

        // At one point consciousness-altering devices like the microscope and telescope were criminalized for exactly the same reasons that psychedelic plants 
        // were banned in later years. They allow us to peer into bits and zones of Chaos. -- Timothy Leary

        // What I feel or believe or experience is my business, and what I do is all our businesses; and reward or punish me according to whether I play 
        // the game well — ethically and rightly — or unethically. = Timothy Leary

        #region Send Bitcoins
        private void btnSendBitCoins_Click(object sender, RoutedEventArgs e)
        {
            if (_connected)
            {
                // cause youre not a child any more

                //ListBoxItem lpi = (ListBoxItem)lbSendFromAccount.SelectedItem;                                    // red white and blue           
                //JToken token = lpi.Tag as JToken;                                                                        // gaze in your looking glass
                //string fromAddress = token["address"].ToString();
                //string fromAccount = token["account"].ToString();
                string fromAddress = currentAddress;
                string toAddress = tbSendToAddress.Text.ToString();
                if (!String.IsNullOrEmpty(fromAddress) && !String.IsNullOrEmpty(toAddress))
                {
                    double dAmount = Convert.ToDouble(tbSendAmount.Text);
                    Int64 amount = (Int64)(dAmount * 10000000);
                    if (amount > 0.0)
                    {
                        string comment = tbComment.Text;
                        string commentTo = String.Empty; // Legacy! Thanks to jgartz for knowing his shit and helping clarify what this is about. :)

                        if (!fromAddress.Equals(toAddress))
                        {
                            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
                            try
                            {
                                // red white and blue

                                //if (fromAddress.Equals(currentAddress))
                                Dispatcher.BeginInvoke(() =>
                                { // the future is on the path
                                    try
                                    {
                                        if (MessageBox.Show("Are you sure you want to send these bitcoins?", "Confirmation Required!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                            bitnet.SendToAddress(CoinsSent, toAddress, amount, comment, commentTo);                                                          // lift up your hearts and make a new start
                                        else
                                        {
                                            tbSendAmount.Text = "00000000.00000000";
                                            MessageBox.Show("Payment cancelled.");
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        // Suppress this exception.
                                    }
                                });
                                //else                                                                                                                      // come lead us away from here
                                //    bitnet.SendFrom(CoinsSent, fromAccount, toAddress, amount, 1, comment, commentTo);                                                      // oh lead us away
                            }
                            catch
                            {
                                StopMatrix(LayoutRoot);
                                Notify("Error sending bitcoins!  Please ensure you have enough bitcoins in your wallet to send!");
                            }
                        }
                        else
                            Notify("You can't send bitcoins from and to the same account.");                                      // - Styx, "Suite Madame Blue"
                    }
                    else
                        Notify("You must specify a non-zero amount to send.");
                }
                else
                    Notify("Send from and send to addresses may not be blank.");
            }
            else
                Notify("Please connect to the server first.");
        }

        private object CoinsSent(SLBTCPacket packet)            
        {
            LoadAllTransactions(false);             // You see it really doesnt matter
            StopMatrix(LayoutRoot);           // When you're buried in disguise

            if ((packet != null) && (packet.result != null))
                Notify("Bitcoins sent! Tansaction:" + Environment.NewLine + packet.result.ToString());   // by the dark glass on your eyes            
            else
                Notify("Bitcoins sent.  Please refresh for transaction data.");

            return null;                     // though your flesh has crystalized
        }                                                   // Still ... you turn me on.
        #endregion

        #region Receive Bitcoins
        protected void btnRecvBitcoins_Click(object sender, RoutedEventArgs e)
        {
            if (_connected)
            {
                if ((lbRecvAddress.SelectedValue != null) && (((ListBoxItem)lbRecvAddress.SelectedValue).Tag != null))
                {
                    try
                    {
                        StringBuilder sbMessage = new StringBuilder();
                        sbMessage.Append(tbRecvName.Text + " requests you send " + tbRecvAmount.Text + " BTC to address " + ((JToken)((ListBoxItem)lbRecvAddress.SelectedValue).Tag)["address"] + " - BitDozer for Windows Phone");
                        if (!SMSHelper.SendMessage(tbRecvNumber.Text, sbMessage.ToString()))
                        {
                            Notify("Error occurred sending text message. :(  Sorry for party rocking. :)");
                        }
                    }
                    catch (Exception err)
                    {
                        Notify("An error occurred requesting the bitcoins. :(");
                    }
                }
                else
                {
                    Notify("Please select an address to receive the bitcoins.");
                }
            }
            else
            {
                Notify("Please connect to the server first.");
            }
        }
        #endregion

        #region All Transactions
        private void LoadAllTransactions(bool bMessage)
        {
            BTCClosure btcc = TransactionsReturnedMsg;
            if (!bMessage)
                btcc = TransactionsReturned;

            if (bMessage)
                InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.ListTransactions(btcc, "*", 100);
                //bitnet.ListTransactions(TransactionsReturned, CurrentAccount, 0);
            }
            catch
            {
                if (bMessage)
                    StopMatrix(LayoutRoot);
            }
        }

        private object _transactionsReturned(SLBTCPacket packet)
        {
            JArray txns = packet.result as JArray;

            List<Bitcoin> lTxns = new List<Bitcoin>();
            foreach (JToken token in txns)
            {
                Bitcoin btc = new Bitcoin(token);
                lTxns.Add(btc);
            }

            var ordered = from btc in lTxns
                          orderby btc.TxDateTime descending
                          select btc;

            AllListBox.ItemsSource = ordered;

            StopMatrix(LayoutRoot);

            return null;
        }

        private object TransactionsReturnedMsg(SLBTCPacket packet)
        {
            _transactionsReturned(packet);

            LoadReceivedBitcoins(true);

            return null;
        }

        private object TransactionsReturned(SLBTCPacket packet)
        {
            _transactionsReturned(packet);

            LoadReceivedBitcoins(false);

            return null;
        }
        #endregion

        // My advice to myself and to everyone else, particularly young people, is to turn on, tune in and drop out. By drop out, 
        // I mean to detach yourself from involvement in secular, external social games. But the dropping out has to occur internally 
        // before it can occur externally. I'm not telling kids just to quit school; I'm not telling people to quit their jobs. That 
        // is an inevitable development of the process of turning on and tuning in. - Timothy Leary

        #region Received Bitcoins
        public void LoadReceivedBitcoins(bool bMessage)
        {
            BTCClosure btcc = ReceivedBitcoinsMsg;
            if (!bMessage)
                btcc = ReceivedBitcoins;

            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.ListReceivedByAddress(btcc, 0, false);
            }
            catch (Exception err)
            {
                StopMatrix(LayoutRoot);
                Notify("Error: " + err.Message);
            }
        }

        public object _receivedBitcoins(SLBTCPacket packet)
        {
            JArray recvd = packet.result as JArray;

            List<Bitcoin> lBtcs = new List<Bitcoin>();
            foreach (JToken token in recvd)
            {
                Bitcoin btc = new Bitcoin(token);
                lBtcs.Add(btc);
            }

            ReceivedListBox.ItemsSource = lBtcs.OrderByDescending(btc => btc.Confirmations);
            ReceivedListBox.DataContext = lBtcs.OrderByDescending(btc => btc.Confirmations); 

            StopMatrix(LayoutRoot);

            return null;
        }

        private object ReceivedBitcoinsMsg(SLBTCPacket packet)
        {
            _receivedBitcoins(packet);

            LoadSentBitcoins(true);

            return null;
        }

        private object ReceivedBitcoins(SLBTCPacket packet)
        {
            _receivedBitcoins(packet);

            LoadSentBitcoins(false);

            return null;
        }

        protected void GetBitcoinInfo(Bitcoin btc)
        {
            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.GetTransaction((packet) =>
                {
                    JObject joResult = packet.result as JObject;
                    btc.TxnData = joResult.ToString();

                    return null;
                }, btc.Address);
            }
            catch (Exception err)
            {
                StopMatrix(LayoutRoot);
                Notify("Error: " + err.Message);
            }
        }
        #endregion

        #region SentBitcoins
        public void LoadSentBitcoins(bool bMessage)
        {
            BTCClosure btcc = SentBitcoinsMsg;
            if (!bMessage)
                btcc = SentBitcoins;

            InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
            try
            {
                bitnet.ListTransactions(btcc, CurrentAccount.Equals("Default Account") ? "*" : CurrentAccount, 100);
            }
            catch (Exception err)
            {
                StopMatrix(LayoutRoot);
                Notify("Error: " + err.Message);
            }
        }

        public object _sentBitcoins(SLBTCPacket packet)
        {
            JArray sent = packet.result as JArray;

            List<Bitcoin> lBtcs = new List<Bitcoin>();
            foreach (JToken token in sent)
            {
                if ((token["category"] != null) && (token["category"].ToString().Equals("send")))
                {
                    Bitcoin btc = new Bitcoin(token);
                    lBtcs.Add(btc);
                }
            }            

            SentListBox.ItemsSource = lBtcs.OrderByDescending(btc => btc.TxDateTime);

            StopMatrix(LayoutRoot);

            return null;
        }

        public object SentBitcoinsMsg(SLBTCPacket packet)
        {
            _sentBitcoins(packet);

            FinalizeConnect();

            return null;
        }

        public object SentBitcoins(SLBTCPacket packet)
        {
            _sentBitcoins(packet);

            return null;
        }

        protected void FinalizeConnect()
        {
            pvtBitDozer.Height = BitDozer.Current.RootVisual.RenderSize.Height - 32 - ApplicationBar.DefaultSize; // adjust the pivot height to account for the ad at the top.
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            StopMatrix(LayoutRoot);
            Notify("Connected!");
        }

        public void Notify(String szNotify)   // Right before your eyes, we pull laughter from the skies
        {                                       // And he laughs until he cries, then he dies, then he dies
            Dispatcher.BeginInvoke(() =>    // Come inside, the show's about to start -- 
            {                       // GUARANTEED TO BLOW YOUR HEAD APART!
                try
                {
                    MessageBox.Show(szNotify);    // You gotta see the show! 
                }
                catch (Exception err)
                {
                    // Suppress this exception.
                }
            });                     // Its a dynamo! 
        }                                   // You GOTTA SEE THE SHOW! IT'S ROCK AND ROLL! OOOOOOOOOOOOOH!
        #endregion

        private void btnDonate_Click(object sender, RoutedEventArgs e)
        {
            tbSendToAddress.Text = btnDonate.Content.ToString();                        // - Emerson, Lake & Palmer, Karn Evil 9 
            pvtBitDozer.SelectedItem = piSend;
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)                                 // Soon the gypsy queen in a glaze of vasoline will perform on guillotine, what a scene, what a scene
        {                                                                                                   // Next upon the stand, will you please extend a hand to Alexander's Ragtime Band! Dixieland Dixieland!
            btnConnect.BorderBrush = BitDozer.Current.Resources["DimmedBrush"] as SolidColorBrush;      // Roll up.  Roll up.  Roll up.  See the show!
            btnDisconnect.BorderBrush = BitDozer.Current.Resources["HighlightBrush"] as SolidColorBrush;    // Performing on a stool, we've a sight to make you drool...

            if (InitializeBitnet(tbUserName.Text, pbPassword.Password))
            {
                InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);                     // Seven Virgins and a mule! 

                try
                {
                    bitnet.GetBalance(UpdateBalance, null, 0);
                    bitnet.GetDifficulty(UpdateDifficulty);                                                     // Keep it cool! Keep it cool! 
                    bitnet.GetConnectionCount(UpdateConnectionCount);                                       // We'd like it to be known that 
                    bitnet.GetBlockCount(UpdateBlockCount);                                                     // the exhibits that were shown 
                    bitnet.GetBlockNumber(UpdateBlockNumber);                                               // were exclusively our own.  
                    bitnet.GetHashesPerSec(UpdateHashesPerSec);                                                 // All our own.
                    bitnet.GetInfo(UpdateInfoMsg);                                                          // All our own.                                                                    
                    caAccounts.SetAccount(CurrentAccount, currentAddress);
                    _connected = true;                                                                      // Come and see the show! Come and see the show!
                }
                catch (Exception err)
                {
                    Disconnect();
                    StopMatrix(LayoutRoot);
                    Notify("An error occurred while connecting to server.");
                }
            }
            else
            {
                btnDisconnect.BorderBrush = BitDozer.Current.Resources["DimmedBrush"] as SolidColorBrush;      
                btnConnect.BorderBrush = BitDozer.Current.Resources["HighlightBrush"] as SolidColorBrush;    
            }
        }

        private void Disconnect()
        {
            btnConnect.BorderBrush = BitDozer.Current.Resources["HighlightBrush"] as SolidColorBrush;
            btnDisconnect.BorderBrush = BitDozer.Current.Resources["DimmedBrush"] as SolidColorBrush;

            ApplicationBar.IsVisible = false;
            ApplicationBar.IsMenuEnabled = false;
            pvtBitDozer.Height = BitDozer.Current.RootVisual.RenderSize.Height - 32 + ApplicationBar.DefaultSize; // adjust the pivot height to account for the ad at the top and the disappearance of the application bar!.

            if (_connected)
            {
                _connected = false;
                bitnet.Credentials = null;
                pbPassword.Password = String.Empty;
                caAccounts.SetAccount(null);
            }
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            bool bWasConnected = _connected;
            Disconnect();

            if (bWasConnected)
            {
                Notify("Disconnected.");
            }
            else
            {
                Notify("Connect to server first.");
            }
        }

        private void iSacredHeart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_connected)
                ApplicationBar.IsVisible = false;
            BitDozer.Current.RootVisual = new SpanishInquisition();
        }

        private void iDedications_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_connected)
                ApplicationBar.IsVisible = false;

            Dedications dedications = new Dedications();
            InitializeMatrix(true, false, dedications.LayoutRoot, dedications.LayoutRoot_MouseLeftButtonUp);
            try
            {                
                StartMatrix();
                BitDozer.Current.RootVisual = dedications;
            }
            catch (Exception err)
            {
                StopMatrix(dedications.LayoutRoot);
                if (_connected)
                    ApplicationBar.IsVisible = true;
                Notify("Error: " + err.Message);
            }
        }

        private void iGeckoFawkes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((BitDozer)BitDozer.Current).WhoIsTheWalrus = "geckofawkes";
            ((BitDozer)BitDozer.Current).SplashReward();            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (_connected)
            {
                ApplicationBar.IsVisible = false;
                BitDozer.Current.RootVisual = new NewAddress(bitnet, CurrentAccount);
            }
            else
            {
                Notify("Connect to the server first.");
            }
        }

        private void setAccount_Click(object sender, RoutedEventArgs e)
        {
            if (_connected)
            {
                if (sender is MenuItem)
                    CurrentAccount = ((MenuItem)sender).Tag as String;
                else
                    CurrentAccount = ((Button)sender).Tag as String;

                InitializeMatrix(false, true, LayoutRoot, overlay_MouseLeftButtonDown);
                try
                {
                    if (CurrentAccount == "Default Account")
                        bitnet.GetBalance(UpdateBalanceMsg, null, 0);
                    else
                        bitnet.GetBalance(UpdateBalanceMsg, CurrentAccount, 0);

                    GetServerStats(false, false);
                }
                catch (Exception err)
                {
                    StopMatrix(LayoutRoot);
                    Notify("Error: " + err.Message);
                }
            }
            else
            {
                Notify("Connect to the server first.");
            }
        }

        private object _updateBalance(SLBTCPacket packet)
        {
            string balance = packet.result.ToString();
            tbWalletBalance.Text = "    " + balance + " BTC";
            return balance;
        }

        private object UpdateBalanceMsg(SLBTCPacket packet)
        {
            //var balance = _updateBalance(packet);
            var balance = packet.result.ToString();
            caAccounts.SetAccount(CurrentAccount, currentAddress);
            Notify("Now using account [" + CurrentAccount + "]." + Environment.NewLine + "Current Balance: " + balance + " BTC");
            return null;
        }

        private object UpdateBalance(SLBTCPacket packet)
        {
            string balance = packet.result.ToString();
            tbWalletBalance.Text = "    " + balance + " BTC";
            return null;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            if (_connected)
            {
                ApplicationBar.IsVisible = false;
                BitDozer.Current.RootVisual = new NewAccount(bitnet, CurrentAccount);
            }
            else
            {
                Notify("Connect to the server first.");
            }
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            if (_connected)
            {
                GetServerStats(false, true);
            }
            else
            {
                Notify("Connec to the server first.");
            }
        }

        private void SetCurrAccount_Click(object sender, RoutedEventArgs e)
        {
            if (_connected)
            {
                if (MessageBox.Show("Do you want to set this as the current account?", "Set Current Account", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    setAccount_Click(sender, e);
                }
            }
            else
            {
                Notify("Connect to the server first.");
            }
        }

        private void AddressesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (ListBoxItem lbi in e.RemovedItems)
            //{
            //    lbi.Foreground = BitDozer.Current.Resources["AddressesListBrush"] as SolidColorBrush;
            //}
            //foreach (ListBoxItem lbi in e.AddedItems)
            //{
            //    lbi.Foreground = BitDozer.Current.Resources["AddressesHighlighter"] as SolidColorBrush;
            //}
        }

        private void iGadgetGirl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            InitializeMatrix(true, false, LayoutRoot, gadgetgirl_MouseLeftButtonDown);
            StartMatrix();
        }

        private void InitializeMatrix(bool bGG, bool bMatrix, Panel pContainer, MouseButtonEventHandler buttonHandler)
        {
            if ((_matrixTextEffect == null) || (overlay == null))
            {
                // Yeah, yeah, in the ideal world this would be refactored so as not to duplicate teh codez, but ya know what, I don't fuckin' care. :)
                if (_matrixTextEffect == null)
                {
                    _matrixTextEffect = new MatrixTextEffect.MatrixTextEffect();
                    _matrixTextEffect.Height = this.ActualHeight;
                    _matrixTextEffect.Width = this.ActualWidth;
                    _matrixTextEffect.SetValue(Canvas.ZIndexProperty, 10);
                    _matrixTextEffect.gg = bGG;
                    _matrixTextEffect.matrix = bMatrix;
                }

                if (overlay == null)
                {
                    overlay = new Canvas();
                    overlay.Height = this.ActualHeight;
                    overlay.Width = this.ActualWidth;
                    overlay.Background = new SolidColorBrush(Colors.Transparent);
                    overlay.SetValue(Canvas.ZIndexProperty, 20);
                    overlay.MouseLeftButtonDown += buttonHandler;
                }

                if (pContainer != null)
                {
                    pContainer.Children.Insert(1, _matrixTextEffect);
                    pContainer.Children.Insert(1, overlay);
                }
                else
                {
                    LayoutRoot.Children.Insert(1, _matrixTextEffect);
                    LayoutRoot.Children.Insert(1, overlay);
                }

                StartMatrix();
            }
        }

        void overlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StopMatrix(LayoutRoot);
        }

        void gadgetgirl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StopMatrix(LayoutRoot);
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.devicearmors.com", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private bool _matrixStarted = false;
        public void StartMatrix()
        {
            _matrixTextEffect.Start();
            _matrixStarted = true;
        }

        public void StopMatrix(Panel pContainer)
        {
            if ((_matrixStarted) && (_matrixTextEffect != null))
            {
                _matrixTextEffect.Stop();
                if (pContainer != null)
                {                    
                    pContainer.Children.RemoveAt(1);
                    pContainer.Children.RemoveAt(1);
                }
                else
                {
                    LayoutRoot.Children.RemoveAt(1);
                    LayoutRoot.Children.RemoveAt(1);
                }
                _matrixTextEffect = null;
                overlay = null;
                _matrixStarted = false;
            }
        }

        private void geckofawkes_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.geckofawkes.com", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void linkBitDozer_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.tagelmoust.com/bitdozer", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void linkTagelmoust_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.tagelmoust.com", UriKind.Absolute);
            webBrowserTask.Show();
        }
    }

    public static class HelperExtensions
    {
        public static float ToFloat(this JToken token)          // Do you want to be the player?
        {
            float result = 0.0f;
            try
            {
                result = (float)Convert.ToDouble(token.ToString());
            }
            catch
            {
                result = 0.0f;
            }
            return result;
        }

        public static Int64 ToInt(this JToken token)                // Do you want to be the string?
        {
            Int64 result = 0;
            try
            {
                result = Convert.ToInt64((float)token);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static Int64 ToBTCInt(this JToken token)                // Do you want to be the string?
        {
            Int64 result = 0;
            try
            {
                result = Convert.ToInt64((float)token * 100000000);
            }
            catch
            {
                result = 0;
            }
            return result;
        }
    }

    // We always have urged people: Don't take LSD unless you are very well prepared, unless you are specifically prepared to go out of your mind. 
    // Don't take it unless you have someone that's very experienced with you to guide you through it. And don't take it unless you are ready to have 
    // your perspective on yourself and your life radically changed, because you're gonna be a different person, and you should be ready to face this 
    // possibility. - Timothy Leary         http://www.youtube.com/watch?v=O4-lgo-MeAw

    public class BitcoinValueFormatter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (parameter != null)   
            //{   
            //string formatterString = parameter.ToString();   
            //if (!string.IsNullOrEmpty(formatterString))  
            //{
            Int64 iValue = (Int64)value;
            String szValue = String.Empty;

            if (parameter != null)
                szValue += parameter.ToString() + ": ";
            Int64 left = Math.Abs(iValue) / 100000000;
            Int64 right = Math.Abs(iValue) % 100000000;

            string szIndicator = (iValue < 0) ? "-" : String.Empty;
            szValue += szIndicator + String.Format(culture, "{0:0}.{1:00000000} BTC", left, right);

            return szValue;
            //}  
            //}  
            //return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (object)System.Convert.ToInt64(value);
        }
        #endregion
    }

    public class XAccountHighlighter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                AccountDescriptorItem adi = (AccountDescriptorItem)value;

                Brush bAccountBrush = null;

                String currentAccount = ((BitDozer)BitDozer.Current).TheMainPage.CurrentAccount;
                if ((adi.IsDefaultAccount) && (adi.Account == currentAccount))
                {
                    LinearGradientBrush lgb = new LinearGradientBrush();

                    GradientStopCollection gsc = new GradientStopCollection();

                    SolidColorBrush curbrush = ((BitDozer)BitDozer.Current).Resources["CurrentAccountBrush"] as SolidColorBrush;
                    SolidColorBrush defbrush = ((BitDozer)BitDozer.Current).Resources["DefaultAccountBrush"] as SolidColorBrush;

                    GradientStop gs1 = new GradientStop();
                    gs1.Offset = 0.25;
                    gs1.Color = defbrush.Color;
                    gsc.Add(gs1);

                    GradientStop gs2 = new GradientStop();
                    gs2.Offset = 1.0;
                    gs2.Color = curbrush.Color;
                    gsc.Add(gs2);

                    lgb.GradientStops = gsc;

                    bAccountBrush = lgb;
                }
                else if (adi.IsDefaultAccount)
                    bAccountBrush = ((BitDozer)BitDozer.Current).Resources["DefaultAccountBrush"] as SolidColorBrush;
                else if (adi.Account == currentAccount)
                    bAccountBrush = ((BitDozer)BitDozer.Current).Resources["CurrentAccountBrush"] as SolidColorBrush;
                else
                    bAccountBrush = ((BitDozer)BitDozer.Current).Resources["AccountBrush"] as SolidColorBrush;

                return bAccountBrush;
            }
            else
                return ((BitDozer)BitDozer.Current).Resources["StandardBrush"] as SolidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Brush binding is one-way only.");
        }
        #endregion
    }

    public class AmountValueConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush bBrush = ((BitDozer)BitDozer.Current).Resources["AmountHighlighter"] as SolidColorBrush;

            if (value != null) 
            {
                double fValue = 0.0f;
                try
                {
                    fValue = System.Convert.ToDouble((string)value.ToString());
                }
                catch
                {
                    return bBrush;
                }

                if (fValue < 0)
                {
                    bBrush = ((BitDozer)BitDozer.Current).Resources["SentAmountHighlighter"] as SolidColorBrush;
                }
            }

            return bBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Brush binding is one-way only.");
        }
        #endregion
    }

    public class TxnValueConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String szTxnPart = String.Empty;

            if (value != null)
            {
                szTxnPart = value.ToString();
                int ilen = szTxnPart.Length;
                string szTest = parameter.ToString().Trim().ToLower();
                if (szTest == "right")
                {
                    szTxnPart = szTxnPart.Substring(0, ilen / 2);
                }
                else
                {
                    szTxnPart = szTxnPart.Substring(ilen / 2);
                }
            }

            return szTxnPart;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("TxnLeft binding is one-way only.");
        }
        #endregion
    }

    public class AccountDescriptorItem
    {
        private String _account;
        public String Account
        {
            get { return String.IsNullOrEmpty(_account) ? "Default Account" : _account; }
            set { _account = value; }
        }

        private Int64 _balance;
        public Int64 Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public AccountDescriptorItem(KeyValuePair<string, JToken> kvp)
        {
            Account = kvp.Key;
            Balance = Convert.ToInt64(kvp.Value.ToFloat() * 100000000);
        }

        public bool IsDefaultAccount
        {
            get { return String.IsNullOrEmpty(_account); }
            private set { }
        }
    }

    // Still.... You turn me on.
    public static class SMSHelper
    {
        public static bool SendMessage(String toNumber, String msg)
        {
            try
            {
                SmsComposeTask textMsg = new SmsComposeTask();
                textMsg.To = toNumber;
                textMsg.Body = msg;
                textMsg.Show();

                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}

// Quick Recap for those who have been asleep.
// 
// Circa 180 A.D. - Irenaeus, bishop of Lyons, wrote a treatise in five volumes titled On the Detection and Overthrow of the So-Called Gnosis
// 1480 - The Tribunal of the Holy Office of the Inquisition (Spanish: Tribunal del Santo Oficio de la Inquisición), commonly known as the Spanish Inquisition (Inquisición española), was a tribunal established by Catholic 
//        Monarchs Ferdinand II of Aragon and Isabella I of Castile.
// November 5, 1605 - Guy Fawkes discovered with enough gunpowder to blow up parliament. http://en.wikipedia.org/wiki/Guy_Fawkes
// December 16, 1773 - Boston Tea Party. We kinda got sick of giving away our money to a bunch of corrupt mutherfuckers.
// July 4, 1776 - Signing of the US Declaration of Independence and the start of throwing off the chains of repressive government.
// 1 September 1939 - World War II begins and the Nazis and Fascists who favor repressing and killing their own citizens take 5 years, 
//                    and countless lives to defeat.
// April 19, 1943 - Albert Hofmann discovers LSD, aka (6aR,9R)- N,N- diethyl- 7-methyl- 4,6,6a,7,8,9- hexahydroindolo- [4,3-fg] quinoline- 9-carboxamide.
// January 14, 1967 - Timothy Leary, "the most dangerous man in the world", teaches us all Tune In, Turn On, Drop Out.
// October 24, 1968 - LSD was made illegal in the United States by Richard "Tricky Dick" Nixon.
// April 15, 1989 - Tianamen Square Protests begin.
// June 4, 1989 - The Chinese government brutally slaughters hundreds if not thousands of their own people who just want to be free. 
// June 5, 1989 - Tianamen Square "Tank Man" protestor peacefully protests.  While not known for sure, it is claimed he was executed 14 days later.
// September 11, 2001 - Do you really need me to tell you this was 9/11?  Crazy fuckers blow up the WTC in NYC and the Pentagon.
// October 26, 2001 - The American public is so scared out of their minds they relinquish the majority of their freedoms for a panacea of being made safer.
// September 19, 2008 - The economic house of cards begins to fall, and the powers that be bail out the fat cats, the corrupted power brokers, and the banks
//                      while the average worker drone gets screwed over once again with no lube.
// June 13, 2009 - Iranians start peaceful revolution only to be violently repressed and killed by their oh-so-glorious supreme leader who 
//                 during Friday prayers broadcast live on television on 26 June Ayatollah Ahmad Khatami is reported to have said: 
//                 "Anybody who fights against the Islamic system or the leader of Islamic society, fight him until complete destruction," 
//                 and called for the execution of leading demonstrators as they are "people who wage war against God".
//                 ^^^ =)  And God needs *you* to kill people for what reason? Really??!? Didn't the *ONE* God tell us to NOT KILL each other? 
// May 24, 2009 - Satoshi Nakamoto releases Bitcoin on the world.  Genesis block comment: "The Times 03/Jan/2009 Chancellor on brink of second bailout for banks".
// 18 December 2010 - Start of the Arab Spring with the revolt and overthowing of the governments in Tunisia and 17 other Middle East countries.
// June 17, 2011 - Found Bitcoin and started to realize its implications and importance.
// September 17, 2011 - Occupy Wall Street starts
// October 15, 2011 - Worldwide Occupy Protests
// October 25, 2011 - The system decides to try and crush Occupy by raiding the Occupy Oakland encampment.  Subsequently, all remaining Occupy Encampents were systemically shutdown leaving Occupy Protesters no way to peacefully protest.  Wonder where this will go? </sarcasm>
