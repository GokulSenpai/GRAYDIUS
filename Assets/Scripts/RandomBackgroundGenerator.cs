using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackgroundGenerator : MonoBehaviour
{
    public GameObject[] RandomBackgroundGen;

    // Start is called before the first frame update
    void Start()
    {
        RandomGen();
    }

    private IEnumerator Generator(int randomNumber)
    {
        for (int i = 0; i < RandomBackgroundGen.Length; i++)
        {
            if (randomNumber == i)
            {
                RandomBackgroundGen[randomNumber].SetActive(true);
            }
            else
            {
                RandomBackgroundGen[i].SetActive(false);
            }
        }
        yield return new WaitForSeconds(2.85f);
        RandomGen();
    }

    private void RandomGen()
    {
        int randomNumber = Random.Range(0, 7);
        StartCoroutine(Generator(randomNumber));
    }
}
