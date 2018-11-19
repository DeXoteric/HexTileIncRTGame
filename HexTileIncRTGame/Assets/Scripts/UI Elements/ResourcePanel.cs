using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] protected TileID tileID;
    [SerializeField] protected NewTileSO tileSO;
    [SerializeField] protected Image tileImage;
    [SerializeField] protected TextMeshProUGUI tileNameText;
    [SerializeField] protected TextMeshProUGUI tileTierText;
    [SerializeField] protected TextMeshProUGUI tileIncomeText;
    [SerializeField] protected TextMeshProUGUI tileDescriptionText;
    [SerializeField] protected Image[] icons;
    [SerializeField] protected TileType[] tileType;

    protected int resourceLevel = 1;
    protected float income;

    private void Update()
    {
        tileTierText.text = resourceLevel.ToString();
        tileIncomeText.text = GetTotalIncome().ToString();
    }

    protected void UpdateTileInfo()
    {
        tileImage.sprite = tileSO.tileSprite;

        tileNameText.text = tileSO.tileName;

        resourceLevel = UpgradeLevelDictionary.GetUpgradeLevel(tileID.ToString());
        tileTierText.text = resourceLevel.ToString();

        tileIncomeText.text = GetTotalIncome().ToString();

        ShowIcons();

        tileDescriptionText.text = "Gives " + tileSO.tileAdjacencyBonus.ToString() + "% bonus income to each adjacent tile of same type";
    }

    protected void ShowIcons()
    {
        foreach (var icon in icons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < tileSO.tileType.Length; i++)
        {
            icons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                //if (selectedTile.tileType[i].ToString() == UIManager.instance.tileTypeIcons[j].name)
                if (string.Equals(tileSO.tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    icons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }

    protected float GetTotalIncome()
    {
        income = 0;
        foreach (var tile in Board.instance.placedTiles)

        {
            if (tile.GetComponent<Tile>().tileID == tileID)
            {
                income += tile.GetComponent<Tile>().tileIncome;
                tile.GetComponent<Tile>().RefreshData();
                tile.GetComponent<Tile>().RefreshDataDisplay();
                tile.GetComponentInChildren<TileCavasController>().UpdateTileIncomeInfo();
            }
        }
        UIManager.instance.UpdateOutputDataDisplay();
        
        return income;
    }

    public void Upgrade()
    {
        resourceLevel += 1;
        UpgradeLevelDictionary.SetUpgradeLevel(tileID.ToString(), resourceLevel);
    }
}