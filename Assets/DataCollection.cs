using ChainedRam.Core.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : MonoBehaviour {


    private static System.Random r = new System.Random(); 

    public Animal[] animals;
    int prevAnimal = 0; 

    public Clickable[] Clickables;
    int prevClick = 0;

    public GameObject Clapping;

    public AudioSource ClappingSource;
    public AudioClip yay; 

    int scoreCount = 0; 


    private void Awake()
    {
        animals = GetComponentsInChildren<Animal>(); 
    }

    public Animal GetRandomPair()
    {

        return GetRandom(animals, ref prevAnimal); 
    }

    public Clickable getRandomClickable()
    {
        return GetRandom(Clickables, ref prevClick);
    }


    public void SwitchClickable(Clickable current)
    {
        scoreCount++; 
        current.ShutDown();


        var next = getRandomClickable();


        if(scoreCount < 5)
            StartCoroutine(DelayedStart(next)); 
        else
        {
            scoreCount = 0;
            StartCoroutine(ShowClapping(DelayedStart(next))); 
        }
    }

    private IEnumerator ShowClapping(IEnumerator next)
    {
        yield return new WaitForSeconds(1f);
        Clapping.gameObject.SetActive(true); 
        ClappingSource.Play();
        ClappingSource.PlayOneShot(yay, 2f); 

        yield return new WaitForSeconds(3f);

        ClappingSource.Stop();
        Clapping.gameObject.SetActive(false);


        StartCoroutine(next);
    }

    IEnumerator DelayedStart(Clickable c)
    {
        yield return new WaitForSeconds(0.75f);
        c.Showup();

    }

    T GetRandom<T>(T[] array, ref int p)
    {
        int i;
        do
        {
            i = r.Next(array.Length); 
        } while (i == p);
      
        p = i; 
        return array[i]; 
    }
}
