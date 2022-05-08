using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    //public string dialog;
    public bool playerInRange;
    public GameObject pressSpace;
    [SerializeField] Dialog dialog;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
           
       
                StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
                pressSpace.SetActive(false);
            }

        

        }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player In Range");
            playerInRange = true;
            pressSpace.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Left Range");
            playerInRange = false;
            
            pressSpace.SetActive(false);
        }
    }
}

