using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    public class Address
    {
        private double longitude;
        private double latitude;
        private string locationName;
        private string area;

        public Address(string locationName, double longitude, double latitude, string area)
        {
            setLocationName(locationName);
            setLongitude(longitude);
            setLatitude(latitude);
            setArea(area);
        }

        public double getLongitude()
        {
            return longitude;
        }
        public double getLatitude()
        {
            return latitude;
        }
        public string getLocationName()
        {
            return locationName;
        }
        public string getArea()
        {
            return area;
        }
        public void setLongitude(double longitude)
        {
            this.longitude = longitude;
        }
        public void setLatitude(double latitude)
        {
            this.latitude = latitude;
        }
        public void setLocationName(string locationName)
        {
            this.locationName = locationName;
        }
        public void setArea(string area)
        {
            this.area = area;
        }
    }
}