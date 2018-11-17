using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public static IncomeManager instance;

    public float currentMoney;

    public float totalIncome;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //TODO remove for final build
        {
            UpdateTotalOutputs();
            UpdateCurrentResources();
            UIManager.instance.UpdateOutputDataDisplay();
        }
    }

    public void UpdateTotalOutputs()
    {
        totalIncome = 0;

        foreach (var tile in Board.instance.placedTiles)
        {
            totalIncome += tile.GetComponent<Tile>().GetTileIncome();
        }
    }

    public void UpdateCurrentResources()
    {
        currentMoney += totalIncome;
    }
}