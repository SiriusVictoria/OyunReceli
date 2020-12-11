using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
  public int damage;
  void OnTriggerEnter(Collider col) 
  {
     if (Input.GetKeyDown(attackbutton))
     {
<<<<<<< Updated upstream
         if (col.GetComponent<EnemyStats>())
         {              
             EnemyStats stats = col.GetComponent<EnemyStats>();
             stats.Hit(damage);
         }
=======
         if (col.GetComponent<EnemyStats>()
         {
             EnemyStats stats = col.GetComponent<EnemyStats>();
             stats.Hit(damage);
         })
>>>>>>> Stashed changes
     }
  }

}
