using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Vector2 limit;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(transform.position, 0.2f, whatIsGround);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y) + limit, 0.1f);
    }
}
