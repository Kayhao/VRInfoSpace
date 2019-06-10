using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour {

    private float waitTime = 2;
    private void Awake()
    {
        EventCenter.AddListener<string>(EventDefine.ShowTips,Show);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(EventDefine.ShowTips,Show);
    }

    private void Show(string str)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = str;
        StartCoroutine("AutoHide");
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
