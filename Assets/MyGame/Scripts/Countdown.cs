using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float timeLeft;

    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentCount = 0;
    public static Countdown instance;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    private void Start()
    {
        scoreText.text = "Count: " + currentCount.ToString() + "/7";
    }

    public void Count()
    {
        currentCount++;
        scoreText.text = "Count: " + currentCount.ToString() + "/7";

    }

    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
        }
        else
        {
            timeLeft = 0;
            Time.timeScale = 0;
        }

        if (timeLeft == 0)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }

        if(currentCount == 7 && timeLeft != 0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        time.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
