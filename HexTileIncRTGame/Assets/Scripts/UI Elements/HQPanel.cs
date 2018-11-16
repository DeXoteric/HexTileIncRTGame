using TMPro;
using UnityEngine;

public class HQPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileNameText;
    [SerializeField] private TextMeshProUGUI tileTierText;
    [SerializeField] private TextMeshProUGUI tileIncomeText;

    private TileHQ tileHQ;

   

    private void Awake()
    {
        tileHQ = FindObjectOfType<TileHQ>();
    }

    private void Start()
    {
        UpdateTileInfo();
    }


    private void UpdateTileInfo()
    {
        tileNameText.text = tileHQ.tileName;
        tileTierText.text = tileHQ.tileTier.ToString();
        tileIncomeText.text = tileHQ.GetTileIncome().ToString();
    }
}