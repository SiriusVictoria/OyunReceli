using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShooter : MonoBehaviour
{
    // Projectile prefabs to be shot
    [SerializeField] private Projectile m_projectile;

    // Size of the player, used as a variable in determining where to spawn the projectile
    private Vector2 m_playerSize;

    // Input so that we can set the Event listeners for the shoot input
    private PlayerInput m_playerInput;

    // Whether or not this object can shoot
    private bool m_shooterEnabled;

    // Direction where to aim fire ball
    private Vector3 m_direction;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
      m_playerInput = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    private void Start()
    {
        // Add the Spawn projectile as an event listener to the input
        m_playerInput.SetOnAttackCallback(SpawnProjectile);
    }
    public void SpawnProjectile(XDirection p_direction)
    {
        if(m_shooterEnabled)
        {
            StartCoroutine(SpawnProjectileCoroutine(p_direction));
        }   
    }
    private IEnumerator SpawnProjectileCoroutine(XDirection p_direction)
    {
        

        }    // Set Proper direction
            m_direction = Vector3.zero;
            if (p_direction == XDirection.LEFT)
            {
                m_direction = Vector3.left;
            }
            else if (p_direction == XDirection.RIGHT)
            {
                m_direction = Vector3.right;
            }
        }
    }
/// Set Whether or not the object is able to shoot projectiles
    /// </summary>
    public void SetShooter(bool p_active)
    {
        m_shooterEnabled = p_active;
    }

    public void SpawnFireballCallback()
    {
        // Spawn the projectile in the desired direction
        Projectile projectile = Instantiate(m_projectile, transform.position + m_direction * (m_playerSize.x + 1.125f), Quaternion.identity);
        projectile.SetXDirection(m_direction == Vector3.left ? XDirection.LEFT : XDirection.RIGHT);
    }

}
