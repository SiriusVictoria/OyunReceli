using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3;

    // Start is called before the first frame update
    void Start()
    {

        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            avatar1.transform.position = avatar2.transform.position;
            avatar1.transform.position = avatar3.transform.position;
            avatar1.transform.rotation = avatar2.transform.rotation;
            avatar1.transform.rotation = avatar3.transform.rotation;
            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);


        }

        if (Input.GetKey("2"))
        {
            avatar2.transform.position = avatar1.transform.position;
            avatar2.transform.position = avatar3.transform.position;
            avatar2.transform.rotation = avatar1.transform.rotation;
            avatar2.transform.rotation = avatar3.transform.rotation;
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            avatar3.gameObject.SetActive(false);


        }

        if (Input.GetKey("3"))
        {
            avatar3.transform.position = avatar1.transform.position;
            avatar3.transform.position = avatar2.transform.position;
            avatar3.transform.rotation = avatar1.transform.rotation;
            avatar3.transform.rotation = avatar2.transform.rotation;

            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(true);

        }
    }
}
