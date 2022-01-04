using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category With Negative Id Value")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id. Value must be higher than 0");
        }
        [Fact(DisplayName ="Create Category With Short Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With Empty Name")]
        public void CreateCategory_EmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}