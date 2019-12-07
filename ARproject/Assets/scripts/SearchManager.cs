using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{
    public GameObject CanvasObject;
    private GameObject temp;
    private WebViewObject webViewObject;
    public Text searchWordInput;

    private void Awake()
    {
        CanvasObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameObject.Find("WebViewObject") != null)
            {
                Destroy(GameObject.Find("WebViewObject"));
                return;
            }
            else if (!CanvasObject.activeSelf)
            {
                Destroy(temp);
                CanvasObject.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Entrance");
            }
        }
    }

    public void Search()
    {
        if (PlayerPrefs.GetString(searchWordInput.text.ToString(),"") != "") //어플리케이션에 시뮬레이션이 저장되어있는 단어일 경우
        {
            CanvasObject.SetActive(false);
            temp = (GameObject)Instantiate(Resources.Load(PlayerPrefs.GetString(searchWordInput.text.ToString(), "") + "labChildren"));
        }
        else //아닐 경우, 웹사이트 사전 검색페이지로 이동
        {
            string strUrl = "https://terms.naver.com/search.nhn?query=" + searchWordInput.ToString() + "&searchType=&dicType=&subject=all";

            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) => { Debug.Log(string.Format("CallFromJS[{0}]", msg)); });
            webViewObject.LoadURL(strUrl);
            webViewObject.SetVisibility(true);
            webViewObject.SetMargins(0, 0, 0, 0);
        }
    }
}
