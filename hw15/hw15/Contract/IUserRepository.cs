using hw15.Dtos;
using hw15.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Contract;

public interface IUserRepository
{
    public User Get(int id);
    public void GenerateAndSaveVerificationCode(int userId, string fullName, int verificationCode, DateTime expirationTime);
    public VerificationDto GetVerificationDataById(int userId);
    public void SaveVerificationData(VerificationDto verificationDto);



}
