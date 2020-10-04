using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;
    private int displayScore;
    public int multiplier = 1;
    public TextMeshPro speechText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOverScore.text = score.ToString();
        if(score > displayScore)
        {
            int diff = score - displayScore;
            if (diff > 500)
            {
                displayScore += 50;
            }
            else
            {
                displayScore += 1;
            }
        }
        scoreText.text = displayScore.ToString();
        if (multiplier > 1)
        {
            multiText.text = multiplier.ToString() + "x";
        }
        else
        {
            multiText.text = "";
        }

        if(gameOverScreen.activeInHierarchy == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            SceneManager.LoadScene("menu");
        }

    }

    public void ShowText(string text)
    {
        speechText.text = text;
        speechText.GetComponentInParent<Animator>().SetTrigger("showText");
    }
}
