using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName;
    public Sprite tileSprite;
    public float baseIncomeOutput;
    public float baseCost;

    public float incomeOutput;
    public float bonusMultiplier;
    public int tileTier = 1;

    private void Start()
    {
        GameManager.instance.placedTiles += 1;

        gameObject.name = tileName;

        incomeOutput = GetIncomeOutput();

        RefreshData();
    }

    public float GetIncomeOutput()
    {
        var output = baseIncomeOutput + (tileTier - 1) + (baseIncomeOutput * bonusMultiplier / 100);

        return output;
    }

    public void AddBonusMultiplier()
    {
        bonusMultiplier += 10;
        incomeOutput = GetIncomeOutput();

        RefreshData();
    }

    private void RefreshData()
    {
        InputOutputManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
    }
}