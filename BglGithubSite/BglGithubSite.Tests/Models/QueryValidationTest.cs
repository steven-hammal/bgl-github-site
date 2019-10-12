using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using BglGithubSite.Models;
using System.ComponentModel.DataAnnotations;

namespace BglGithubSite.Tests.Models
{
    public class QueryValidationTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("ThisShouldBeAValidNameExceptForTheFactItIsTooLong")]
        [InlineData("no_non_hyphen_symbols")]
        [InlineData("no--consecutive-hyphens")]
        [InlineData("-no-leading-hyphens")]
        [InlineData("no-trailing-hyphens-")]
        public void UsernameInvalid (string userName)
        {
            var query = new Query
            {
                Username = userName
            };

            ValidateModel(query).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("valid-name")]
        [InlineData("123")]
        [InlineData("valid-123")]
        [InlineData("also-valid-456")]
        public void UsernameValid(string userName)
        {
            var query = new Query
            {
                Username = userName
            };

            ValidateModel(query).Should().BeEmpty();
        }

        // From https://stackoverflow.com/a/4331964
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
