using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameWin = false;
    public  int storeTheTurn=1;
    public bool playerVsComputer = false;
    public bool playerVsPlayer = false;
    string buttonText;
    public AudioClip buttonClickSound;
    public AudioSource audioSouce;
    public bool activeturn = false;
    public GameObject[] WinningLines;    
    private void Awake()
    {
        audioSouce.GetComponent<AudioSource>();
        instance = this;
    }
    public void OnPlayerMove(int _index)
    {
        storeTheTurn++; 

        if (IsGameWonBy(GameUi.instance.playerX))
        {
            GameUi.instance.WinText(GameUi.instance.playerX);
            GameUi.instance.GameWinPanel();
        }
        if (IsGameWonBy(GameUi.instance.playerO))
        {
            GameUi.instance.WinText(GameUi.instance.playerO);
            GameUi.instance.GameWinPanel();
        }
         if (storeTheTurn >= 10 && !isGameWin)
        {
            GameUi.instance.GameOverPanel();
            
        }
        if (storeTheTurn % 2 == 0 && storeTheTurn<=9)
        {
            if (playerVsComputer && !isGameWin || activeturn)
            {

                    GameUi.instance.ActivePlayerX();
                    StartCoroutine(PlayervsComputer());
   
            }
            if (playerVsPlayer)
            { 

                GameUi.instance.ActivePlayerX();
                
            }
        }
        else
        {
                GameUi.instance.ActivePlayerO();
        }
    }
    public IEnumerator PlayervsComputer()
    {
        yield return new WaitForSeconds(2f);
        audioSouce.PlayOneShot(buttonClickSound);
            int randomNumber = 0;
            do
            {
                randomNumber = Random.Range(0, PlayerController.instance.buttons.Length);
            } while (!PlayerController.instance.buttons[randomNumber].interactable);
            
            GameUi.instance.ActivePlayerO();
        PlayerController.instance.OnBotButtonPressed(randomNumber);
        activeturn = false;
       
    }
    

    public bool IsGameWonBy(string player)
    {

        if (PlayerController.instance.buttons[0].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[1].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[2].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[0].SetActive(true);
            isGameWin = true;
            
            return true;
        }
        else if (PlayerController.instance.buttons[0].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[3].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[6].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[5].SetActive(true);
            isGameWin = true;
            
            return true;
        }
        else if (PlayerController.instance.buttons[0].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[4].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[8].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[6].SetActive(true);
            isGameWin = true;
            
            return true;
        }
        else if (PlayerController.instance.buttons[3].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[4].GetComponentInChildren<Text>().text == player &&PlayerController.instance. buttons[5].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[1].SetActive(true);
            isGameWin = true;
           
            return true;
        }
        else if (PlayerController.instance.buttons[6].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[7].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[8].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[2].SetActive(true);
            isGameWin = true;
          
            return true;
        }
        else if (PlayerController.instance.buttons[1].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[4].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[7].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[3].SetActive(true);
            isGameWin = true;
            
            return true;
        }
        else if (PlayerController.instance.buttons[2].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[4].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[6].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[4].SetActive(true);
            isGameWin = true;
          
            return true;
        }
        else if (PlayerController.instance.buttons[2].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[5].GetComponentInChildren<Text>().text == player && PlayerController.instance.buttons[8].GetComponentInChildren<Text>().text == player)
        {
            WinningLines[7].SetActive(true);
            isGameWin = true;
          
            return true;
        }
        return false;
    }



}
