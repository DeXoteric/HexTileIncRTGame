using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{

    public static GameDataManager instance;
    public static SaveData saveData;

    [Header("Default Game Values")]
    [SerializeField] float startingMoney;
    [SerializeField] int startingPrestigeLevel;

    private void OnEnable()
    {
        instance = this;

        if (PlayerPrefs.HasKey("GameData"))
        {
            LoadGame();
        }
        else
        {
            SetDefaultValuesForNewGame();
            SaveGame();
        }
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

    public void HardReset()
    {
        saveData = new SaveData();

        SetDefaultValuesForNewGame();
        SaveGame();

        SceneManager.LoadScene(0);
    }

    public void SoftReset()
    {
        saveData = new SaveData();

        SetDefaultValuesForSoftReset();
        SaveGame();

        SceneManager.LoadScene(0);
    }

    #region Current Money
    public float GetCurrentMoney()
    {
        return saveData.currentMoney;
    }

    public void SetCurrentMoney(float currentMoney)
    {
        saveData.currentMoney = currentMoney;
    }
    #endregion

    #region Prestige Level
    public int GetPrestigeLevel()
    {
        return saveData.prestigeLevel;
    }

    public void SetPrestigeLevel(int prestigeLevel)
    {
        saveData.prestigeLevel = prestigeLevel;
    }
    #endregion

    private void SetDefaultValuesForNewGame()
    {
        SetCurrentMoney(startingMoney);
        SetPrestigeLevel(startingPrestigeLevel);
    }

    private void SetDefaultValuesForSoftReset()
    {
        SetCurrentMoney(startingMoney);
        SetPrestigeLevel(GameManager.instance.prestigeLevel + 1);
    }
}