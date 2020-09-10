using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLibrary : MonoBehaviour
{

    #region Singleton
    public static CardLibrary instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of library");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPackOpened();
    public OnPackOpened onPackOpenedCallback;


    public List<GameObject> skillCards = new List<GameObject>();
    
    public bool Add(GameObject skillCard)
    {
        skillCards.Add(skillCard);

        if (onPackOpenedCallback != null)
        {
            onPackOpenedCallback.Invoke();
        }
        
        return true;
    }

    public void Remove(GameObject skillCard)
    {
        skillCards.Remove(skillCard);

        if (onPackOpenedCallback != null)
        {
            onPackOpenedCallback.Invoke();
        }
    }
}
