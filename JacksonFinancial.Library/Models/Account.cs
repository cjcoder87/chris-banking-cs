using System;
using System.Collections;
using System.Collections.Generic;
namespace Library.Models
{
  public class Account
  {
    public string AccountName { get; set; }
    public string UserName { get; set; }
    public decimal AccountBalance { get; set; }
    public int Id { get; set; }

    //  public Account(int id, string username, string accountname, decimal number){

    //  }

    public override string ToString()
    {
      return "Account ID: " + Id + "\r\n" + "Name: " + UserName + "\r\n" + "Account Type: " + AccountName + "\r\n" + "Total Balance: $" + AccountBalance + "\r\n";
    }

  }
}
