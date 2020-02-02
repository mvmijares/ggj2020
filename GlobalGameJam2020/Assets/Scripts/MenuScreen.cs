using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
    GameManager gm_instance;
    // Start is called before the first frame update
    void Start()
    {
        gm_instance = GameManager.instance;
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnHelpButtonClicked()
    {
        SceneManager.LoadScene("Help Menu");
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
