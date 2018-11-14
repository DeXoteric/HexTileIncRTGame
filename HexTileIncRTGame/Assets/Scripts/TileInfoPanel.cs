using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileInfoPanel : MonoBehaviour {

     public TextMeshProUGUI tileNameText;
    public TextMeshProUGUI tileTierText;
    public TextMeshProUGUI tileIncomeText;

    private Tile selectedTile;

    public void SetSelectedTile(Tile selectedTile)
    {
        this.selectedTile = selectedTile;


        UpdateTileInfo();
    }

    private void UpdateTileInfo()
    {
        tileNameText.text = selectedTile.name;
        tileTierText.text = selectedTile.tileTier.ToString();
        tileIncomeText.text = selectedTile.GetIncomeOutput().ToString();
    }
    

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
