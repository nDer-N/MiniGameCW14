using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewMonoBehaviourScript2 : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float spins = 50f;
    public float returnSpeed = 720f;
    private bool isSpinning = false;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Quaternion originalRotation;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        Movement();
        if(Input.GetKeyDown(KeyCode.C))
        {
            ToggleSpin();
        }
        HandleSpin();
        
    }
     void ToggleSpin()
    {
        isSpinning = !isSpinning;
    }
     void HandleSpin()
     {
        if(isSpinning)
        {
            transform.Rotate(0f, 0f, -spins * Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                originalRotation,
                returnSpeed * Time.deltaTime
            );
        }

     }
     void Movement()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
