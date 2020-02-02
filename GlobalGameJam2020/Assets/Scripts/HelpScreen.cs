using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScreen : MonoBehaviour
{

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
