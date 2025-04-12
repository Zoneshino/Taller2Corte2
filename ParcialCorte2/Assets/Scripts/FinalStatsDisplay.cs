using UnityEngine;
using TMPro;
using System.IO;

public class FinalStatsDisplay : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField nameInput;
    public TMP_Text timeText;
    public TMP_Text itemsText;

    [Header("Datos del Jugador")]
    private float totalTime;
    private int greenGem;
    private int purpleGem;
    private int blueGem;
    private int snowflake;
    private int star;

    void OnEnable()
    {
        UpdateStatsDisplay();
    }

    private void UpdateStatsDisplay()
    {
        totalTime = TimerManager.instance.GetTotalTime();
        string formattedTime = FormatTime(totalTime);
        timeText.text = $"Tiempo Total: {formattedTime}";

        PlayerCollector collector = FindObjectOfType<PlayerCollector>();
        if (collector != null)
        {
            greenGem = collector.GetItemCount("Green");
            purpleGem = collector.GetItemCount("Purple");
            blueGem = collector.GetItemCount("Blue");
            snowflake = collector.GetItemCount("Snowflake");
            star = collector.GetItemCount("Star");

            itemsText.text =
                $"Gema verde: {greenGem}\n" +
                $"Gema morada: {purpleGem}\n" +
                $"Gema azul: {blueGem}\n" +
                $"Copo de nieve: {snowflake}\n" +
                $"Estrella: {star}";
        }
        else
        {
            Debug.LogWarning("No se encontró PlayerCollector en la escena");
            itemsText.text = "No se encontraron datos de colección";
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return $"{minutes:00}:{seconds:00}";
    }

    public void SaveData()
    {
        if (string.IsNullOrWhiteSpace(nameInput.text))
        {
            Debug.LogWarning("Por favor ingresa un nombre válido");
            return;
        }

        PlayerData data = new PlayerData
        {
            playerName = nameInput.text.Trim(),
            time = totalTime,
            greenGem = greenGem,
            purpleGem = purpleGem,
            blueGem = blueGem,
            snowflake = snowflake,
            star = star,
            timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        string path = Path.Combine(Application.persistentDataPath, "player_data.json");

        try
        {
            PlayerDataList dataList = File.Exists(path) ?
                JsonUtility.FromJson<PlayerDataList>(File.ReadAllText(path)) :
                new PlayerDataList();

            dataList.records.Add(data);

            string json = JsonUtility.ToJson(dataList, true);
            File.WriteAllText(path, json);

            Debug.Log($"Datos guardados exitosamente en: {path}");
            Debug.Log($"Total de registros: {dataList.records.Count}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al guardar datos: {e.Message}");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public float time;
    public int greenGem;
    public int purpleGem;
    public int blueGem;
    public int snowflake;
    public int star;
    public string timestamp;
}

[System.Serializable]
public class PlayerDataList
{
    public System.Collections.Generic.List<PlayerData> records = new System.Collections.Generic.List<PlayerData>();
}