﻿using UnityEngine;

[CreateAssetMenu(menuName = "New Tile")]
public class TileSO : ScriptableObject
{

    public TileID tileID;
    public string tileName;
    public Sprite tileSprite;
    public float tileBaseIncome;
    public float tileBaseCost;
    public TileType[] tileType;
    public float tileAdjacencyBonus;
}