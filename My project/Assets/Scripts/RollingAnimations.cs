using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RollingAnimations : MonoBehaviour
{
    public GameObject button;
    public GameObject targetObject;

    private void Start()
    {
        HoverButton hoverButton = button.GetComponent<HoverButton>();
        if (hoverButton != null)
        {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
        }
        else
        {
            Debug.LogError("HoverButton component not found on the button object.");
        }
    }

    private void OnButtonDown(Hand hand)
    {
        Debug.Log("Button pressed");

        Animator animator = targetObject.GetComponent<Animator>();
        if (animator != null)
        {
            if (animator.speed == 0)
            {
                animator.speed = 1;
            }
            else
            {
                animator.speed = 0;
            }
        }
    }
}
