using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocus)    // If currently being focused
        {
            
            if (!hasInteracted)
            {
                // Interact with the object
                hasInteracted = true;
                Interact();
                
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
    }

    // This method is meant to be overwritten
    public virtual void Interact()
    {
        Debug.Log("Has interacted");
    }
}
