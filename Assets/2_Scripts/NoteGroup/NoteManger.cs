using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] intiKeycodeArr;
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroup;
    [SerializeField] private float noteGroupGap;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    public void Create()
    {
        foreach (KeyCode keyCode in intiKeycodeArr)
        {
            CreateNoteGroup(keyCode);
        }
    }

    void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;
        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupList.Count);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}
