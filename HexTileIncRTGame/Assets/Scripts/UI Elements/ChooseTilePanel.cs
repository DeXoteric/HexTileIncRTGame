using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTilePanel : MonoBehaviour
{
    [SerializeField] Button tileButtonOne;
    [SerializeField] Button tileButtonTwo;
    [SerializeField] Button tileButtonThree;

    [SerializeField] private TextMeshProUGUI tileOneNameText;
    [SerializeField] private TextMeshProUGUI tileOneIncomeText;
    [SerializeField] private TextMeshProUGUI tileOneCostText;

    [SerializeField] private TextMeshProUGUI tileTwoNameText;
    [SerializeField] private TextMeshProUGUI tileTwoIncomeText;
    [SerializeField] private TextMeshProUGUI tileTwoCostText;

    [SerializeField] private TextMeshProUGUI tileThreeNameText;
    [SerializeField] private TextMeshProUGUI tileThreeIncomeText;
    [SerializeField] private TextMeshProUGUI tileThreeCostText;

   
    private List<NewTileSO> choosedTilesSO;

    float tileOneCost, tileTwoCost, tileThreeCost;

    private void Update()
    {
        if (tileOneCost <= IncomeManager.instance.currentMoney)
        {
            tileButtonOne.interactable = true;
                
        } else
        {
            tileButtonOne.interactable = false;
                
        }
        if (tileTwoCost <= IncomeManager.instance.currentMoney)
        {
            tileButtonTwo.interactable = true;

        }
        else
        {
            tileButtonTwo.interactable = false;

        }
        if (tileThreeCost <= IncomeManager.instance.currentMoney)
        {
            tileButtonThree.interactable = true;

        }
        else
        {
            tileButtonThree.interactable = false;

        }
    }

    private void OnEnable()
    {
        if (GameManager.instance.rerollTiles)
        {
            choosedTilesSO = new List<NewTileSO>();

            var tilesSO = Board.instance.tilesSO;

            for (int i = 0; i < 3; i++)
            {
                var randomTileSO = tilesSO[Random.Range(0, tilesSO.Count)];
                choosedTilesSO.Add(randomTileSO);
            }

            tileOneCost = MathFunctions.CalculateTileCost(choosedTilesSO[0].tileBaseCost);
            tileTwoCost = MathFunctions.CalculateTileCost(choosedTilesSO[1].tileBaseCost);
            tileThreeCost = MathFunctions.CalculateTileCost(choosedTilesSO[2].tileBaseCost);

            tileOneNameText.text = choosedTilesSO[0].name;
            tileOneIncomeText.text = choosedTilesSO[0].tileBaseIncome.ToString();
            tileOneCostText.text = tileOneCost.ToString();

            tileTwoNameText.text = choosedTilesSO[1].name;
            tileTwoIncomeText.text = choosedTilesSO[1].tileBaseIncome.ToString();
            tileTwoCostText.text = tileTwoCost.ToString();

            tileThreeNameText.text = choosedTilesSO[2].name;
            tileThreeIncomeText.text = choosedTilesSO[2].tileBaseIncome.ToString();
            tileThreeCostText.text = tileThreeCost.ToString();

            GameManager.instance.rerollTiles = false;
        }

    }

    private void OnDisable()
    {
        
        
    }

    public void SelectTileSO(int index)
    {
        Board.instance.selectedTileSO = choosedTilesSO[index];

        Board.instance.ShowActiveHexes();

        UIManager.instance.EnableTilePlacementUIElements(choosedTilesSO[index].name);

        //UIManager.instance.ToggleChooseTilePanel();
    }
}