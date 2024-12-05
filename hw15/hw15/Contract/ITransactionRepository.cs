using hw15.DAL;
using hw15.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface ITransactionRepository
{
    List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
    float DailyWithdrawal(string cardNumber);
    void Add(Entity.Transaction transaction);
}
