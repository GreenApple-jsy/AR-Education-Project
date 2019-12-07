using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceManager : MonoBehaviour
{
    private WebViewObject webViewObject;

    private void Awake()
    {
        PlayerPrefs.SetString("공유결합", "공유결합");
        PlayerPrefs.SetString("공유", "공유결합");
        PlayerPrefs.SetString("이온결합", "이온결합");
        PlayerPrefs.SetString("이온", "이온결합");
        PlayerPrefs.SetString("불꽃반응", "불꽃반응");
        PlayerPrefs.SetString("불꽃색반응", "불꽃반응");
        PlayerPrefs.SetString("속도", "속도");
        PlayerPrefs.SetString("마찰력", "마찰력");
        PlayerPrefs.SetString("마찰", "마찰력");
    }

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
        SceneManager.LoadScene("Selection");
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
