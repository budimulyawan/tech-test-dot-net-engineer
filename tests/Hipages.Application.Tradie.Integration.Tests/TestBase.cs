using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.Integration.Tests
{
    using static Testing;

    public class TestBase
    {

        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
