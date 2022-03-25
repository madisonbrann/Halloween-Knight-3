using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public List<GameObject> enemy_list = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Pursuing Trigger");
            for (int i = 0; i < enemy_list.Count; i++)
            {
                enemy_list[i].GetComponent<GhostAI>().pursuing = true;
            }
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Pursuing Trigger");
            for (int i = 0; i < enemy_list.Count; i++)
            {
                enemy_list[i].GetComponent<GhostAI>().pursuing = false;
            }
        }
    }
}
