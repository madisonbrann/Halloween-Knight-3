using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRanged : MonoBehaviour
{
    public bool ability_unlocked = false;
    public Transform rangedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (ability_unlocked == true)
                fireRanged();
        }
    }

    private void fireRanged()
    {
        //Debug.Log("fire called");
        Transform projectile = Instantiate(rangedPrefab, transform.position+(Camera.main.transform.forward*2), transform.rotation);
        Rigidbody rigid = projectile.GetComponent<Rigidbody>();
        rigid.AddForce(Camera.main.transform.forward * 1000f);
        //Destroy(projectile.gameObject, 2f);
    }
}
