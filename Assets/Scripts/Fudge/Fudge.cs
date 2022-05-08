using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fudge : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public GameObject pressSpace;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                pressSpace.SetActive(false);


            }
 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player In Range");
            playerInRange = true;
            pressSpace.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Left Range");
            playerInRange = false;
            dialogBox.SetActive(false);
            pressSpace.SetActive(false);
        }
    }
}
