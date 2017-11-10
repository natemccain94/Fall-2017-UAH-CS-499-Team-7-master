using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listing
/// </summary>
public class Listing
{
        private string listing_state, listing_city, listing_description, listing_roomDescription, listing_nameSubDivision, listing_alarminfo,listing_street, listing_shortDescription;
        private Int64 listing_zip, listing_sqFT, listing_price;
        private byte[] pic1, pic2, pic3, pic4, pic5, pic6;
        private Boolean listing_occupied;
        string path;
        //default contructor
        public Listing()
        {
            
            listing_state = "empty";
            listing_city = "empty";
            listing_street = "empty";
            listing_shortDescription = "empty";
            listing_description = "empty";
            listing_roomDescription = "empty";
            listing_nameSubDivision = "empty";
            listing_alarminfo = "empty";
            listing_zip = 0;
            listing_sqFT = 0;
            listing_price = 0;
            Listing_occupied = false;
            pic1 = null;
            pic2 = null;
            pic3 = null;
            pic4 = null;
            pic5 = null;
            pic6 = null;
        }

        public long Listing_price { get => listing_price; set => listing_price = value; }
        public string Listing_state { get => listing_state; set => listing_state = value; }
        public string Listing_city { get => listing_city; set => listing_city = value; }
        public string Listing_description { get => listing_description; set => listing_description = value; }
        public string Listing_roomDescription { get => listing_roomDescription; set => listing_roomDescription = value; }
        public string Listing_nameSubDivision { get => listing_nameSubDivision; set => listing_nameSubDivision = value; }
        public string Listing_alarminfo { get => listing_alarminfo; set => listing_alarminfo = value; }
        public long Listing_zip { get => listing_zip; set => listing_zip = value; }
        public long Listing_sqFT { get => listing_sqFT; set => listing_sqFT = value; }
        public string Listing_street { get => listing_street; set => listing_street = value; }
        public string Listing_shortDescription { get => listing_shortDescription; set => listing_shortDescription = value; }
        public bool Listing_occupied { get => listing_occupied; set => listing_occupied = value; }
}