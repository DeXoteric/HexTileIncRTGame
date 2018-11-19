using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileCavasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI incomeText;
    [SerializeField] private Image[] icons;

    private float tileIncome;
    private Tile tile;

    private void Start()
    {
        tile = GetComponentInParent<Tile>();

        UpdateTileIncomeInfo();

        ShowIcons();
    }

    private void Update()
    {
        if (tileIncome != tile.tileIncome)
        {
            UpdateTileIncomeInfo();
        }
    }

    public void UpdateTileIncomeInfo()
    {
        tileIncome = tile.tileIncome;
        incomeText.text = "+" + tileIncome.ToString("F2");
    }

    private void ShowIcons()
    {
        foreach (var icon in icons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < tile.tileType.Length; i++)
        {
            icons[i].gameObject.SetActive(true);

            for (int j = 0; j < UIManager.instance.tileTypeIcons.Count; j++)
            {
                //if (selectedTile.tileType[i].ToString() == UIManager.instance.tileTypeIcons[j].name)
                if (string.Equals(tile.tileType[i].ToString(), UIManager.instance.tileTypeIcons[j].name))
                {
                    icons[i].sprite = UIManager.instance.tileTypeIcons[j];
                }
            }
        }
    }
}