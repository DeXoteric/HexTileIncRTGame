using System.Collections.Generic;

public static class UpgradeLevelDictionary
{
    private static Dictionary<string, int> upgradeLevels = new Dictionary<string, int>();

    public static int GetUpgradeLevel(string id)
    {
        if (upgradeLevels.ContainsKey(id))
        {
            return upgradeLevels[id];
        }
        else
        {
            return 1;
        }
    }

    public static void SetUpgradeLevel(string id, int upgradeLevel)
    {
        if (upgradeLevels.ContainsKey(id))
        {
            upgradeLevels.Remove(id);
            upgradeLevels.Add(id, upgradeLevel);
        }
        else
        {
            upgradeLevels.Add(id, upgradeLevel);
        }
    }

    
}