using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flamelabSimulation : MonoBehaviour
{
    Vector3 nichromeBasePosition = new Vector3(2f, -110f, 41f);
    Vector3 nichromeDesPosition = new Vector3(2f, 36f, 41f);
    public Button[] elementButtons = new Button[6];
    public GameObject nichromeWire;
    public GameObject[] Fire = new GameObject[7]; //0기본, 1나트륨, 2리튬, 3칼륨, 4스트론튬, 5구리, 6칼슘

    void Start()
    {
        Fire[0].SetActive(true);
        for (int i = 1; i < 7; i++)
            Fire[i].SetActive(false);
        nichromeWire.transform.localPosition = nichromeBasePosition;
    }

    public void elementSelection(int n)
    {
        Fire[0].SetActive(true);
        for (int i = 1; i < 7; i++)
            Fire[i].SetActive(false);
        for (int i = 0; i < 6; i++)
            elementButtons[i].interactable = false;

        StartCoroutine(nichromeWireMovement(n));
    }

    IEnumerator nichromeWireMovement(int n)
    {
        yield return new WaitForSeconds(0.5f);
        float ydiff = (36f + 110f) / 15;
        for (float i = -110f; i <= 36f; i += ydiff)
        {
            nichromeWire.transform.localPosition = new Vector3(nichromeBasePosition.x, i, nichromeBasePosition.z);
            yield return new WaitForSeconds(0.08f);
        }
        StartCoroutine(showFire(n));
    }

    IEnumerator showFire(int n)
    {
        for (int i = 0; i < 7; i++)
            Fire[i].SetActive(false);
        Fire[n].SetActive(true);
        Fire[n].GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 6; i++)
            elementButtons[i].interactable = true;
    }
}
