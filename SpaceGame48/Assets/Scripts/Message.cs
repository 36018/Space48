using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text introField;

    [SerializeField] private TMP_Text messageField;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Introduction());

        StartMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.");
    }

    public void StartMessage(string message)
    {
        StartCoroutine(ShowMessage(message));
    }
    
   /* IEnumerator Introduction() {
        yield return new WaitForSeconds(0.2f);
        introField.enabled = true;
        
        yield return new WaitForSeconds(5f);
        introField.enabled = false;
    }*/
    IEnumerator ShowMessage(string message) {
       
        messageField.enabled = true;
        messageField.text = message;
        Debug.Log(message);
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
     
    }
    
}

    /*TO DO 
    
    Optie 1:

    void GetHit(){ 
        //zorg voor enemies die terugschieten. Als je geraakt wordt gaan er levens af. als je levens op zijn ben je af en herstart de game.
    }  
    void HealthBoost(){ 
        //zorg voor een extra powerup die je een health boost geeft
    }

    Optie 2:

    void ActivateShield(){ 
        //Zorg voor een energie schild dat aangezet kan worden     
    }
    void DeactivateShield(){
        //Zorg dat je het schild uit kunt zetten om energie te sparen
    }
    void CheckShieldEnergy(){
        //zorg dat je energie op gaat bij gebruik van het schild
        //is de energie op dan gaat het schild uit
    }
    void RegenerateShield(){
        //Zorg dat je schild langzaam regenereert
    } 

    */


