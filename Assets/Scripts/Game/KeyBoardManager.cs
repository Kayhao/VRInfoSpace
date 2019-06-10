using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardManager : MonoBehaviour {

    public Text text;
    public string input;
    public bool isUp = false;

    //private void Awake()
    //{
    //    EventCenter.AddListener<bool>(EventDefine.ShowKeyBoard,IsActive);
    //    gameObject.SetActive(false);
    //}
    //private void IsActive(bool value)
    //{
    //    gameObject.SetActive(value);
    //}
    //private void OnDestroy()
    //{
    //    EventCenter.RemoveListener<bool>(EventDefine.ShowKeyBoard, IsActive);
    //}

    private void Update()
    {
        text.text = input.ToString();
    }

    public void Delete()
    {
        if (input==null || input=="")
        {
            return;
        }
        input= input.Substring(0,input.Length-1);
    }

    public void EnterKey()
    {
        if (input == null || input == "")
        {
           EventCenter.Broadcast(EventDefine.ShowTips,"亲，输入为空哦");
        }
        else
        {
            EventCenter.Broadcast(EventDefine.DialogText,input,transform.position,transform.rotation);
        }
        input = "";
    }
}
