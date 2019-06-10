using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogParent : MonoBehaviour {

    private void Awake()
    {
        EventCenter.AddListener<bool>(EventDefine.IsActiveDialogParent,IsActive);
    }
    private void IsActive(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.IsActiveDialogParent,IsActive);
    }
}
