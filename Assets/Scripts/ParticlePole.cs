using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePole : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float radius;
    [SerializeField] float force;
 
    [SerializeField] enum POLESTATE { POSITIVE, NEGATIVE };
    [SerializeField] POLESTATE poleState;
    Vector2 dir = Vector2.zero;

    private void FixedUpdate()
    {
        Collider2D [] colls2D = Physics2D.OverlapCircleAll(transform.position, radius);
        if(colls2D != null)
        {
            foreach(Collider2D col in colls2D)
            {
                if (col.gameObject.CompareTag("Enemy"))
                {
                    switch (poleState)
                    {
                        //ROJO
                        case POLESTATE.POSITIVE:
                            dir = (col.transform.position - transform.position).normalized;
                            break;
                        //AZUL
                        case POLESTATE.NEGATIVE:
                            dir = (transform.position - col.transform.position).normalized;
                            break;         
                    }
                    col.GetComponent<Rigidbody2D>().AddForceAtPosition(dir * force, col.transform.position, ForceMode2D.Force);
                    print("Empujando");
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
