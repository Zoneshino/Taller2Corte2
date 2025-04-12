using UnityEngine;
using TMPro;

public class CollectorUIConnector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI starText;

    void Start()
    {
        if (PlayerCollector.instance != null)
        {
            PlayerCollector.instance.AssignUI(scoreText, starText);
        }
        else
        {
            Debug.LogWarning("PlayerCollector no encontrado al conectar UI.");
        }
    }
}