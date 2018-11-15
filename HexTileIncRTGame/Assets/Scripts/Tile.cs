using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName;
    public Sprite tileSprite;
    public float tileBaseIncome;
    public float tileBaseCost;

    public int tileTier = 1;
    public float tileIncome;
    public float adjacencyMultiplier;
    

    private void Start()
    {
        GameManager.instance.placedTiles += 1;

        gameObject.name = tileName;

        tileIncome = GetTileIncome();

        RefreshData();
    }

    public float GetTileIncome()
    {
        var output = tileBaseIncome + (tileTier - 1) + (tileBaseIncome * adjacencyMultiplier / 100);

        return output;
    }

    public void AddBonusMultiplier()
    {
        adjacencyMultiplier += 10;
        tileIncome = GetTileIncome();

        RefreshData();
    }

    private void RefreshData()
    {
        InputOutputManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
    }
}