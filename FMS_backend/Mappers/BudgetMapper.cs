using AutoMapper;
using FMS_backend.Models.TransactionF;
using FMS_backend.DTOs;
using System.Linq;

public class BudgetMapper : Profile
{
    public BudgetMapper()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(src => src.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(src => src.Surname, opt => opt.MapFrom(src => src.User.Surname))
            .ForMember(src => src.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
            .ForMember(src => src.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(src => src.NickName, opt => opt.MapFrom(src => src.User.NickName));

        CreateMap<TransactionDto, Transaction>()
            .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.Name))
            .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForPath(dest => dest.User.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
            .ForPath(dest => dest.User.NickName, opt => opt.MapFrom(src => src.NickName));


        CreateMap<BankAccount, BankAccountDto>();

        CreateMap<Budget, BudgetDto>()
            .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions.Select(t => new TransactionDto
            {
                OperationDate = t.OperationDate,
                Amount = t.Amount,
                TransactionTypes = t.TransactionType,
                StatusTypes = t.StatusType
            })))
            .ForMember(dest => dest.BankAccounts, opt => opt.MapFrom(src => src.BankAccounts.Select(ba => new BankAccountDto
            {
                BankName = ba.BankName,
                Balance = ba.Balance,
                AccountNumber = ba.AccountNumber
            })));     
    }
}
