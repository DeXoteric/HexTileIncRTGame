using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileInfoPanel : MonoBehaviour
{
    [SerializeField] private Image tileImage;
    [SerializeField] private TextMeshProUGUI tileNameText;
    [SerializeField] private TextMeshProUGUI tileTierText;
    [SerializeField] private TextMeshProUGUI tileIncomeText;
    [SerializeField] private TextMeshProUGUI tileTypeText;
    [SerializeField] private TextMeshProUGUI tileDescriptionText;
    [SerializeField] private Image[] icons;

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
       

        selectedTile.tileHighlight.enabled = true;

        UpdateTileInfo();
    }

    private void UpdateTileInfo()
    {
        tileImage.sprite = selectedTile.tileSprite;

        tileNameText.text = selectedTile.tileName;

        tileTierText.text = selectedTile.tileLevel.ToString();

        tileIncomeText.text = selectedTile.GetTileIncome().ToString();

        tileTypeText.text = "Type: ";
        for (int i = 0; i < selectedTile.tileType.Length - 1; i++)
        {
            tileTypeText.text += selectedTile.tileType[i];
            tileTypeText.text += " / ";
        }
        tileTypeText.text += selectedTile.tileType[selectedTile.tileType.Length - 1];

        ShowIcons();

        tileDescriptionText.text = "Gives " + selectedTile.TileAdjacencyBonus.ToString() + "% bonus income to each adjacent tile of same type";
    }

    private void ShowIcons()
    {
        foreach (var icon in icons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < selectedTile.tileType.Length; i++)
        {
            icons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                //if (selectedTile.tileType[i].ToString() == UIManager.instance.tileTypeIcons[j].name)
                if (string.Equals(selectedTile.tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    icons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }
}