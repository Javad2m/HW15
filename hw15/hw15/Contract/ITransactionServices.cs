using hw15.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface ITransactionServices
{
    public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount);
    public List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
}
