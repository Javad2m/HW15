using hw15.Contract;
using hw15.Entity;
using hw15.Framework;
using hw15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Services;

public class CardServices : ICardServices
{
    ICardRepository _CardRepository;
    public CardServices()
    {
        _CardRepository = new CardRepository();
    }

    public Result PasswordIsValid(string cardNumber, string password)
    {
        var tryCount = _CardRepository.GetWrongPasswordTry(cardNumber);

        if (tryCount > 3)
            return new Result() { IsSuccess = false, Message = "You have entered the wrong password 3 times. Your account is permanently blocked" };

        var passwordIsValid = _CardRepository.Login(cardNumber, password);

        if (passwordIsValid == false)
        {
            _CardRepository.SetWrongPasswordTry(cardNumber);
            return new Result() { IsSuccess = false, Message = "Card number Or Password Is Wrong" };
        }
        else
        {
            _CardRepository.ClearWrongPasswordTry(cardNumber);
            return new Result() { IsSuccess = true, Message = "Welcome" };
        }
    }

    public float ReciveInventoryInventory(string cardNumber)
    {
        var balance = _CardRepository.Inventory(cardNumber);
        return balance;
    }

    public string ShowName(string cardNumber)
    {
        var card = _CardRepository.GetCardBy(cardNumber);
        return card.HolderName;
    }

    public Result ChPass(string cardNumber, string oldPass, string newPass)
    {
        if (newPass.Length < 4)
        {
            return new Result() { IsSuccess = false, Message = "Password Most be =+4 Char" };

        }


        var card = _CardRepository.GetCardBy(cardNumber);
        if (card.Password == oldPass)
        {
            _CardRepository.ChangePassword(cardNumber, oldPass, newPass);
            return new Result() { IsSuccess = true, Message = "Password Is Changed" };
        }
        else
        {
            return new Result() { IsSuccess = false, Message = "Password Is Changed Wrong!" };

        }
    }

    public Card Find(string cardNumber)
    {
        var card = _CardRepository.GetCardBy(cardNumber);
        return card;
    }
}
