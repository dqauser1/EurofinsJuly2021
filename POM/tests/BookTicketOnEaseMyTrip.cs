using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace POM.tests
{
    class BookTicketOnEaseMyTrip
    {
        [Category("POM")]
        [Test]
        public void When_I_Enter_Valid_Info_I_Can_See_Flight_Options()
        {
            var homepage = new EaseMyTripHomePage();
            //homepage.EnterFlightInfo("Delhi", "Mumbai", "10/07/2021", "17/07/2021");
            homepage.SetDepartureCity("Bangalore");
            homepage.SetArrivalCity("Kolkata");
            homepage.SetDepartDate("10/07/2021");
            homepage.Search();

            var resultspage = new EaseMyTripFlightResultsPage();
            float price = resultspage.GetPriceOfFirstOption();
            Assert.That(price, Is.LessThan(10000));
            resultspage.BookFirstOption();
        }

    }
}
