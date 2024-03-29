using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePregab = null;
    [SerializeField] private GameObject noteSpawn = null;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRender;
    [SerializeField] private Sprite normalBtnSprit;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private Animation anim; 

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++) 
        {
            GameObject noteGameObj = Instantiate(notePregab);
            noteGameObj.transform.SetParent(noteSpawn.transform);
            noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;



            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }
        
    }

    void Update()
    {

    }

    public void OnInput(bool V)
    {
        anim.Play();
        btnSpriteRender.sprite = selectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRender.sprite = normalBtnSprit;
    }
}