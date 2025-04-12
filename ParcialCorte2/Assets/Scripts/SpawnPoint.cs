using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScenePositioner : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject spawnPoint = GameObject.Find("SpawnPoint");

            if (player != null && spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
            }
            else
            {
                Debug.LogWarning("No se encontró el jugador o el SpawnPoint en la escena.");
            }
        }
    }
}