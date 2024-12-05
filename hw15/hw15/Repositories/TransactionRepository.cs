using hw15.Contract;
using hw15.DAL;
using hw15.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _appDbContext;

    public TransactionRepository()
    {
        _appDbContext = new AppDbContext();
    }

    public void Add(Entity.Transaction transaction)
    {
        _appDbContext.Transactions.Add(transaction);
        _appDbContext.SaveChanges();
    }

    public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
    {
        return _appDbContext.Transactions
            .Where(x => x.SourceCard.CardNumber == cardNumber || x.DestinationCard.CardNumber == cardNumber)
            .Select(x => new GetTransactionsDto
            {
                SourceCardNumber = x.SourceCard.CardNumber,
                DestinationsCardNumber = x.DestinationCard.CardNumber,
                ActionAt = x.ActionAt,
                Amount = x.Amount,
                IsSuccess = x.IsSuccess,
            }).ToList();
    }

    public float DailyWithdrawal(string cardNumber)
    {
        var amountOfTransactions = _appDbContext.Transactions
            .Where(x => x.ActionAt.Date == DateTime.Now.Date && x.SourceCard.CardNumber == cardNumber)
            .Sum(x => x.Amount);

        return amountOfTransactions;
    }
}
