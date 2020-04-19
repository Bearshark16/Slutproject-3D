using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemSpawner : NetworkBehaviour
{
    [SerializeField]
    public List<string> keys = new List<string>();
    public List<GameObject> values = new List<GameObject>();

    public GameObject itemSpawnPoints;

    private Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();

    private Random gen = new Random();

    private void Awake()
    {
        if (keys.Count != 0 && values.Count != 0)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                items.Add(keys[i], values[i]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform ch in itemSpawnPoints.transform)
        {
            int index = Random.Range(0, values.Count);
            GameObject x = Instantiate(values[index], ch.position, ch.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
