using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Data

    public static GameManager instance = null; //Singleton
    private int score;
    private int timer;
    public int maxTime;

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
    private void Update()
    {
        
    }
}
