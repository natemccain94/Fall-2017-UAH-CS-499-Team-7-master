using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace test2
{
    #region Nate's input
    
    /// <summary>
    /// 
    /// </summary>
    public class SQL_Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SQL_Connection" /> class.
        /// </summary>
        public SQL_Connection() { }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        public void openConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString =
                //"Data Source=DESKTOP-QM2SFGD;Initial Catalog=Housing;Integrated Security=True";
                "Data Source=DESKTOP-08QT6IE;Initial Catalog=Housing;Integrated Security=True";
            connection.Open();
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void closeConnection()
        {
            connection.Close();
        }

        #region functions that affect the listing database.

        #region Adding a listing

        /// <summary>
        /// Adds the listing.
        /// </summary>
        /// <param name="listing_smallPhoto">The small image.</param>
        /// <param name="listing_largePhoto">The large image.</param>
        /// <param name="listingPrice">The listing price.</param>
        /// <param name="street">The street.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="squareFootage">The square footage.</param>
        /// <param name="agent_id">The agent identifier.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void AddListing(Image listing_smallPhoto, Image listing_largePhoto, int listingPrice, string street, string city,
            string state, string zip, int squareFootage, int agent_id, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        "INSERT INTO listing (listing_smallPhoto, listing_largePhoto, listing_price, listing_street, listing_city, listing_state, "
                        + "listing_zip, listing_sqFT, listing_hitCount, listingLifetimeHitCount, agent_id, agency_id) VALUES (@listing_smallPhoto, @listing_largePhoto, @listing_price, "
                        + "@listing_street, @listing_city, @listing_state, @listing_zip, @listing_sqFT, 0, 0, @agent_id, @agency_id)";
                    // For each variable just start inserting stuff
                    command.Parameters.Add("@listing_smallPhoto", SqlDbType.Image);
                    command.Parameters.Add("@listing_largePhoto", SqlDbType.Image);
                    command.Parameters.Add("@listing_price", SqlDbType.Int);
                    command.Parameters.Add("@listing_street", SqlDbType.NVarChar);
                    command.Parameters.Add("@listing_city", SqlDbType.NVarChar);
                    command.Parameters.Add("@listing_state", SqlDbType.NVarChar);
                    command.Parameters.Add("@listing_zip", SqlDbType.NVarChar);
                    command.Parameters.Add("@listing_sqFT", SqlDbType.Int);
                    command.Parameters.Add("@agent_id", SqlDbType.Int);
                    command.Parameters.Add("@agency_id", SqlDbType.Int);

                    command.Parameters["@listing_smallPhoto"].Value = ImagetoByte(listing_smallPhoto);
                    command.Parameters["@listing_largePhoto"].Value = ImagetoByte(listing_largePhoto);
                    command.Parameters["@listing_price"].Value = listingPrice;
                    command.Parameters["@listing_street"].Value = street.ToCharArray();
                    command.Parameters["@listing_city"].Value = city.ToCharArray();
                    command.Parameters["@listing_state"].Value = state.ToCharArray();
                    command.Parameters["@listing_zip"].Value = zip.ToCharArray();
                    command.Parameters["@listing_sqFT"].Value = squareFootage;
                    command.Parameters["@agent_id"].Value = agent_id;
                    command.Parameters["@agency_id"].Value = agency_id;

                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region updating parts of a listing

        /// <summary>
        /// Updates the photo small.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoSmall(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_smallPhoto = @listing_smallPhoto WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_smallPhoto", SqlDbType.Image);

                    command.Parameters["@listing_smallPhoto"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo large.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoLarge(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_largePhoto = @listing_largePhoto WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_largePhoto", SqlDbType.Image);

                    command.Parameters["@listing_largePhoto"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo one.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoOne(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET pic1 = @pic1 WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@pic1", SqlDbType.Image);

                    command.Parameters["@pic1"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo two.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoTwo(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET pic2 = @pic2 WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@pic2", SqlDbType.Image);

                    command.Parameters["@pic2"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo three.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoThree(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET pic3 = @pic3 WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@pic3", SqlDbType.Image);

                    command.Parameters["@pic3"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo four.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoFour(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET pic4 = @pic4 WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@pic4", SqlDbType.Image);

                    command.Parameters["@pic4"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the photo five.
        /// </summary>
        /// <param name="replacementImage">The replacement image.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdatePhotoFive(Image replacementImage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET pic5 = @pic5 WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@pic5", SqlDbType.Image);

                    command.Parameters["@pic5"].Value = ImagetoByte(replacementImage);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the listing price.
        /// </summary>
        /// <param name="replacementPrice">The replacement price.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateListingPrice(int replacementPrice, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_price = @listing_price WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_price", SqlDbType.Int);

                    command.Parameters["@listing_price"].Value = replacementPrice;

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the street.
        /// </summary>
        /// <param name="replacementStreet">The replacement street.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateStreet(string replacementStreet, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_street = @listing_street WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_street", SqlDbType.NVarChar);

                    command.Parameters["@listing_street"].Value = replacementStreet.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the city.
        /// </summary>
        /// <param name="replacementCity">The replacement city.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateCity(string replacementCity, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_city = @listing_city WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_city", SqlDbType.NVarChar);

                    command.Parameters["@listing_city"].Value = replacementCity.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="replacementState">State of the replacement.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateState(string replacementState, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_state = @listing_state WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_state", SqlDbType.NVarChar);

                    command.Parameters["@listing_state"].Value = replacementState.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the zip.
        /// </summary>
        /// <param name="replacementZip">The replacement zip.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateZip(string replacementZip, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_zip = @listing_zip WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_zip", SqlDbType.NVarChar);

                    command.Parameters["@listing_zip"].Value = replacementZip.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the square footage.
        /// </summary>
        /// <param name="replacementSquareFootage">The replacement square footage.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateSquareFootage(int replacementSquareFootage, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_sqFT = @listing_sqFT WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_sqFT", SqlDbType.Int);

                    command.Parameters["@listing_sqFT"].Value = replacementSquareFootage;

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the description.
        /// </summary>
        /// <param name="replacementDescription">The replacement description.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateDescription(string replacementDescription, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_description = @listing_description WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_description", SqlDbType.NVarChar);

                    command.Parameters["@listing_description"].Value = replacementDescription.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the room description.
        /// </summary>
        /// <param name="replacementRoomDescription">The replacement room description.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateRoomDescription(string replacementRoomDescription, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_roomDescription = @listing_roomDescription WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_roomDescription", SqlDbType.NVarChar);

                    command.Parameters["@listing_roomDescription"].Value = replacementRoomDescription.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the short description.
        /// </summary>
        /// <param name="replacementShortDescription">The replacement short description.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateShortDescription(string replacementShortDescription, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_shortDescription = @listing_shortDescription WHERE ",
                            "listing_id = ", listing_id);
                    command.Parameters.Add("@listing_shortDescription", SqlDbType.NVarChar);

                    command.Parameters["@listing_shortDescription"].Value = replacementShortDescription.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the subdivision.
        /// </summary>
        /// <param name="replacementSubdivision">The replacement subdivision.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateSubdivision(string replacementSubdivision, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_nameSubDivision = @listing_nameSubdivision WHERE ",
                            "listing_id = ", listing_id);

                    command.Parameters.Add("@listing_nameSubdivision", SqlDbType.NVarChar);
                    command.Parameters["@listing_nameSubdivision"].Value = replacementSubdivision.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        // I don't know if this will work correctly, but it should. -Nate
        /// <summary>
        /// Increments the daily hit count.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        public void IncrementDailyHitCount(int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_hitCount = listing_hitCount + 1 WHERE ",
                            "listing_id = ", listing_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Resets the daily hit count.
        /// </summary>
        public void ResetDailyHitCount()
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE dbo.listing SET listing_hitCount = 0";

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Resets the daily hit count.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        public void ResetDailyHitCount(int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_hitCount = 0 WHERE ",
                            "listing_id = ", listing_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the lifetime hit count.
        /// </summary>
        public void UpdateLifetimeHitCount()
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE dbo.listing SET listingLifetimeHitCount = listing_HitCount + listingLifetimeHitCount";

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the lifetime hit count.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateLifetimeHitCount(int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "UPDATE dbo.listing SET listingLifetimeHitCount = listing_hitCount + listingLifetimeHitCount WHERE ",
                            "listing_id = ", listing_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the alarm information.
        /// </summary>
        /// <param name="replacementAlarmInfo">The replacement alarm information.</param>
        /// <param name="listing_id">The listing identifier.</param>
        public void UpdateAlarmInfo(string replacementAlarmInfo, int listing_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_alarmInfo = @listing_alarmInfo WHERE ",
                            "listing_id = ", listing_id);
                    // For each variable just start inserting stuff
                    command.Parameters.Add("@listing_alarmInfo", SqlDbType.NVarChar);

                    command.Parameters["@listing_alarmInfo"].Value = replacementAlarmInfo.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        // This region sets a value to null if used on part of a listing.

        #region deleting part of a listing/removing a listing

        /// <summary>
        /// Removes the photo one.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemovePhotoOne(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET extraPhotoOne = NULL WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the photo two.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemovePhotoTwo(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET extraPhotoTwo = NULL WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the photo three.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemovePhotoThree(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET extraPhotoThree = NULL WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the photo four.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemovePhotoFour(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET extraPhotoFour = NULL WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the photo five.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemovePhotoFive(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET extraPhotoFive = NULL WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the square footage.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveSquareFootage(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_sqFT = 0 WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the description.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveDescription(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_description = '' WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the room description.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveRoomDescription(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_roomDescription = '' WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the subdivision.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveSubdivision(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_nameSubDivision = '' WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the alarm information.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveAlarmInfo(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.listing SET listing_alarmInfo = '' WHERE ",
                            "listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Removes the listing.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        public void RemoveListing(int listingID)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("DELETE FROM dbo.listing WHERE listing_id = ", listingID);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion


        #region Retrieving info for listing.

        // Get the number of listing (total).
        /// <summary>
        /// Gets the total number of listing.
        /// </summary>
        /// <returns></returns>
        public int GetTotalNumberOfListings()
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT COUNT(*) FROM dbo.listing";
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the number of listing (from the agent).
        /// <summary>
        /// Gets the total number of listing from agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public int GetTotalNumberOfListingsFromAgent(int agent_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Concat("SELECT COUNT(*) FROM dbo.listing WHERE agent_id = ",
                        agent_id);
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the number of listing (from an agency).
        /// <summary>
        /// Gets the total number of listing from agency.
        /// </summary>
        /// <param name="agency_id">The agency identifier.</param>
        /// <returns></returns>
        public int GetTotalNumberOfListingsFromAgency(int agency_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Concat("SELECT COUNT(*) FROM dbo.listing WHERE agency_id = ",
                        agency_id);
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get all listing within a given square footage range.
        /// <summary>
        /// Gets the listing filter by square footage.
        /// </summary>
        /// <param name="squareFootLow">The square foot low.</param>
        /// <param name="squareFootHigh">The square foot high.</param>
        /// <returns></returns>
        public DataTable GetListingsFilterBySquareFootage(int squareFootLow, int squareFootHigh)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "SELECT ALL listing_smallPhoto, listing_price, listing_street, listing_city, listing_state, ",
                            "listing_zip, listing_sqFT, agent_id, agency_id FROM dbo.listing WHERE ",
                            "listing_sqFT BETWEEN @low AND @high");

                    command.Parameters.Add("@low", SqlDbType.Int);
                    command.Parameters.Add("@high", SqlDbType.Int);
                    command.Parameters["@low"].Value = squareFootLow;
                    command.Parameters["@high"].Value = squareFootHigh;

                    table.Columns.Add("listing_smallPhoto");
                    table.Columns.Add("listing_price");
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_sqFT");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) row["listing_smallPhoto"];
                            row["listing_smallPhoto"] = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return table;
        }

        // Get all listing within a given price range.
        /// <summary>
        /// Gets the listing filter by price range.
        /// </summary>
        /// <param name="costLow">The cost low.</param>
        /// <param name="costHigh">The cost high.</param>
        /// <returns></returns>
        public DataTable GetListingsFilterByPriceRange(int costLow, int costHigh)
        {
            var table = new DataTable();

            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "SELECT ALL listing_smallPhoto, listing_price, listing_street, listing_city, listing_state, ",
                            "listing_zip, listing_sqFT, agent_id, agency_id FROM dbo.listing WHERE ",
                            "listing_price BETWEEN @low AND @high");

                    command.Parameters.Add("@low", SqlDbType.Int);
                    command.Parameters.Add("@high", SqlDbType.Int);
                    command.Parameters["@low"].Value = costLow;
                    command.Parameters["@high"].Value = costHigh;

                    table.Columns.Add("listing_smallPhoto");
                    table.Columns.Add("listing_price");
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_sqFT");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) row["listing_smallPhoto"];
                            row["listing_smallPhoto"] = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return table;
        }

        // Get all listing matching the searched zip code.
        /// <summary>
        /// Gets the listing filter by zip code.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <returns></returns>
        public DataTable GetListingsFilterByZipCode(string zip)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "SELECT * FROM dbo.listing WHERE ",
                            "listing_zip = @searchZip");

                    command.Parameters.Add("@searchZip", SqlDbType.NVarChar);
                    command.Parameters["@searchZip"].Value = zip.ToCharArray();

                    table.Columns.Add("listing_id");
                    table.Columns.Add("listing_smallPhoto");
                    table.Columns.Add("listing_largePhoto");
                    table.Columns.Add("pic1");
                    table.Columns.Add("pic2");
                    table.Columns.Add("pic3");
                    table.Columns.Add("pic4");
                    table.Columns.Add("pic5");
                    table.Columns.Add("listing_price");
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_sqFT");
                    table.Columns.Add("listing_description");
                    table.Columns.Add("listing_roomDescription");
                    table.Columns.Add("listing_shortDescription");
                    table.Columns.Add("listing_nameSubDivision");
                    table.Columns.Add("listing_hitCount");
                    table.Columns.Add("listing_alarmInfo");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");
                    table.Columns.Add("listing_occupied");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            // small photo
                            var dataStream = new byte[0];
                            dataStream = (byte[]) row["listing_smallPhoto"];
                            row["listing_smallPhoto"] = BytetoImage(dataStream);

                            // large photo
                            dataStream = (byte[])row["listing_largePhoto"];
                            row["listing_largePhoto"] = BytetoImage(dataStream);
                            // pic1
                            dataStream = (byte[])row["pic1"];
                            row["pic1"] = BytetoImage(dataStream);
                            // pic2
                            dataStream = (byte[])row["pic2"];
                            row["pic2"] = BytetoImage(dataStream);
                            // pic3
                            dataStream = (byte[])row["pic3"];
                            row["pic3"] = BytetoImage(dataStream);
                            // pic4
                            dataStream = (byte[])row["pic4"];
                            row["pic4"] = BytetoImage(dataStream);
                            // pic5
                            dataStream = (byte[])row["pic5"];
                            row["pic5"] = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return table;
        }

        // Get all listing, no filtering.
        /// <summary>
        /// Gets all listing.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllListings()
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "SELECT ALL listing_smallPhoto, listing_price, listing_street, listing_city, listing_state, ",
                            "listing_zip, listing_sqFT, agent_id, agency_id FROM");

                    table.Columns.Add("listing_smallPhoto");
                    table.Columns.Add("listing_price");
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_sqFT");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);

                        foreach (DataRow row in table.Rows)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) row["listing_smallPhoto"];
                            row["listing_smallPhoto"] = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        public int GetSpecificListingForTestPurposes(int agent_id)
        {
            int result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_id FROM dbo.listing WHERE agent_id = @agentID";
                    command.Parameters.Add("@agentID", SqlDbType.Int);
                    command.Parameters["@agentID"].Value = agent_id;
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get all info for one specific listing. To be used for the agent detailed page.
        /// <summary>
        /// Gets the specific listing.
        /// </summary>
        /// <param name="listingID">The listing identifier.</param>
        /// <returns></returns>
        public DataTable GetSpecificListing(int listingID)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listingID;

                    table.Columns.Add("listing_smallPhoto");
                    table.Columns.Add("listing_largePhoto");
                    table.Columns.Add("pic1");
                    table.Columns.Add("pic2");
                    table.Columns.Add("pic3");
                    table.Columns.Add("pic4");
                    table.Columns.Add("pic5");
                    table.Columns.Add("listing_price");
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_sqFT");
                    table.Columns.Add("listing_description");
                    table.Columns.Add("listing_roomDescription");
                    table.Columns.Add("listing_short_Description");
                    table.Columns.Add("listing_nameSubdivision");
                    table.Columns.Add("listing_alarmInfo");
                    table.Columns.Add("listing_hitCount");
                    table.Columns.Add("listingLifetimeHitCount");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            var dataStream = new byte[0];

                            dataStream = (byte[]) row["listing_smallPhoto"];
                            row["listing_smallPhoto"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["listing_largePhoto"];
                            row["listing_largePhoto"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["pic1"];
                            row["pic1"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["pic2"];
                            row["pic2"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["pic3"];
                            row["pic3"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["pic4"];
                            row["pic4"] = BytetoImage(dataStream);

                            dataStream = (byte[]) row["pic5"];
                            row["pic5"] = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        /// <summary>
        /// Gets all listing for email to specific agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public DataTable GetAllListingsForEmailToSpecificAgent(int agent_id)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = String.Concat("Select All listing_street, listing_city, listing_state, ",
                        "listing_zip, listing_hitCount, listingLifetimeHitCount FROM dbo.listing where agent_id = ",
                        "@agent_id");
                        
                    command.Parameters.Add("@agent_id", SqlDbType.Int);
                    command.Parameters["@agent_id"].Value = agent_id;
                    
                    table.Columns.Add("listing_street");
                    table.Columns.Add("listing_city");
                    table.Columns.Add("listing_state");
                    table.Columns.Add("listing_zip");
                    table.Columns.Add("listing_hitCount");
                    table.Columns.Add("listingLifetimeHitCount");
                    
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }


        // Get the large photo for a specific listing
        /// <summary>
        /// Gets the large photo.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetLargePhoto(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_largePhoto FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["listing_largePhoto"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the small photo for a specific listing.
        /// <summary>
        /// Gets the small photo.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetSmallPhoto(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_smallPhoto FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["listing_smallPhoto"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the first extra picture for a specific listing.
        /// <summary>
        /// Gets the photo one.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetPhotoOne(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT pic1 FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["pic1"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the second extra picture for a specific listing.
        /// <summary>
        /// Gets the photo two.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetPhotoTwo(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT pic2 FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["pic2"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the third extra picture for a specific listing.
        /// <summary>
        /// Gets the photo three.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetPhotoThree(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT pic3 FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["pic3"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the fourth extra picture for a specific listing.
        /// <summary>
        /// Gets the photo four.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetPhotoFour(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT pic4 FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["pic4"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the fifth extra picture for a specific listing.
        /// <summary>
        /// Gets the photo five.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public Image GetPhotoFive(int listing_id)
        {
            Image image = null;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT pic5 FROM dbo.listing WHERE listing_id = @listingID";

                    command.Parameters.Add("@listingID", SqlDbType.Int);
                    command.Parameters["@listingID"].Value = listing_id;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count == 1)
                        {
                            var dataStream = new byte[0];
                            dataStream = (byte[]) dataSet.Tables[0].Rows[0]["pic5"];
                            image = BytetoImage(dataStream);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return image;
        }

        // Get the listing price for a specific listing.
        /// <summary>
        /// Gets the listing price.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public int GetListingPrice(int listing_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_price FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the listing street for a specific listing.
        /// <summary>
        /// Gets the listing street.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingStreet(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_street FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the listing city for a specific listing.
        /// <summary>
        /// Gets the listing city.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingCity(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_city FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the listing state for a specific listing.
        /// <summary>
        /// Gets the state of the listing.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingState(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_state FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the listing zip code for a specific listing.
        /// <summary>
        /// Gets the listing zip.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingZip(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_zip FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the listing square footage for a specific listing.
        /// <summary>
        /// Gets the listing square footage.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public int GetListingSquareFootage(int listing_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_sqFT FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the short description for a specific listing.
        /// <summary>
        /// Gets the listing short description.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingShortDescription(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_shortDescription FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the description for a specific listing.
        /// <summary>
        /// Gets the listing description.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingDescription(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_description FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the room description for a specific listing.
        /// <summary>
        /// Gets the listing room description.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingRoomDescription(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_roomDescription FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the subdivision for a specific listing.
        /// <summary>
        /// Gets the listing subdivision.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingSubdivision(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_nameSubdivision FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the alarm information for a specific listing.
        /// <summary>
        /// Gets the listing alarm information.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingAlarmInfo(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_alarmInfo FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the daily hit count for a specific listing.
        /// <summary>
        /// Gets the listing daily hit count.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public int GetListingDailyHitCount(int listing_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listing_hitCount FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the lifetime hit count for a specific listing.
        /// <summary>
        /// Gets the listing lifetime hit count.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public int GetListingLifetimeHitCount(int listing_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT listingLifetimeHitCount FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        // Get the listing agent id for a specific listing.
        /// <summary>
        /// Gets the listing agent identifier.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingAgentID(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT agent_id FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        // Get the agency id for a specific listing.
        /// <summary>
        /// Gets the listingagency identifier.
        /// </summary>
        /// <param name="listing_id">The listing identifier.</param>
        /// <returns></returns>
        public string GetListingagency_id(int listing_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT agency_id FROM dbo.listing WHERE listing_id = @listing";
                    command.Parameters.Add("@listing", SqlDbType.Int);
                    command.Parameters["@listing"].Value = listing_id;

                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        #endregion

        #endregion

        #region functions that affect the agent database.

        #region Add an agent to the database.

        /// <summary>
        /// Adds the agent.
        /// </summary>
        /// <param name="agent_Fname">The agent fname.</param>
        /// <param name="agent_Lname">The agent lname.</param>
        /// <param name="agent_Uname">The agent uname.</param>
        /// <param name="agent_password">The agent password.</param>
        /// <param name="agent_number">The agent number.</param>
        /// <param name="agent_email">The agent email.</param>
        /// <param name="agency_id">The agency identifier.</param>
        /// <param name="agent_number2">The agent number2.</param>
        public void AddAgent(string agent_Fname, string agent_Lname, string agent_Uname, string agent_password,
            string agent_number,
            string agent_email, int agency_id, string agent_number2)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        "INSERT INTO agent (agent_Fname, agent_Lname, agent_Uname, agent_password, agent_number, agent_email, agency_id, "
                        + "agent_number2) VALUES (@agent_Fname, @agent_Lname, @agent_Uname, @agent_password,  @agent_number, @agent_email, @agency_id, "
                        + "@agent_number2)";
                    // For each variable just start inserting stuff
                    command.Parameters.Add("@agent_Fname", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent_Lname", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent_Uname", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent_password", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent_number", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent_email", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_id", SqlDbType.Int);
                    command.Parameters.Add("@agent_number2", SqlDbType.NVarChar);

                    command.Parameters["@agent_Fname"].Value = agent_Fname.ToCharArray();
                    command.Parameters["@agent_Lname"].Value = agent_Lname.ToCharArray();
                    command.Parameters["@agent_Uname"].Value = agent_Uname.ToCharArray();
                    command.Parameters["@agent_password"].Value = agent_password.ToCharArray();
                    command.Parameters["@agent_number"].Value = agent_number.ToCharArray();
                    command.Parameters["@agent_email"].Value = agent_email.ToCharArray();
                    command.Parameters["@agency_id"].Value = agency_id;
                    command.Parameters["@agent_number2"].Value = agent_number2.ToCharArray();

                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Update parts of an agent in the agent database.

        /// <summary>
        /// Updates the first name of the agent.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentFirstName(string firstName, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_Fname = @agent_Fname WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_Fname", SqlDbType.NVarChar);

                    command.Parameters["@agent_Fname"].Value = firstName.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the last name of the agent.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentLastName(string lastName, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_Lname = @agent_Lname WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_Lname", SqlDbType.NVarChar);

                    command.Parameters["@agent_Lname"].Value = lastName.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agent username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentUsername(string userName, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_Uname = @agent_Uname WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_Uname", SqlDbType.NVarChar);

                    command.Parameters["@agent_Uname"].Value = userName.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agent password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentPassword(string password, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_password = @agent_password WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_password", SqlDbType.NVarChar);

                    command.Parameters["@agent_password"].Value = password.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agent number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentNumber(string phoneNumber, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_number = @agent_number WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_number", SqlDbType.NVarChar);

                    command.Parameters["@agent_number"].Value = phoneNumber.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agent email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="agent_id">The agent identifier.</param>
        public void UpdateAgentEmail(string email, int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agent SET agent_email = @agent_email WHERE ",
                            "agent_id = ", agent_id);
                    command.Parameters.Add("@agent_email", SqlDbType.NVarChar);

                    command.Parameters["@agent_email"].Value = email.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Delete an agent

        /// <summary>
        /// Deletes the agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        public void DeleteAgent(int agent_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("DELETE FROM dbo.agent WHERE agent_id = ", agent_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Retrieve stuff from the agent database.

        /// <summary>
        /// Gets the total number of agents using service.
        /// </summary>
        /// <returns></returns>
        public int GetTotalNumberOfAgentsUsingService()
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT COUNT(*) FROM dbo.agent";
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the total number of agents with agency.
        /// </summary>
        /// <param name="agency_id">The agency identifier.</param>
        /// <returns></returns>
        public int GetTotalNumberOfAgentsWithAgency(int agency_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Concat("SELECT COUNT(*) FROM dbo.agent WHERE agency_id = ", agency_id);
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the first name of the agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public string GetAgentFirstName(int agent_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_Fname FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the last name of the agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public string GetAgentLastName(int agent_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_Lname FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the agent identifier.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public int GetAgentID(string username)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT agent_id FROM dbo.agent WHERE agent_Uname = @username";
                    command.Parameters.Add("@username", SqlDbType.NVarChar);
                    command.Parameters["@username"].Value = username.ToCharArray();
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the name of the agent user.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public string GetAgentUserName(int agent_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_Uname FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        /// <summary>
        /// Checks the agent password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="enteredPassword">The entered password.</param>
        /// <returns></returns>
        public bool CheckAgentPassword(string username, string enteredPassword)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT agent_password FROM dbo.agent WHERE agent_Uname = @username";
                    command.Parameters.Add("@username", SqlDbType.NVarChar);
                    command.Parameters["@username"].Value = username.ToCharArray();
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return string.Equals(enteredPassword, result);
        }

        /// <summary>
        /// Gets the agent phone number.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public string GetAgentPhoneNumber(int agent_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_number FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the agent email.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public string GetAgentEmail(int agent_id)
        {
            var result = "";
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_email FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToString(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = "error";
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the agency of agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public int GetAgencyOfAgent(int agent_id)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Concat("SELECT agency_id FROM dbo.agent WHERE agent_id = ", agent_id);
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the agent.
        /// </summary>
        /// <param name="agent_id">The agent identifier.</param>
        /// <returns></returns>
        public DataTable GetAgent(int agent_id)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT agent_Fname, agent_Lname, agent_number, agent_email, agency_id ",
                            "FROM dbo.agent WHERE agent_id = ", agent_id);

                    table.Columns.Add("agent_Fname");
                    table.Columns.Add("agent_Lname");
                    table.Columns.Add("agent_number");
                    table.Columns.Add("agent_email");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        /// <summary>
        /// Gets all agents.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllAgents()
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT ALL agent_Fname, agent_Lname, agent_number, agent_email, agent_id, ",
                            "agency_id FROM dbo.agent");

                    table.Columns.Add("agent_Fname");
                    table.Columns.Add("agent_Lname");
                    table.Columns.Add("agent_number");
                    table.Columns.Add("agent_email");
                    table.Columns.Add("agent_id");
                    table.Columns.Add("agency_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        /// <summary>
        /// Gets all agents from agency.
        /// </summary>
        /// <param name="agency_id">The agency identifier.</param>
        /// <returns></returns>
        public DataTable GetAllAgentsFromAgency(int agency_id)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("SELECT ALL agent_Fname, agent_Lname, agent_number, agent_email, agent_id ",
                            "FROM dbo.agent WHERE agency_id = ", agency_id);

                    table.Columns.Add("agent_Fname");
                    table.Columns.Add("agent_Lname");
                    table.Columns.Add("agent_number");
                    table.Columns.Add("agent_email");
                    table.Columns.Add("agent_id");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        #endregion

        #endregion

        #region functions that affect the agency database.

        #region Add an agency to the database.

        /// <summary>
        /// Adds the agency.
        /// </summary>
        /// <param name="agency_name">Name of the agency.</param>
        /// <param name="agency_email">The agency email.</param>
        /// <param name="agency_phone">The agency phone.</param>
        /// <param name="agency_street">The agency street.</param>
        /// <param name="agency_city">The agency city.</param>
        /// <param name="agency_state">State of the agency.</param>
        /// <param name="agency_zip">The agency zip.</param>
        public void AddAgency(string agency_name, string agency_email, string agency_phone, string agency_street,
            string agency_city, string agency_state, string agency_zip)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        "INSERT INTO agency (agency_name, agency_email, agency_phone, agency_street, agency_city, agency_state, "
                        + "agency_zip) VALUES (@agency_name, @agency_email, @agency_phone, @agency_street, @agency_city, @agency_state, "
                        + "@agency_zip)";
                    // For each variable just start inserting stuff
                    command.Parameters.Add("@agency_name", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_email", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_phone", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_street", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_city", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_state", SqlDbType.NVarChar);
                    command.Parameters.Add("@agency_zip", SqlDbType.NVarChar);

                    command.Parameters["@agency_name"].Value = agency_name.ToCharArray();
                    command.Parameters["@agency_email"].Value = agency_email.ToCharArray();
                    command.Parameters["@agency_phone"].Value = agency_phone.ToCharArray();
                    command.Parameters["@agency_street"].Value = agency_street.ToCharArray();
                    command.Parameters["@agency_city"].Value = agency_city.ToCharArray();
                    command.Parameters["@agency_state"].Value = agency_state.ToCharArray();
                    command.Parameters["@agency_zip"].Value = agency_zip;

                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Update parts of an agent in the agency database.

        /// <summary>
        /// Updates the name of the agency.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyName(string name, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_name = @agency_name WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_name", SqlDbType.NVarChar);

                    command.Parameters["@agency_name"].Value = name.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agency email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyEmail(string email, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_email = @agency_email WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_email", SqlDbType.NVarChar);

                    command.Parameters["@agency_email"].Value = email.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agency phone.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyPhone(string phoneNumber, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_phone = @agency_phone WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_phone", SqlDbType.NVarChar);

                    command.Parameters["@agency_phone"].Value = phoneNumber.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agency street.
        /// </summary>
        /// <param name="street">The street.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyStreet(string street, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_street = @agency_street WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_street", SqlDbType.NVarChar);

                    command.Parameters["@agency_street"].Value = street.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agency city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyCity(string city, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_city = @agency_city WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_city", SqlDbType.NVarChar);

                    command.Parameters["@agency_city"].Value = city.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the state of the agency.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyState(string state, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_state = @agency_state WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_state", SqlDbType.NVarChar);

                    command.Parameters["@agency_state"].Value = state.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the agency zip.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <param name="agency_id">The agency identifier.</param>
        public void UpdateAgencyZip(string zip, int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("UPDATE dbo.agency SET agency_zip = @agency_zip WHERE ",
                            "agency_id = ", agency_id);
                    command.Parameters.Add("@agency_zip", SqlDbType.NVarChar);

                    command.Parameters["@agency_zip"].Value = zip.ToCharArray();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Remove/Delete items in the agency database.

        /// <summary>
        /// Deletes the agency.
        /// </summary>
        /// <param name="agency_id">The agency identifier.</param>
        public void DeleteAgency(int agency_id)
        {
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat("DELETE FROM dbo.agency WHERE agency_id = ", agency_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        #endregion

        #region Retrieve stuff from the agency database.

        /// <summary>
        /// Gets the total number of agencies.
        /// </summary>
        /// <returns></returns>
        public int GetTotalNumberOfAgencies()
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT COUNT(*) FROM dbo.agency";
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all agencies.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllAgencies()
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        "SELECT ALL agency_name, agency_email, agency_phone, agency_street, agency_city, "
                        + "agency_state, agency_zip FROM dbo.agency";

                    table.Columns.Add("agency_name");
                    table.Columns.Add("agency_email");
                    table.Columns.Add("agency_phone");
                    table.Columns.Add("agency_street");
                    table.Columns.Add("agency_city");
                    table.Columns.Add("agency_state");
                    table.Columns.Add("agency_zip");

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        /// <summary>
        /// Gets the agency.
        /// </summary>
        /// <param name="agency_id">The agency identifier.</param>
        /// <returns></returns>
        public DataTable GetAgency(int agency_id)
        {
            var table = new DataTable();
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Concat(
                            "SELECT agency_name, agency_email, agency_phone, agency_street, agency_city, ",
                            "agency_state, agency_zip FROM dbo.agency WHERE agency_id = ", agency_id);

                    table.Columns.Add("agency_name");
                    table.Columns.Add("agency_email");
                    table.Columns.Add("agency_phone");
                    table.Columns.Add("agency_street");
                    table.Columns.Add("agency_city");
                    table.Columns.Add("agency_state");
                    table.Columns.Add("agency_zip");


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return table;
        }

        /// <summary>
        /// Gets the agency identifier.
        /// </summary>
        /// <param name="agency_name">Name of the agency.</param>
        /// <returns></returns>
        public int GetAgencyID(string agency_name)
        {
            var result = -1;
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Concat("SELECT agency_id FROM dbo.agency WHERE",
                        " agency_name = '", agency_name, "'");
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = -1;
                }
            }
            return result;
        }
        #endregion

        #endregion


        /// <summary>
        /// Image to the byte.
        /// </summary>
        /// <param name="imageIn">The image in.</param>
        /// <returns></returns>
        public byte[] ImagetoByte(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }

        /// <summary>
        /// Byte to the image.
        /// </summary>
        /// <param name="byteArrayIn">The byte array in.</param>
        /// <returns></returns>
        public Image BytetoImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }


        /// <summary>
        /// The connection
        /// </summary>
        private SqlConnection connection;
        /// <summary>
        /// The command
        /// </summary>
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            SQL_Connection connection = new SQL_Connection();
            connection.openConnection();

            connection.AddListing(Resource1.glorious_leader, Resource1.Glorious_Leader_makes_Cupcakes, 666,
                "street", "city",
                "state", "zip", 444, 5, 5);
            DataTable helper = new DataTable();
            helper = connection.GetListingsFilterByZipCode("zip");
            Console.WriteLine(helper.Rows[0]["listing_street"]);
            Console.ReadLine();
        }
    }
}