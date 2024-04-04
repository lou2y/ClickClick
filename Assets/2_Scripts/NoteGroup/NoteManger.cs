using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManger : MonoBehaviour
{
    public static NoteManger Instance;
    [SerializeField] private NoteGroup[] noteGroupArr;

    private void Awake()
    {
        Instance = this;
    }

    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupArr.Length);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupArr)
        {
            if(keyCode == noteGroup.keycode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}
    