using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

    private string characterName;
    private void Awake()
    {
        transform.Find("SelectButton").GetComponent<Button>().onClick.AddListener(()=> 
        {
            EventCenter.Broadcast(EventDefine.IsShowSelectionPanel, true);
            ShowPanel(false);
        });
        transform.Find("StartButton").GetComponent<Button>().onClick.AddListener(()=>
        {
            ShowPanel(false);
            PlayerPrefs.SetString("CharacterName", characterName);
            EventCenter.Broadcast(EventDefine.LoadScene);
            //SceneManager.LoadSceneAsync();
        });
        EventCenter.AddListener<bool>(EventDefine.IsShowStartPanel,ShowPanel);
        EventCenter.AddListener<string>(EventDefine.IsChooseCharacter,ChooseCharacter);
    }

    private void ShowPanel(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.IsShowStartPanel, ShowPanel);
        EventCenter.RemoveListener<string>(EventDefine.IsChooseCharacter, ChooseCharacter);
    }

    private void ChooseCharacter(string name)
    {
        characterName = name;
    }
}
