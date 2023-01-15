using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenuController : MonoBehaviour
{
    
    
    public void ExitGame()
    {
        Application.Quit();

    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenScene(string sceneName)
    {

        SceneManager.LoadSceneAsync(sceneName);
    }


}
