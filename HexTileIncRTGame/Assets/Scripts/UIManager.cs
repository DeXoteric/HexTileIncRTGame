using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private TextMeshProUGUI incomeText;

    public List<Sprite> tileTypeIcons = new List<Sprite>();

    private void Awake()
    {
        instance = this;

        tileTypeIcons.AddRange(Resources.LoadAll<Sprite>("Sprites/Tile Type Icons"));
    }

    public void UpdateOutputDataDisplay()
    {
        currentMoneyText.text = "Coins: " + IncomeManager.instance.currentMoney.ToString("F2");
        incomeText.text = "Income: " + IncomeManager.instance.totalIncome.ToString("F2") + " Coins per Tick";
    }
}