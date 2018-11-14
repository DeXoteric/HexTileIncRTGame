using UnityEngine;

public class TagDestroyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Empty Hex")
        {
            HexTileMapManager.instance.activeHexes.Add(collision.gameObject);
            collision.gameObject.tag = "Active Hex";
        }
        else if (collision.gameObject.transform.position  == gameObject.transform.position)
        {
            HexTileMapManager.instance.unusedHexes.Remove(collision.gameObject);
            HexTileMapManager.instance.activeHexes.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}