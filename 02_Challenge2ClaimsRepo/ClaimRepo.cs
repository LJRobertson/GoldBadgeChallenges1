using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge2ClaimsRepo
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();

        //Create
        public void CreateANewClaimToQueue(Claim newClaim)
        {
            _claimsQueue.Enqueue(newClaim);
        }

        //Read
        public Queue<Claim> GetClaimQueue()
        {
            return _claimsQueue;
        }

        //Get by ID
        public Claim GetClaimByIDViaQueue(int claimNumber)
        {
            foreach (Claim claimItem in _claimsQueue)
            {
                if(claimItem.ClaimID == claimNumber)
                {
                    return claimItem;
                }
            }
            return null;
        }
    }
}

 
