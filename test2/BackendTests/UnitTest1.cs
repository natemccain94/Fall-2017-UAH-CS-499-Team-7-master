﻿using System;
using System.Data;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test2;

namespace BackendTests
{
    [TestClass]
    public class DatabaseTests
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ISeeData = new SQL_Connection();
            ISeeData.openConnection();
            
        }

        [TestMethod]
        public void StartUp()
        {
            ISeeData.AddAgency("test", "test@test.com", "2562560000", "street", "city", "state", "33333");
            int testAgencyID = ISeeData.GetAgencyID("test");

            Assert.AreNotEqual(-1,testAgencyID);

            ISeeData.AddAgent("first", "last", "user", "pass", "2562560101", "agent@agent.com", testAgencyID,
                "22222");
            int testAgentID = ISeeData.GetAgentID("user");

            Assert.AreNotEqual(-1, testAgentID);

            ISeeData.AddListing(Resource1.glorious_leader, Resource1.Glorious_Leader_makes_Cupcakes, 55555, "street",
                "city", "state", "test", 444, testAgentID, testAgencyID);
            int testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);

            Assert.AreNotEqual(-1, testListingID);
        }

        [TestMethod]
        public void UpdateTestListingInformation()
        {
            // Arrange
            int testListingID;
            int testAgentID;
            // Act
            testAgentID = ISeeData.GetAgentID("user");
            testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);

            ISeeData.UpdatePhotoSmall(Resource1.Glorious_Leader_makes_Cupcakes, testListingID);
            ISeeData.UpdatePhotoLarge(Resource1.glorious_leader, testListingID);
            ISeeData.UpdatePhotoOne(Resource1.glorious_leader, testListingID);
            ISeeData.UpdatePhotoTwo(Resource1.glorious_leader, testListingID);
            ISeeData.UpdatePhotoThree(Resource1.glorious_leader, testListingID);
            ISeeData.UpdatePhotoFour(Resource1.glorious_leader, testListingID);
            ISeeData.UpdatePhotoFive(Resource1.glorious_leader, testListingID);
            ISeeData.UpdateListingPrice(999, testListingID);
            ISeeData.UpdateStreet(changeString, testListingID);
            ISeeData.UpdateCity(changeString, testListingID);
            ISeeData.UpdateState(changeString, testListingID);
            ISeeData.UpdateZip(changeString, testListingID);
            ISeeData.UpdateSquareFootage(999, testListingID);
            ISeeData.UpdateDescription(changeString, testListingID);
            ISeeData.UpdateRoomDescription(changeString, testListingID);
            ISeeData.UpdateShortDescription(changeString, testListingID);
            ISeeData.UpdateSubdivision(changeString, testListingID);
            ISeeData.UpdateAlarmInfo(changeString, testListingID);
            // Assert
            Assert.AreEqual(999, ISeeData.GetListingPrice(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingStreet(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingCity(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingState(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingZip(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingDescription(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingRoomDescription(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingShortDescription(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingSubdivision(testListingID));
            Assert.AreEqual(changeString, ISeeData.GetListingAlarmInfo(testListingID));
            Assert.AreEqual(999, ISeeData.GetListingSquareFootage(testListingID));
            Assert.IsInstanceOfType(ISeeData.GetSmallPhoto(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetLargePhoto(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoOne(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoTwo(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoThree(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFour(testListingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFive(testListingID), typeof(Bitmap));
        }

        [TestMethod]
        public void ChangeTestListingHitCounts_GetNumberOfListings()
        {
            // Arrange
            int testListingID;
            int testAgentID;
            // Act
            testAgentID = ISeeData.GetAgentID("user");
            testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);

            ISeeData.IncrementDailyHitCount(testListingID);
            ISeeData.IncrementDailyHitCount(testListingID);
            ISeeData.IncrementDailyHitCount(testListingID);
            ISeeData.UpdateLifetimeHitCount(testListingID);
            ISeeData.ResetDailyHitCount(testListingID);
            ISeeData.IncrementDailyHitCount(testListingID);
            ISeeData.IncrementDailyHitCount(testListingID);
            // Assert
            Assert.AreEqual(3, ISeeData.GetListingLifetimeHitCount(testListingID));
            Assert.AreEqual(2, ISeeData.GetListingDailyHitCount(testListingID));
            Assert.AreNotEqual(0, ISeeData.GetTotalNumberOfListings());
        }

        [TestMethod]
        public void RemovePartsOfTestListing()
        {
            // Arrange
            int testListingID;
            int testAgentID;
            // Act
            testAgentID = ISeeData.GetAgentID("user");
            testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);

            ISeeData.RemovePhotoOne(testListingID);
            ISeeData.RemovePhotoTwo(testListingID);
            ISeeData.RemovePhotoThree(testListingID);
            ISeeData.RemovePhotoFour(testListingID);
            ISeeData.RemovePhotoFive(testListingID);
            ISeeData.RemoveRoomDescription(testListingID);
            ISeeData.RemoveDescription(testListingID);
            ISeeData.RemoveSubdivision(testListingID);
            ISeeData.RemoveAlarmInfo(testListingID);

            // Assert
            Assert.IsInstanceOfType(ISeeData.GetPhotoOne(testListingID),typeof(Image));
            Assert.IsInstanceOfType(ISeeData.GetPhotoTwo(testListingID), typeof(Image));
            Assert.IsInstanceOfType(ISeeData.GetPhotoThree(testListingID), typeof(Image));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFour(testListingID), typeof(Image));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFive(testListingID), typeof(Image));
            Assert.AreEqual("",ISeeData.GetListingRoomDescription(testListingID));
            Assert.AreEqual("", ISeeData.GetListingDescription(testListingID));
            Assert.AreEqual("", ISeeData.GetListingSubdivision(testListingID));
            Assert.AreEqual("", ISeeData.GetListingAlarmInfo(testListingID));
        }

        [TestMethod]
        public void TestGetDataTableFunctions()
        {
            // Arrange
            int testListingID;
            int testAgentID;
            // Act
            testAgentID = (int) ISeeData.GetAgentID("user");
            testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);
            // Assert
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterBySquareFootage(0, 1000000), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterByPriceRange(0, 1000000000), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterByZipCode(changeString), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllListings(), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetSpecificListing(testListingID), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllListingsForEmailToSpecificAgent(testAgentID), typeof(DataTable));
        }
        
        [TestMethod]
        public void DeleteTestListing()
        {
            // Arrange
            int testAgentID;
            int testListingID;
            // Act
            testAgentID = ISeeData.GetAgentID("user");
            testListingID = ISeeData.GetSpecificListingForTestPurposes(testAgentID);

            ISeeData.RemoveListing(testListingID);
            // Assert
            Assert.AreNotEqual(testListingID, ISeeData.GetSpecificListing(testListingID));
        }

        [TestMethod]
        public void GetAgentID_EditAgentInfo()
        {
            // Arrange
            int editNumber = 666;
            int testAgentID;
            // Act
            testAgentID = (int) ISeeData.GetAgentID("user");

            ISeeData.UpdateAgentFirstName(changeString, testAgentID);
            ISeeData.UpdateAgentLastName(changeString, testAgentID);
            ISeeData.UpdateAgentUsername(changeString, testAgentID);
            ISeeData.UpdateAgentPassword(changeString, testAgentID);
            ISeeData.UpdateAgentNumber(editNumber.ToString(), testAgentID);
            ISeeData.UpdateAgentEmail(changeString, testAgentID);

            // Assert
            Assert.AreEqual(testAgentID, ISeeData.GetAgentID(changeString));
        }

        [TestMethod]
        public void DifferentAgentGetFunctionTests()
        {
            // Arrange
            string checkString = "Yarg";
            int testAgentID;

            // Act
            testAgentID = (int) ISeeData.GetAgentID(changeString);

            // Assert
            Assert.AreNotEqual(0, ISeeData.GetTotalNumberOfAgentsUsingService());
            Assert.AreEqual(checkString, ISeeData.GetAgentFirstName(testAgentID));
            Assert.AreEqual(checkString, ISeeData.GetAgentLastName(testAgentID));
            Assert.AreEqual(checkString, ISeeData.GetAgentUserName(testAgentID));
            Assert.IsTrue(ISeeData.CheckAgentPassword(checkString, checkString));
            Assert.AreEqual(666.ToString(), ISeeData.GetAgentPhoneNumber(testAgentID));
            Assert.AreEqual(checkString, ISeeData.GetAgentEmail(testAgentID));
        }

        [TestMethod]
        public void TestDataTableGetFunctions()
        {
            // Arrange
            DataRow set;
            DataTable helper = new DataTable();
            int testAgentID;
            int testAgencyID;
            // Act
            testAgentID = (int) ISeeData.GetAgentID(changeString);
            testAgencyID = (int) ISeeData.GetAgencyID("test");
            helper = ISeeData.GetAgent(testAgentID);
            set = helper.Rows[0];
            // Assert
            Assert.AreEqual("Yarg", set["agent_Fname"]);
            Assert.IsInstanceOfType(ISeeData.GetAllAgents(), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllAgentsFromAgency(testAgencyID), typeof(DataTable));
        }

        [TestMethod]
        public void GetAgentID_DeleteAgent()
        {
            // Arrange
            int testAgentID;
            // Act
            testAgentID = ISeeData.GetAgentID(changeString);
            ISeeData.DeleteAgent(testAgentID);
            // Assert
            Assert.AreNotEqual(testAgentID, ISeeData.GetAgentID("Yarg"));
        }

        [TestMethod]
        public void UpdateAnAgency()
        {
            // Arrange
            int testAgencyID;
            DataRow set;
            DataTable helper = new DataTable();
            // Act
            testAgencyID = (int) ISeeData.GetAgencyID("test");

            ISeeData.UpdateAgencyName("kiiim", testAgencyID);
            ISeeData.UpdateAgencyEmail("jong", testAgencyID);
            ISeeData.UpdateAgencyPhone("un", testAgencyID);
            ISeeData.UpdateAgencyStreet("is", testAgencyID);
            ISeeData.UpdateAgencyCity("sexy,", testAgencyID);
            ISeeData.UpdateAgencyState("not", testAgencyID);
            ISeeData.UpdateAgencyZip("fatass", testAgencyID);
            helper = ISeeData.GetAgency(testAgencyID);
            set = helper.Rows[0];

            // Assert
            Assert.AreEqual("kiiim", set["agency_name"]);
            Assert.AreEqual("jong", set["agency_email"]);
            Assert.AreEqual("un", set["agency_phone"]);
            Assert.AreEqual("is", set["agency_street"]);
            Assert.AreEqual("sexy,", set["agency_city"]);
            Assert.AreEqual("not", set["agency_state"]);
            Assert.AreEqual("fatass", set["agency_zip"]);
        }

        [TestMethod]
        public void RemoveAnAgency()
        {
            // Arrange
            int testAgencyID;
            // Act
            testAgencyID = (int) ISeeData.GetAgencyID("kiiim");
            ISeeData.DeleteAgency(testAgencyID);
            // Assert
            Assert.AreNotEqual(testAgencyID, ISeeData.GetAgencyID("kiiim"));
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            ISeeData.closeConnection();
        }
        
        private string changeString = "Yarg";
        private static SQL_Connection ISeeData;
    }
}
