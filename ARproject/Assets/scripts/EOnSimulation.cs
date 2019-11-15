using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOnSimulation : MonoBehaviour
{
    public GameObject EonStartButton;
    public GameObject EonRestartButton;
    public GameObject Na, Cl;
    public GameObject Nae1;
    public GameObject NaRedOuterRing, ClBlueOuterRing, ClRedOuterRing;
    public GameObject ExplanationText;
    Vector3 Nae1StartPosition, NaStartPosition, ClStartPosition;

    private void Start()
    {
        NaRedOuterRing.SetActive(true);
        ClRedOuterRing.SetActive(true);
        ClBlueOuterRing.SetActive(false);
        ExplanationText.SetActive(false);
        EonRestartButton.SetActive(false);
        Nae1StartPosition = Nae1.GetComponent<Transform>().localPosition;
        NaStartPosition = Na.GetComponent<Transform>().localPosition;
        ClStartPosition = Cl.GetComponent<Transform>().localPosition;
    }

    public void EOnSimulationStart()
    {
        EonStartButton.SetActive(false);
        StartCoroutine(e1Movement());
    }

    IEnumerator e1Movement()
    {
        yield return new WaitForSeconds(1.0f);
        Nae1.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        NaRedOuterRing.SetActive(false);
        yield return new WaitForSeconds(3.3f);
        ClRedOuterRing.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        ClBlueOuterRing.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(pull());
    }

    IEnumerator pull()
    {
        float v = (0.241f - 0.2f) / 5;
        for (int i = 0; i < 5; i++)
        {
            Na.transform.localPosition = new Vector3(Na.transform.localPosition.x + v, Na.transform.localPosition.y, Na.transform.localPosition.z);
            Cl.transform.localPosition = new Vector3(Cl.transform.localPosition.x - v, Cl.transform.localPosition.y, Cl.transform.localPosition.z);
            Nae1.transform.localPosition = new Vector3(Nae1.transform.localPosition.x - v, Nae1.transform.localPosition.y, Nae1.transform.localPosition.z);
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(2f);
        ExplanationText.SetActive(true);
        yield return new WaitForSeconds(1f);
        EonRestartButton.SetActive(true);
    }

    public void EonSimulationReStart()
    {
        Nae1.transform.localPosition = Nae1StartPosition;
        Na.transform.localPosition = NaStartPosition;
        Cl.transform.localPosition = ClStartPosition;
        ClBlueOuterRing.SetActive(false);
        NaRedOuterRing.SetActive(true);
        ClRedOuterRing.SetActive(true);
        ExplanationText.SetActive(false);
        EonRestartButton.SetActive(false);
        Invoke("EOnSimulationStart", 2f);
    }
}
