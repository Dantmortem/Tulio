using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public bool isMovementEnabled = true;
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    public Camera cameramain;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = transform.Find("UnitRoot").GetComponent<Animator>();
    }
    
    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
    }
    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        if (isMovementEnabled)
        {
            movement = playerControls.Movement.Move.ReadValue<Vector2>();
            myAnimator.SetFloat("moveX", movement.x);
            myAnimator.SetFloat("moveY", movement.y);
        }
        else
        {
            movement = Vector2.zero;
        }
    }
    private void Move()
    {
        if (isMovementEnabled)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 playerScreenPoint = cameramain.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            myAnimator.SetBool("isFacingRight",false);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            myAnimator.SetBool("isFacingRight",true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
