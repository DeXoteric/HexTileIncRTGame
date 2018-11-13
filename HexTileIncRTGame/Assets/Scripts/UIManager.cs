using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField] Text placeTileText;
    [SerializeField] GameObject cancelPlacementButton;

    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] TextMeshProUGUI productionText;
    [SerializeField] TextMeshProUGUI incomeText;
    

    private void Awake()
    {
        instance = this;
        UpdateOutputDataDisplay();
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
        foodText.text = "Food: " + InputOutputManager.instance.currentFood + " +" + InputOutputManager.instance.totalFoodOutput + " per tick";
        productionText.text = "Resources: " + InputOutputManager.instance.currentProduction + " +" + InputOutputManager.instance.totalProductionOutput + " per tick";
        incomeText.text = "Income: " + InputOutputManager.instance.currentIncome + " +" + InputOutputManager.instance.totalIncomeOutput + " per tick";

    }
}
