using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public bool playerInRange;


    public void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.onTarget){
            
            //if inventory is not full
            if(!InventorySystem.Instance.CheckIfFull()){
                InventorySystem.Instance.AddToInventory(ItemName);
                Destroy(gameObject);
            }
            else {

            }

        }
    }
    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Optional: Provide feedback to the player (e.g., show a prompt)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Optional: Hide the prompt when the player leaves the range
        }
    }
}
