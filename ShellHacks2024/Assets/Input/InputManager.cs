using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction movement;
    public InputAction attack;
    public InputAction pause;
    private PlayerControls playerControls;
    public UnityEvent OnAttackInput;
    public UnityEvent OnPause;


    void Awake()
    {
        playerControls = new PlayerControls();   
    }

    private void Update()
    {
        attack.performed += Attack;
        pause.performed += Pause;

    }

    private void OnEnable()
    {
        movement = playerControls.Player.Movement;
        attack = playerControls.Player.Attack;
        pause = playerControls.Player.Pause;
        movement.Enable();
        attack.Enable();
        pause.Enable();
    }
    private void OnDisable()
    {
        attack.performed -= Attack;
        pause.performed -= Pause;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        OnAttackInput.Invoke();

    }
    private void Pause(InputAction.CallbackContext context)
    {
        Debug.Log("Pause");
        OnPause.Invoke();
    }

     
    

    
  

    
}
