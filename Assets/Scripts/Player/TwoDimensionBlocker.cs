using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionBlocker : MonoBehaviour
{
    private PlayerMovement movement;
    [SerializeField] BoxCollider[] _2dblockers;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (movement.Check2D)
        {
            foreach(BoxCollider bc in _2dblockers)
            {
                bc.enabled = true;
            }  
        }
        else
        {
            foreach (BoxCollider bc in _2dblockers)
            {
                bc.enabled = false;
            }
        }
    }
}
