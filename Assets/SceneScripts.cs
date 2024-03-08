using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TextMeshProUGUI tries;

    private bool isPaused = false;
    public int numberOfTries = 0;

    public TextMeshProUGUI lastTries;


    private void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("TriesCount"))
        {
            numberOfTries = PlayerPrefs.GetInt("TriesCount");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeLevel();
            }
            else
            {
                PauseLevel();
            }
        }
        tries.text =  "You died" + " " + numberOfTries.ToString() + " Times";
        lastTries.text = "Congratulations\r \nYou died " +numberOfTries.ToString() + " times \r\nYou are officially zombie\r\n";

    }

    // Method to restart the level
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        numberOfTries++;
        PlayerPrefs.SetInt("TriesCount", numberOfTries); // Change the key here
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    public void PauseLevel()
    {
        Time.timeScale = 0f;
        isPaused = true;

        // Show the pause menu UI
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
}
