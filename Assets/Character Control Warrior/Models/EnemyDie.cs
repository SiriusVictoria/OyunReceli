using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    bool isAlive;

    public GameObject chickenPrefab;

    void Start()
    {
        isAlive = true;

    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.name == "Knight")
        {
            if (collision.collider.gameObject.GetComponent<MeleeCharMovement>())
            {
                if (collision.collider.gameObject.GetComponent<MeleeCharMovement>().isAttacking)
                {
                    GetComponent<Animator>().SetBool("died", true);
                }
            }
        }

        else if (collision.collider.name == "Prop_Arrow_01(Clone)")
        {
            GetComponent<Animator>().SetBool("died", true);
        }

        else if (collision.collider.name == "Orb(Clone)")
        {
            GetComponent<Animator>().SetBool("died", true);
            Invoke("ChangeChicken", 1f);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Knight")
        {
            if (collision.collider.gameObject.GetComponent<MeleeCharMovement>())
            {
                if (collision.collider.gameObject.GetComponent<MeleeCharMovement>().isAttacking)
                {
                    GetComponent<Animator>().SetBool("died", true);
                }
            }
        }
    }

    private void ChangeChicken()
    {
        Instantiate(chickenPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
