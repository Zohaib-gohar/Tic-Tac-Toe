using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public static GameUi instance;
    public Text playerXturnText;
    public Text playerOturnText;
    public GameObject winningPanel;
    public GameObject gamePanel;
    public GameObject mainPanel;
    public GameObject gameover;
    public Text WiningText;
    public string playerX = "X";
    public string playerO = "O";
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void onGamePlayWithPlayer()
    {
        GameManager.instance.playerVsPlayer=true;
        gamePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void onGamePlayWithComputer()
    {
        GameManager.instance.playerVsComputer = true;
        gamePanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        mainPanel.SetActive(false);
    }
 
    public void ActivePlayerX()
    {
        playerXturnText.gameObject.SetActive(true); 
        playerOturnText.gameObject.SetActive(false);
    }
    public void ActivePlayerO()
    {
        playerXturnText.gameObject.SetActive(false);
        playerOturnText.gameObject.SetActive(true);
    }
    public void GameOverPanel()
    {
        StartCoroutine(GameTie());
    }

    IEnumerator GameTie()
    {
        yield return new WaitForSeconds(3);
        gameover.SetActive(true);
        mainPanel.SetActive(false);
    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(4);
        winningPanel.SetActive(true);
        gamePanel.SetActive(false);
        for (int i = 0; i < GameManager.instance.WinningLines.Length; i++)
        {
            GameManager.instance.WinningLines[i].SetActive(false);

        }
        
    }
    public void GameWinPanel()
    {
        for (int i = 0; i < PlayerController.instance.buttons.Length; i++)
        {

            PlayerController.instance.buttons[i].interactable=false;
        }
        
        StartCoroutine(WinDelay());
       
    }
    public void WinText(string _wintext)
    {
        WiningText.text = "Player  "+ _wintext +"  Win!!";
    }
}
