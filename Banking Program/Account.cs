using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Program
{
    ///<summary>
    /// This class is an implementation of the concept of a bank account. 
    /// It implements the public functionality defined by the <cref>IAccount</cref> interface for end-user interactivity.
    ///</summary>
    internal class Account: IAccount
    {
        #region MEMBERS
        private string name = "";
        private string address = "";
        private ulong accountNumber = 0;
        private double balance = 0.0;
        private const double initialBalance = 100.0;
        private AccountState state;
        #endregion

        #region PUBLIC_ENUMS
        public enum AccountState
        {
            _new,
            _active,
            _underAudit,
            _frozen,
            _closed
        }
        #endregion

        #region IACCOUNT_METHODS
        public bool SetName(string inName)
        {
            if (inName == null || inName == "")
                return false;

            name = inName;
            return true;
        }

        public string GetName()
        {
            return name;
        }
        public bool SetAddress(string inAddress)
        {
            if (inAddress == null || inAddress == "")
                return false;

            address = inAddress;
            return true;
        }
        public string GetAddress()
        {
            return address;
        }
        public bool SetAccountNumber(ulong inAccountNumber)
        {
            this.accountNumber = inAccountNumber;
            return true;
        }
        public ulong GetAccountNumber()
        {
            return this.accountNumber;
        }
        public void PayInFunds(double amount)
        {
            if (amount < 0.0)
                throw new ArgumentException($"amount({amount}) is not a positive number. Use the WithdrawFunds method for decreasing the balance");

            balance += amount;
        }
        public bool WithdrawFunds(double amount)
        {
            if(amount < 0.0)
                throw new ArgumentException($"amount({amount}) is not a positive number. Use the PayInFunds method for increasing the balance");

            if ((balance - amount) < 0.0)
                return false;

            balance -= amount;
            return true;
        }
        public bool SetBalance(double inBalance)
        {
            if(inBalance < initialBalance)
                return false;

            balance = inBalance;
            return true;
        }
        public double GetBalance()
        {
            return balance;
        }
        public void SetState(AccountState state = AccountState._new)
        {
            this.state = state;
        }
        public AccountState GetState()
        {
            return state;
        }
        #endregion

        #region GET_SET
        public double InitialBalance { get; }
        #endregion
    }
}
