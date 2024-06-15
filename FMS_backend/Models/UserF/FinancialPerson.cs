using FMS_backend.Models.BankOperationF;
using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.UserF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS_backend.Models.UserF
{
    public class FinancialPerson : User, IAccountant, IFinancialSpecialist
    {
        private string? _specialization = string.Empty;
        private string? _rank = string.Empty;
        private int _numberOfReports;
        private int _numberOfPredictions;
        public List<SpecializationType> FinancialPersonRoles { get; set; } = new List<SpecializationType>();

        public string? Specialization
        {
            get => _specialization;
            set => _specialization = value ?? throw new ArgumentNullException();
        }

        public string? Rank
        {
            get => _rank;
            set => _rank = value ?? throw new ArgumentNullException();
        }

        public int NumberOfReports
        {
            get => _numberOfReports;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _numberOfReports = value;
            }
        }

        public int NumberOfPredictions
        {
            get => _numberOfPredictions;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _numberOfPredictions = value;
            }
        }

        public ICollection<BankOperation> BankOperations { get; set; } = new HashSet<BankOperation>();
        public ICollection<FinancialReport> FinancialReports { get; set; } = new HashSet<FinancialReport>();
        public ICollection<FinancialPrediction> FinancialPredictions { get; set; } = new HashSet<FinancialPrediction>();
    }
}
