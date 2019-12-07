using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
