// Modified 2/8/2012 Gecko Fawkes, Dallas, Texas
// Modified 6/21/2011 Gecko Fawkes, Dallas, Texas
//
// ORIGINAL NOTES:
// COPYRIGHT 2011 Konstantin Ineshin, Irkutsk, Russia.
// If you like this project please donate BTC 18TdCC4TwGN7PHyuRAm8XV88gcCmAHqGNs
// ---- END ---
// New Notes!
// Now Supports Silverlight and Windows Phone 7!
// ---- END ---
// In order to allow this to build for use by non-dispatched technologies, 
// there is now a precompiler definition "DISPATCHER" which needs to be set in
// any SL/WP7 project and *NOT* in non-SL/WPF projects.
// ---- END ---

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows;
using System.Windows.Threading;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitnet.Client
{
    public delegate void ErrorDelegate(string errMsg);

    public class BitnetClient : IBitnetClient
    {
        public BitnetClient()
        {
        }

        public BitnetClient(string a_sUri)
        {
            Url = new Uri(a_sUri);
        }

        public Uri Url;

        public ICredentials Credentials;

        public Dispatcher Dispatcher;

        public ErrorDelegate _errs;

        public void InvokeMethod(string a_sMethod, BTCClosure b_closure, BTCClosure b_callback, params object[] a_params)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Credentials = Credentials;
            //webRequest.ContentType = "application/json-rpc";
            webRequest.UserAgent = "bitcoin-json-rpc";
            webRequest.ContentType = "application/json";
            webRequest.Headers["Keep-Alive"] = "1";
            webRequest.Method = "POST";
            

            JObject joe = new JObject();
            joe["jsonrpc"] = "1.0";
            joe["id"] = "1";
            joe["method"] = a_sMethod;

            if (a_params != null)
            {
                if (a_params.Length > 0)
                {
                    JArray props = new JArray();
                    foreach (var p in a_params)
                    {
                        props.Add(p);
                    }
                    joe.Add(new JProperty("params", props));
                }
            }

            SLBTCPacket slbtcp = new SLBTCPacket() { request = webRequest, requestObject = joe, closure = b_closure, callback = b_callback };            
            webRequest.BeginGetRequestStream(BuildInvokedRequest, slbtcp);
        }

        public void BuildInvokedRequest(IAsyncResult result)
        {
            if ((result != null) && (result.AsyncState != null) && (result.AsyncState is SLBTCPacket))
            {
                SLBTCPacket slbtcp = result.AsyncState as SLBTCPacket;
                try
                {
                    string s = JsonConvert.SerializeObject(slbtcp.requestObject);
                    // serialize json for the request
                    byte[] byteArray = Encoding.UTF8.GetBytes(s);

                    Stream requestStream = slbtcp.request.EndGetRequestStream(result);
                    requestStream.Write(byteArray, 0, byteArray.Length);
                    requestStream.Flush();
                    requestStream.Close();

                    slbtcp.request.Headers["ContentLength"] = byteArray.Length.ToString();

                    slbtcp.request.BeginGetResponse(ProcessResponse, slbtcp);                                        
                }
                catch
                {
                    if (Dispatcher != null)
                    {
#if DISPATCHER
                        Dispatcher.BeginInvoke(() =>
                        {
                            try
                            {
                                if (_errs == null)
                                {
                                    MessageBox.Show("Error Invoking Request.");
                                }
                                else
                                    _errs("Error Invoking Server Request.");
                            }
                            catch (Exception)
                            {
                                // Suppress this exception!
                            }
                        });
#else
                    throw new Exception("Error Invoking Request");
#endif
                    }
                    else
                    {
                        if (_errs != null)
                            _errs("Error Invoking Server Request");
                        else
                            throw new Exception("Error Invoking Server Request");
                    }
                }
            }
            else
            {
                if (Dispatcher != null)
                {
#if DISPATCHER
                    Dispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            if (_errs != null)
                                _errs("Error Invoking Server Request.");
                            else
                                MessageBox.Show("Error Invoking Request.");
                        }
                        catch (Exception err)
                        {
                            // Suppress this exception!
                        }
                    });
#else
                    throw new Exception("Error Invoking Request");
#endif
                }
                else
                {
                    if (_errs != null)
                        _errs("Error Invoking Server Request");
                    else
                        throw new Exception("Error Invoking Server Request");
                }
            }
        }

        public void ProcessResponse(IAsyncResult result)
        {
            SLBTCPacket slbtcp = result.AsyncState as SLBTCPacket;

            try
            {
                WebResponse webResponse = slbtcp.request.EndGetResponse(result);

                using (Stream str = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(str))
                    {
                        JObject joe = JsonConvert.DeserializeObject<JObject>(sr.ReadToEnd());
                        slbtcp.responseObject = joe;
                        if (slbtcp.closure != null)
                            slbtcp.closure(slbtcp);

                        if ((Dispatcher != null) && (slbtcp.callback != null))
                        {
#if DISPATCHER
                            Dispatcher.BeginInvoke(() =>
                                {
                                    try
                                    {
                                        slbtcp.callback(slbtcp);
                                    }
                                    catch (Exception err)
                                    {
                                        // Suppress this exception!
                                    }
                                });
#else
                            slbtcp.callback(slbtcp);
#endif
                        } 
                        else if (slbtcp.callback != null)
                        {
                            slbtcp.callback(slbtcp);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                if (Dispatcher != null)
                {
#if DISPATCHER

                    Dispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            if (_errs != null)
                                _errs(err.Message);
                            else
                                MessageBox.Show(err.Message);
                        }
                        catch (Exception err2)
                        {
                            // Suppress this exception!
                        }
                    });
#else
                    throw err;
#endif
                }
                else
                {
                    throw err;
                }
            }
        }

        #region BackupWallet
        public void BackupWallet(BTCClosure b_callback, string a_destination)
        {
            InvokeMethod("backupwallet", null, b_callback, a_destination);
        }
        #endregion

        #region GetAccount
        public void GetAccount(BTCClosure b_callback, string s_address)
        {
            InvokeMethod("getaccount", FinishGetAccount, b_callback, s_address);
        }
        public object FinishGetAccount(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();

            return packet.result;
        }
        #endregion

        #region GetAccountAddress
        public void GetAccountAddress(BTCClosure b_callback, string a_account)
        {
            InvokeMethod("getaccountaddress", FinishAccountAddress, b_callback, a_account);
        }
        public object FinishAccountAddress(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region GetAddressesByAccount
        public void GetAddressesByAccount(BTCClosure b_callback, string a_account)
        {
            InvokeMethod("getaddressesbyaccount", FinishGetAddressesByAccount, b_callback, a_account);
        }
        public object FinishGetAddressesByAccount(SLBTCPacket packet)
        {
            IEnumerable<string> response = from o in packet.responseObject["result"]
                                           select o.ToString();
            packet.result = response;
            return packet.result;
        }
        #endregion

        #region GetBalance
        public void GetBalance(BTCClosure b_callback, string a_account = null, int a_minconf = 1)
        {
            if (a_account == null)
            {
                InvokeMethod("getbalance", FinishGetBalance, b_callback);
            }
            else
            {
                InvokeMethod("getbalance", FinishGetBalance, b_callback, a_account, a_minconf);
            }
        }
        public object FinishGetBalance(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetBlockByCount
        public void GetBlockByCount(BTCClosure b_callback, int a_height)
        {
            InvokeMethod("getblockbycount", FinishGetBlockByCount, b_callback, a_height);
        }
        public object FinishGetBlockByCount(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region GetBlockCount
        public void GetBlockCount(BTCClosure b_callback)
        {
            InvokeMethod("getblockcount", FinishGetBlockCount, b_callback);
        }
        public object FinishGetBlockCount(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetBlockNumber
        public void GetBlockNumber(BTCClosure b_callback)
        {
            InvokeMethod("getblocknumber", FinishGetBlockNumber, b_callback);
        }
        public object FinishGetBlockNumber(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetConnectionCount
        public void GetConnectionCount(BTCClosure b_callback)
        {
            InvokeMethod("getconnectioncount", FinishGetConnectionCount, b_callback);
        }
        public object FinishGetConnectionCount(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetDifficulty
        public void GetDifficulty(BTCClosure b_callback)
        {
            InvokeMethod("getdifficulty", FinishGetDifficulty, b_callback);
        }
        public object FinishGetDifficulty(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion;

        #region GetGenerate
        public void GetGenerate(BTCClosure b_callback)
        {
            InvokeMethod("getgenerate", FinishGetGenerate, b_callback);
        }
        public object FinishGetGenerate(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetHashesPerSec
        public void GetHashesPerSec(BTCClosure b_callback)
        {
            InvokeMethod("gethashespersec", FinishGetHashesPerSec, b_callback);
        }
        public object FinishGetHashesPerSec(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetInfo
        public void GetInfo(BTCClosure b_callback)
        {
            InvokeMethod("getinfo", FinishGetInfo, b_callback);
        }
        public object FinishGetInfo(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"] as JObject;
            return packet.result;
        }
        #endregion

        #region GetNewAddress
        public void GetNewAddress(BTCClosure b_callback, string a_account)
        {
            InvokeMethod("getnewaddress", FinishGetNewAddress, b_callback, a_account);
        }
        public object FinishGetNewAddress(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region GetReceivedByAccount
        public void GetReceivedByAccount(BTCClosure b_callback, string a_account, int a_minconf = 1)
        {
            InvokeMethod("getreceivedbyaccount", FinishGetReceivedByAccount, b_callback, a_account, a_minconf);
        }
        public object FinishGetReceivedByAccount(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetReceivedByAddress
        public void GetReceivedByAddress(BTCClosure b_callback, string a_address, int a_minconf = 1)
        {
            InvokeMethod("getreceivedbyaddress", FinishGetReceivedByAddress, b_callback, a_address, a_minconf);
        }
        public object FinishGetReceivedByAddress(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region GetTransaction
        public void GetTransaction(BTCClosure b_callback, string a_txid)
        {
            InvokeMethod("gettransaction", FinishGetTransaction, b_callback, a_txid);
        }
        public object FinishGetTransaction(SLBTCPacket packet)
        {
            JObject result = packet.responseObject["result"] as JObject;
            packet.result = result;
            return packet.result;
        }
        #endregion

        #region GetWork
        public void GetWork(BTCClosure b_callback)
        {
            InvokeMethod("getwork", FinishGetWork, b_callback);
        }
        public void GetWork(BTCClosure b_callback, string a_data)
        {
            InvokeMethod("getwork", FinishGetWork, b_callback, a_data);
        }
        public object FinishGetWork(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region Help
        public void Help(BTCClosure b_callback, string a_command = "")
        {
            InvokeMethod("help", FinishHelp, b_callback, a_command);
        }
        public object FinishHelp(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region ListAccounts
        public void ListAccounts(BTCClosure b_callback, int a_minconf = 1)
        {
            InvokeMethod("listaccounts", FinishListAccounts, b_callback, a_minconf);
        }
        public object FinishListAccounts(SLBTCPacket packet)
        {
            JObject result = packet.responseObject["result"] as JObject;
            packet.result = result;
            return packet.result;
        }
        #endregion

        #region ListReceivedByAccount
        public void ListReceivedByAccount(BTCClosure b_callback, int a_minconf = 1, bool a_includeEmpty = false)
        {
            InvokeMethod("listreceivedbyaccount", FinishListReceivedByAccount, b_callback, a_minconf, a_includeEmpty);
        }
        public object FinishListReceivedByAccount(SLBTCPacket packet)
        {
            JArray result = packet.responseObject["result"] as JArray;
            packet.result = result;
            return packet.result;
        }
        #endregion

        #region ListReceivedByAddress
        public void ListReceivedByAddress(BTCClosure b_callback, int a_minconf = 1, bool a_includeEmpty = false)
        {
            InvokeMethod("listreceivedbyaddress", FinishListReceivedByAddress, b_callback, a_minconf, a_includeEmpty);
        }
        public object FinishListReceivedByAddress(SLBTCPacket packet)
        {
            JArray result = packet.responseObject["result"] as JArray;
            packet.result = result;
            return packet.result;
        }
        #endregion

        #region ListTransactions
        public void ListTransactions(BTCClosure b_callback, string a_account, int a_count = 10)
        {
            InvokeMethod("listtransactions", FinishListTransactions, b_callback, a_account, a_count);
        }
        public object FinishListTransactions(SLBTCPacket packet)
        {
            JArray result = packet.responseObject["result"] as JArray;
            packet.result = result;
            return packet.result;
        }
        #endregion

        #region Move
        public void Move(BTCClosure b_callback, string a_fromAccount, string a_toAccount, Int64 a_amount, int a_minconf = 1, string a_comment = "")
        {
            InvokeMethod("move", FinishMove, b_callback, a_fromAccount, a_toAccount, a_amount, a_minconf, a_comment);
        }
        public object FinishMove(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"];
            return packet.result;
        }
        #endregion

        #region SendFrom
        public void SendFrom(BTCClosure b_callback, string a_fromAccount, string a_toAddress, Int64 a_amount, int a_minconf = 1, string a_comment = "", string a_commentTo = "")
        {
            InvokeMethod("sendfrom", FinishSendFrom, b_callback, a_fromAccount, a_toAddress, (float)((double)a_amount / 10000000.0), a_minconf, a_comment, a_commentTo);
        }
        public object FinishSendFrom(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region SendToAddress
        public void SendToAddress(BTCClosure b_callback, string a_address, Int64 a_amount, string a_comment, string a_commentTo)
        {
            InvokeMethod("sendtoaddress", FinishSendToAddress, b_callback, a_address, (float)((double)a_amount / 10000000.0), a_comment, a_commentTo);
        }
        public object FinishSendToAddress(SLBTCPacket packet)
        {
            packet.result = packet.responseObject["result"].ToString();
            return packet.result;
        }
        #endregion

        #region SetAccount
        public void SetAccount(BTCClosure b_callback, string a_address, string a_account)
        {
            InvokeMethod("setaccount", null, b_callback, a_address, a_account);
        }
        #endregion

        #region SetGenerate
        public void SetGenerate(BTCClosure b_callback, bool a_generate, int a_genproclimit = 1)
        {
            InvokeMethod("setgenerate", null, b_callback, a_generate, a_genproclimit);
        }
        #endregion

        #region Stop
        public void Stop(BTCClosure b_callback)
        {
            InvokeMethod("stop", null, b_callback);
        }
        #endregion

        #region ValidateAddress
        public void ValidateAddress(BTCClosure b_callback, string a_address)
        {
            InvokeMethod("validateaddress", FinishValidateAddress, b_callback, a_address);
        }
        public object FinishValidateAddress(SLBTCPacket packet)
        {
            JObject result = packet.responseObject["result"] as JObject;
            packet.result = result;
            return packet.result;
        }
        #endregion
    }

    public class SLBTCPacket
    {
        public HttpWebRequest request = null; // the http web request 
        public JObject requestObject = null; // object sent in to a request
        public JObject responseObject = null;  // object received from a response
        public BTCClosure closure = null;  // BTC Closure Method that executes to finish processing a request
        public BTCClosure callback = null; // BTC Closure Method to execute call when the request is done
        public object result = null; // the finished result of the request
    }

    public delegate object BTCClosure(SLBTCPacket packet);

}
