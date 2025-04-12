using UnityEngine;

public class FloatingHeart : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;
    public float minDistanceFromPlayer = 2f;

    private float direction = 1f;
    private Camera mainCamera;
    private float cameraWidth;
    private float yHeight;

    void Start()
    {
        mainCamera = Camera.main;

        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;
        cameraWidth = halfWidth;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            yHeight = player.transform.position.y;

            float playerX = player.transform.position.x;
            float randomX;

            do
            {
                randomX = Random.Range(
                    mainCamera.transform.position.x - cameraWidth,
                    mainCamera.transform.position.x + cameraWidth
                );
            }
            while (Mathf.Abs(randomX - playerX) < minDistanceFromPlayer);

            transform.position = new Vector3(randomX, yHeight, 0);
        }

        direction = Random.value > 0.5f ? 1f : -1f;
    }

    void Update()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        float offsetY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, yHeight + offsetY, pos.z);

        float xMax = mainCamera.transform.position.x + cameraWidth;
        float xMin = mainCamera.transform.position.x - cameraWidth;

        if (transform.position.x > xMax || transform.position.x < xMin)
        {
            direction *= -1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Corazón atrapado!");
            Destroy(gameObject);
        }
    }
}

