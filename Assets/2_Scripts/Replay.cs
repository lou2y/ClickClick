using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    
    public void OnClicked()
    {
        Debug.Log("onCel..............");
        SceneManager.LoadScene("Main");
    }
}                                 
