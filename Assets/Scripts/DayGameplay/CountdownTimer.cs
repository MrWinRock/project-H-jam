using UnityEngine;
using TMPro;  // Import TMPro namespace for TextMeshPro
using UnityEngine.SceneManagement;  // For changing scenes

public class CountdownTimer : MonoBehaviour {
    public float countdownTime = 360f;  // 6 minutes in seconds
    public TextMeshProUGUI countdownText;  // Reference to the TMP text component
    // public string sceneToLoad = "MenuScreen";  // The scene to load when time is up

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;  // Initialize the timer with the 6-minute countdown
    }

    void Update()
    {
        // Decrease the current time by the time passed since the last frame
        currentTime -= Time.deltaTime;

        // Display the time in minutes and seconds
        DisplayTime(currentTime);

        // If the time runs out, load the next scene
        if (currentTime <= 0)
        {
            ChangeScene();
        }
    }

    // Function to update the TMP text with the formatted time
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;  // Avoid negative time display
        }

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Format the time string and display it in the TextMeshPro component
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Function to change the scene when the time is up
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
