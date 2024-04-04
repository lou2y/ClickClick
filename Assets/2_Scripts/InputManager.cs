using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    [SerializeField] private NoteGroup[] noteGroupArr;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.A))
        {
            NoteManger.Instance.OnInput(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NoteManger.Instance.OnInput(KeyCode.S);
        }
    }
}
