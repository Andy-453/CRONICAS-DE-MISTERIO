using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;
    
    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject keyManager;    

    [HideInInspector]
    public GameObject DocumentManager;    
    
    [HideInInspector]
    public GameObject key;

    [HideInInspector]
    public GameObject Document;

    public bool playersKey;
    public bool playersDocument;

    private void Start()
    {
        keyManager = GameObject.FindWithTag("KeyManager");
        if (!playersKey)
        {
            int allkeys = keyManager.transform.childCount;
            for(int i = 0; i < allkeys; i++)
            {
                if(keyManager.transform.GetChild(i).gameObject.GetComponent<items>().ID == ID)
                {
                    key = keyManager.transform.GetChild(i).gameObject;
                }
            }
        }
        DocumentManager = GameObject.FindWithTag("DocumentManager");
        if (!playersDocument)
        {
            int allDocuments = DocumentManager.transform.childCount;
            for (int i = 0; i < allDocuments; i++)
            {
                if (DocumentManager.transform.GetChild(i).gameObject.GetComponent<items>().ID == ID)
                {
                    Document = DocumentManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    private void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                equipped = false;
            }
            if (equipped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void itemUsage()
    {
        if( type == "Key")
        {
            key.SetActive(true);

            key.GetComponent<items>().equipped = true;
        }
        if (type == "Document")
        {
            Document.SetActive(true);

            Document.GetComponent<items>().equipped = true;
        }
    }
}
