using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public NewTileSO selectedTileSO;

    public TileID tileID;
    public TileType[] tileType;
    public string tileName;
    public Sprite tileSprite { get; private set; }
    public SpriteRenderer tileHighlight;
    public float tileBaseIncome;
    public float tileBaseCost { get; private set; }

    public int tileLevel { get; protected set; }
    public float tileIncome { get; private set; }

    public float TileAdjacencyBonus { get; private set; }

    private float adjacencyMultiplier;
    private float globalMultiplier;
    private float totalMultiplier;

    private void Start()
    {
        tileID = selectedTileSO.tileID;
        tileType = selectedTileSO.tileType;
        gameObject.name = selectedTileSO.name;
        tileName = selectedTileSO.tileName;
        tileSprite = selectedTileSO.tileSprite;
        tileBaseIncome = selectedTileSO.tileBaseIncome;
        tileBaseCost = selectedTileSO.tileBaseCost;
        TileAdjacencyBonus = selectedTileSO.tileAdjacencyBonus;
        tileLevel = UpgradeLevelDictionary.GetUpgradeLevel(tileID.ToString());
        GetComponent<SpriteRenderer>().sprite = tileSprite;

        var tileCost = MathFunctions.CalculateTileCost(tileBaseCost);
        IncomeManager.instance.RemoveFromCurrentMoney(tileCost);

        GameManager.instance.placedTiles += 1;

        RefreshData();
        RefreshDataDisplay();
    }

    public float GetTileIncome()
    {
        tileLevel = UpgradeLevelDictionary.GetUpgradeLevel(tileID.ToString());

        var totalIncome = MathFunctions.CalculateTileIncome(tileBaseIncome, tileLevel, totalMultiplier);

        return totalIncome;
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

    public void RefreshData()
    {
        totalMultiplier = adjacencyMultiplier + globalMultiplier;

        tileIncome = GetTileIncome();
    }

    public void RefreshDataDisplay()
    {
        IncomeManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
    }
}