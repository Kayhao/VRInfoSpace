using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    private Text loading_Text;
    private AsyncOperation operation;
    private bool isLoading = false;
    private void Awake()
    {
        loading_Text = GetComponent<Text>();
        gameObject.SetActive(false);
        EventCenter.AddListener(EventDefine.LoadScene,Load);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.LoadScene,Load);
    }

    private void Load()
    {
        gameObject.SetActive(true);
        StartCoroutine("LoadingScene");
    }
    IEnumerator LoadingScene()
    {
        int progress = -1;
        int progress_full = 100;
        while (progress<progress_full)
        {
            progress++;
            ShowProgress(progress);
            if (isLoading==false)
            {
                operation= SceneManager.LoadSceneAsync(1);
                operation.allowSceneActivation = false;
                isLoading = true;
            }
            yield return new WaitForEndOfFrame();
        }
        if (progress==100)
        {
            operation.allowSceneActivation = true;
            StopCoroutine("LoadingScene");
        }
    }
    private void ShowProgress(int progress)
    {
        loading_Text.text = progress.ToString()+"%";
    }
}
