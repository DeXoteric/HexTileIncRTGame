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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
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
        incomeText.text = "Income: " + InputOutputManager.instance.currentIncome + " +" + InputOutputManager.instance.totalIncomeOutput + " per tick";
    }

    public void EnableTileInfoPanel()
    {
        tileInfoPanel.gameObject.SetActive(true);
    }

    
}