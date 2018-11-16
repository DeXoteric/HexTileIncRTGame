using UnityEngine;

[CreateAssetMenu(menuName = "New Tile")]
public class NewTileSO : ScriptableObject
{
    

    public string tileName;
    public Sprite tileSprite;
    public float tileBaseIncome;
    public float tileBaseCost;
    public TileType[] tileType;
    public float tileAdjacencyBonus;
}