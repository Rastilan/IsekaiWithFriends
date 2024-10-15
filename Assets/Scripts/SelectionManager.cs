using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 
public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance {get; set;}
    
    public bool onTarget = false;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    public float rayDist = 10f;

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }
 
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDist))
        {
            var selectionTransform = hit.transform;
            InteractableObject interactble = selectionTransform.GetComponent<InteractableObject>();
 
            if (interactble && interactble.playerInRange)
            {
                onTarget = true;
                interaction_text.text = interactble.GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else 
            { 
                onTarget = false;
                interaction_Info_UI.SetActive(false);
            }
 
        }
        else {
            onTarget = false;
            interaction_Info_UI.SetActive(false);
        }
    }
}