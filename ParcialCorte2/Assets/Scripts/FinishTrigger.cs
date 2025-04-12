using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject finalPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimerManager.instance.StopTimer();
            finalPanel.SetActive(true);
        }
    }
}