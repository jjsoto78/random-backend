namespace DrinkService;
public abstract class Drink : IDrink
{
    string _Name = string.Empty;
    bool _IsCarbonated = false;
    public string Name { get => _Name; set => _Name = value; }
    public bool IsCarbonated { get => _IsCarbonated; set => _IsCarbonated = value; }
    public abstract string GetDescription();
}

// base type encapsulates everything common to hierarchy, and should not change
interface IDrink
{
    public string Name { get; set; }
    public bool IsCarbonated { get; set; }

    // so that derived types can provide implementation
    public abstract string GetDescription();
}

public class Juice : Drink, IJuice
{
    string _Fruit = string.Empty;
    public string Fruit { get => _Fruit; set => _Fruit = value; }

    public override string GetDescription()
    {
        string carbonatedStatus = IsCarbonated ? "carbonated" : "not carbonated";
        return $"{Name}, {carbonatedStatus}, made from {Fruit}.";
    }
}
public class Beer : Drink, IAlcoholDrink
{
    decimal _Alcohol = 0.0M;
    const decimal MAX_ALCOHOL = 80M;
    const decimal MIN_ALCOHOL = 1M;
    public decimal Alcohol { get => _Alcohol; set => _Alcohol = validateAlcoholContent(value); }

    private decimal validateAlcoholContent(decimal value)
    {
        if (value < MIN_ALCOHOL) value = MIN_ALCOHOL;
        if (value > MAX_ALCOHOL) value = MAX_ALCOHOL;

        return value;
    }
    public override string GetDescription()
    {
        string carbonatedStatus = IsCarbonated ? "carbonated" : "not carbonated";
        return $"{Name}, {carbonatedStatus}, {Alcohol}%.";
    }
}
public class Soda : Drink, ISoda
{
    string _Brand = string.Empty;
    public string Brand { get => _Brand; set => _Brand = value; }

    public override string GetDescription()
    {
        string carbonatedStatus = IsCarbonated ? "carbonated" : "not carbonated";
        return $"{Brand} {Name}, {carbonatedStatus}.";
    }
}

interface IJuice
{
    public string Fruit { get; set; }
}

interface IAlcoholDrink
{
    public decimal Alcohol { get; set; }
}
interface ISoda
{
    public string Brand { get; set; }
}
