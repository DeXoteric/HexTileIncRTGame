using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTilePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileOneNameText;
    [SerializeField] private TextMeshProUGUI tileOneIncomeText;
    [SerializeField] private TextMeshProUGUI tileOneCostText;

    [SerializeField] private TextMeshProUGUI tileTwoNameText;
    [SerializeField] private TextMeshProUGUI tileTwoIncomeText;
    [SerializeField] private TextMeshProUGUI tileTwoCostText;

    [SerializeField] private TextMeshProUGUI tileThreeNameText;
    [SerializeField] private TextMeshProUGUI tileThreeIncomeText;
    [SerializeField] private TextMeshProUGUI tileThreeCostText;

    [SerializeField] private List<NewTileSO> tilesSO;
    private List<NewTileSO> choosedTilesSO;

    public NewTileSO tileOneSO;
    public NewTileSO tileTwoSO;
    public NewTileSO tileThreeSO;

    private void OnEnable()
    {
        if (GameManager.instance.rerollTiles)
        {
            choosedTilesSO = new List<NewTileSO>();

            for (int i = 0; i < 3; i++)
            {
                var randomTileSO = tilesSO[Random.Range(0, tilesSO.Count)];
                choosedTilesSO.Add(randomTileSO);
            }

            tileOneSO = choosedTilesSO[0];
            tileTwoSO = choosedTilesSO[1];
            tileThreeSO = choosedTilesSO[2];

            tileOneNameText.text = tileOneSO.name;
            tileOneIncomeText.text = tileOneSO.tileBaseIncome.ToString();
            tileOneCostText.text = tileOneSO.tileBaseCost.ToString();

            tileTwoNameText.text = tileTwoSO.name;
            tileTwoIncomeText.text = tileTwoSO.tileBaseIncome.ToString();
            tileTwoCostText.text = tileTwoSO.tileBaseCost.ToString();

            tileThreeNameText.text = tileThreeSO.name;
            tileThreeIncomeText.text = tileThreeSO.tileBaseIncome.ToString();
            tileThreeCostText.text = tileThreeSO.tileBaseCost.ToString();

            GameManager.instance.rerollTiles = false;
        }

        Debug.Log("1");
    }

    private void OnDisable()
    {
        GameManager.instance.rerollTiles = true;
        Debug.Log("2");
    }

    public void SelectTileSO(int index)
    {
        HexTileMapManager.instance.selectedTileSO = choosedTilesSO[index];

        HexTileMapManager.instance.ShowActiveHexes();

        UIManager.instance.EnableTilePlacementUIElements(choosedTilesSO[index].name);

        UIManager.instance.ToggleChooseTilePanel();
    }
}