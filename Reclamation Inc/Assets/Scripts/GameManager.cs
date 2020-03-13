using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Components")]
    [SerializeField] GameObject creditsUIText;

    [Space]
    [Header("Game Stats")]
    [SerializeField] public int moneyCredits = 0;

    void Awake(){
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        // Credits UI Text
        creditsUIText.GetComponent<Text>().text = "$ " + moneyCredits;
    }
    

    public void LoseGame(){
        // Call Lost Game screen

        // Remove this when lost screen is implemented as the button function will use this
        SceneManager.LoadScene("MainMenu");
    }

    public void CreditsCount(int _add){
        moneyCredits += _add;
    }
}
