using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTilePanel : MonoBehaviour
{
    [Header("Tile 1")]
    [SerializeField] private Button tileButtonOne;
    [SerializeField] private TextMeshProUGUI tileOneNameText;
    [SerializeField] private TextMeshProUGUI tileOneIncomeText;
    [SerializeField] private TextMeshProUGUI tileOneCostText;
    [SerializeField] private TextMeshProUGUI tileOneDescriptionText;
    [SerializeField] private Image[] tileOneIcons;

    [Header("Tile 2")]
    [SerializeField] private Button tileButtonTwo;
    [SerializeField] private TextMeshProUGUI tileTwoNameText;
    [SerializeField] private TextMeshProUGUI tileTwoIncomeText;
    [SerializeField] private TextMeshProUGUI tileTwoCostText;
    [SerializeField] private TextMeshProUGUI tileTwoDescriptionText;
    [SerializeField] private Image[] tileTwoIcons;

    [Header("Tile 3")]
    [SerializeField] private Button tileButtonThree;
    [SerializeField] private TextMeshProUGUI tileThreeNameText;
    [SerializeField] private TextMeshProUGUI tileThreeIncomeText;
    [SerializeField] private TextMeshProUGUI tileThreeCostText;
    [SerializeField] private TextMeshProUGUI tileThreeDescriptionText;
    [SerializeField] private Image[] tileThreeIcons;

    private List<NewTileSO> choosedTilesSO;

    private float tileOneCost, tileTwoCost, tileThreeCost;

    private void Update()
    {
        if (tileOneCost <= IncomeManager.instance.CurrentMoney)
        {
            tileButtonOne.interactable = true;
        }
        else
        {
            tileButtonOne.interactable = false;
        }
        if (tileTwoCost <= IncomeManager.instance.CurrentMoney)
        {
            tileButtonTwo.interactable = true;
        }
        else
        {
            tileButtonTwo.interactable = false;
        }
        if (tileThreeCost <= IncomeManager.instance.CurrentMoney)
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

            tileOneNameText.text = choosedTilesSO[0].tileName;
            tileOneIncomeText.text = "Base income: +" + choosedTilesSO[0].tileBaseIncome.ToString();
            tileOneCostText.text = "Cost: " + tileOneCost.ToString("F2");
            tileOneDescriptionText.text = "Gives " + choosedTilesSO[0].tileAdjacencyBonus.ToString() + "% bonus income to each adjacent tile of same type";
            ShowIconsForTileOne();

            tileTwoNameText.text = choosedTilesSO[1].tileName;
            tileTwoIncomeText.text = "Base income: +" + choosedTilesSO[1].tileBaseIncome.ToString();
            tileTwoCostText.text = "Cost: " + tileTwoCost.ToString("F2");
            tileTwoDescriptionText.text = "Gives " + choosedTilesSO[1].tileAdjacencyBonus.ToString() + "% bonus income to each adjacent tile of same type";
            ShowIconsForTileTwo();

            tileThreeNameText.text = choosedTilesSO[2].tileName;
            tileThreeIncomeText.text = "Base income: +" + choosedTilesSO[2].tileBaseIncome.ToString();
            tileThreeCostText.text = "Cost: " + tileThreeCost.ToString("F2");
            tileThreeDescriptionText.text = "Gives " + choosedTilesSO[2].tileAdjacencyBonus.ToString() + "% bonus income to each adjacent tile of same type";
            ShowIconsForTileThree();

            GameManager.instance.rerollTiles = false;
        }
    }

    public void SelectTileSO(int index)
    {
        Board.instance.selectedTileSO = choosedTilesSO[index];

        //Board.instance.ShowActiveHexes();
   
        
    }

    private void ShowIconsForTileOne()
    {
        foreach (var icon in tileOneIcons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < choosedTilesSO[0].tileType.Length; i++)
        {
            tileOneIcons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                if (string.Equals(choosedTilesSO[0].tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    tileOneIcons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }

    private void ShowIconsForTileTwo()
    {
        foreach (var icon in tileTwoIcons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < choosedTilesSO[1].tileType.Length; i++)
        {
            tileTwoIcons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                if (string.Equals(choosedTilesSO[1].tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    tileTwoIcons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }

    private void ShowIconsForTileThree()
    {
        foreach (var icon in tileThreeIcons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < choosedTilesSO[2].tileType.Length; i++)
        {
            tileThreeIcons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                if (string.Equals(choosedTilesSO[2].tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    tileThreeIcons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }
}