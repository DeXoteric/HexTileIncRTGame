using TMPro;
using UnityEngine;

public class TileInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileNameText;
    [SerializeField] private TextMeshProUGUI tileTierText;
    [SerializeField] private TextMeshProUGUI tileIncomeText;

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
}