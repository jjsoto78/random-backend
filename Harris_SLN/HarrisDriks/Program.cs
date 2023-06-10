var orangeJuice = new Juice { Name = "Orange Juice", Fruit = "Orange" };
var beer = new Beer { Name = "Budweiser", IsCarbonated = true, Alcohol = 5M };
var soda = new Soda { Name = "Cola", IsCarbonated = true, Brand = "Pepsi" };

var drinks = new List<IDrink> { orangeJuice, beer, soda };

foreach (IDrink drink in drinks)
{
    Console.WriteLine(drink.GetDescription());
}