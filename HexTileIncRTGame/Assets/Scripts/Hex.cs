using UnityEngine;

public class Hex : MonoBehaviour
{
    private void OnEnable()
    {
        Board.instance.unusedHexes.Add(gameObject);
    }
}