using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private string tileName;

    [SerializeField] private float baseIncomeOutput;

    public float incomeOutput;
    public float bonusMultiplier;
    public int tileTier = 1;

    private void Start()
    {
        GameManager.instance.placedTiles += 1;

        gameObject.name = tileName;

        incomeOutput = GetIncomeOutput();

        InputOutputManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
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
    }
}