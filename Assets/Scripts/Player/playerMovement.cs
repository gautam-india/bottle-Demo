using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{


    public Rigidbody2D playerRigidbody;
    public float jumpVelocity;
    public float moveSpeed;
    public BoxCollider2D playerCollider;

    [SerializeField]
    private LayerMask environmentLayerMask;

    public Transform collidedItem;
    [SerializeField] Animator playerAnim;

    
    private void Awake()
    {
        playerAnim = this.GetComponentInChildren<Animator>();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        playerCollider = transform.GetComponent<BoxCollider2D>();
        offsetX();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAnim.SetInteger("isJumped", 0);
    }



    // Update is called once per frame
    void Update()
    {
        getCollidedItem();

        
        // FOR JUMPING AND MOVING THE BOTTLE IN FORWARD DIRECTION
        if (isGrounded() && Input.GetMouseButtonDown(0))
        {
            
            playerAnim.SetInteger("isJumped", 1);
            Vector2 velocityY = Vector2.up * jumpVelocity;
            playerRigidbody.velocity = new Vector2( + moveSpeed ,velocityY.y);
        }
        // MOVE THE PLAYER IF ITS ON A MOVING OBJECT FOR NOW ONLY AMBULANCE IS MOVING 
        if (isGrounded() && collidedItem.name == "Ambulance")
        {
            Vector3 temp = transform.position;
            temp.x = collidedItem.position.x;
            transform.position = temp;
        }
        if (isGrounded() && playerRigidbody.velocity.y == 0)
        {
            playerAnim.SetInteger("isJumped", 0);
        }
       
        
    }

    public bool isGrounded()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, extraHeight, environmentLayerMask);
        Color rayColor;

        if (raycastHit2D.collider != null)
        {
            
            rayColor = Color.green;
            
        }
        else
        {
            
            rayColor = Color.red;
        }


        Debug.DrawRay(playerCollider.bounds.center + new Vector3(playerCollider.bounds.extents.x, 0), Vector2.down * (playerCollider.bounds.extents.y + extraHeight), rayColor);

        Debug.DrawRay(playerCollider.bounds.center - new Vector3(playerCollider.bounds.extents.x, 0), Vector2.down * (playerCollider.bounds.extents.y + extraHeight), rayColor);

        Debug.DrawRay(playerCollider.bounds.center - new Vector3(playerCollider.bounds.extents.x, playerCollider.bounds.extents.y), Vector2.right  * (playerCollider.bounds.extents.y), rayColor);

        

        return raycastHit2D.collider != null;
    }

    void getCollidedItem()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, extraHeight, environmentLayerMask);

        collidedItem = raycastHit2D.transform;

    }

    void offsetX()
    {
        cameraMovement.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }
}
