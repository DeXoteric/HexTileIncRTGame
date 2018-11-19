using UnityEngine;

public class MathFunctions
{
    private const float MULTIPLIER_1_15 = 1.15f;
    private const float MULTIPLIER_1_07 = 1.07f;

    public static float CalculateTileCost(float baseTileCost)
    {
        var placedTiles = GameManager.instance.placedTiles;
        var prestige = GameManager.instance.prestigeLevel;

        float tileCost = baseTileCost * Mathf.Pow(MULTIPLIER_1_15, placedTiles - 1);
        float bonusFromPrestige = tileCost * (prestige - 1) * 10 / 100;
        float totalTileCost = tileCost + bonusFromPrestige;

        return totalTileCost;
    }

    public static float CalculateTileIncome(float baseTileIncome, int tileLevel, float totalMultiplier)
    {
        var prestige = GameManager.instance.prestigeLevel;

        float baseTileIncomeWithTileLevelBonus = baseTileIncome + (tileLevel - 1);
        float tileIncome = baseTileIncomeWithTileLevelBonus + (baseTileIncomeWithTileLevelBonus * totalMultiplier / 100);
        var bonusFromPrestige = tileIncome * (prestige - 1) * 20 / 100;
        var totalIncome = tileIncome + bonusFromPrestige;

        return totalIncome;
    }
}