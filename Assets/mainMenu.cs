using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(sceneName:"scene_parallax") ;
    }

    public void quitGame() {

        Debug.Log("Quit");
        Application.Quit();
    }
}
