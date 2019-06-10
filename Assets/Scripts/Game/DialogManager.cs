using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    private Transform parent;
    private void Awake()
    {
        EventCenter.AddListener<string,Vector3,Quaternion>(EventDefine.DialogText,DialogText);
        parent = GameObject.FindGameObjectWithTag("DialogParent").transform;
    }


    private void DialogText(string text,Vector3 pos,Quaternion rotation)
    {
        int random = UnityEngine.Random.Range(1,10);
        string path = "Dialog/dialog_" + random;
        GameObject go= ResourcesLoad.LoadObj(path);
        GameObject Go=Instantiate(go,pos,rotation);
        Go.transform.SetParent(parent);
        Go.GetComponentInChildren<Text>().text = text;
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string, Vector3, Quaternion>(EventDefine.DialogText, DialogText);
    }
}
