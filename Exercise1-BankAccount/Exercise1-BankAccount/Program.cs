using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1_BankAccount {
    public abstract class BankAccount {
       // Fields
        private String accNum;
        private double balance;

        // Properties
        public String AccountNumber {
            get {
                return accNum;
            }
        }

        public double Balance {
            get {
                return balance;
            }
            set {
                balance = value;
            }
        }

        // Constructor
        public BankAccount(string accNum) {
            Balance = 0;
            this.accNum = accNum;
        }

        // Abstract methods
        public abstract void MakeDeposit(double amount);
        public abstract void MakeWithdrawal(double amount);
    }

    public class CurrentAccount : BankAccount {
        private double overdraft;
        private AccountTransaction[] transactionHistory;
        private int numTransactions;

        public double Overdraft {
            get {
                return overdraft;
            }
        }

        public AccountTransaction[] TransactionHistory {
            get {
                return transactionHistory;
            }
        }

        public CurrentAccount(String accNum, double overdraft)
            : base(accNum) {
                this.overdraft = overdraft;
                transactionHistory = new AccountTransaction[3];
                numTransactions = 0;
        }

        public override void MakeDeposit(double amount) {
            Balance += amount;
            transactionHistory[numTransactions++] 
                = new AccountTransaction(TransactionType.Deposit, amount);
        }

        public override void MakeWithdrawal(double amount) {
            if (amount > 0) {
                if (amount > (Balance + overdraft)) {
                    throw new ApplicationException("Insufficient Funds");
                }
                else {
                    Balance = Balance - amount;
                    transactionHistory[numTransactions++]
                        = new AccountTransaction(TransactionType.Withdrawal, amount);
                }
            }
            else {
                throw new ArgumentException("Amount must be greater than 0");
            }
        }

        public override String ToString() {
            String output;
            output = "Current Account:\t" + "number:" + AccountNumber +
                " balance: " + Balance;

            output += "\nTransaction history:\n";
            for (int i = 0; i < numTransactions; i++) {
                output += transactionHistory[i].ToString() + "\n";
            }
            return output;
        }
    }

    public enum TransactionType {
        Deposit, Withdrawal
    }

    // an account transaction
    public class AccountTransaction {
        private TransactionType type;	// deposit/withdrawal
        private double amount;			// amount concerned

        // constructor
        public AccountTransaction(TransactionType type, double amount) {
            this.type = type;
            this.amount = amount;
        }

        // return human readable String
        public override String ToString() {
            return "type: " + type + " amount: " + amount;
        }
    }
}
