using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("wholeBGMplayer") != null)
        {
            Destroy(gameObject);
        }
        else
        {
            name = "wholeBGMplayer";
            DontDestroyOnLoad(this);
        }
        
    }
}
