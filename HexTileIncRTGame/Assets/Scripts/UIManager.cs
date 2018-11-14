using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text placeTileText;
    [SerializeField] private GameObject cancelPlacementButton;

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
        incomeText.text = "Income: " + InputOutputManager.instance.currentIncome.ToString("F2") + " +" + InputOutputManager.instance.totalIncomeOutput.ToString("F2") + " per tick";
    }

    public void ToggleTileInfoPanel()
    {
        tileInfoPanel.gameObject.SetActive(!tileInfoPanel.gameObject.activeInHierarchy);
    }

    public void ToggleChooseTilePanel()
    {
        chooseTilePanel.gameObject.SetActive(!chooseTilePanel.gameObject.activeInHierarchy);
    }
}