using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player details")]
    private string playerName;
    private Rigidbody2D rb;
    [SerializeField]private float moveSpeed = 5f; //Serialize to edit in Unity Inspector
    private Vector2 moveInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get the componenet of what this is attached to
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if(context.canceled) //when movement is stopped on keyboard or analog stick
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>(); //most recent context read value
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
}
