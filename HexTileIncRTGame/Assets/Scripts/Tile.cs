using UnityEngine;

public class Tile : MonoBehaviour
{
    public NewTileSO selectedTileSO;

    public TileType[] tileType;
    public string tileName;
    public Sprite tileSprite;
    public SpriteRenderer tileHighlight;
    public float tileBaseIncome;
    public float tileBaseCost;

    public int tileTier = 1;
    public float tileIncome;

    public float tileAdjacencyBonus;

    private float adjacencyMultiplier;
    private float globalMultiplier;
    private float totalMultiplier;

    private void Start()
    {
        tileType = selectedTileSO.tileType;
        gameObject.name = selectedTileSO.name;
        tileName = selectedTileSO.tileName;
        tileSprite = selectedTileSO.tileSprite;
        tileBaseIncome = selectedTileSO.tileBaseIncome;
        tileBaseCost = selectedTileSO.tileBaseCost;
        tileAdjacencyBonus = selectedTileSO.tileAdjacencyBonus;

        GetComponent<SpriteRenderer>().sprite = tileSprite;

        IncomeManager.instance.currentMoney -= MathFunctions.CalculateTileCost(tileBaseCost);

        GameManager.instance.placedTiles += 1;

        RefreshData();
        RefreshDataDisplay();
    }

    public float GetTileIncome()
    {
        var output = tileBaseIncome + (tileTier - 1) + (tileBaseIncome * totalMultiplier / 100);

        return output;
    }

    public void AddAdjacencyMultiplier(float multiplier)
    {
        adjacencyMultiplier += multiplier;

        RefreshData();
        RefreshDataDisplay();
    }

    public void AddGlobalMultiplier(float multiplier)
    {
        globalMultiplier += multiplier;

        RefreshData();
        RefreshDataDisplay();
    }

    protected void RefreshData()
    {
        totalMultiplier = adjacencyMultiplier + globalMultiplier;

        tileIncome = GetTileIncome();
    }

    protected void RefreshDataDisplay()
    {
        IncomeManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
    }
}