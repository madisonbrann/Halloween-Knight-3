using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStation : MonoBehaviour
{
    // Start is called before the first frame update
    public string ability;
    public int cost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deactivate()
    {
       // this.transform.parent.gameObject.SetActive(false);
       gameObject.SetActive(false);
    }

}
