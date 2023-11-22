using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceaneController : MonoBehaviour
{
    static string nextScene;
    [SerializeField]
    Image loadingBar;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    void Start()
    {
        StartCoroutine(LoadscenePeocess());
    }

    
    IEnumerator LoadscenePeocess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float time = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                loadingBar.fillAmount = op.progress;
            }
            else
            {
                time += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.0f, 1f, time);
                if(loadingBar.fillAmount >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
