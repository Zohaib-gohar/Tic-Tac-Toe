using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Button[] buttons;
    int playervsPlayerTurnCount = 0;
   
    void Start()
    {
        instance = this;
    }
    public void OnPlayerButtonPressed(int _index)
    {
        if(GameManager.instance.playerVsPlayer)
        {
            playervsPlayerTurnCount++;
            
            
                if (playervsPlayerTurnCount % 2 == 0)
                {
                    GameManager.instance.audioSouce.PlayOneShot(GameManager.instance.buttonClickSound);
                    buttons[_index].GetComponentInChildren<Text>().text = GameUi.instance.playerX;
                    buttons[_index].interactable = false;
                    GameManager.instance.OnPlayerMove(_index);
                    
                }
                else
                {
                    GameManager.instance.audioSouce.PlayOneShot(GameManager.instance.buttonClickSound);
                    buttons[_index].GetComponentInChildren<Text>().text = GameUi.instance.playerO;
                    buttons[_index].interactable = false;
                    GameManager.instance.OnPlayerMove(_index);
                    
                }
                
            
            
        }
        else if(GameManager.instance.playerVsComputer && !GameManager.instance.activeturn)
        {
            
            
                GameManager.instance.audioSouce.PlayOneShot(GameManager.instance.buttonClickSound);
                buttons[_index].GetComponentInChildren<Text>().text = GameUi.instance.playerO;
                buttons[_index].interactable = false;
                GameManager.instance.OnPlayerMove(_index);
            GameManager.instance.activeturn = true;



        }
    }
    public void OnBotButtonPressed(int _index)
    {
        buttons[_index].GetComponentInChildren<Text>().text = GameUi.instance.playerX;
        buttons[_index].interactable = false;
        GameManager.instance.OnPlayerMove(_index);
    }

}

