using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardCollection : MonoBehaviour
{

    public int defaultNumOfBasicCards = 2;

    
    public static CardCollection Instance;
    private Dictionary<string, SkillCard> allCardsDictionary = new Dictionary<string, SkillCard>();
    public Dictionary<SkillCard, int> quantityOfEachCard = new Dictionary<SkillCard, int>();

    private SkillCard[] allCardsArray;

    public void Awake()
    {
        Instance = this;

        allCardsArray = Resources.LoadAll<SkillCard>("");
        foreach (SkillCard sc in allCardsArray)
        {
            if (!allCardsDictionary.ContainsKey(sc.name))
                allCardsDictionary.Add(sc.name, sc);
        }
    }


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
