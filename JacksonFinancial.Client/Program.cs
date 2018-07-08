using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Library.Models;
using System.Threading;
using System.Data.SqlClient;

namespace JacksonFinancial.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      DefaultMenu();

    }
    public static Program R = new Program();//lets methods run other methods code

    public List<Account> accounts = new List<Account>();// allows me to call list from another method


    public static void DefaultMenu()
    {
      string choice;
      bool exit = false;
      do
      {
        Console.WriteLine("1-Display Accounts|2-Deposit|3-Withdraw|4-Transfer|5-Create Account|6-Quit");
        choice = Console.ReadLine();


        switch (choice)
        {
          case "1":
            //List Accounts
            Console.WriteLine("Display Accounts");
            DisplayLists();

            break;
          case "2":
            //Deposit
            Console.WriteLine("Deposit Funds");
            DisplayLists();
            Deposit();

            break;
          case "3":
            //Withdraw
            Console.WriteLine("Withdraw Funds");
            DisplayLists();
            Withdraw();

            break;
          case "4":
            //Transfer
            Console.WriteLine("Transfer Funds");
            DisplayLists();
            Transfer();
            break;
          case "5":
            //Create Account
            Console.WriteLine("Create Account");
            CreateAccount();

            break;
          case "6":
            //Exit Program
            exit = true;
            Console.WriteLine("Progam Ended");
            break;
        }
      } while (!exit);

      Console.ReadLine();
    }

    public string balance;
    public decimal number;

    public static Random rnd = new Random();
    public static uint IdMaker = (uint)rnd.Next(1, 1000);
    public static uint ticker = (uint)DateTime.Now.Ticks;
    public static uint AccountIndexer = ticker + IdMaker;

    public static void CreateAccount()
    {
      Console.WriteLine("Enter name:");
      string username = Console.ReadLine();
      // alternative is to generate own student number
      Console.WriteLine("Enter Account Type:");
      string accountname = Console.ReadLine();
      // perform validations then create Student 
      Console.WriteLine("Enter initial deposit:");
      R.balance = Console.ReadLine();
      // check result of TryParse
      decimal.TryParse(R.balance, out R.number);
      R.accounts.Add(new Account { Id = AccountIndexer, UserName = username, AccountName = accountname, AccountBalance = R.number });
      AccountIndexer += IdMaker;
      Console.WriteLine("\r\n" + "You now have " + R.accounts.Count + " accounts listed below." + "\r\n");
      R.accounts.ForEach(Console.WriteLine);
      // List<Account> r = List1[0];  

    }

    public static void DisplayLists()
    {


      if (R.accounts.Count > 0)
      {

        for (int i = 0; i < R.accounts.Count; i++)
        {
          Console.WriteLine(R.accounts[i].ToString());
        }

      }
      else
      {
        Console.WriteLine("Nothing to see here");

      }
      // Console.WriteLine(R.ToString());
      // R.ToString();


    }
    string chooseAccount;
    string chooseAccount2;
    string deposit;
    public static void Deposit()
    {
      Console.WriteLine("Which Account Would You Like to Deposit To(Choose ID)");
      R.chooseAccount = Console.ReadLine();
      decimal.TryParse(R.chooseAccount, out decimal number3);
      Console.WriteLine("How much do you want to Deposit(Choose ID)");
      R.deposit = Console.ReadLine();
      decimal.TryParse(R.deposit, out decimal number2);
      // decimal.TryParse(R.balance, out decimal number2);

      var list = R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance += number2).ToList();
      // Console.WriteLine("Your account balance now is " + R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance).ToList());
      DisplayLists();

    }
    public static void Withdraw()
    {
      Console.WriteLine("Which Account Would You Like to Withdraw From(Choose ID)");
      R.chooseAccount = Console.ReadLine();
      decimal.TryParse(R.chooseAccount, out decimal number3);
      Console.WriteLine("How much do you want to Withdraw(Choose ID)");
      R.deposit = Console.ReadLine();
      decimal.TryParse(R.deposit, out decimal number2);
      // decimal.TryParse(R.balance, out decimal number2);

      var list = R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance -= number2).ToList();
      // Console.WriteLine("Your account balance now is " + R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance).ToList());
      DisplayLists();

    }

    public static void Transfer()
    {
      Console.WriteLine("Which Account Would You Like to Transfer From(Choose ID)");
      R.chooseAccount = Console.ReadLine();
      decimal.TryParse(R.chooseAccount, out decimal number3);
      Console.WriteLine("Which Account Would You Like to Transfer To(Choose ID)");
      R.chooseAccount2 = Console.ReadLine();
      decimal.TryParse(R.chooseAccount2, out decimal number4);
      Console.WriteLine("How much do you want to Transfer");
      R.deposit = Console.ReadLine();
      decimal.TryParse(R.deposit, out decimal number2);
      // decimal.TryParse(R.balance, out decimal number2);

      var list = R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance -= number2).ToList();
      var list2 = R.accounts.Where(a => a.Id == number4).Select(b => b.AccountBalance += number2).ToList();
      // Console.WriteLine("Your account balance now is " + R.accounts.Where(a => a.Id == number3).Select(b => b.AccountBalance).ToList());
      DisplayLists();

    }


  }
}



// This code will check if the number typed is actually a real number

// public static void CheckRealNumber(){
//   decimal num1;
//   string s;
//   bool res = true;
//   Console.WriteLine("Type a Number");

//   do
//   {
//     s = Console.ReadLine();
//     res = decimal.TryParse(s, out num1);
//     switch (res)
//     {
//       case true:
//         Console.WriteLine("You typed number " + num1);
//         break;
//       case false:
//         Console.WriteLine("This was not a number. Please Type a Number");
//         break;
//     }
//   } while (!res);
// }