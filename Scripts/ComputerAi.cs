using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAi : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayervsComputer()
    {
        yield return new WaitForSeconds(2f);
       
        if (GameManager.instance.playerVsComputer)
        {
            
            
                int randomNumber = Random.Range(0, PlayerController.instance.buttons.Length);
                while(PlayerController.instance.buttons[randomNumber].interactable)
                {
                   



                }


            
        }
    }
}
