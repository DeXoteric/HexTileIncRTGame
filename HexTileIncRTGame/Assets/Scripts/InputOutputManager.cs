using UnityEngine;

public class InputOutputManager : MonoBehaviour
{
    public static InputOutputManager instance;

    public float currentMoney;

    public float totalIncome;

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
        totalIncome = 0;

        foreach (var tile in HexTileMapManager.instance.placedTiles)
        {
            totalIncome += tile.GetComponent<Tile>().GetTileIncome();
        }
    }

    public void UpdateCurrentResources()
    {
        currentMoney += totalIncome;
    }
}