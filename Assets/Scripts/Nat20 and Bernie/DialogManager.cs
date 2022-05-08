using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    public bool playerInRange;

    public static DialogManager Instance { get; private set; }

 


    private void Awake()
    {
        Instance = this;
    }

    int currentLine = 0;
    Dialog dialog;
    bool isTyping;

    public IEnumerator ShowDialog(Dialog dialog)
    {

        yield return new WaitForEndOfFrame();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            currentLine++;
            if (currentLine < dialog.Lines.Count)
            {
                

                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
            }
            
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }



private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Player In Range");
        playerInRange = true;
       
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Player Left Range");
        playerInRange = false;
            dialogBox.SetActive(false);

        
    }
}
}

