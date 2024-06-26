﻿
using FMS_backend.Models.TransactionF;

namespace FMS_backend.Models.UserF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;

        public HashSet<Transaction> Transactions { get; set; }
    }
} 
