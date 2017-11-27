using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listing
/// </summary>
public class Listing
{
        private string listing_state, listing_city, listing_description, listing_roomDescription, listing_nameSubDivision, listing_alarminfo,listing_street, listing_shortDescription, listing_zip;
        private Int32 listing_sqFT, listing_price, hitcount, lifetime_hitcount;
        private byte[] largePic, smallPic,pic1, pic2, pic3, pic4, pic5;
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
            listing_zip = "empty";
            listing_sqFT = 0;
            listing_price = 0;
            Hitcount = 0;
            Lifetime_hitcount = 0;
            Listing_occupied = false;
            LargePic = null;
            SmallPic = null;
            Pic1 = null;
            Pic2 = null;
            Pic3 = null;
            Pic4 = null;
            Pic5 = null;
        }

        public int Listing_price { get => listing_price; set => listing_price = value; }
        public string Listing_state { get => listing_state; set => listing_state = value; }
        public string Listing_city { get => listing_city; set => listing_city = value; }
        public string Listing_description { get => listing_description; set => listing_description = value; }
        public string Listing_roomDescription { get => listing_roomDescription; set => listing_roomDescription = value; }
        public string Listing_nameSubDivision { get => listing_nameSubDivision; set => listing_nameSubDivision = value; }
        public string Listing_alarminfo { get => listing_alarminfo; set => listing_alarminfo = value; }
        public string Listing_zip { get => listing_zip; set => listing_zip = value; }
        public int Listing_sqFT { get => listing_sqFT; set => listing_sqFT = value; }
        public string Listing_street { get => listing_street; set => listing_street = value; }
        public string Listing_shortDescription { get => listing_shortDescription; set => listing_shortDescription = value; }
        public bool Listing_occupied { get => listing_occupied; set => listing_occupied = value; }
        public byte[] Pic1 { get => pic1; set => pic1 = value; }
        public byte[] Pic2 { get => pic2; set => pic2 = value; }
        public byte[] Pic3 { get => pic3; set => pic3 = value; }
        public byte[] Pic4 { get => pic4; set => pic4 = value; }
        public byte[] Pic5 { get => pic5; set => pic5 = value; }
         public byte[] LargePic { get => largePic; set => largePic = value; }
         public byte[] SmallPic { get => smallPic; set => smallPic = value; }
         public int Hitcount { get => hitcount; set => hitcount = value; }
         public int Lifetime_hitcount { get => lifetime_hitcount; set => lifetime_hitcount = value; }
}