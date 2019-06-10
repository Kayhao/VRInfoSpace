using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButton : MonoBehaviour {

    private bool isClick = false;
    private Image image;
    private void Awake()
    {
        EventCenter.AddListener(EventDefine.HideButton,OnClick);
        image=GetComponentInChildren<Image>();
    }
    private void Start()
    {
        image.transform.localEulerAngles = new Vector3(0,0,-90);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.HideButton,OnClick);
    }

    private void OnClick()
    {
        isClick = !isClick;
        if (isClick)
        {
            image.sprite = ResourcesLoad.LoadSprite("show");
        }
        else
        {
            image.sprite = ResourcesLoad.LoadSprite("hide");
        }
    }
}
