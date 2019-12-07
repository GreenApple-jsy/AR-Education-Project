using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ffSimulation : MonoBehaviour
{
    public int weight, power;
    public GameObject left, right, equal;
    public Text powerText, weightText;
    public GameObject pullButtonObject;
    public GameObject Spring, Box;
    public Vector3 boxLocation, springLocation;

    private void Start()
    {
        boxLocation = Box.transform.localPosition;
        springLocation = Spring.transform.localPosition;
        weight = 3;
        power = 3;
        left.SetActive(false);
        right.SetActive(false);
        equal.SetActive(false);
    }

    public void powerChange(int value)
    {
        power += value;
        if (power < 0)
            power = 0;
        powerText.text = power.ToString() + "f";
    }

    public void weightChange(int value)
    {
        weight += value;
        if (weight < 2)
            weight = 2;
        weightText.text = weight.ToString();
        Box.transform.localScale = new Vector3(Box.transform.localScale.x, Box.transform.localScale.y, 20 * weight);
        Box.transform.localPosition = new Vector3(boxLocation.x, boxLocation.y, boxLocation.z - (weight - 3) * 10);
    }

    public void pull()
    {
        Box.transform.localPosition = new Vector3(boxLocation.x, boxLocation.y, boxLocation.z - (weight - 3) * 10);
        Spring.transform.localPosition = springLocation;
        pullButtonObject.SetActive(false);
        StartCoroutine(showResult());
    }

    IEnumerator showResult()
    {
        for (int i = 130; i <= 180; i++) //스프링 잡아당기기
        {
            Spring.transform.localPosition = new Vector3(springLocation.x + (i - 130) * 0.2f, springLocation.y, springLocation.z);
            Spring.transform.localScale = new Vector3(100f, 100f, i);
            yield return 0.08f;
        }

        if (3 * weight > power)
        {
            StartCoroutine(showSign(left));
            for (int i = 180; i >= 130; i--)
            {
                Spring.transform.localPosition = new Vector3(springLocation.x + (i - 130) * 0.2f, springLocation.y, springLocation.z);
                Spring.transform.localScale = new Vector3(100f, 100f, i);
                yield return 0.08f;
            }
        }
        else if (3 * weight == power)
        {
            StartCoroutine(showSign(equal));
            for (int i = 180; i >= 130; i--)
            {
                Spring.transform.localPosition = new Vector3(springLocation.x + (i - 130) * 0.2f, springLocation.y, springLocation.z);
                Spring.transform.localScale = new Vector3(100f, 100f, i);
                yield return 0.08f;
            }
        }
        else //움직이는 경우
        {
            StartCoroutine(showSign(right));
            StartCoroutine(Movement());
            for (int i = 180; i >= 130; i--)
            {
                Spring.transform.localScale = new Vector3(100f, 100f, i);
                yield return 0.08f;
            }
        }
        pullButtonObject.SetActive(true);
    }

    IEnumerator showSign(GameObject t)
    {
        t.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        t.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        t.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        t.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        t.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        t.SetActive(false);
        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator Movement()
    {
        for (int i = 0; i < 40; i++)
        {
            Spring.transform.localPosition = new Vector3(springLocation.x + 10 + 0.7f * i, springLocation.y, springLocation.z);
            Box.transform.localPosition = new Vector3(boxLocation.x + i, boxLocation.y, Box.transform.localPosition.z);
            yield return 0.1f;
        }
    }
}
