using UnityEngine;

public class InputOutputManager : MonoBehaviour
{
    public static InputOutputManager instance;

    public float currentFood;
    public float currentProduction;
    public float currentIncome;

    public float totalFoodOutput;
    public float totalProductionOutput;
    public float totalIncomeOutput;

    private void Awake()
    {
        instance = this;
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateTotalOutputs();
            UpdateCurrentResources();
            UIManager.instance.UpdateOutputDataDisplay();
        }
    }

    public void UpdateTotalOutputs()
    {
        totalFoodOutput = 0;
        totalProductionOutput = 0;
        totalIncomeOutput = 0;

        foreach (var tile in HexTileMapManager.instance.placedTiles)
        {
            totalFoodOutput += tile.GetComponent<Tile>().foodOutput;
            totalProductionOutput += tile.GetComponent<Tile>().productionOutput;
            totalIncomeOutput += tile.GetComponent<Tile>().incomeOutput;
        }
    }

    public void UpdateCurrentResources()
    {
        foreach (var tile in HexTileMapManager.instance.placedTiles)
        {
            currentFood += tile.GetComponent<Tile>().foodOutput;
            currentProduction += tile.GetComponent<Tile>().productionOutput;
            currentIncome += tile.GetComponent<Tile>().incomeOutput;
        }
    }
}