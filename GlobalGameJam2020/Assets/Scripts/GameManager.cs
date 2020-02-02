using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneState
{
    None, Menu, Help, Game, End

}
public class GameManager : MonoBehaviour
{
    #region Data
    public SceneState sceneState;
    public static GameManager instance = null; //Singleton
    private int score = 0;
    private float startTimer = 0.0f;
    public float startTime = 3f;
    public bool start = false;
    private float gameTime = 0.0f;
    public float maxTime;

    [Tooltip("Time it takes for item to get destroyed after being used")]
    public float itemTimeOut = 10f;
    #endregion
    /* Will change this layer once, scene transitioning is implemented
     * 
     */
    public Transform playerCamera;
    public Transform player;
    public Transform shoppingCart;
    #region User Interface
    [Header("User Interface")]
    private Transform scoreTransform;
    private Transform gameTimerTransform;

    #endregion

    #region Main Menu


    #endregion

    #region Audio
    [Header("Audio")]
    AudioSource audioSource;
    public AudioClip menuAudio;
    public AudioClip gameAudio;

    #endregion
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Development":
                {
                    //OnDevelopmentScene();
                    break;
                }
            case "Main Menu":
                {
                    OnMainMenuScene();
                    break;
                }
            case "Game":
                {
                    OnGameScene();
                    break;
                }

        }
    }

    private void OnMainMenuScene()
    {
        sceneState = SceneState.Menu;
        audioSource.clip = menuAudio;
        audioSource.Play();
    }

    private void OnGameScene()
    {
        sceneState = SceneState.Game;
        GameObject score = GameObject.FindGameObjectWithTag("Score Text");
        GameObject gameTimer = GameObject.FindGameObjectWithTag("Game Timer Text");

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject playerCameraObject = GameObject.FindGameObjectWithTag("Player Camera");
        GameObject shoppingCartObject = GameObject.FindGameObjectWithTag("Shopping Cart");

        if (playerObject)
        {
            player = playerObject.transform;
        }
        if (playerCameraObject)
        {
            playerCamera = playerCameraObject.transform;
        }
        if (shoppingCartObject)
        {
            shoppingCart = shoppingCartObject.transform;
        }
        if (score)
            scoreTransform = score.transform;

        if (gameTimer)
            gameTimerTransform = gameTimer.transform;

        gameTime = maxTime;

        audioSource.clip = gameAudio;
        audioSource.Play();
       
    }
    public PlayerCamera GetPlayerCamera()
    {
        if (playerCamera)
            return playerCamera.GetComponent<PlayerCamera>();
        else
        {
            Debug.Log("Player camera script component not found");
            return null;
        }
    }

    public Player GetPlayer()
    {
        if (player)
        {
            return player.GetComponent<Player>();
        }
        else
        {
            Debug.Log("Player script component not found.");
            return null;
        }
    }
    public ShoppingCart GetShoppingCart()
    {
        if (shoppingCart)
        {
            return shoppingCart.GetComponent<ShoppingCart>();
        }
        else
        {
            Debug.Log("ShoppingCart script component not found.");
            return null;
        }
    }
    public void AddScore(int value)
    {
        score += value;
    }
    private void Update()
    {
        if (sceneState == SceneState.Game)
        {
            if(scoreTransform)
                scoreTransform.GetChild(0).GetComponent<Text>().text = score.ToString();

            if (!start)
            {
                startTimer += Time.deltaTime;

                if (startTimer >= startTime)
                {
                    start = true;
                    startTimer = 0.0f;
                }

            }
            else
            {
                gameTime -= Time.deltaTime;
                if(gameTime <= 15.0f)
                {
                    if(audioSource.pitch < 1.5f)
                        audioSource.pitch += Time.deltaTime;
                }
                if(gameTime <= 0.0f)
                {
                    Debug.Log("Game has finished!!");
                }

                if (gameTimerTransform)
                {
                    string minutes = Mathf.Floor(gameTime / 60).ToString("00");
                    string seconds = (gameTime % 60).ToString("00");

                    gameTimerTransform.GetChild(0).GetComponent<Text>().text = string.Format("{0}:{1}", minutes, seconds);
                }
            }
        }
        
    }
}
