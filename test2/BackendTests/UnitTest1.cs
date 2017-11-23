using System;
using System.Data;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test2;

namespace BackendTests
{
    /// <summary>
    /// Test functions that interact with the listing database.
    /// </summary>
    [TestClass]
    public class ListingDatabaseTests
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [ClassInitialize]
        public static void Init()
        {
            ISeeData = new SQL_Connection();
            ISeeData.openConnection();
        }

        /// <summary>
        /// Adds the listing get listing identifier.
        /// </summary>
        [TestMethod]
        public void AddListing_GetListingID()
        {
            // Arrange
            ISeeData.AddListing(Resource1.Glorious_Leader_makes_Cupcakes, Resource1.glorious_leader,
                66666, "What is love", "baby don't hurt me",
                "don't hurt me", "no mas", 66666, 66666, 66666);
            DataRow row;
            // Act
            row = ISeeData.GetListingsFilterByZipCode("no mas").Rows[0];
            listingID = (int) row[0];
            // Assert
            Assert.AreNotEqual(-1,listingID);
        }

        /// <summary>
        /// Updates the test listing information.
        /// </summary>
        [TestMethod]
        public void UpdateTestListingInformation()
        {
            // Arrange

            // Act
            ISeeData.UpdatePhotoSmall(Resource1.Glorious_Leader_makes_Cupcakes,listingID);
            ISeeData.UpdatePhotoLarge(Resource1.glorious_leader, listingID);
            ISeeData.UpdatePhotoOne(Resource1.glorious_leader, listingID);
            ISeeData.UpdatePhotoTwo(Resource1.glorious_leader, listingID);
            ISeeData.UpdatePhotoThree(Resource1.glorious_leader, listingID);
            ISeeData.UpdatePhotoFour(Resource1.glorious_leader, listingID);
            ISeeData.UpdatePhotoFive(Resource1.glorious_leader, listingID);
            ISeeData.UpdateListingPrice(99999,listingID);
            ISeeData.UpdateStreet("street",listingID);
            ISeeData.UpdateCity("city", listingID);
            ISeeData.UpdateState("state",listingID);
            ISeeData.UpdateZip("zip",listingID);
            ISeeData.UpdateSquareFootage(99999,listingID);
            ISeeData.UpdateDescription("description",listingID);
            ISeeData.UpdateRoomDescription("room description", listingID);
            ISeeData.UpdateShortDescription("short description",listingID);
            ISeeData.UpdateSubdivision("subdivision",listingID);
            ISeeData.UpdateAlarmInfo("alarm info",listingID);
            // Assert
            Assert.AreEqual(99999,ISeeData.GetListingPrice(listingID));
            Assert.AreEqual("street", ISeeData.GetListingStreet(listingID));
            Assert.AreEqual("city", ISeeData.GetListingCity(listingID));
            Assert.AreEqual("state", ISeeData.GetListingState(listingID));
            Assert.AreEqual("zip", ISeeData.GetListingZip(listingID));
            Assert.AreEqual("description", ISeeData.GetListingDescription(listingID));
            Assert.AreEqual("room description", ISeeData.GetListingRoomDescription(listingID));
            Assert.AreEqual("short description", ISeeData.GetListingShortDescription(listingID));
            Assert.AreEqual("subdivision", ISeeData.GetListingSubdivision(listingID));
            Assert.AreEqual("alarm info", ISeeData.GetListingAlarmInfo(listingID));
            Assert.AreEqual(99999, ISeeData.GetListingSquareFootage(listingID));
            Assert.IsInstanceOfType(ISeeData.GetSmallPhoto(listingID),typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetLargePhoto(listingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoOne(listingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoTwo(listingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoThree(listingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFour(listingID), typeof(Bitmap));
            Assert.IsInstanceOfType(ISeeData.GetPhotoFive(listingID), typeof(Bitmap));
        }

        /// <summary>
        /// Changes the test listing hit counts.
        /// </summary>
        [TestMethod]
        public void ChangeTestListingHitCounts_GetNumberOfListings()
        {
            // Arrange

            // Act
            ISeeData.IncrementDailyHitCount(listingID);
            ISeeData.IncrementDailyHitCount(listingID);
            ISeeData.IncrementDailyHitCount(listingID);
            ISeeData.UpdateLifetimeHitCount(listingID);
            ISeeData.ResetDailyHitCount(listingID);
            ISeeData.IncrementDailyHitCount(listingID);
            ISeeData.IncrementDailyHitCount(listingID);
            // Assert
            Assert.AreEqual(3,ISeeData.GetListingLifetimeHitCount(listingID));
            Assert.AreEqual(2,ISeeData.GetListingDailyHitCount(listingID));
            Assert.AreNotEqual(0,ISeeData.GetTotalNumberOfListings());
        }

        /// <summary>
        /// Removes the parts of test listing.
        /// </summary>
        [TestMethod]
        public void RemovePartsOfTestListing()
        {
            // Arrange
            // This one might need more testing for the photos.
            DataRow row;
            // Act
            ISeeData.RemovePhotoOne(listingID);
            ISeeData.RemovePhotoTwo(listingID);
            ISeeData.RemovePhotoThree(listingID);
            ISeeData.RemovePhotoFour(listingID);
            ISeeData.RemovePhotoFive(listingID);
            ISeeData.RemoveSquareFootage(listingID);
            ISeeData.RemoveRoomDescription(listingID);
            ISeeData.RemoveDescription(listingID);
            ISeeData.RemoveSubdivision(listingID);
            ISeeData.RemoveAlarmInfo(listingID);
            row = ISeeData.GetSpecificListing(listingID).Rows[0];
            // Assert
            Assert.IsNull(row["extraPhotoOne"]);
            Assert.IsNull(row["extraPhotoTwo"]);
            Assert.IsNull(row["extraPhotoThree"]);
            Assert.IsNull(row["extraPhotoFour"]);
            Assert.IsNull(row["extraPhotoFive"]);
            Assert.IsNull(row["listingSquareFootage"]);
            Assert.IsNull(row["listingDescription"]);
            Assert.IsNull(row["listingRoomDescription"]);
            Assert.IsNull(row["listingSubdivision"]);
            Assert.IsNull(row["listingAlarmInfo"]);
        }

        /// <summary>
        /// Gets the parts of test listing.
        /// </summary>
        [TestMethod]
        public void TestGetDataTableFunctions()
        {
            // Arrange

            // Act

            // Assert
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterBySquareFootage(0,1000000),typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterByPriceRange(0,1000000000), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetListingsFilterByZipCode("zip"), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllListings(), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetSpecificListing(listingID), typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllListingsForEmailToSpecificAgent(66666), typeof(DataTable));
        }

        /// <summary>
        /// Deletes the test listing.
        /// </summary>
        [TestMethod]
        public void DeleteTestListing()
        {
            // Arrange

            // Act
            ISeeData.RemoveListing(listingID);
            // Assert
            Assert.AreNotEqual(listingID, ISeeData.GetSpecificListing(listingID));
        }

        /// <summary>
        /// Ends the of listing tests.
        /// </summary>
        [ClassCleanup]
        public static void EndOfListingTests()
        {
            ISeeData.closeConnection();
        }

        /// <summary>
        /// The i see data
        /// </summary>
        public static SQL_Connection ISeeData;
        /// <summary>
        /// The listing identifier
        /// </summary>
        private int listingID;
    }

    /// <summary>
    /// Test functions that interact with the agent database.
    /// </summary>
    [TestClass]
    public class AgentDatabaseTests
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [ClassInitialize]
        public static void Init()
        {
            ISeeData = new SQL_Connection();
            ISeeData.openConnection();
        }

        /// <summary>
        /// Adds an agent get agent identifier.
        /// </summary>
        [TestMethod]
        public void AddAnAgent_GetAgentID()
        {
            // Arrange
            int id;
            // Act
            ISeeData.AddAgent("agent_Fname", "agent_Lname", "agent_Uname",
                "agent_password", "agent_number", "agent_email", 696969, "000");
            id = ISeeData.GetAgentID("agent_Uname");
            // Assert
            Assert.AreNotEqual(-1, id);
        }

        /// <summary>
        /// Gets the agent identifier edit agent information.
        /// </summary>
        [TestMethod]
        public void GetAgentID_EditAgentInfo()
        {
            // Arrange
            int id;
            string editInfo = "Yarg";
            int editNumber = 666;
            // Act
            id = ISeeData.GetAgentID("agent_Uname");
            ISeeData.UpdateAgentFirstName(editInfo,id);
            ISeeData.UpdateAgentLastName(editInfo, id);
            ISeeData.UpdateAgentUsername(editInfo, id);
            ISeeData.UpdateAgentPassword(editInfo, id);
            ISeeData.UpdateAgentNumber(editNumber.ToString(), id);
            ISeeData.UpdateAgentEmail(editInfo, id);

            // Assert
            Assert.AreEqual(id, ISeeData.GetAgentID(editInfo));
        }

        /// <summary>
        /// Differents the agent get function tests.
        /// </summary>
        [TestMethod]
        public void DifferentAgentGetFunctionTests()
        {
            // Arrange
            int id;
            string checkString = "Yarg";

            // Act
            id = ISeeData.GetAgentID(checkString);

            // Assert
            Assert.AreNotEqual(0,ISeeData.GetTotalNumberOfAgentsUsingService());
            Assert.AreEqual(1,ISeeData.GetTotalNumberOfAgentsWithAgency(696969));
            Assert.AreEqual(checkString,ISeeData.GetAgentFirstName(id));
            Assert.AreEqual(checkString,ISeeData.GetAgentLastName(id));
            Assert.AreEqual(checkString,ISeeData.GetAgentUserName(id));
            Assert.IsTrue(ISeeData.CheckAgentPassword(checkString,checkString));
            Assert.AreEqual(checkString,ISeeData.GetAgentPhoneNumber(id));
            Assert.AreEqual(checkString,ISeeData.GetAgentEmail(id));
            Assert.AreEqual(696969,ISeeData.GetAgencyOfAgent(id));
        }

        /// <summary>
        /// Tests the data table get functions.
        /// </summary>
        [TestMethod]
        public void TestDataTableGetFunctions()
        {
            // Arrange
            int id;
            DataRow set;
            // Act
            id = ISeeData.GetAgentID("Yarg");
            set = ISeeData.GetAgent(id).Rows[0];
            // Assert
            Assert.AreEqual("Yarg",set[1]);
            Assert.IsInstanceOfType(ISeeData.GetAllAgents(),typeof(DataTable));
            Assert.IsInstanceOfType(ISeeData.GetAllAgentsFromAgency(696969),typeof(DataTable));
        }

        /// <summary>
        /// Gets the agent identifier delete agent.
        /// </summary>
        [TestMethod]
        public void GetAgentID_DeleteAgent()
        {
            // Arrange
            int id;
            // Act
            id = ISeeData.GetAgentID("Yarg");
            ISeeData.DeleteAgent(id);
            // Assert
            Assert.AreNotEqual(id,ISeeData.GetAgentID("Yarg"));
        }

        /// <summary>
        /// Ends the of agent tests.
        /// </summary>
        [ClassCleanup]
        public static void EndOfAgentTests()
        {
            ISeeData.closeConnection();
        }

        /// <summary>
        /// The i see data
        /// </summary>
        public static test2.SQL_Connection ISeeData;
    }

    /// <summary>
    /// Test functions that interact with the agency database.
    /// </summary>
    [TestClass]
    public class AgencyDatabaseTests
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [ClassInitialize]
        public static void Init()
        {
            ISeeData = new SQL_Connection();
            ISeeData.openConnection();
        }

        /// <summary>
        /// Adds an agency get agency identifier.
        /// </summary>
        [TestMethod]
        public void AddAnAgency_GetAgencyID()
        {
            // Arrange
            ISeeData.AddAgency("agency_name","agency_email","agency_phone",
                "agency_street","agency_city","agency_state","agency_zip");
            int id;
            DataRow set;
            // Act
            id = ISeeData.GetAgencyID("agency_name");
            var helper = ISeeData.GetAgency(id);
            set = helper.Rows[0];
            // Assert
            Assert.AreSame(typeof(DataTable),helper);
            Assert.AreEqual("agency_name", set[0]);
        }

        /// <summary>
        /// Updates an agency.
        /// </summary>
        [TestMethod]
        public void UpdateAnAgency()
        {
            // Arrange
            int id;
            DataRow set;

            // Act
            id = ISeeData.GetAgencyID("agency_name");
            ISeeData.UpdateAgencyName("kiiim",id);
            ISeeData.UpdateAgencyEmail("jong", id);
            ISeeData.UpdateAgencyPhone("un", id);
            ISeeData.UpdateAgencyStreet("is", id);
            ISeeData.UpdateAgencyCity("sexy,", id);
            ISeeData.UpdateAgencyState("not", id);
            ISeeData.UpdateAgencyZip("fatass", id);
            var helper = ISeeData.GetAgency(id);
            set = helper.Rows[0];

            // Assert
            Assert.AreEqual("kiiim",set[0]);
            Assert.AreEqual("jong", set[1]);
            Assert.AreEqual("un", set[2]);
            Assert.AreEqual("is", set[3]);
            Assert.AreEqual("sexy,", set[4]);
            Assert.AreEqual("not", set[5]);
            Assert.AreEqual("fatass", set[6]);
        }

        /// <summary>
        /// Removes an agency.
        /// </summary>
        [TestMethod]
        public void RemoveAnAgency()
        {
            // Arrange
            int id;

            // Act
            id = ISeeData.GetAgencyID("kiiim");
            ISeeData.DeleteAgency(id);
            // Assert
            Assert.AreNotEqual(id, ISeeData.GetAgencyID("kiiim"));
        }

        /// <summary>
        /// Ends the of agency tests.
        /// </summary>
        [ClassCleanup]
        public static void EndOfAgencyTests()
        {
            ISeeData.closeConnection();
        }

        /// <summary>
        /// The i see data
        /// </summary>
        public static test2.SQL_Connection ISeeData;
    }
}
