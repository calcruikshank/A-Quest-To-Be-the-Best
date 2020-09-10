using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptionParent : MonoBehaviour
{

    public CharacterUI charUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!charUI.charUIisActive)
        {
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
                
        }
    }
}
