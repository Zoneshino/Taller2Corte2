using UnityEngine;

public class PlayerScenePosition : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.Find("SpawnPoint");

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
            Debug.Log(" Jugador movido al SpawnPoint.");
        }
        else
        {
            Debug.LogWarning(" No se encontró el jugador o el SpawnPoint.");
        }
    }
}