using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class SelectionManager : MonoBehaviour
{
 
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    public float rayDist = 10f;
 
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
 
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else 
            { 
                interaction_Info_UI.SetActive(false);
            }
 
        }
        else {
            interaction_Info_UI.SetActive(false);
        }
    }
}