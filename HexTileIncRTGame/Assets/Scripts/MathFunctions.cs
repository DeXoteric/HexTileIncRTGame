using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions  {

    private const float MULTIPLIER_1_15 = 1.15f;
    private const float MULTIPLIER_1_07 = 1.07f;

    public static float CalculateTileCost(float baseTileCost)
    {
        var placedTiles = GameManager.instance.placedTiles;

        float tileCost = baseTileCost * Mathf.Pow(MULTIPLIER_1_15, placedTiles -1);
        return tileCost;
    }
}
