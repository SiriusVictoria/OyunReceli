using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject avatar1, avatar2;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
=======

    // Start is called before the first frame update
    void Start()
    {

>>>>>>> main
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
<<<<<<< HEAD
            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
=======
            avatar1.transform.position = avatar2.transform.position;
            avatar1.transform.rotation = avatar2.transform.rotation;
            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
            


>>>>>>> main
        }

        if (Input.GetKey("2"))
        {
<<<<<<< HEAD
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
=======
            avatar2.transform.position = avatar1.transform.position;
            avatar2.transform.rotation = avatar1.transform.rotation;
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            

>>>>>>> main
        }
    }
}
