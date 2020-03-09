using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private float cameraSpeed = 5.0f;
    private float cameraDragSpeed = 2.0f;

    // When player is following character
    public void CameraFollowPlayerChar(GameObject _PlayerCharObj, Camera _MainCamera){
        // Make temp variable in order for the default Z not to be effected
        Vector3 tempPosition = new Vector3(_PlayerCharObj.transform.position.x, _PlayerCharObj.transform.position.y, -10.0f);
        _MainCamera.transform.position = tempPosition;
        // Implement CAmera Drag later for effects option maybe
        //_MainCamera.transform.Translate(_PlayerCharObj.transform.position * (cameraDragSpeed * Time.deltaTime));
    }

    // When player enters planning mode
    public void CameraPlanningMode(Camera _MainCamera){
         // WSAD control camera movement
        if(Input.GetKey(KeyCode.W)){
            _MainCamera.transform.Translate(Vector3.up * (cameraSpeed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.S)){
            _MainCamera.transform.Translate(Vector3.down * (cameraSpeed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.A)){
            _MainCamera.transform.Translate(Vector3.left * (cameraSpeed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.D)){
            _MainCamera.transform.Translate(Vector3.right * (cameraSpeed * Time.deltaTime));
        }
    }
}
