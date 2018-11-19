using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float tickTimer;

    

    public int prestigeLevel;
    public int placedTiles;

    public int farmAmount;
    public int farmLevel = 1;

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
        
        prestigeLevel = GameDataManager.instance.GetPrestigeLevel();
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
            GameDataManager.instance.SetCurrentMoney(IncomeManager.instance.CurrentMoney);
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