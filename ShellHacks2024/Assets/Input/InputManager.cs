using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction movement;
    public InputAction attack;
    private PlayerControls playerControls;
    public UnityEvent OnAttackInput;


    void Awake()
    {
        playerControls = new PlayerControls();   
    }

    private void Update()
    {
        attack.performed += Attack;
    }

    private void OnEnable()
    {
        movement = playerControls.Player.Movement;
        attack = playerControls.Player.Attack;
        movement.Enable();
        attack.Enable();
    }
    private void OnDisable()
    {
        attack.performed -= Attack;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        OnAttackInput.Invoke();
    }

     
    

    
  

    
}
