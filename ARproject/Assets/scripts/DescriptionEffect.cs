using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionEffect : MonoBehaviour
{
    float size = 1f;
    bool up = true;

    void Update()
    {
        this.transform.localScale = new Vector2(size, size);
        if (up)
        {
            size += 0.3f * Time.deltaTime;
            if (size >= 1.1f)
                up = false;
        }
        else
        {
            size -= 0.3f * Time.deltaTime;
            if (size <= 0.9f)
                up = true;
        }
    }
}
