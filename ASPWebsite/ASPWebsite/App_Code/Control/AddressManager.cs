using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPWebsite.App_Code.Entity;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// Address manager.
    /// Responsible for managing Address objects.
    /// </summary>
    public class AddressManager
    {
        private ApiManager apiManager = new ApiManager();

        /// <summary>
        /// Creates the new address.
        /// </summary>
        /// <returns>The new address.</returns>
        /// <param name="locationName">Location name.</param>
        public Address createNewAddress(string locationName)
        {
            double[] coordinates;
            String area;
            coordinates = apiManager.getCoordinates(locationName);
            if (coordinates == null)
                return null;
            area = apiManager.getArea(coordinates[0], coordinates[1]);
            return new Address(locationName, coordinates[0], coordinates[1], area);
        }

    }
}