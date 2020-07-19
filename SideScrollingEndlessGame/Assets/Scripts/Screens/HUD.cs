using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text highScoreTxt, currentScoreTxt;

    private float  _counter;


    void OnEnable()
    {
        GetHighScore();
    }

    void OnDisable()
    {
        SetHighScore();
    }

    void Update()
    {
        CalculateCurrentScore();
    }

    void CalculateCurrentScore()
    {
        _counter += Time.deltaTime;
        GameManager.gameManager.currentScore = Mathf.Ceil(_counter);
        currentScoreTxt.text = "Curr: " + GameManager.gameManager.currentScore.ToString();
    }

    void SetHighScore()
    {
        if (GameManager.gameManager.currentScore > GameManager.gameManager.highScore)
        {
            GameManager.gameManager.highScore = GameManager.gameManager.currentScore;
            PlayerPrefs.SetFloat("HIGH-SCORE", GameManager.gameManager.highScore);
        }
    }

    void GetHighScore()
    {
        GameManager.gameManager.highScore = PlayerPrefs.GetFloat("HIGH-SCORE", 0);
        highScoreTxt.text = "High: " + GameManager.gameManager.highScore.ToString();
    }
}
