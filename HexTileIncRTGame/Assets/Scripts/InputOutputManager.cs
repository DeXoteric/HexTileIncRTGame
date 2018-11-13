using UnityEngine;

public class InputOutputManager : MonoBehaviour
{
    public static InputOutputManager instance;

    public float currentIncome;

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
        totalIncomeOutput = 0;

        foreach (var tile in HexTileMapManager.instance.placedTiles)
        {
            totalIncomeOutput += tile.GetComponent<Tile>().GetIncomeOutput();
        }
    }

    public void UpdateCurrentResources()
    {
        currentIncome += totalIncomeOutput;
    }
}