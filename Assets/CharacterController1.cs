using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float dash = 25f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.5f;
    private bool isDashing = false;
    private float dashTimeLeft;
    private float cooldownTimeLeft;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.right;
    private Vector2 dashDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        Movement();

        if (Input.GetKeyDown(KeyCode.C) && !isDashing && cooldownTimeLeft <= 0f)
        {
            StartDash();
        }
        if (isDashing)
        {
            dashTimeLeft -= Time.deltaTime;
            if (dashTimeLeft <= 0f) isDashing = false;
        }
        if (cooldownTimeLeft > 0f)
        {
            cooldownTimeLeft -= Time.deltaTime;
        }
        
    }

     void StartDash()
     {
        isDashing = true;
        dashTimeLeft = dashDuration;
        cooldownTimeLeft = dashCooldown + dashDuration;

        dashDirection = moveInput.sqrMagnitude > 0.01f ? moveInput.normalized : lastMoveDirection;
     }

     void Movement()
    {
        if(isDashing)
        {
            rb.MovePosition(rb.position + dashDirection * dash * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
       
    }
}
