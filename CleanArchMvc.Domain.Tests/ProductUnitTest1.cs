using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName="Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        
        [Fact(DisplayName = "Create Product With Description Name")]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Prod", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Negative Id")]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id. Value must be higher than 0");
        }

        [Fact(DisplayName = "Create Product With Image too long Id")]
        public void CreateProduct_WithImageNameTooLong_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image too looooooooooonnnnnnnnnngggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggglooooooooooonnnnnnnnnngggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggglooooooooooonnnnnnnnnngggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Empty Value Image Name")]
        public void CreateProduct_WithEmptyValueImageName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create Product With Negative Stock")]
        [InlineData(-5)]
        public void CreateProduct_WithNegativeStock_DomainExceptionInvalidId(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "image name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Theory(DisplayName = "Create Product With Negative Price")]
        [InlineData(-5)]
        public void CreateProduct_WithNegativePrice_DomainExceptionInvalidId(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", value, 99, "image name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }
    }
}
