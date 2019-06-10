using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour {

    public Material material_01;
    public Material material_02;
    private MeshRenderer meshrenderer;
    private string keyValue;
    private string upValue;
    private KeyBoardManager keyBoardManager;
    private bool isClick = true;
    private float timer = 0.0f;
    private float time = 0.3f;

    private void Awake()
    {
        meshrenderer = GetComponentInChildren<MeshRenderer>();
        keyValue = transform.GetChild(0).GetComponent<Text>().text;
        keyBoardManager = GetComponentInParent<KeyBoardManager>();
        if (keyValue=="0" || keyValue=="1" || keyValue=="2" || keyValue == "3" || keyValue == "4" || keyValue == "5" || keyValue == "6" || keyValue == "7" || keyValue == "8" || keyValue == "9" 
            || keyValue == "UP" || keyValue == "Back" || keyValue == "Enter" || keyValue == "," || keyValue == "." || keyValue == "!")
        {
            upValue = keyValue;
        }
        else
        {
            upValue = keyValue.ToUpper();
        }
    }

    private void Update()
    {
        if (keyBoardManager.isUp)
        {
            transform.GetChild(0).GetComponent<Text>().text = upValue;
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = keyValue;
        }
        if (isClick==false)
        {
            timer += Time.deltaTime;
            if (timer>=time)
            {
                timer = 0.0f;
                isClick = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Finger" && isClick)
        {
            meshrenderer.material = material_02;
            if (keyValue=="UP")
            {
                keyBoardManager.isUp = !keyBoardManager.isUp;
            }
            else if(keyValue=="Back")
            {
                keyBoardManager.Delete();
            }
            else if (keyValue=="Enter")
            {
                keyBoardManager.EnterKey();
            }
            else
            {
                if (keyBoardManager.isUp)
                {
                    keyBoardManager.input += upValue;
                }
                else
                {
                    keyBoardManager.input += keyValue;
                }        
            }    
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Finger")
        {
            isClick = false;
            meshrenderer.material = material_01;
        }    
    }
}
