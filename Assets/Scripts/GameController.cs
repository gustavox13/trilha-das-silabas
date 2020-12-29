using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] words = new GameObject[8];

    private int currentWord = 0;

    private int currentCorrectID;

    public int QuantPlays = 0;

    [SerializeField]
    private GameObject kitAnswer1;

    [SerializeField]
    private GameObject kitAnswer2;

    [SerializeField]
    private GameObject finalScreen;

    [SerializeField]
    private GameObject tutorialScreen;

    [SerializeField]
    private GameObject Adelaide;

    private Animator adelaideAnim;

    private AudioSource adelaideSom;

    private string currentdirection;



    [SerializeField]
    private GameObject scenary;

    private Animator scenaryAnim;

    [SerializeField]
    private GameObject school;

    private Animator schoolAnim;

    private void Awake()
    {
        ShuffleQuestions();
        adelaideAnim = Adelaide.GetComponent<Animator>();
        adelaideSom = Adelaide.GetComponent<AudioSource>();
        scenaryAnim = scenary.GetComponent<Animator>();
        schoolAnim = school.GetComponent<Animator>();
    }


    public void CloseTutoAndStart()
    {
        tutorialScreen.SetActive(false);
        StartTurn();

    }





    //INICIA O TURNO
    private void StartTurn()
    {
        words[currentWord].SetActive(true);

        //if(words[currentWord].GetComponent<WordClass>().CorrectID == 1 || words[currentWord].GetComponent<WordClass>().CorrectID == 2) //SELECIONA E ATIVA O KIT DE RESPOSTAS
        //{
            kitAnswer1.SetActive(true);
        //}
       // else
        //{
          //  kitAnswer2.SetActive(true);
        //}
    }

    //VERIFICA A RESPOSTA
    public void CheckAnswer(int selectedAnswer)
    {
        QuantPlays++;

        if (selectedAnswer == words[currentWord].GetComponent<WordClass>().CorrectID)
        {
            StartCoroutine(CorrectAnswer());
        }
        else
        {
            StartCoroutine(WrongAnswer());
        }
    }

    
    public void getDirection(string direction)
    {

        currentdirection = direction;
        Debug.Log(currentdirection);
    }
    

    IEnumerator WrongAnswer()
    {

        //if (words[currentWord].GetComponent<WordClass>().CorrectID == 1 || words[currentWord].GetComponent<WordClass>().CorrectID == 2) //SELECIONA E DESATIVA O KIT DE RESPOSTAS
        //{
            kitAnswer1.SetActive(false);
       // }
       // else
       // {
        //    kitAnswer2.SetActive(false);
       // }


        adelaideSom.Play();
        adelaideAnim.SetTrigger("wrong");

        yield return new WaitForSeconds(1f);

        StartTurn();
    }


    IEnumerator CorrectAnswer()
    {

       // if (words[currentWord].GetComponent<WordClass>().CorrectID == 1 || words[currentWord].GetComponent<WordClass>().CorrectID == 2) //SELECIONA E DESATIVA O KIT DE RESPOSTAS
        //{
            kitAnswer1.SetActive(false);
       // }
       // else
       // {
       //     kitAnswer2.SetActive(false);
       // }

        words[currentWord].GetComponent<WordClass>().EditWord();


        yield return new WaitForSeconds(1.2f);

        adelaideAnim.SetTrigger(currentdirection);


        yield return new WaitForSeconds(1.6f);

        schoolAnim.SetTrigger("aument");
        scenaryAnim.SetTrigger("advance");
        

        yield return new WaitForSeconds(0.5f);

        words[currentWord].SetActive(false);

        FinalStep();
    }


    private void FinalStep()
    {
        if(currentWord < 7)
        {
            currentWord++;
            StartTurn();
        }
        else
        {
            StartCoroutine(FinalAnimation());
        }
    }


    IEnumerator FinalAnimation()
    {

        
        scenaryAnim.SetTrigger("finish");

        yield return new WaitForSeconds(1.6f);

        adelaideAnim.SetTrigger("arrived");


        yield return new WaitForSeconds(3f);

        finalScreen.SetActive(true);
        Debug.Log(QuantPlays);
    }





    //EMBARALHAR FRASES
    private void ShuffleQuestions()
    {
        for (int i = 0; i < words.Length; i++)
        {
            GameObject obj = words[i];
            int randomizeArray = Random.Range(0, i);
            words[i] = words[randomizeArray];
            words[randomizeArray] = obj;
        }
    }
}
