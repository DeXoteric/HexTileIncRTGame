using System.Linq;
using UnityEngine;

public class TileTypeCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var gameObjectArray = gameObject.GetComponentInParent<Tile>().tileType;
        var collisionArray = other.GetComponentInParent<Tile>().tileType;
        var bonus = other.GetComponentInParent<Tile>().tileAdjacencyBonus;

        if (gameObjectArray.Intersect(collisionArray).Any())
        {
            gameObject.GetComponentInParent<Tile>().AddAdjacencyMultiplier(bonus);
        }
    }
}