// Project Prolog
// Name: Andrew Todd
// CS3260 Section 001
// Project: Lab_03
// Date: 09/11/22
// Purpose: This Project is the first stages of a banking program. The program impements
// the basic functionality and error checking of a bank account structure, as well as Console
// based input for testing and usabuility.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------

namespace Banking_Program
{
    ///<summary>
    /// This class is the program entrypoint and is responsible for handling input and output for the program.
    ///</summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Account _account = new();

            Console.WriteLine("Making new account...");
            do
            {
                Console.WriteLine("Enter the name that will appear on the account.");
                if (_account.SetName(Console.ReadLine()))
                    break;
                else
                    Console.WriteLine("Invalid name entered. Enter a non empty name.\n");

            }while(true);

            do
            {
                Console.WriteLine("Enter the address that will appear on the account");
                if (_account.SetAddress(Console.ReadLine()))
                    break;
                else
                    Console.WriteLine("Invalid address entered. Enter a non empty address.\n");

            } while (true);

            do
            {
                Console.WriteLine("Enter the Account Number that will appear on the account");

                if (ulong.TryParse(Console.ReadLine(), out ulong num))
                {
                    if (_account.SetAccountNumber(num))
                        break;
                    else
                        Console.WriteLine("Invalid Account Number entered. Enter valid non-negative whole number.\n");
                }
                else
                    Console.WriteLine("Input could not be parsed to ulong. Enter a valid non-negative whole number.\n");

            } while (true);

            do
            {
                Console.WriteLine("Enter the Balance for the new account");

                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    if (_account.SetBalance(num))
                        break;
                    else
                        Console.WriteLine($"Invalid Balance entered. Enter a non-negative balance greater than new account minimum {_account.InitialBalance}\n");
                }
                else
                    Console.WriteLine("Input could not be parsed to double. Enter a valid non-negative number.\n");

            } while (true);

        State: do
            {
                Console.WriteLine("Enter the state for the new account. Default is new (entering null will result in new)");

                string? input = Console.ReadLine();

                if (uint.TryParse(input, out uint num))
                {
                    switch (num)
                    {
                        case 0:
                            Console.WriteLine("Setting state to new");
                            _account.SetState(Account.AccountState._new);
                            break;
                        case 1:
                            Console.WriteLine("Setting state to active");
                            _account.SetState(Account.AccountState._active);
                            break;
                        case 2:
                            Console.WriteLine("Setting state to underAudit");
                            _account.SetState(Account.AccountState._underAudit);
                            break;
                        case 3:
                            Console.WriteLine("Setting state to frozen");
                            _account.SetState(Account.AccountState._frozen);
                            break;
                        case 4:
                            Console.WriteLine("Setting state to closed");
                            _account.SetState(Account.AccountState._closed);
                            break;
                        default:
                            Console.WriteLine("Unrecognized Input. Try again.");
                            goto State;
                    }
                    Console.WriteLine();
                    break;
                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Null or Empty string entered. Setting Account State to defualt new state");
                    _account.SetState();
                    Console.WriteLine();
                    break;
                }

            } while (true);
            
            Console.WriteLine("New Account:");
            Console.WriteLine($"Name associated with account: {_account.GetName()}");
            Console.WriteLine($"Address associated with account: {_account.GetAddress()}");
            Console.WriteLine($"Account Number: {_account.GetAccountNumber()}");
            Console.WriteLine($"Account Balance: {_account.GetBalance()}");
            Console.WriteLine($"Account State: {_account.GetState().ToString()}");
            Console.WriteLine();

            do
            {
                Console.WriteLine("Deposit new funds.\nHow much would you like to deposit?");
                try
                {
                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        _account.PayInFunds(num);
                    }
                    else
                        Console.WriteLine("Unable to parse input.");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"Exception in PayInFunds thrown. ({exception.Message})");
                }

                Console.WriteLine($"Account Balance: {_account.GetBalance()}");
                Console.WriteLine();

                Console.WriteLine("Stop entering deposits? (y/n)");
                Console.WriteLine();
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine();
                    break;
                }
            } while (true);

            do
            {
                Console.WriteLine("Withdraw funds.\nHow much would you like to withdraw?");
                try
                {
                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        if (!_account.WithdrawFunds(num))
                            Console.WriteLine("Withdraw amount exceeds account balance. Withdraw operation canceled.");
                    }
                    else
                        Console.WriteLine("Unable to parse input.");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"Exception in WithdrawFunds thrown. ({exception.Message})");
                }

                Console.WriteLine($"Account Balance: {_account.GetBalance()}");
                Console.WriteLine();

                Console.WriteLine("Stop entering withdrawals? (y/n)");
                Console.WriteLine();
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine();
                    break;
                }
            } while (true);
        }
    }
}