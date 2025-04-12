using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPortal : MonoBehaviour
{
    [Header("Nombre exacto de la escena a cargar")]
    public string nextSceneName = "SceneGame2";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador recogió la llave. Cargando " + nextSceneName);

            if (TimerManager.instance != null)
            {
                TimerManager.instance.SwitchToScene2();
            }

            SceneManager.LoadScene(nextSceneName);
        }
    }
}