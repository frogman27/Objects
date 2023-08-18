using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveInput = new Vector2(horizontal, vertical).normalized;
        GetComponent<Rigidbody2D>().velocity = moveInput * moveSpeed;

        RotateTowardDirection();
    }

    private void RotateTowardDirection()
    {
        if(moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
}
