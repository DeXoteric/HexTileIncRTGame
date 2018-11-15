using TMPro;
using UnityEngine;

public class TileInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileNameText;
    [SerializeField] private TextMeshProUGUI tileTierText;
    [SerializeField] private TextMeshProUGUI tileIncomeText;

    private Tile previousSelectedTile;
    private Tile selectedTile;

    public void ShowSelectedTile(Tile selectedTile)
    {
        if (this.selectedTile != null)
        {
            previousSelectedTile = this.selectedTile;
            previousSelectedTile.tileHighlight.enabled = false;
        }
        this.selectedTile = selectedTile;

        Debug.Log(HexTileMapManager.instance.placedTiles.IndexOf(selectedTile));

        selectedTile.tileHighlight.enabled = true;

        UpdateTileInfo();
    }

    private void UpdateTileInfo()
    {
        tileNameText.text = selectedTile.tileName;
        tileTierText.text = selectedTile.tileTier.ToString();
        tileIncomeText.text = selectedTile.GetTileIncome().ToString();
    }
}