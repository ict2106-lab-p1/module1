namespace LivingLab.Core.Constants;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public static class FuelTypes
{
    public const string FUEL_OIL = "PetroleumProducts";
    public const string FUEL_NATURAL_GAS = "NaturalGas";
    public const string FUEL_COAL = "Coal";
    /**
    Includes solar and wind, but may also include other exotic fuels like waste-to-energy or wood
    Unfortunately, data.gov.sg doesn't provide enough granularity to identify
    So the best we can do is assume all energy sources in "Others" is net-zero carbon
    */
    public const string FUEL_RENEWABLE = "Others";
}
