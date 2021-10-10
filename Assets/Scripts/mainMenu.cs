using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class mainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void playGame()
    {
        SceneManager.LoadScene(sceneName:"Niveau1") ;
    }

    public void quitGame() {

        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadNextLevel() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        //Load Scene
    
    }


}
