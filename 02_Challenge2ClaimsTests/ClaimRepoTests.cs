using System;
using System.Collections.Generic;
using _02_Challenge2ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge2ClaimsTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange() 
        {
            _repo = new ClaimRepo();
            _claim = new Claim(3, TypeOfClaim.Home, "stolen ring", 200.00, DateTime.Parse("12/24/2017"), DateTime.Parse("01/05/2018"));

            _repo.CreateANewClaimToQueue(_claim);
        }

        [TestMethod]
        public void AddClaimToQueue_ShouldGetNotNull()
        {
            //Arrange

            //Act
            _repo.CreateANewClaimToQueue(_claim);
            Claim claimFromRepo = _repo.GetClaimByIDViaQueue(3);

            //Assert
            Assert.IsNotNull(claimFromRepo);
        }

        [TestMethod]
        public void ReturnClaimQueue_ShouldBeNotNull()
        {
            //Arrange

            //Act
            Queue<Claim> testQueue = _repo.GetClaimQueue();

            //Assert
            Assert.IsNotNull(testQueue);
        }

        [TestMethod]
        public void GetClaimByID_ShouldBeEqual()
        {
            //Act

            //Arrange
            Claim claim = _repo.GetClaimByIDViaQueue(3);
            int claimNumber = claim.ClaimID;

            //Assert
            Assert.AreEqual(3, claimNumber);
        }
    }
}
