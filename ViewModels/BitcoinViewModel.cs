// BitDozer.BitcoinViewModel                                                           ....A desperate disease requires a dangerous remedy....
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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitdozer.ViewModels
{
    public class Bitcoin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _address = String.Empty;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }

        private String _account = String.Empty;
        public String Account
        {
            get
            {
                if (!String.IsNullOrEmpty(_account))
                    return _account;
                else
                    return "Default Account";
            }
            set
            {
                if (value != _account)
                {
                    _account = value;
                    NotifyPropertyChanged("Account");
                }
            }
        }

        private String _label = String.Empty;
        public String Label
        {
            get
            {
                return _label;
            }
            set
            {
                if (value != _label)
                {
                    _label = value;
                    NotifyPropertyChanged("Label");
                }
            }
        }

        private Int64 _amount = 0;
        public Int64 Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    NotifyPropertyChanged("Amount");
                }
            }
        }

        private Int64 _confirmations = 0;
        public Int64 Confirmations
        {
            get
            {
                return _confirmations;
            }
            set
            {
                if (value != _confirmations)
                {
                    _confirmations = value;
                    NotifyPropertyChanged("Confirmations");
                }
            }
        }

        //public String Status;
        //public String Date;
        //public String From;
        //public String To;
        //public String Credit;
        //public String Debit;
        //public String TxnFee;
        //public String Net;
        //public String Comment;
        //public String CommentTo;

        private String _category = String.Empty;
        public String Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (value != _category)
                {
                    _category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        private String _txid = String.Empty;
        public String TXID
        {
            get
            {
                return _txid;
            }
            set
            {
                if (value != _txid)
                {
                    _txid = value;
                    NotifyPropertyChanged("TXID");
                }
            }
        }

        private long _time = 0;
        public long Time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value != _time)
                {
                    _time = value;
                }
            }
        }

        public String TxnData;

        public Bitcoin()
        {

        }

        public Bitcoin(JToken token)
            : base()
        {
            this.LoadFromJToken(token);
        }

        public String AmountString
        {
            get
            {
                BitcoinValueFormatter bvf = new BitcoinValueFormatter();
                String szResult = bvf.Convert(Amount, typeof(Brush), null, null) as String;
                return szResult;
            }
            private set { }
        }

        public String TxDate
        {
            get
            {
                return TxDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            private set { }
        }

        public DateTime TxDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Time);
            }
            private set { }
        }

        public void LoadFromJToken(JToken token)
        {
            if (token["address"] != null)
                Address = token["address"].ToString();

            if (token["account"] != null)
                Account = token["account"].ToString();

            if (token["label"] != null)
                Label = token["label"].ToString();

            if (token["amount"] != null)
                Amount = token["amount"].ToBTCInt();

            if (token["confirmations"] != null)
                Confirmations = token["confirmations"].ToInt();

            //if (token["status"] != null)
            //    Status = token["status"].ToString();

            //if (token["date"] != null)
            //    Date = token["date"].ToString();

            //if (token["from"] != null)
            //    From = token["from"].ToString();

            //if (token["to"] != null)
            //    To = token["to"].ToString();

            //if (token["credit"] != null)
            //    Credit = token["credit"].ToString();

            //if (token["debit"] != null)
            //    Debit = token["debit"].ToString();

            //if (token["txnfee"] != null)
            //    TxnFee = token["txnfee"].ToString();

            //if (token["comment"] != null)
            //    Comment = token["comment"].ToString();

            //if (token["commentto"] != null)
            //    CommentTo = token["commentto"].ToString();

            if (token["category"] != null)
                Category = token["category"].ToString();

            if (token["txid"] != null)
                TXID = token["txid"].ToString();

            if (token["time"] != null)
                Time = token["time"].ToInt();
        }
    }
}
