using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemSpawner : NetworkBehaviour
{
    [SerializeField]
    public List<string> keys = new List<string>();
    public List<GameObject> values = new List<GameObject>();

    private Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(keys.Count != 0 && values.Count != 0)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                items.Add(keys[i], values[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
