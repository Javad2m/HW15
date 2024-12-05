using hw15.Contract;
using hw15.Dtos;
using hw15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Services;

public class TransactionServices : ITransactionServices
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICardRepository _cardRepository;

    public TransactionServices()
    {
        _cardRepository = new CardRepository();
        _transactionRepository = new TransactionRepository();
    }

    public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
    {
        var list = _transactionRepository.GetListOfTransactions(cardNumber);
        return list;
    }

    public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
    {
        var isSuccess = false;

        if (amount == 0)
            return "The transfer amount must be greater than 0";

        if (sourceCardNumber.Length < 16 || sourceCardNumber.Length > 16)
            return "sourceCardNumber is not valid";

        if (destinationCardNumber.Length < 16 || destinationCardNumber.Length > 16)
            return "sourceCardNumber is not valid";

        if (!_cardRepository.CardIsActive(sourceCardNumber))
            return "sourceCardNumber is not valid";

        if (!_cardRepository.CardIsActive(destinationCardNumber))
            return "destinationCardNumber is not valid";


        var sourceCard = _cardRepository.GetCardBy(sourceCardNumber);
        var destinationCard = _cardRepository.GetCardBy(destinationCardNumber);

        if (sourceCard.Balance < amount)
            return "your card doesn't have enough balance for this transaction";

        if (amount > 1000 && sourceCard.Balance< amount *(float)1.015)
            return "your card doesn't have enough balance for this transaction";

        if (amount < 1000 && sourceCard.Balance < amount * (float)1.005)
            return "your card doesn't have enough balance for this transaction";

        if ((_transactionRepository.DailyWithdrawal(sourceCardNumber) + amount) > 250)
            return "Your daily transfer limit is full";

        try
        {

            _cardRepository.Deposit(destinationCardNumber, amount);
            if (amount > 1000)
            {
                amount = amount * (float)1.015;
            }
            else if (amount < 1000)
            {
                amount = amount * (float)1.005;
            }
            _cardRepository.Withdraw(sourceCardNumber, amount);

            isSuccess = true;

        }
        catch (Exception e)
        {
            isSuccess = false;
            return "Transfer money failed";
        }
        finally
        {
            var transaction = new Entity.Transaction()
            {
                SourceCardId = sourceCard.Id,
                DestinationCardId = destinationCard.Id,
                Amount = amount,
                ActionAt = DateTime.Now,
                IsSuccess = isSuccess
            };

            _transactionRepository.Add(transaction);
        }
        return "The money transfer operation was successful";
    }
}
