using hw15.Entity;
using hw15.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface ICardRepository
{
    public bool Login(string carnumber, string password);
    public void SetWrongPasswordTry(string cardNumber);
    public int GetWrongPasswordTry(string cardNumber);
    public void ClearWrongPasswordTry(string cardNumber);
    public void Withdraw(string cardNumber, float balance);
    public void Deposit(string cardNumber, float balance);
    public bool CardIsActive(string cardNumber);
    public Card GetCardBy(string cardNumber);

    public float Inventory (string cardNumber);

    public void ChangePassword(string cardNumber,string oldPass,string newPass);
}
