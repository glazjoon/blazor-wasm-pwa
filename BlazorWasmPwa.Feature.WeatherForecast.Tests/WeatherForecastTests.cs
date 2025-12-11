namespace BlazorWasmPwa.Feature.WeatherForecast.Tests;

[TestFixture]
public class WeatherForecastTests
{
    [Test]
    public void Create_Returns_ValidInstance_When_InputsAreValid()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var temperatureC = 25;

        // Act
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Assert
        Assert.That(forecast, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(forecast.Date, Is.EqualTo(date));
            Assert.That(forecast.TemperatureC, Is.EqualTo(temperatureC));
        }
    }

    [Test]
    public void Create_Throws_ArgumentOutOfRangeException_When_TemperatureC_Is_BelowMinimum()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var temperatureC = -91;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => WeatherForecast.Create(date, temperatureC));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.ParamName, Is.EqualTo("temperatureC"));
            Assert.That(ex.Message, Does.Contain("Temperature must be between -90°C and 60°C"));
        }
    }

    [Test]
    public void Create_Throws_ArgumentOutOfRangeException_When_TemperatureC_Is_AboveMaximum()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var temperatureC = 61;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => WeatherForecast.Create(date, temperatureC));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.ParamName, Is.EqualTo("temperatureC"));
            Assert.That(ex.Message, Does.Contain("Temperature must be between -90°C and 60°C"));
        }
    }

    [TestCase(-90)]
    [TestCase(0)]
    [TestCase(30)]
    [TestCase(60)]
    public void Create_Returns_ValidInstance_When_TemperatureC_Is_WithinValidRange(int temperatureC)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        // Act
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Assert
        Assert.That(forecast.TemperatureC, Is.EqualTo(temperatureC));
    }

    [Test]
    public void Create_Throws_ArgumentException_When_Date_Is_InThePast()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
        var temperatureC = 25;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => WeatherForecast.Create(date, temperatureC));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.ParamName, Is.EqualTo("date"));
            Assert.That(ex.Message, Does.Contain("Forecast date cannot be in the past"));
        }
    }

    [Test]
    public void Create_Returns_ValidInstance_When_Date_Is_Today()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today);
        var temperatureC = 25;

        // Act
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Assert
        Assert.That(forecast.Date, Is.EqualTo(date));
    }

    [Test]
    public void Create_Returns_ValidInstance_When_Date_Is_InTheFuture()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        var temperatureC = 25;

        // Act
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Assert
        Assert.That(forecast.Date, Is.EqualTo(date));
    }

    [TestCase(0, 32)]
    [TestCase(10, 50)]
    [TestCase(20, 68)]
    [TestCase(30, 86)]
    [TestCase(-10, 15)]
    public void Property_TemperatureF_HasCorrectValue_When_TemperatureC_IsSet(int temperatureC,
        int expectedTemperatureF)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Act
        var actualTemperatureF = forecast.TemperatureF;

        // Assert
        Assert.That(actualTemperatureF, Is.EqualTo(expectedTemperatureF));
    }

    [Test]
    public void TemperatureCategory_Returns_Freezing_When_TemperatureC_IsBelowZero()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, -5);

        // Act
        var category = forecast.TemperatureCategory;

        // Assert
        Assert.That(category, Is.EqualTo("Freezing"));
    }

    [TestCase(0)]
    [TestCase(5)]
    [TestCase(9)]
    public void TemperatureCategory_Returns_Cold_When_TemperatureC_IsBetweenZeroAndTen(int temperatureC)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Act
        var category = forecast.TemperatureCategory;

        // Assert
        Assert.That(category, Is.EqualTo("Cold"));
    }

    [TestCase(10)]
    [TestCase(15)]
    [TestCase(19)]
    public void TemperatureCategory_Returns_Mild_When_TemperatureC_IsBetweenTenAndTwenty(int temperatureC)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Act
        var category = forecast.TemperatureCategory;

        // Assert
        Assert.That(category, Is.EqualTo("Mild"));
    }

    [TestCase(20)]
    [TestCase(25)]
    [TestCase(29)]
    public void TemperatureCategory_Returns_Warm_When_TemperatureC_IsBetweenTwentyAndThirty(int temperatureC)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Act
        var category = forecast.TemperatureCategory;

        // Assert
        Assert.That(category, Is.EqualTo("Warm"));
    }

    [TestCase(30)]
    [TestCase(40)]
    [TestCase(60)]
    public void TemperatureCategory_Returns_Hot_When_TemperatureC_IsThirtyOrAbove(int temperatureC)
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var forecast = WeatherForecast.Create(date, temperatureC);

        // Act
        var category = forecast.TemperatureCategory;

        // Assert
        Assert.That(category, Is.EqualTo("Hot"));
    }
}