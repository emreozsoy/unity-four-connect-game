using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public GameObject player1;
    public gameController gameController;

    bool isBusy = false;

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerClick()
    {

        if (!isBusy)
        {
            isBusy = true;
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f; // Z koordinatýný sýfýra ayarla (2D oyun için)
            if (gameController.moveCount % 2 == 0)
            {
                player1.gameObject.name = "Yellow";
                player1.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                player1.gameObject.name = "Red";
                player1.GetComponent<SpriteRenderer>().color = Color.yellow;
            }

            // Oyuncu objesini bu konumda oluþtur
            Instantiate(player1, clickPosition, Quaternion.identity);
            if (gameController.moveCount == 1)
            {
            }

            // gameController.PlayerMove(gameController.moveCount, 0, 0);
            gameController.moveCount++;
        }
        StartCoroutine(spawnTimer());
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(2);
        isBusy=false;
        
        
    }

}
