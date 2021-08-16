using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerMask;
    public DialogSetings dialog;

    bool playerHit;
    private List<string> sentences = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerMask);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialog.dialogues.Count; i++)
        {
            switch (DialogControl.instance.language) {
                case DialogControl.idiom.pt:
                    sentences.Add(dialog.dialogues[i].sentence.portuguese);
                    break;
                case DialogControl.idiom.eng:
                    sentences.Add(dialog.dialogues[i].sentence.english);
                    break;
                case DialogControl.idiom.spa:
                    sentences.Add(dialog.dialogues[i].sentence.spanish);
                    break;            
            }            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
