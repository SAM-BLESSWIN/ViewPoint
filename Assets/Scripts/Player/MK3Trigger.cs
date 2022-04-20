using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK3Trigger : MonoBehaviour
{
    private PlayerMovement movement;
    [SerializeField] BoxCollider keytrigger;
    [SerializeField] BoxCollider liftrigger;


    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(movement.Checkkey && keytrigger.enabled)
        {
            liftrigger.enabled = true;
            keytrigger.enabled = false;
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (movement.Check2D && other.gameObject.CompareTag("level4keytrigger"))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 9.25f);
        }

        if (movement.Check2D && movement.Checkkey && other.gameObject.CompareTag("level4lifttrigger"))
        {
           gameObject.transform.position = new Vector3(1.45f, 1.10f, 4.10f);
        }
    }

}
