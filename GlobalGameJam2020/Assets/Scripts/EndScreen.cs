using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    #region Data
    GameManager gm_instance;

    
    #endregion

    private void Start()
    {
        gm_instance = GameManager.instance;
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }



}
