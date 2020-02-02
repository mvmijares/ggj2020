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
    [SerializeField]
    private float startTimer = 0.0f;
    public float startTime = 3f;
    public bool start = false;
    [SerializeField]
    private float gameTimer = 0.0f;
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

    private Transform scoreTransform;
    
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
                    OnDevelopmentScene();
                    break;
                }
            case "Game":
                {
                    OnGameScene();
                    break;
                }
        }
    }

    private void OnGameScene()
    {

    }

    private void OnDevelopmentScene()
    {
        sceneState = SceneState.Game;
        GameObject score = GameObject.FindGameObjectWithTag("Score Text");

        if (score)
            scoreTransform = score.transform;

       
       
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
                gameTimer += Time.deltaTime;
                if (gameTimer >= maxTime)
                {
                    Debug.Log("Game has finished!!");
                }
            }
        }
        
    }
}
