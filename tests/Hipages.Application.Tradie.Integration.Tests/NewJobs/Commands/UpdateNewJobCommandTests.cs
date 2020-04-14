using FluentAssertions;
using Hipages.Application.Tradie.NewJobs.Commands.UpdateNewJob;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hipages.Application.Tradie.Integration.Tests.NewJobs.Commands
{
    using static Testing;

    public class UpdateNewJobCommandTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new UpdateNewJobCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
    }
}
