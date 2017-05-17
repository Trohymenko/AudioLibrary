using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BLL.Interfaces;
using BLL.Services;

namespace UnitTests
{
    [TestFixture]
    public class Testing
    {
        GetInfoService service = new GetInfoService("DefaultDb");

         [Test]
        public void GetinfoserviceGetAllTracks_nullfilter_DoesNotThrow()
        {

            Assert.DoesNotThrow(() => service.GetAllTracks());
        }
        [Test]
        public void GetinfoserviceGetallGenres_nullfilter_DoesNotThrow()
        {

            Assert.DoesNotThrow(() => service.GetAllGenres());
        }
        [Test]
        public void GetinfoserviceGetTrackRate_notExistedNameFilter_Throws()
        {

            Assert.Throws<Exception>(() => service.GetTrackRate("Not existed track"));
        }       
    }
}
