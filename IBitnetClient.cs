// COPYRIGHT 2011 Konstantin Ineshin, Irkutsk, Russia.
// If you like this project please donate BTC 18TdCC4TwGN7PHyuRAm8XV88gcCmAHqGNs

using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;


namespace Bitnet.Client
{
  interface IBitnetClient
  {
    /// <summary>
    /// Safely copies wallet.dat to destination, which can be a directory or a path with filename.
    /// </summary>
    /// <param name="a_destination"></param>
    void BackupWallet(BTCClosure b_callback, string a_destination);

    /// <summary>
    /// Returns the account associated with the given address.
    /// </summary>
    /// <param name="a_address"></param>
    void GetAccount(BTCClosure b_callback, string a_address);

    /// <summary>
    /// Returns the current bitcoin address for receiving payments to this account.
    /// </summary>
    /// <param name="a_account"></param>
    void  GetAccountAddress(BTCClosure b_callback, string a_account);

    /// <summary>
    /// Returns the list of addresses for the given account.
    /// </summary>
    /// <param name="a_account"></param>
    void GetAddressesByAccount(BTCClosure b_callback, string a_account);

    /// <summary>
    /// If [account] is not specified, returns the server's total available balance.
    /// If [account] is specified, returns the balance in the account.
    /// </summary>
    /// <param name="a_account"></param>
    /// <param name="a_minconf"></param>
    void GetBalance(BTCClosure b_callback, string a_account = "", int a_minconf = 1);

    /// <summary>
    /// Dumps the block existing at specified height. 
    /// </summary>
    /// <param name="a_height"></param>
    void GetBlockByCount(BTCClosure b_callback, int a_height);

    /// <summary>
    /// Returns the number of blocks in the longest block chain.
    /// </summary>
    void GetBlockCount(BTCClosure b_callback);

    /// <summary>
    /// Returns the block number of the latest block in the longest block chain.
    /// </summary>
    void GetBlockNumber(BTCClosure b_callback);

    /// <summary>
    /// Returns the number of connections to other nodes.
    /// </summary>
    void GetConnectionCount(BTCClosure b_callback);

    /// <summary>
    /// Returns the proof-of-work difficulty as a multiple of the minimum difficulty.
    /// </summary>
    void GetDifficulty(BTCClosure b_callback);

    /// <summary>
    /// Returns true or false whether bitcoind is currently generating hashes
    /// </summary>
    void GetGenerate(BTCClosure b_callback);

    /// <summary>
    /// Returns a recent hashes per second performance measurement while generating.
    /// </summary>
    void GetHashesPerSec(BTCClosure b_callback);

    /// <summary>
    /// Returns an object containing various state info.
    /// </summary>
    void GetInfo(BTCClosure b_callback);

    /// <summary>
    /// Returns a new bitcoin address for receiving payments.
    /// If [account] is specified (recommended), it is added to the address book so payments 
    /// received with the address will be credited to [account].
    /// </summary>
    /// <param name="a_account"></param>
    void GetNewAddress(BTCClosure b_callback, string a_account);

    /// <summary>
    /// Returns the total amount received by addresses with accountin 
    /// transactions with at least [minconf] confirmations.
    /// </summary>
    /// <param name="a_account"></param>
    /// <param name="a_minconf"></param>
    void GetReceivedByAccount(BTCClosure b_callback, string a_account, int a_minconf = 1);

    /// <summary>
    /// Returns the total amount received by bitcoinaddressin transactions 
    /// with at least [minconf] confirmations.
    /// </summary>
    /// <param name="a_address"></param>
    /// <param name="a_minconf"></param>
    void GetReceivedByAddress(BTCClosure b_callback, string a_address, int a_minconf = 1);

    /// <summary>
    /// Get detailed information about txid
    /// </summary>
    /// <param name="a_txid"></param>
    void GetTransaction(BTCClosure b_callback, string a_txid);
    
    /// <summary>
    /// Tries to solve the block and returns true if it was successful.
    /// </summary>
    void GetWork(BTCClosure b_callback);

    /// <summary>
    /// Returns formatted hash data to work on
    /// </summary>
    /// <param name="a_data"></param>
    void GetWork(BTCClosure b_callback, string a_data);

    /// <summary>
    /// List commands, or get help for a command.
    /// </summary>
    /// <param name="a_command"></param>
    void Help(BTCClosure b_callback, string a_command = "");

    /// <summary>
    /// Returns Object that has account names as keys, account balances as values.
    /// </summary>
    /// <param name="a_minconf"></param>
    void ListAccounts(BTCClosure b_callback, int a_minconf = 1);

    /// <summary>
    /// Returns an array of objects containing:
    /// </summary>
    /// <param name="a_minconf"></param>
    /// <param name="a_includeEmpty"></param>
    void ListReceivedByAccount(BTCClosure b_callback, int a_minconf = 1, bool a_includeEmpty = false);

    /// <summary>
    /// Returns an array of objects containing:
    /// </summary>
    /// <param name="minconf"></param>
    /// <param name="a_includeEmpty"></param>
    void ListReceivedByAddress(BTCClosure b_callback, int a_minconf = 1, bool a_includeEmpty = false);

    /// <summary>
    /// Returns up to [count] most recent transactions for account account.
    /// </summary>
    /// <param name="account"></param>
    /// <param name="a_count"></param>
    void ListTransactions(BTCClosure b_callback, string a_account, int a_count = 10);

    /// <summary>
    /// Move from one account in your wallet to another.
    /// </summary>
    /// <param name="a_fromAccount"></param>
    /// <param name="a_toAccount"></param>
    /// <param name="a_amount"></param>
    /// <param name="a_minconf"></param>
    /// <param name="a_comment"></param>
    void Move(BTCClosure b_callback, string a_fromAccount, string a_toAccount, Int64 a_amount, int a_minconf = 1, string a_comment = "");

    /// <summary>
    /// Amount is a real and is rounded to the nearest 0.01. Returns the transaction ID if successful.
    /// </summary>
    /// <param name="a_fromAccount"></param>
    /// <param name="a_toAddress"></param>
    /// <param name="a_amount"></param>
    /// <param name="a_minconf"></param>
    /// <param name="a_comment"></param>
    /// <param name="a_commentTo"></param>
    void SendFrom(BTCClosure b_callback, string a_fromAccount, string a_toAddress, Int64 a_amount, int a_minconf = 1, string a_comment = "", string a_commentTo = "");

    /// <summary>
    /// Send coins to address. Returns txid.
    /// </summary>
    /// <param name="a_address"></param>
    /// <param name="a_amount"></param>
    /// <param name="a_comment"></param>
    /// <param name="a_commentTo"></param>
    void SendToAddress(BTCClosure b_callback, string a_address, Int64 a_amount, string a_comment, string a_commentTo);

    /// <summary>
    /// Sets the account associated with the given address.
    /// </summary>
    /// <param name="a_address"></param>
    /// <param name="a_account"></param>
    void SetAccount(BTCClosure b_callback, string a_address, string a_account);

    /// <summary>
    /// Generation is limited to [genproclimit] processors, -1 is unlimited.
    /// </summary>
    /// <param name="a_generate">true or false to turn generation on or off</param>
    /// <param name="a_genproclimit"></param>
    void SetGenerate(BTCClosure b_callback, bool a_generate, int a_genproclimit = 1);

    /// <summary>
    /// Stop bitcoin server.
    /// </summary>
    void Stop(BTCClosure b_callback);

    /// <summary>
    /// Return information about bitcoinaddress.
    /// </summary>
    /// <param name="a_address"></param>
    void ValidateAddress(BTCClosure b_callback, string a_address);
  }
}
