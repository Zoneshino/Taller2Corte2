using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MovePlayer player = other.GetComponent<MovePlayer>();
            if (player != null)
            {
                player.ResetToStartPosition();
            }
        }
    }
}
