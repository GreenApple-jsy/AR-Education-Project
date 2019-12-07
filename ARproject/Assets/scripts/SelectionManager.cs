using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Entrance");
        }
    }

    public void SearchButton()
    {
        SceneManager.LoadScene("Search");
    }

    public void CameraButton()
    {
        SceneManager.LoadScene("ARmain");
    }
}
