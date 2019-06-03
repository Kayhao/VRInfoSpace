using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterPanel : MonoBehaviour {

    private void Awake()
    {
        gameObject.SetActive(false);
        EventCenter.AddListener<bool>(EventDefine.IsShowSelectionPanel, ShowPanel);
        transform.Find("returnBtn").GetComponent<Button>().onClick.AddListener(()=>
        {
            EventCenter.Broadcast(EventDefine.IsShowStartPanel,true);
            ShowPanel(false);
        });
    }

    private void ShowPanel(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.IsShowSelectionPanel, ShowPanel);
    }
}
