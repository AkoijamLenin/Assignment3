using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("Game Saved: " + path);
    }

    public static GameData LoadGame()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);
        }
        Debug.LogWarning("No save file found!");
        return null;
    }

    public static void DeleteSave()
    {
        if (File.Exists(path)) File.Delete(path);
    }
}
