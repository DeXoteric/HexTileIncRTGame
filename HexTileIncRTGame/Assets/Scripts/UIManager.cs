using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text placeTileText;
    [SerializeField] private GameObject cancelPlacementButton;

    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private TextMeshProUGUI incomeText;

    [SerializeField] private TileInfoPanel tileInfoPanel;
    [SerializeField] private ChooseTilePanel chooseTilePanel;

    private void Awake()
    {
        instance = this;
    }

    public void EnableTilePlacementUIElements(string tileName)
    {
        placeTileText.gameObject.SetActive(true);
        cancelPlacementButton.SetActive(true);
        placeTileText.text = "Place " + tileName + " on the board";
    }

    public void DisableTilePlacementUIElements()
    {
        placeTileText.gameObject.SetActive(false);
        cancelPlacementButton.SetActive(false);
    }

    public void UpdateOutputDataDisplay()
    {
        currentMoneyText.text = "Coins: " + IncomeManager.instance.currentMoney.ToString("F2");
        incomeText.text = "Income: " + IncomeManager.instance.totalIncome.ToString("F2") + " Coins per Tick";
    }

    public void EnableTileInfoPanel()
    {
        if (!tileInfoPanel.gameObject.activeInHierarchy)
        {
            tileInfoPanel.gameObject.SetActive(true);
        }
    }

    public void DisableTileInfoPanel()
    {
        tileInfoPanel.gameObject.SetActive(false);
    }

    public void ToggleChooseTilePanel()
    {
        chooseTilePanel.gameObject.SetActive(!chooseTilePanel.gameObject.activeInHierarchy);
    }

    public void DeselectTile() //TODO currently it's a brute force solution, move it, change it
    {
        foreach (var tile in Board.instance.placedTiles)
        {
            tile.tileHighlight.enabled = false;
        }
    }
}