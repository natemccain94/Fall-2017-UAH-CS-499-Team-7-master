using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test2;

namespace BackendTests
{
    [TestClass]
    public class ListingDatabaseTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [TestClass]
    public class AgentDatabaseTests
    {
        
    }

    [TestClass]
    public class AgencyDatabaseTests
    {
        [TestMethod]
        public void AddAnAgency_GetAgencyID()
        {
            // Arrange
            test2.SQL_Connection ISeeData = new SQL_Connection();
            ISeeData.openConnection();
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
            ISeeData.closeConnection();
        }

        [TestMethod]
        public void UpdateAnAgency()
        {
            // Arrange
            test2.SQL_Connection ISeeData = new SQL_Connection();
            ISeeData.openConnection();
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

            ISeeData.closeConnection();
        }

        [TestMethod]
        public void RemoveAnAgency()
        {
            // Arrange
            test2.SQL_Connection ISeeData = new SQL_Connection();
            ISeeData.openConnection();
            int id;

            // Act
            id = ISeeData.GetAgencyID("kiiim");
            ISeeData.DeleteAgency(id);
            // Assert
            Assert.AreNotEqual(id, ISeeData.GetAgencyID("kiiim"));
            ISeeData.closeConnection();
        }
    }
}
