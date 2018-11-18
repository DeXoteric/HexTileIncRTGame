using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static SaveData saveData;

    private void OnEnable()
    {
        LoadGame();
    }

    private void OnDisable()
    {
        SaveGame();
    }

    public void LoadGame()
    {
        var data = PlayerPrefs.GetString("GameData");
        saveData = JsonUtility.FromJson<SaveData>(data);
    }

    public void SaveGame()
    {
        var data = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("GameData", data);
    }

    public static float GetCurrentMoney()
    {
        return saveData.currentMoney;
    }

    public static void SetCurrentMoney(float currentMoney)
    {
        saveData.currentMoney = currentMoney;
    }
}