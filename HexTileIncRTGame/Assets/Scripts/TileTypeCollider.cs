using UnityEngine;

public class TileTypeCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.tag)
        {
            other.GetComponentInParent<Tile>().AddBonusMultiplier();
        }
    }
}