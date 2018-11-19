using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private TextMeshProUGUI incomeText;

    [HideInInspector] public List<Sprite> tileTypeIcons = new List<Sprite>();

    private void Awake()
    {
        instance = this;

        tileTypeIcons.AddRange(Resources.LoadAll<Sprite>("Sprites/Tile Type Icons"));
    }

    public void UpdateOutputDataDisplay()
    {
        currentMoneyText.text = "Coins: " + IncomeManager.instance.CurrentMoney.ToString("F2");
        incomeText.text = "Income: " + IncomeManager.instance.TotalIncome.ToString("F2") + " Coins per Tick";
    }
}