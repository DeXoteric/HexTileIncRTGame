using UnityEngine;

public class TileTypeCollider : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == collision.tag)
        {
            collision.GetComponentInParent<Tile>().AddBonusMultiplier();
        }
    }
}