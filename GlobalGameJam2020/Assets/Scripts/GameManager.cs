using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Data

    public static GameManager instance = null; //Singleton
    private int score = 0;
    private float imer;
    public float maxTime;

    [Tooltip("Time it takes for item to get destroyed after being used")]
    public float itemTimeOut = 10f;
    #endregion
    /* Will change this layer once, scene transitioning is implemented
     * 
     */
    public Transform playerCamera;
    public Transform player;

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

    public void AddScore(int value)
    {
        score += value;
    }
    private void Update()
    {
        Debug.Log("Score is " + score);
    }
}
