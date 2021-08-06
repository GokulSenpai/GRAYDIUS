using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomBackgroundGenerator : MonoBehaviour
{
    public GameObject[] randomBackgroundGen;

    public float repeatRate = 2.69f;

    private float _previousIteration;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(Generator), 0f, repeatRate);
    }

    private void Generator()
    {
        int randomNumber = Random.Range(0, 7);

        if (Math.Abs(_previousIteration - randomNumber) < 0.00001)
        {
            randomNumber = Random.Range(0, 7);
        }
        else
        {
            _previousIteration = randomNumber;
        }
        
        for (int i = 0; i < randomBackgroundGen.Length; i++)
        {
            if (randomNumber == i)
            {
                randomBackgroundGen[randomNumber].SetActive(true);
            }
            else
            {
                randomBackgroundGen[i].SetActive(false);
            }
        }
    }
    
}
