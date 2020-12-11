using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Department_Repository
{
    public class Claims_Repository
    {
        private Queue<Claim> _claims = new Queue<Claim>();

        // Create
        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim); 
        }

        // Read
        public Queue<Claim> GetClaims()
        {
            return _claims;
        }


        // Update

        // Delete
    }
}
