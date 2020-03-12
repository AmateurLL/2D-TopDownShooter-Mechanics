using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    void Awake(){
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void LoseGame(){
        // Call Lost Game screen

        // Remove this when lost screen is implemented as the button function will use this
        SceneManager.LoadScene("MainMenu");
    }

}
