using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen, endScreen, hud;

    public float highScore, currentScore;
    public event Action OnGameplayStart = delegate { };
    public event Action OnGameplayEnd = delegate { };

    #region singleton
    public static GameManager gameManager;
    void Awake()
    {
        if(gameManager == null)
            gameManager = this;
    }
    #endregion


    //when player clicks on start button to start gameplay
    public void StartGameplay()
    {
        //tap sound
        AudioManager.audioManager.PlaySound(AudioManager.audioManager.clips.tap);

        //close start screen
        startScreen.SetActive(false);

        //open HUD screen
        hud.SetActive(true);

        OnGameplayStart();
    }

    //when player loses gameplay
    public void EndGameplay()
    {
        //close HUD
        hud.SetActive(false);

        //open end screen
        endScreen.SetActive(true);

        OnGameplayEnd();
    }

    //when player clicks on retry button
    public void Retry()
    {
        startScreen.SetActive(true);
        endScreen.SetActive(false);
        hud.SetActive(false);

        //tap sound
        AudioManager.audioManager.PlaySound(AudioManager.audioManager.clips.tap);

        //reload the scene
        SceneManager.LoadSceneAsync(0);
        
    }

}
