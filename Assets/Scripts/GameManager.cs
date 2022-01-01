using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button startButton;
    public Button quitButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public GameObject player;
    public List<GameObject> planets;
    public bool isGameActive;
    private int score;

    void Start()
    {
        isGameActive = false;
        Screen.SetResolution(2560, 1440, true, 60);
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        if(planets.Count == 0)
        {
            GameOver();
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        Debug.Log("Planets remaining: " + planets.Count);
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RemovePlanet(GameObject planet)
    {
        planets.Remove(planet);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive=true;
        scoreText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
