using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    private AudioSource Source;
    public AudioSource Shared; 

    public DataCollection collection;

    private SpriteRenderer spriteRenderer;
    private Animal current;

    public bool Initial; 




    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Source = GetComponent<AudioSource>(); 

        Showup(); 


        gameObject.SetActive(Initial);
        
    }

    private void Start()
    {
        Source.Play();
    }

    public void Showup()
    {
        current = collection.GetRandomPair();
        spriteRenderer.sprite = current.Sprite;
        Source.clip = current.Sound;

        gameObject.SetActive(true); 
    }

    public void ShutDown()
    {
        gameObject.SetActive(false); 
    }

    private void OnMouseDown()
    {
        Shared.PlayOneShot(current.Name, 2f); 
        collection.SwitchClickable(this); 
    }
   
}
