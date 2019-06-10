using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour {

    private bool isActiveDialogParent = true;


    public void KeyBoard()
    {
        // EventCenter.Broadcast(EventDefine.ShowKeyBoard,true);
        EventCenter.Broadcast(EventDefine.ShowKeyBoard);
    }
    public void Pencil()
    {

    }
    public void Image()
    {

    }
    public void Hide()
    {
        isActiveDialogParent = !isActiveDialogParent;
        EventCenter.Broadcast(EventDefine.HideButton);
        EventCenter.Broadcast(EventDefine.IsActiveDialogParent,isActiveDialogParent);
    }
}
