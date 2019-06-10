using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeyBoard : MonoBehaviour {

    private GameObject keyBoard;
    private bool isClick=false;
    private void Awake()
    {
        keyBoard = GameObject.FindGameObjectWithTag("KeyBoard");
        EventCenter.AddListener(EventDefine.ShowKeyBoard, OnClick);
        keyBoard.SetActive(false);
    }

    private void OnClick()
    {
        isClick = !isClick;
        if (isClick)
        {
            keyBoard.SetActive(true);
        }
        else
        {
            keyBoard.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.ShowKeyBoard,OnClick);
    }
}
