using LandLord.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LandLord.Tests
{
    public class HausTest
    {
        [Fact]
        public void nameTest()
        {
            Haus haus = new Haus("neu");
            Assert.Equal("neu", haus.Name);
        }
    }
}
