using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordClass : MonoBehaviour
{

    public int CorrectID;

    private Text myText;

    [SerializeField]
    private string editedWord;

    [SerializeField]
    private GameObject audioCorrect;

    private AudioSource correctAlert;


    private void Start()
    {
        correctAlert = audioCorrect.GetComponent<AudioSource>();
        myText = this.gameObject.GetComponent<Text>();        
    }



    public void EditWord()
    {
        correctAlert.Play();
        myText.text = editedWord;
    }




}
