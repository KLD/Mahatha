using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {


    public Clickable other;

    private AudioSource Source;
    public AudioSource Shared; 

    public DataCollection collection;

    private SpriteRenderer spriteRenderer;
    private Animal current;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Source = GetComponent<AudioSource>(); 
        GetNewAnimal(); 
        Source.Play(); 
    }

   
    private void GetNewAnimal()
    {
        current = collection.GetRandomPair();
        spriteRenderer.sprite = current.Sprite;
        Source.clip = current.Sound;
    }


    private void OnMouseDown()
    {
        Shared.PlayOneShot(current.Name);

        this.gameObject.SetActive(false);
        other.gameObject.SetActive(true); 
        GetNewAnimal();
    }

    
}
