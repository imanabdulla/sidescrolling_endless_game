using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Text highScoreTxt, currentScoreTxt;

    void Start()
    {
        currentScoreTxt.text = "Current Score: " + GameManager.gameManager.currentScore.ToString();
        highScoreTxt.text = "High Score: " + GameManager.gameManager.highScore.ToString();
    }
}
