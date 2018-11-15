using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float tickTimer;

    public int placedTiles;

    public bool isNewGame = true;
    public bool rerollTiles = true;
    public bool IsOnMobile { get; private set; }

    private void Awake()
    {
        instance = this;
        CheckIfOnMobile();
    }

    private void Start()
    {
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickTimer);
            IncomeManager.instance.UpdateTotalOutputs();
            IncomeManager.instance.UpdateCurrentResources();
            UIManager.instance.UpdateOutputDataDisplay();
        }
    }

    private void CheckIfOnMobile()
    {
#if UNITY_ANDROID || UNITY_IOS
        IsOnMobile = true;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        IsOnMobile = false;
#endif
    }
}