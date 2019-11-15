using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GongUSimulation : MonoBehaviour
{
    public GameObject GongUStartButton;
    public GameObject GongURestartButton;
    public GameObject h1, h2;
    public GameObject e1, e2;
    public GameObject Ring1, Ring2;
    public GameObject ExplanationText;
    Vector3 h1StartPosition, h2StartPosition, Ring1StartPosition, Ring2StartPosition;

    private void Start()
    {
        Ring1.SetActive(false);
        Ring2.SetActive(false);
        ExplanationText.SetActive(false);
        GongURestartButton.SetActive(false);
        h1StartPosition = h1.GetComponent<Transform>().localPosition;
        h2StartPosition = h2.GetComponent<Transform>().localPosition;
        Ring1StartPosition = Ring1.GetComponent<Transform>().localPosition;
        Ring2StartPosition = Ring2.GetComponent<Transform>().localPosition;
    }

    public void GongUSimulationStart()
    {
        GongUStartButton.SetActive(false);
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        yield return new WaitForSeconds(1.0f);
        e1.GetComponent<Animation>().Stop();
        e2.GetComponent<Animation>().Stop();
        e1.transform.localPosition = new Vector3(-0.06f, 0.095f, -0.06f);
        e2.transform.localPosition = new Vector3(0.06f, 0.095f, 0.06f);
        yield return new WaitForSeconds(1.5f);
        float v = 0.006f;
        for (int i = 0; i < 10; i++)
        {
            h1.transform.localPosition = new Vector3(h1.transform.localPosition.x + v, h1.transform.localPosition.y, h1.transform.localPosition.z);
            e1.transform.localPosition = new Vector3(e1.transform.localPosition.x + v, e1.transform.localPosition.y, e1.transform.localPosition.z);
            Ring1.transform.localPosition = new Vector3(Ring1.transform.localPosition.x + v, Ring1.transform.localPosition.y, Ring1.transform.localPosition.z);
            h2.transform.localPosition = new Vector3(h2.transform.localPosition.x - v, h2.transform.localPosition.y, h2.transform.localPosition.z);
            e2.transform.localPosition = new Vector3(e2.transform.localPosition.x - v, e2.transform.localPosition.y, e2.transform.localPosition.z);
            Ring2.transform.localPosition = new Vector3(Ring2.transform.localPosition.x - v, Ring2.transform.localPosition.y, Ring2.transform.localPosition.z);
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(Explanation());
    }

    IEnumerator Explanation()
    {
        yield return new WaitForSeconds(1f);
        Ring1.SetActive(true);
        Ring2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ExplanationText.SetActive(true);
        yield return new WaitForSeconds(1f);
        GongURestartButton.SetActive(true);
    }

    public void GongUSimulationReStart()
    {
        h1.transform.localPosition = h1StartPosition;
        h2.transform.localPosition = h2StartPosition;
        Ring1.transform.localPosition = Ring1StartPosition;
        Ring2.transform.localPosition = Ring2StartPosition;
        Ring1.SetActive(false);
        Ring2.SetActive(false);
        ExplanationText.SetActive(false);
        GongURestartButton.SetActive(false);
        e1.GetComponent<Animation>().Play();
        e2.GetComponent<Animation>().Play();
        Invoke("GongUSimulationStart", 2f);
    }
}
