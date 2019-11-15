using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceManager : MonoBehaviour
{
    private WebViewObject webViewObject;

    private void Update()
    {
        if (GameObject.Find("WebViewObject") != null)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(GameObject.Find("WebViewObject"));
                return;
            }
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void WebButton()
    {
        string strUrl = "https://greenapple16.tistory.com/79?category=811357";

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => { Debug.Log(string.Format("CallFromJS[{0}]", msg)); });
        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(0, 0, 0, 0);
    }

    public void ExitButton()
    {
        Application.Quit(0);
    }
}
