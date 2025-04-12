using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && LifeSystem.instance != null)
        {
            LifeSystem.instance.AddLife();
            Destroy(gameObject);
            Debug.Log("?? Corazón recogido");
        }
    }
}
