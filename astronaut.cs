
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustPower = 10f;  
    public float rotationSpeed = 200f;  
    private Rigidbody2D rb;
    private bool isThrusting = false;  
    private Vector2 thrustDirection;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float rotationInput = Input.GetAxis("Horizontal");
        if (rotationInput != 0)
        {
           
            transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isThrusting = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isThrusting = false;
        }
    }

    void FixedUpdate()
    {
        if (isThrusting)
        {
            
            thrustDirection = transform.up; 
            rb.AddForce(thrustDirection * thrustPower, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Vector2 contactNormal = collision.contacts[0].normal; 
        rb.AddForce(-contactNormal * thrustPower, ForceMode2D.Impulse);
    }
}