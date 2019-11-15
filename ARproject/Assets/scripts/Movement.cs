using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Butterfly;
    public GameObject Eagle;
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            Butterfly.transform.Rotate(0, 90, 0, Space.Self);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Butterfly.GetComponent<Rigidbody>().AddForce(transform.up * 1200f);

        if (Input.GetKey(KeyCode.Alpha3))
            Eagle.transform.Rotate(0, 90, 0, Space.Self);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Eagle.GetComponent<Rigidbody>().AddForce(transform.up * 1200f);
    }
}
