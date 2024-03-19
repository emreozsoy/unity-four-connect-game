using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class blackCircle : MonoBehaviour
{
    private int colorChange;
    int row, col;

    public gameController gameController;


    void Start()
    {

    }

    // Update is called once per frame
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameController.moveCount >= 8)
        {

            if (collision.name == ("Yellow(Clone)"))
            {
                row = Int32.Parse(this.gameObject.name.Substring(1, 1));
                col = Int32.Parse(this.gameObject.name.Substring(3, 1));

                colorChange = 1;
                gameController.gameArea[row, col] = 1;
                StartCoroutine(WaitAndPrint(2));

            }
            if (collision.name == ("Red(Clone)"))
            {
                row = Int32.Parse(this.gameObject.name.Substring(1, 1));
                col = Int32.Parse(this.gameObject.name.Substring(3, 1));

                colorChange = 2;
                print("red GELDÝ");
                gameController.gameArea[row, col] = 2;

                StartCoroutine(WaitAndPrint(2));

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameController.moveCount >= 8)
        {
            if (collision.name is "Yellow(Clone)" or "Red(Clone)")
            {
                StopCoroutine(WaitAndPrint(2));
                colorChange = 0;
                print("Siyah oldu GELDÝ = " + colorChange);
                gameController.gameArea[row, col] = 0;
            }
        }
    }

  IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

       if(gameController.WinningCondition(gameController.gameArea, colorChange))
        {
            int x = 100;
            while (x > 10)
            {
                x--;
                print("OLDUUUUUU");
            }
        }
        /*
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                print("gameArea[" + i + "," + j + "]" + gameController.gameArea[i,j]);
            }

        }
        */
    }
}
