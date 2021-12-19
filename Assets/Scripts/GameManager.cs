using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    void Start()
    {
        Screen.SetResolution(1024, 768, false, 60);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
