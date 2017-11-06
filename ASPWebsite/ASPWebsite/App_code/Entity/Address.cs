using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Entity
{
    /// <summary>
    /// Address.
    /// </summary>
    public class Address
    {
        public double longitude;
        public double latitude;
        public string locationName;
        public string area { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ASPWebsite.App_Code.Entity.Address"/> class.
        /// </summary>
        /// <param name="locationName">Location name.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="latitude">Latitude.</param>
        /// <param name="area">Area.</param>
        public Address(string locationName, double longitude, double latitude, string area)
        {
            setLocationName(locationName);
            setLongitude(longitude);
            setLatitude(latitude);
            setArea(area);
        }
        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <returns>The longitude.</returns>
        public double getLongitude()
        {
            return longitude;
        }
        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <returns>The latitude.</returns>
        public double getLatitude()
        {
            return latitude;
        }
        /// <summary>
        /// Gets the name of the location.
        /// </summary>
        /// <returns>The location name.</returns>
        public string getLocationName()
        {
            return locationName;
        }
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns>The area.</returns>
        public string getArea()
        {
            return area;
        }
        /// <summary>
        /// Sets the longitude.
        /// </summary>
        /// <param name="longitude">Longitude.</param>
        private void setLongitude(double longitude)
        {
            this.longitude = longitude;
        }
        /// <summary>
        /// Sets the latitude.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        private void setLatitude(double latitude)
        {
            this.latitude = latitude;
        }
        /// <summary>
        /// Sets the name of the location.
        /// </summary>
        /// <param name="locationName">Location name.</param>
        private void setLocationName(string locationName)
        {
            this.locationName = locationName;
        }
        /// <summary>
        /// Sets the area.
        /// </summary>
        /// <param name="area">Area.</param>
        private void setArea(string area)
        {
            this.area = area;
        }
    }
}