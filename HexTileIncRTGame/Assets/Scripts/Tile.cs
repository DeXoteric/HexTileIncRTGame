using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private string tileName;
    [SerializeField] private float baseFoodOutput;
    [SerializeField] private float baseProductionOutput;
    [SerializeField] private float baseIncomeOutput;

    public float foodOutput { get; private set; }
    public float productionOutput { get; private set; }
    public float incomeOutput { get; private set; }

    private void Start()
    {
        GameManager.instance.placedTiles += 1;

        gameObject.name = tileName;

        foodOutput = baseFoodOutput;
        productionOutput = baseProductionOutput;
        incomeOutput = baseIncomeOutput;
        
        InputOutputManager.instance.UpdateTotalOutputs();
        UIManager.instance.UpdateOutputDataDisplay();
    }
}