using UnityEngine;

public class TagDestroyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Empty Hex")
        {
            Board.instance.activeHexes.Add(other.gameObject);
            other.gameObject.tag = "Active Hex";
        }
        else if (other.gameObject.transform.position  == gameObject.transform.position)
        {
            Board.instance.unusedHexes.Remove(other.gameObject);
            Board.instance.activeHexes.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}