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
    private KeyCode keyCode;
    public KeyCode keycode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        //노트 삭제
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePregab);
        noteGameObj.transform.SetParent(noteSpawn.transform);
        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;

        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        //삭제
        if (noteList.Count > 0)
         {
           Note delNote = noteList[0];
           delNote.DeleteNote();
           noteList.RemoveAt(0);
         }
          
        //줄 내려오기
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        CreateNote(isApple);

        anim.Play();
        btnSpriteRender.sprite = selectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRender.sprite = normalBtnSprit;
    }
}