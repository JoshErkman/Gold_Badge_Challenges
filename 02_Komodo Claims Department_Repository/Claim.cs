using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Department_Repository
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft
        }
        public string ClaimId { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                if (DateOfIncident.AddDays(30) > DateOfClaim)
                {
                    return true;
                }
                else if (DateOfIncident > DateOfClaim)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim() { }

        public Claim(string claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

    }
}
