using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static int[,] gameArea;


    public static int moveCount = 1;
    //0 means the square is empty
    //1 means there is the first player move
    //2 means there is the second player move


    void Start()
    {
        gameArea = new int[6, 7];


        //Give gameArea starting numbers

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                gameArea[i, j] = 0;

                print("gameArea[" + i + "," + j + "]" + gameArea[i, j]);
            }

        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerMove(int moveCount,int row, int column)
    {
        int whichPlayer;


        if (moveCount >= 8)
        {
            if (moveCount % 2 == 0)
            {
                whichPlayer = 2;

                moveCount++;

                WinningCondition(gameArea,whichPlayer);
            }
            else
            {
                whichPlayer = 1;
                moveCount++;
            }
        }
        else
        {
            return; // turn null if game cannot finish
        }

    }

    public bool WinningCondition(int[,] gameBoard, int player)
    {
        // Check horizontal win
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (gameBoard[row, col] == player &&
                    gameBoard[row, col + 1] == player &&
                    gameBoard[row, col + 2] == player &&
                    gameBoard[row, col + 3] == player)
                {
                    return true;
                }
            }
        }

        // Check vertical win
        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (gameBoard[row, col] == player &&
                    gameBoard[row + 1, col] == player &&
                    gameBoard[row + 2, col] == player &&
                    gameBoard[row + 3, col] == player)
                {
                    return true;
                }
            }
        }

        // Check diagonal win (up-right direction)
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (gameBoard[row, col] == player &&
                    gameBoard[row + 1, col + 1] == player &&
                    gameBoard[row + 2, col + 2] == player &&
                    gameBoard[row + 3, col + 3] == player)
                {
                    return true;
                }
            }
        }

        // Check diagonal win (up-left direction)
        for (int row = 0; row < 3; row++)
        {
            for (int col = 3; col < 7; col++)
            {
                if (gameBoard[row, col] == player &&
                    gameBoard[row + 1, col - 1] == player &&
                    gameBoard[row + 2, col - 2] == player &&
                    gameBoard[row + 3, col - 3] == player)
                {
                    return true;
                }
            }
        }

        // If no winning condition is found, return false
        return false;
    }


    //Change text
    void GameOver(int whichPlayer)
    {
        // if(whichPlayer== 1) { return; }
        // else { return; }
    }


}

