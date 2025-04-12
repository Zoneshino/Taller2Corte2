using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject creditsPanel;
    public Toggle soundToggle;
    public Text highScoreText;

    void Start()
    {
        instructionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        soundToggle.isOn = PlayerPrefs.GetInt("sound", 1) == 1;

        ShowHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SceneGame1");
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ToggleSound(bool isOn)
    {
        PlayerPrefs.SetInt("sound", isOn ? 1 : 0);
        AudioListener.volume = isOn ? 1 : 0;
    }

    private void ShowHighScore()
    {
        string path = Path.Combine(Application.persistentDataPath, "player_data.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerDataList dataList = JsonUtility.FromJson<PlayerDataList>(json);

            if (dataList != null && dataList.records.Count > 0)
            {
                PlayerData last = dataList.records[dataList.records.Count - 1];

                int minutes = Mathf.FloorToInt(last.time / 60);
                int seconds = Mathf.FloorToInt(last.time % 60);
                string formattedTime = $"{minutes:00}:{seconds:00}";

                highScoreText.text = $"Último Jugador: {last.playerName} - Tiempo: {formattedTime}";
            }
            else
            {
                highScoreText.text = "No hay datos guardados aún.";
            }
        }
        else
        {
            highScoreText.text = "No hay archivo de datos.";
        }
    }
}