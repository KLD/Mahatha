using ChainedRam.Core.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : MonoBehaviour {


    private static System.Random r = new System.Random(); 

    public Animal[] animals;




    private void Start()
    {
        animals = GetComponentsInChildren<Animal>(); 
    }


    public Animal GetRandomPair()
    {
        return animals[r.Next(animals.Length)]; 
    }

}
