using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandController : MonoBehaviour
{
    public InputActionReference gripInput;
    public InputActionReference triggerInput;
  
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator)return;
        float grip = gripInput.action.ReadValue<float>();
        float trigger = triggerInput.action.ReadValue<float>();
       
        
        animator.SetFloat("Grip", grip);
        animator.SetFloat("Trigger", trigger);
        
    }
}
