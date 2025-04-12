using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(" El jugador tocó la púa");

            if (LifeSystem.instance != null)
            {
                LifeSystem.instance.TakeDamage();
            }
        }
    }
}
