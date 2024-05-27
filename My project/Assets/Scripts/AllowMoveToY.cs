using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class AllowMoveToY : MonoBehaviour
{
    private Interactable interactable;
    private Vector3 initialPosition;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (interactable != null && interactable.attachedToHand != null)
        {
            Vector3 currentTransform = transform.position;
            if (transform.hasChanged)
            {

                gameObject.transform.position = new Vector3(initialPosition.x, currentTransform.y, initialPosition.z);
                if(currentTransform.y < initialPosition.y)
                {
                    gameObject.transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
                }
            }            
        }
    }
}
