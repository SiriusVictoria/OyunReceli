<<<<<<< HEAD
﻿using UnityEngine;

public class BowScript : MonoBehaviour
{
<<<<<<< Updated upstream
   float _charge;

   public float chargeMax;
   public float chargeRate;

   public KeyCode firebutton;
=======
   float _charge
>>>>>>> Stashed changes


}
=======
﻿using UnityEngine;

public class BowScript : MonoBehaviour
{
  float _charge; //how much our bow charges

  public float chargeMax;
  public float chargeRate;
  public KeyCode fireButton;

  public Transform spawn;
  public Rigidbody arrowObject;

  void Update() 
  {
      if(Input.GetKey(fireButton) && _charge < chargeMax)
      {
          _charge += Time.deltaTime * chargeRate;
          Debug.Log(_charge.ToString());
      }

      if(Input.GetKeyUp(fireButton))
      {
          Rigidbody arrow = Instantiate(arrowObject, spawn.position, Quaternion.identity) as Rigidbody; //new rigidbody for arrowObject
          arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
          _charge = 0; 
      }



  }

}
>>>>>>> main
