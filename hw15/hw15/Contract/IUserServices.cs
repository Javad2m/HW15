using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface IUserServices
{
    public string GenerateVerificationCode(int userId, string fullName);
    public bool ValidateVerificationCode(int userId, string fullName, int verificationCode);

}
