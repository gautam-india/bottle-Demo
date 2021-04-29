using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMove : MonoBehaviour
{
    public float speed;
    public float timeWait;
    

    public Rigidbody2D thisRigidbody;
    public BoxCollider2D ambulanceCollider;

    [SerializeField]
    private LayerMask playerMask;

    private void Awake()
    {
        timeWait = 0f;
        thisRigidbody = GetComponent<Rigidbody2D>();
        ambulanceCollider = GetComponent<BoxCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    

    // Update is called once per frame
    void Update()
    {
        timeWait += Time.deltaTime;
        

        // THIS IS TO CHECK WHEN THE PLAYER HAS COLLIDED WITH THE AMBULANCE OR NOT --- IF YES THEN START MOVING THE AMBULANCE
        if (isMoved())
        {
            // WHEN THE AMBULANCE MOVES IN FORWARD DIRECTION FOR 2 SEC.
            if (timeWait <= 2f)
            {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;
            }
            // MOVE THE AMBULANCE BACKWARD DIRECTION FOR 2 SEC
            else if (timeWait > 2f && timeWait <= 4f)
            {
                Vector3 temp = transform.position;
                temp.x -= speed * Time.deltaTime;
                transform.position = temp;
            }
            else if (timeWait > 4f)
            {
                timeWait = 0;
            }
        }


        // IF NOT THE JUST RETURN NULL TO STOP MOVEMENT
        else
        {

            return;
        }
       

    }



    public bool isMoved()
    {
        float extraHeight = 0.05f;

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(ambulanceCollider.bounds.center, ambulanceCollider.bounds.size, 0f, Vector2.up, extraHeight, playerMask);


        return raycastHit2D.collider != null;
    } 
}
