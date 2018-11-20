using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public TileSO selectedTileSO;

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
        

        Board.instance.placedTiles += 1;

       
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

        
    }

    public void AddGlobalMultiplier(float multiplier)
    {
        globalMultiplier += multiplier;

        
    }

    
}