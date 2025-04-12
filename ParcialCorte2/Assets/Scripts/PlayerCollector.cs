using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    public static PlayerCollector instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI starText;

    private int score = 0;
    private int stars = 0;

    private int greenCount = 0;
    private int purpleCount = 0;
    private int blueCount = 0;
    private int snowflakeCount = 0;

    private float speedBoostDuration = 5f;
    private float boostedSpeed = 10f;
    private float speedBoostEndTime;

    private MovePlayer moveScript;

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
        moveScript = GetComponent<MovePlayer>();
        UpdateUI();
    }

    void Update()
    {
        if (Time.time > speedBoostEndTime)
        {
            moveScript?.ResetSpeed();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            switch (item.type)
            {
                case Item.ItemType.GreenGem:
                    greenCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.PurpleGem:
                    purpleCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.BlueGem:
                    blueCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.Snowflake:
                    snowflakeCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.Star:
                    stars++;
                    break;

                case Item.ItemType.Banana:
                    speedBoostEndTime = Time.time + speedBoostDuration;
                    moveScript?.SetSpeed(boostedSpeed);
                    break;

                case Item.ItemType.Medkit:
                    LifeSystem.instance?.AddLife();
                    break;
            }

            UpdateUI();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LifeSystem.instance?.TakeDamage();
            Debug.Log("Golpe del enemigo");
        }
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (starText != null) starText.text = "Stars: " + stars;
    }

    public int GetItemCount(string type)
    {
        switch (type)
        {
            case "Green": return greenCount;
            case "Purple": return purpleCount;
            case "Blue": return blueCount;
            case "Snowflake": return snowflakeCount;
            case "Star": return stars;
            default: return 0;
        }
    }

    public void AssignUI(TextMeshProUGUI scoreUI, TextMeshProUGUI starUI)
    {
        scoreText = scoreUI;
        starText = starUI;
        UpdateUI();
    }
    public void ResetCounts()
    {
        score = 0;
        stars = 0;
        greenCount = 0;
        purpleCount = 0;
        blueCount = 0;
        snowflakeCount = 0;
        UpdateUI();
    }
}