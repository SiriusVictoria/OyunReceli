using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1, cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);

        }
        if (Input.GetKey("2"))
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);

        }

    }
}
