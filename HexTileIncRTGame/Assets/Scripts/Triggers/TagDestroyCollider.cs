using UnityEngine;

public class TagDestroyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Empty Hex")
        {
            Board.instance.activeHexes.Add(collision.gameObject);
            collision.gameObject.tag = "Active Hex";
        }
        else if (collision.gameObject.transform.position  == gameObject.transform.position)
        {
            Board.instance.unusedHexes.Remove(collision.gameObject);
            Board.instance.activeHexes.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}