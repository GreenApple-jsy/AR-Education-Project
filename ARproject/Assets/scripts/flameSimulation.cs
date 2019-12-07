using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flameSimulation : MonoBehaviour
{
    Vector3 nichromeBasePosition = new Vector3(-1220.9f, -743.46f, 70.25f);
    Vector3 nichromeDesPosition = new Vector3(-1220.9f, -674.1f, 70.25f);
    public Button[] elementButtons = new Button[6];
    public GameObject nichromeWire;
    public GameObject [] Fire = new GameObject[7]; //0기본, 1나트륨, 2리튬, 3칼륨, 4스트론튬, 5구리, 6칼슘
    
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
        float ydiff = (736f - 670f) / 10;
        for (float i = -736f; i <= -670f; i+=ydiff)
        {
            nichromeWire.transform.localPosition = new Vector3(nichromeBasePosition.x, i, nichromeBasePosition.z);
            yield return new WaitForSeconds(0.09f);
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
