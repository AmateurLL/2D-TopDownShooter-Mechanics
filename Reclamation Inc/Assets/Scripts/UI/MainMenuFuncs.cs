using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFuncs : MonoBehaviour
{
    public void PlaySurvivalMode(){
        SceneManager.LoadScene("Survival Mode");       
    }

    public void OpenOptionsSettings(){
        // Deactivate current panel and activate settings panel

    }

    public void QuitGame(){
        //Application.Quit();
        Debug.Log("CLosing Game.....");
    }
}
