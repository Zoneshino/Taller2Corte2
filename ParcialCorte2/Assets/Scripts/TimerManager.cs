using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    public float scene1Time = 0f; 
    public float scene2Time = 0f; 

    private float startTime;       
    private bool isRunning = false; 

    public int currentScene = 1;  

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

    public void StartTimer()
    {
        isRunning = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            float elapsed = Time.time - startTime;
            if (currentScene == 1)
                scene1Time += elapsed;
            else if (currentScene == 2)
                scene2Time += elapsed;

            isRunning = false;
        }
    }


    public void SwitchToScene2()
    {
        StopTimer(); 
        currentScene = 2;
        StartTimer();
    }

    public float GetCurrentTime()
    {
        if (isRunning)
            return Time.time - startTime;
        else
            return 0f;
    }

    public float GetTotalTime()
    {
        float total = scene1Time + scene2Time;
        if (isRunning)
        {
            total += (Time.time - startTime);
        }
        return total;
    }

    public void ResetAllTimes()
    {
        scene1Time = 0f;
        scene2Time = 0f;
        currentScene = 1;
        isRunning = false;
    }


    private void Start()
    {
        if (PlayerPrefs.HasKey("Scene1Time"))
            scene1Time = PlayerPrefs.GetFloat("Scene1Time");
        if (PlayerPrefs.HasKey("Scene2Time"))
            scene2Time = PlayerPrefs.GetFloat("Scene2Time");
    }
}