using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    void OnMouseDown(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
