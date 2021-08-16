using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogObj; //Janela do dialogo
    public Image profileSprite; //Sprite do perfil
    public Text speechText; //Texto da fala
    public Text actorNameText; //Nome do npc

    [Header("Settings")]
    public float typingSpeed; //Velocidade da fala

    //Variáveis de controle
    private bool isShowing; //Se a janela esta ativa ou não
    private int index; //Index das sentenças
    private string[] sentences;

    public static DialogControl instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Pular para próxima frease/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //Quando termina os Textos
            {
                speechText.text = "";
                index = 0;
                dialogObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //Charmar a fala do NPC
    public void Speech( string[] txt)
    {
        if (!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
