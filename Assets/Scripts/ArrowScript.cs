using UnityEngine;

public class ArrowScript : MonoBehaviour
{
  public int damage;

  void OnTriggerEnter(Collider col) 
  {    
     if(col.GetComponent<EnemyStats>())
    {
        EnemyStats stats = col.GetComponent<EnemyStats>();
        stats.Hit(damage);
    }
      
  }

}
