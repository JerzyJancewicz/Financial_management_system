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
            get 
            {
                if (FinancialPersonRoles.Contains(SpecializationType.ACCOUNTANT)) 
                {
                    return _specialization;
                }
                return null;
            }
            set 
            {
                if (FinancialPersonRoles.Contains(SpecializationType.ACCOUNTANT))
                {
                    _specialization = value;
                }
                else 
                {
                    _specialization = null;
                }
            }
        }

        public string? Rank
        {
            get 
            {
                if (FinancialPersonRoles.Contains(SpecializationType.ACCOUNTANT))
                {
                    return _rank;
                }
                return null;
            }
            set
            {
                if (FinancialPersonRoles.Contains(SpecializationType.ACCOUNTANT))
                {
                    _rank = value;
                }
                else
                {
                    _rank = null;
                }
            }
        }

        public int NumberOfReports
        {
            get 
            {
                if (FinancialPersonRoles.Contains(SpecializationType.FINANCIAL_SPECIALIST))
                {
                    return _numberOfReports;
                }
                return 0;
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                if (FinancialPersonRoles.Contains(SpecializationType.FINANCIAL_SPECIALIST))
                {
                    _numberOfReports = value;
                }
                else 
                {
                    _numberOfReports = 0;
                }
            }
        }

        public int NumberOfPredictions
        {
            get
            {
                if (FinancialPersonRoles.Contains(SpecializationType.FINANCIAL_SPECIALIST))
                {
                    return _numberOfPredictions;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                if (FinancialPersonRoles.Contains(SpecializationType.FINANCIAL_SPECIALIST))
                {
                    _numberOfPredictions = value;
                }
                else
                {
                    _numberOfPredictions = 0;
                }
            }
        }

        public ICollection<BankOperation> BankOperations { get; set; } = new HashSet<BankOperation>();
        public ICollection<FinancialReport> FinancialReports { get; set; } = new HashSet<FinancialReport>();
        public ICollection<FinancialPrediction> FinancialPredictions { get; set; } = new HashSet<FinancialPrediction>();
    }
}
