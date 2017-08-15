using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    public GameObject cactus;
    public List<Transform> positions;

	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int random = Random.Range(0, positions.Count);
            Instantiate(cactus, positions[random].position, Quaternion.identity);
            positions.RemoveAt(random);
        }
        
    }
}
