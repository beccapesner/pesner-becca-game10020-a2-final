using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    Animator animator;

    public float moveSpeed = 5.0f;
    public float gravity = -9.81f;

    public InputActionReference moveInput;
    public InputActionReference attackInput;
    public GameObject lanternObject;
    
    [HideInInspector] 
    public UnityEvent OnLanternToggle;
    private bool toggleLantern = true;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (OnLanternToggle == null)
            OnLanternToggle = new UnityEvent();
    }
    

    private void Update()
    {
        PlayerMotion();

        bool attack = attackInput.action.WasPressedThisFrame();
        
        if (attack)
        {
            ToggleLantern();
        }
    }

    void ToggleLantern()
    {
        toggleLantern = !toggleLantern;
        lanternObject.GetComponentInChildren<Light>().enabled = toggleLantern;
        OnLanternToggle.Invoke();
    }

    void PlayerMotion()
    {
        // the following is pretty standard character controller code
        
        // snap the player to the ground if already grounded
        // when jumping, gravity takes over
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 moveDirection = moveInput.action.ReadValue<Vector2>();

        Vector3 move = Vector3.right * moveDirection.x + Vector3.forward * moveDirection.y;
        Vector3 moveVelocity = move * moveSpeed;

        // allow gravity to impact y velocity
        velocity.y += gravity * Time.deltaTime;

        moveVelocity.y = velocity.y;
        
        // finally, Move the character
        controller.Move(moveVelocity * Time.deltaTime);


        // rotate the character using Quaternion LookRotation()
        // slerp = Spherical Linear Interpolation. smoothly interpolates between Quaternion rotations
        Vector3 horizontalVelocity = new Vector3(moveVelocity.x, 0f, moveVelocity.z);
        if (horizontalVelocity.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalVelocity);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                15f * Time.deltaTime
            );
        }

        // set the speed for the animator to change idle/walk states
        animator.SetFloat("Speed", horizontalVelocity.magnitude);
    }
}
