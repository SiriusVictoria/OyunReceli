using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{
     /// <summary>
     /// The speed when falling
     /// </summary>
     [SerializeField]
     private float m_FallSpeed = 0f;
 
     /// <summary>
     /// 
     /// </summary>
     private Rigidbody m_Rigidbody = null;
 
     // Awake is called before Start function
     void Awake()
     {
         m_Rigidbody = GetComponent<Rigidbody>();
     }
 
     // Update is called once per frame
     void Update()
     {
         if (IsGliding && m_Rigidbody.velocity.y < 0f && Mathf.Abs(m_Rigidbody.velocity.y) > m_FallSpeed)
             m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, Mathf.Sign(m_Rigidbody.velocity.y) * m_FallSpeed);
     }
 
     public void StartGliding()
     {
         IsGliding = true;
     }
 
     public void StopGliding()
     {
         IsGliding = false;
     }
 
     /// <summary>
     /// Flag to check if gliding
     /// </summary>
     public bool IsGliding { get; set; } = false;
 
}
