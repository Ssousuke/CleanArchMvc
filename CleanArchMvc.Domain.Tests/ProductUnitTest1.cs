using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Smart TV", "TV Description", 2000, 10, "test-product.jpg");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Smart TV", "TV Description", 2000, 10, "test-product.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "TV", "TV Description", 2000, 10, "test-product.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, to short minimum 3 characters");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(1, "TV Smart", "TV Description", 2000, 10,
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
            " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
            " when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
            "It has survived not only five centuries, but also the leap into electronic typesetting, " +
            "remaining essentially unchanged. It was popularised in the 1960s with the release of " +
            "Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing" +
            " software like Aldus PageMaker including versions of Lorem Ipsum.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("invalid image name, to long, maximum is 250 character");
    }

    [Theory]
    [InlineData(-10)]
    public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
    {
        Action action = () => new Product(1, "TV Smart", "TV Description", 2000, value, "test-product.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }

    [Theory]
    [InlineData(-10)]
    public void CreateProduct_InvalidPriceValue_DomainExceptionNegativeValue(int value)
    {
        Action action = () => new Product(1, "TV Smart", "TV Description", value, 10, "test-product.jpg");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "TV", "TV Description", 2000, 10, null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }
}