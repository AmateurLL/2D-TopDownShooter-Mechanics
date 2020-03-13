using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [Header("Ref List")]
    [SerializeField] public GameObject m_PlayerChar;
    [SerializeField] public Camera m_MainCamera;

    [Space]
    [Header("Status")]
    [SerializeField] public bool isTaticalMode = false;

    void Awake(){
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchMode();
        PlayerModeState();
    }

    void PlayerModeState(){

        if(isTaticalMode){
            // Free Movement Leaving PLayer Character In AI mode
            this.GetComponent<CameraControls>().CameraPlanningMode(m_MainCamera);
            this.GetComponent<CameraControls>().CameraZoomControl();
        }
        else{
            // Controlling PlayerChar
            this.GetComponent<CameraControls>().CameraFollowPlayerChar(m_PlayerChar, m_MainCamera);
        }
    }

    void SwitchMode(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(isTaticalMode){
                isTaticalMode = false;
                m_MainCamera.orthographicSize = this.GetComponent<CameraControls>().CAMDEFSIZE;
            }else{
                isTaticalMode = true;
            }
        }
    }
}
