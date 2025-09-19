using Booking.Domain.DomainService;
using Booking.Domain.Exceptions;
using Moq;

namespace Booking.Domain.Test.BookingTests;

public class UpdateStartSlutTests
{
    [SetUp]
    public void Setup()
    {
    }


    // [TestCase("2025-01-02", "2025-01-03", "2025-01-01")] // Parameteriseret test
    [TestCase("2025-01-02", "2025-01-03")]
    public void Given__StartTid_Is_In_The_Past__Then__Throw__ValidationException(string startStr,
        string slutStr) //string nowStr)
    {
        // Arrange

        var start = DateTime.Parse(startStr);
        var slut = DateTime.Parse(slutStr);
        var bookingOverlapCheckMock = new Mock<IBookingOverlapCheck>();
        // https://stackoverflow.com/questions/7827053/moq-mock-method-with-out-specifying-input-parameter
        bookingOverlapCheckMock
            .Setup(s => s.HasOverlap(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int?>()))
            .Returns(false);

        var sut = new BookingTestFixture() as Entity.Booking;

        // Act & Assert
        Assert.Throws<ValidationException>(() => sut.UpdateStartSlut(start, slut, bookingOverlapCheckMock.Object));
    }


    [TestCase("2025-09-19", "2025-09-20")]
    public void Given__StartTid_Is_In_The_Future_And_SlutTid_GT_StartTid_Then__Booking_Is_Updated(string startStr,
        string slutStr) //string nowStr)
    {
        // Arrange

        var start = DateTime.Parse(startStr);
        var slut = DateTime.Parse(slutStr);
        var bookingOverlapCheckMock = new Mock<IBookingOverlapCheck>();
        // https://stackoverflow.com/questions/7827053/moq-mock-method-with-out-specifying-input-parameter
        bookingOverlapCheckMock
            .Setup(s => s.HasOverlap(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int?>()))
            .Returns(false);

        var sut = new BookingTestFixture() as Entity.Booking;

        // Act
        sut.UpdateStartSlut(start, slut, bookingOverlapCheckMock.Object);

        // Assert
        Assert.That(sut.StartTid, Is.EqualTo(start));
        Assert.That(sut.SlutTid, Is.EqualTo(slut));
    }
}

public class BookingTestFixture : Entity.Booking
{
    //public new DateTime StartTid
    //{
    //    get => base.StartTid;
    //    set => SlutTid = value;
    //}
}