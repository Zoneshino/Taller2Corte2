using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    [Header("Componentes de Texto")]
    [SerializeField] private TextMeshProUGUI timerMinutes;
    [SerializeField] private TextMeshProUGUI timerSeconds;
    [SerializeField] private TextMeshProUGUI timerMilliseconds;

    [Header("Configuración")]
    [Tooltip("Si es verdadero, muestra los milisegundos")]
    [SerializeField] private bool showMilliseconds = true;

    private void Start()
    {
        if (timerMinutes == null || timerSeconds == null || timerMilliseconds == null)
        {
            Debug.LogError("Componentes de texto no asignados en el inspector", this);
            enabled = false;
            return;
        }

        if (TimerManager.instance != null)
        {
            TimerManager.instance.StartTimer();
        }
        else
        {
            Debug.LogWarning("No se encontró TimerManager en la escena");
            enabled = false;
        }
    }

    private void Update()
    {
        if (TimerManager.instance == null) return;

        float totalTime = TimerManager.instance.GetTotalTime(); 
        UpdateTimerDisplay(totalTime);
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000f) % 1000);

        timerMinutes.text = minutes.ToString("00");
        timerSeconds.text = seconds.ToString("00");

        if (showMilliseconds)
        {
            timerMilliseconds.text = (milliseconds / 10).ToString("00");
            timerMilliseconds.gameObject.SetActive(true);
        }
        else
        {
            timerMilliseconds.gameObject.SetActive(false);
        }
    }

    public void ResetDisplay()
    {
        timerMinutes.text = "00";
        timerSeconds.text = "00";
        if (timerMilliseconds != null) timerMilliseconds.text = "00";
    }
}