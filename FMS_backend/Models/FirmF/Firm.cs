using System;
using System.Collections.Generic;
using FMS_backend.Models.BankOperationF;

namespace FMS_backend.Models.FirmF
{
    public class Firm : IClient, IDeliverer
    {
        public int Id { get; set; }

        private string _name = string.Empty;
        private string _address = string.Empty;
        private string _nip = string.Empty;
        private string _phoneNumber = string.Empty;
        private DateTime? _dateOfRegistration;
        private double? _discount;
        private DateTime? _dateOfDelivery;

        public string Name
        {
            get => _name;
            set => _name = value == null ? throw new ArgumentNullException() : value;
        }

        public string Address
        {
            get => _address;
            set => _address = value == null ? throw new ArgumentNullException() : value;
        }

        public string NIP
        {
            get => _nip;
            set => _nip = value == null ? throw new ArgumentNullException() : value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value == null ? throw new ArgumentNullException() : value;
        }

        public TypeOfCustomer Type { get; set; }

        public DateTime? DateOfRegistration
        {
            get => Type == TypeOfCustomer.CLIENT ? _dateOfRegistration : null;
            set
            {
                if (Type == TypeOfCustomer.CLIENT)
                {
                    _dateOfRegistration = value;
                }
                else
                {
                    throw new InvalidOperationException("Only clients can have a DateOfRegistration.");
                }
            }
        }

        public double? Discount
        {
            get => Type == TypeOfCustomer.CLIENT ? _discount : null;
            set
            {
                if (Type == TypeOfCustomer.CLIENT)
                {
                    _discount = value;
                }
                else
                {
                    throw new InvalidOperationException("Only clients can have a Discount.");
                }
            }
        }

        public DateTime? DateOfDelivery
        {
            get => Type == TypeOfCustomer.DELIVERER ? _dateOfDelivery : null;
            set
            {
                if (Type == TypeOfCustomer.DELIVERER)
                {
                    _dateOfDelivery = value;
                }
                else
                {
                    throw new InvalidOperationException("Only deliverers can have a DateOfDelivery.");
                }
            }
        }

        public HashSet<Receipt> Receipts { get; set; } = new HashSet<Receipt>();

        public Firm()
        {
            if (Type == TypeOfCustomer.CLIENT)
            {
                _dateOfRegistration = DateTime.Now;
            }
            else if (Type == TypeOfCustomer.DELIVERER)
            {
                _dateOfDelivery = DateTime.Now;
            }
        }

        public void CountDiscount(DateTime dateOfRegistration)
        {
            if (Type != TypeOfCustomer.CLIENT)
            {
                throw new InvalidOperationException("Only clients can have a discount.");
            }

            var year = DateTime.Now.Year - dateOfRegistration.Year;
            if (year >= 4)
            {
                year = 4;
            }
            switch (year)
            {
                case 1:
                    _discount = 5; break;
                case 2:
                    _discount = 10; break;
                case 3:
                    _discount = 15; break;
                case 4:
                    _discount = 20; break;
                default:
                    _discount = 0; break;
            }
        }
    }
}
