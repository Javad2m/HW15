using hw15.Entity;
using hw15.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface ICardServices
{
    public Result PasswordIsValid(string cardNumber, string password);
    public float ReciveInventoryInventory(string cardNumber);

    public string ShowName(string cardNumber);

    public Result ChPass(string cardNumber, string oldPass, string newPass);
    public Card Find(string cardNumber);
}
