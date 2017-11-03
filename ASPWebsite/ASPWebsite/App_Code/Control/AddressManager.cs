using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPWebsite.App_Code.Entity;

namespace ASPWebsite.App_Code.Control
{
    public class AddressManager
    {
        private ApiManager apiManager = new ApiManager();

        public Address createNewAddress(string locationName)
        {
            double[] coordinates;
            String area;
            coordinates = apiManager.getCoordinates(locationName);
            area = apiManager.getArea(coordinates[0], coordinates[1]);
            return new Address(locationName, coordinates[0], coordinates[1], area);
        }

    }
}