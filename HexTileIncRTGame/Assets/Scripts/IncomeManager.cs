using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public static IncomeManager instance;

    public float CurrentMoney { get; private set; }
    public float TotalIncome { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CurrentMoney = GameDataManager.instance.GetCurrentMoney();
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
        TotalIncome = 0;

        foreach (var tile in Board.instance.placedTiles)
        {
            TotalIncome += tile.GetComponent<Tile>().GetTileIncome();
        }
    }

    public void UpdateCurrentResources()
    {
        CurrentMoney += TotalIncome;
    }

    public void RemoveFromCurrentMoney(float moneyToPay)
    {
        CurrentMoney -= moneyToPay;
    }
}