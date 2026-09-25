using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float frequency=1f;
    public float amplitude=1f;
    private float sineTimer;
    private Rigidbody2D rb;
    private bool SineActive = false;

    private Vector3 baseScale;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        Movement();
        if (Input.GetKeyDown(KeyCode.C))
        {
            SineActive = !SineActive;

            
            if (SineActive) sineTimer = 0f;
        }

        SineScale();
    }

        
    

     void Movement()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void SineScale()
    {
        if (SineActive)
    {   
        
        Debug.Log(SineActive);
       
        sineTimer += Time.deltaTime;
        float sine = Mathf.Sin(sineTimer * frequency);
        float scaleX = 1f + sine * amplitude;

        transform.localScale = new Vector3(baseScale.x * scaleX, baseScale.y, baseScale.z);
         
    }
    else 
    {
        sineTimer = 0f;
        transform.localScale = Vector3.Lerp(transform.localScale, baseScale, Time.deltaTime * 10f);
    }
    
    }
}
