using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;

    public Image[] hearts;
    [Range(0, 5)] public int currentHealth = 5;
    private int maxHealth = 5;

    public GameObject floatingHeartPrefab;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();
        }

        Debug.Log($" Vida actual: {currentHealth}");

        if (currentHealth == 1 && !FloatingHeartExists())
        {
            SpawnFloatingHeart();
        }

        if (currentHealth <= 0)
        {
            Debug.Log(" ¡Game Over!");
        }
    }

    public void AddLife()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHearts();
        }
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }

    private void SpawnFloatingHeart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && floatingHeartPrefab != null)
        {
            Vector3 spawnPos = player.transform.position;
            Instantiate(floatingHeartPrefab, spawnPos, Quaternion.identity);
            Debug.Log(" Corazón flotante instanciado en posición fija.");
        }
    }

    public void AssignHeartUI(Image[] newHearts)
    {
        hearts = newHearts;
        UpdateHearts();
    }

    private bool FloatingHeartExists()
    {
        return GameObject.FindObjectOfType<FloatingHeart>() != null;
    }
}
