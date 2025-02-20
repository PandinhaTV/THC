using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController myCC;

    
    public Animator camAnimator;
    private bool isWalking;
    
    
    private Vector3 inputVector;
    private Vector3 moveVector;
    private float myGravity = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        
        moveVector = (inputVector * moveSpeed)+(Vector3.up*myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(moveVector * Time.deltaTime);
        
    }

    void CheckForHeadBob()
    {
        if (myCC.velocity.magnitude > 0.1f)
        {
            camAnimator.SetBool("isWalking", true);
        }
        else
        {
            camAnimator.SetBool("isWalking", false);
        }
            
    }
}
