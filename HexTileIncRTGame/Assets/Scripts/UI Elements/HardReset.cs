using UnityEngine;

public class HardReset : MonoBehaviour
{
    public void Reset()
    {
        GameDataManager.instance.HardReset();
    }
}