﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class Store : Entity
    {
        public Guid StoreId { get; private set; }
        public string Name { get; private set; }
        public int CityId { get; private set; }
        public int DistrictId { get; private set; }
        public int WardId { get; private set; }
        public bool IsActive { get; private set; }
        public string? TaxCode { get; private set; }
        public string Address { get; private set; }
        public string? GpsLocation { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Phone { get; private set; }
        public string? Fax { get; private set; }
        public string? Email { get; private set; }
        public string? Website { get; private set; }
        public string? Logo { get; private set; }
        public string? BankBranch { get; private set; }
        public string? BankCode { get; private set; }
        public string? BankAccount { get; private set; }

        public Store(
            Guid storeId,
            string name,
            int cityId,
            int districtId,
            int wardId,
            bool isActive,
            string? taxCode,
            string address,
            string? gpsLocation,
            string? postalCode,
            string? phone,
            string? fax,
            string? email,
            string? website,
            string? logo,
            string? bankBranch,
            string? bankCode,
            string? bankAccount
        ) : base (storeId)
        {
            StoreId = storeId;
            Name = name;
            CityId = cityId;
            DistrictId = districtId;
            WardId = wardId;
            IsActive = isActive;
            TaxCode = taxCode;
            Address = address;
            GpsLocation = gpsLocation;
            PostalCode = postalCode;
            Phone = phone;
            Fax = fax;
            Email = email;
            Website = website;
            Logo = logo;
            BankBranch = bankBranch;
            BankCode = bankCode;
            BankAccount = bankAccount;
        }

        public void SetName( string name )
        {
            Name = name;
        }

        public void SetCityId( int cityId )
        {
            CityId = cityId;
        }

        public void SetDisctrictId( int districtId )
        {
            DistrictId = districtId;
        }

        public void SetWardId( int wardId )
        {
            WardId = wardId;
        }

        public void SetActive( bool isActive )
        {
            IsActive = isActive;
        }

        public void SetTaxCode( string? taxCode )
        {
            TaxCode = taxCode;
        }

        public void SetAddress( string address)
        {
            Address = address;
        }

        public void SetGpsLocation( string? gpsLocation )
        {
            GpsLocation = gpsLocation;
        }

        public void SetPostalCode( string? postalCode )
        {
            PostalCode = postalCode;
        }

        public void SetPhone( string? phone )
        {
            Phone = phone;
        }

        public void SetFax( string? fax )
        {
            Fax = fax;
        }

        public void SetEmail( string? email )
        {
            Email = email;
        }

        public void SetWebsite( string? website )
        {
            Website = website;
        }

        public void SetLogo( string? logo )
        {
            Logo = logo;
        }

        public void SetBankBranch( string? bankBranch )
        {
            BankBranch = bankBranch;
        }

        public void SetBankCode( string? bankCode )
        {
            BankCode = bankCode;
        }

        public void SetBankAccount( string? bankAccount )
        {
            BankAccount = bankAccount;
        }
    }
}