using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private bool isMoving;
    private Vector2 input;
    

    private Animator animator;

    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

  

    //Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Remove diagonal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
              
                //Updates new position based on input
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                //Determines if the new location is walkable
                if (isWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }

            if (input.x > 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }

            if (input.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
        //Interacts with objects with the key
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact() {
        // var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));//
        var interactPos = transform.position; //+ facingDir//

         var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
    if (collider != null)
    {
        collider.GetComponent<Interactable>()?.Interact();
    }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //Changes sprite/player position
            //Takes into account current position, future position, and speed
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    //Searches for object type
    //If object is part of the "solidObjectsLayer" then the player cannot move on it
    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer | interactableLayer) != null)
    {
        return false;

    }
    return true;
    }
    }