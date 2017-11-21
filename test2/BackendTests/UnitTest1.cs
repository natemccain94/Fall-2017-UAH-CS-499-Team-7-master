using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test2;

namespace BackendTests
{
    /// <summary>
    /// 
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
        }

        /// <summary>
        /// Updates the test listing information.
        /// </summary>
        [TestMethod]
        public void UpdateTestListingInformation()
        {
            
        }

        /// <summary>
        /// Changes the test listing hit counts.
        /// </summary>
        [TestMethod]
        public void ChangeTestListingHitCounts()
        {
            
        }

        /// <summary>
        /// Removes the parts of test listing.
        /// </summary>
        [TestMethod]
        public void RemovePartsOfTestListing()
        {
            
        }

        /// <summary>
        /// Gets the parts of test listing.
        /// </summary>
        [TestMethod]
        public void GetPartsOfTestListing()
        {
            
        }

        /// <summary>
        /// Deletes the test listing.
        /// </summary>
        [TestMethod]
        public void DeleteTestListing()
        {
            
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
    /// 
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
    /// 
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
