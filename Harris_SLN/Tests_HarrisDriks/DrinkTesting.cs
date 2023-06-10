
namespace Tests_HarrisDriks;

public class DrinkTesting
{

    [Fact]
    public void JuiceTest()
    {
        // Arrange
        string name = "Apple Juice";
        string fruit = "Apple";
        bool carbonatedShouldBe = false;
        string carbonatedStatus = "not carbonated";
        string descriptionShoulBe = $"{name}, {carbonatedStatus}, made from {fruit}.";

        // Act
        var appleJuice = new DrinkService.Juice { Name = name, Fruit = fruit };

        // Assert
        Assert.Equal(appleJuice.IsCarbonated, carbonatedShouldBe);
        Assert.Equal(appleJuice.Fruit, fruit);
        Assert.Equal(appleJuice.Name, name);
        Assert.Equal(appleJuice.GetDescription(), descriptionShoulBe);
    }

    [Fact]
    public void BeerTest()
    {
        // Arrange
        string name = "Miller";
        decimal alcohol = 5M;
        bool carbonatedShouldBe = true;
        string carbonatedStatus = "carbonated";
        string descriptionShoulBe = $"{name}, {carbonatedStatus}, {alcohol}%.";

        // Act
        var beer = new DrinkService.Beer { Name = name, IsCarbonated = carbonatedShouldBe, Alcohol = alcohol };

        // Assert
        Assert.Equal(beer.IsCarbonated, carbonatedShouldBe);
        Assert.Equal(beer.Alcohol, alcohol);
        Assert.Equal(beer.Name, name);
        Assert.Equal(beer.GetDescription(), descriptionShoulBe);
    }
    
    [Fact]
    public void SodaTest()
    {
        // Arrange
        string name = "7up";
        string brand = "Dr Pepper";
        bool carbonatedShouldBe = true;
        string carbonatedStatus = "carbonated";
        string descriptionShoulBe = $"{brand} {name}, {carbonatedStatus}.";

        // Act
        var soda = new DrinkService.Soda { Name = name, IsCarbonated = true, Brand = brand };

        // Assert
        Assert.Equal(soda.IsCarbonated, carbonatedShouldBe);
        Assert.Equal(soda.Brand, brand);
        Assert.Equal(soda.Name, name);
        Assert.Equal(soda.GetDescription(), descriptionShoulBe);
    }
}