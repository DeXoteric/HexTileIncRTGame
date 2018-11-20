using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public static IncomeManager instance;

    public float CurrentMoney { get; private set; }
    public float TotalIncome { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CurrentMoney = GameDataManager.instance.GetCurrentMoney();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //TODO remove for final build
        {
            //TODO Increase money cheat hax for testing
        }
    }
}