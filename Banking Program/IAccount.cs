using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Program
{
    ///<summary>
    /// This interface defines the basic public functionality of any "Account" type
    ///</summary>
    internal interface IAccount
    {
        /// <summary>
        /// Purpose: Sets the "name" member of impelementing class
        /// </summary>
        /// <param name="inName">any valid non-empty string</param>
        /// <returns>true if underlying "name" member was set, false otherwise.</returns>
        bool SetName(string inName);
        /// <summary>
        /// Purpose: The return the "name" member of the impementing class
        /// </summary>
        /// <returns>string "name" member of implementing class</returns>
        string GetName();
        /// <summary>
        /// Purpose: Sets the "address" member of impelementing class
        /// </summary>
        /// <param name="inName">any valid non-empty string</param>
        /// <returns>true if underlying "address" member was set, false otherwise.</returns>
        bool SetAddress(string inAddress);
        /// <summary>
        /// Purpose: The return the "address" member of the impementing class
        /// </summary>
        /// <returns>string "address" member of implementing class</returns>
        string GetAddress();
        /// <summary>
        /// Purpose: Sets the "Account Number" member of impelementing class
        /// </summary>
        /// <param name="inAccountNumber">any valid ulong</param>
        /// <returns>true if underlying "Account Number" member was set, false otherwise.</returns>
        bool SetAccountNumber(ulong inAccountNumber);
        /// <summary>
        /// Purpose: The return the "Account Number" member of the impementing class
        /// </summary>
        /// <returns>ulong "Account Number" member of implementing class</returns>
        ulong GetAccountNumber();
        /// <summary>
        /// Purpose: This is the deposit method for the account. Will add the "amount" param to the implementing class's balance
        /// </summary>
        /// <param name="amount">any valid non-negative double</param>
        void PayInFunds(double amount);
        /// <summary>
        /// Purpose: This is the withdraw method for the account. Will subtract the "amount" param from the implementing class's balance
        /// </summary>
        /// <param name="amount">any valid non-negative double</param>
        /// <returns>true if "amount" was subtracted, false if the amount would bring the balance negative. In such case the operation is ignored.</returns>
        bool WithdrawFunds(double amount);
        /// <summary>
        /// Purpose: Will set the balance of the implementing class to "inBalance".
        /// </summary>
        /// <param name="inBalance">any valid non-negative double</param>
        /// <returns>true if balance was set to "inBalance". false if the "inBalance" is negative. In such case the operation is ignored.</returns>
        bool SetBalance(double inBallance);
        /// <summary>
        /// Purpose: The return the "balance" member of the impementing class
        /// </summary>
        /// <returns>double "balance" member of implementing class</returns>
        double GetBalance();
        /// <summary>
        /// Purpose: Set the "state" member of implementing class.
        /// </summary>
        /// <param name="state">any of the names defined in "Account.AccountState" enumeration.</param>
        void SetState(Account.AccountState state = Account.AccountState._new);
        /// <summary>
        /// Purpose: Get the "state" member of implementing class.
        /// </summary>
        /// <returns><cref>Account.AccountState</cref></returns>
        Account.AccountState GetState();
    }
}
