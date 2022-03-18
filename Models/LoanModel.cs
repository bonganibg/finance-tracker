using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FinanceTrackerLibrary;

namespace FinanceTrackerWebApp.Models
{
    public class LoanModel
    {
        private HomeLoan home = new HomeLoan();
        private VehicleLoan vehicle = new VehicleLoan();
        
        public void WriteToVehicle()
        {
            vehicle.Make = Make;
            vehicle.Model = Model;
            vehicle.PurchasePrice = PurchasePrice;
            vehicle.TotalDeposit = TotalDeposit;
            vehicle.InterestRate = InterestRate;
            vehicle.InsurancePremium = InsurancePremium;
        }

        public void WriteToHome()
        {
            home.Period = Period;
            home.PurchasePrice = PurchasePrice;
            home.TotalDeposit = TotalDeposit;
            home.InterestRate = InterestRate;
        }

        public HomeLoan GetHomeLoan()
        {
            return home;
        }

        public VehicleLoan GetVehicleLoan()
        {
            return vehicle;
        }

        [Display (Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Total Desposit")]
        public decimal TotalDeposit { get; set; }

        [Range(minimum:240, maximum:360)]
        public int Period { get; set; }

        [Display(Name = "Interest Rate")]
        [Range(minimum: 0, maximum: 100)]
        public int InterestRate { get; set; }

        [Display(Name = "Insurance Premium")]
        public decimal InsurancePremium { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

    }
}