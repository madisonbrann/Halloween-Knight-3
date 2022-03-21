using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGrapple : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ability_unlocked = false;
    public bool grappling = false;
    public LayerMask myLayerMask;
    public TextMeshProUGUI interact;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ability_unlocked == true)
        {
            RaycastHit hit;
            if(Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 500, myLayerMask))
            {
                if (hit.transform.gameObject.tag == "Grapple")
                {
                    interact.color = new Color32(128, 0, 128, 255);
                }
                else
                {
                    interact.color = new Color32(255, 255, 255, 255);
                }
            }
        }

         if (Input.GetKeyDown(KeyCode.F))
        {
            if (ability_unlocked == true)
            {
                RaycastHit hit;
                if(Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 500, myLayerMask))
                {
                   // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log(hit.transform.gameObject.tag);
                    if (hit.transform.gameObject.tag == "Grapple")
                    {
                       // Debug.Log("Ray hit grapple");
                        this.GetComponent<CharacterController>().enabled = false;
                        this.transform.position = hit.transform.position;
                        this.GetComponent<CharacterController>().enabled = true;
                    }
                }
                /*
                Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
                this.GetComponent<CharacterController>().enabled = false;
                rigid.isKinematic = false;
                //rigid.useGravity = false;
                rigid.AddForce(Camera.main.transform.forward * 10000f);
                rigid.isKinematic = true;
                grappling = true;
                */


                //yield return new WaitForSeconds(0.01f);
                //this.GetComponent<CharacterController>().enabled = true;
               // rigid.isKinematic = true;
                //rigid.useGravity = true;
               // Debug.Log("Grapple happened");
            }
        }
    }
/*s
    void OnCollisionEnter(Collision collision)
    {
        if (grappling == true)
        {
            grappling = false;
            Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
            this.GetComponent<CharacterController>().enabled = true;
        }

    }
*/
    public void stopGrapple()
    {
        Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }
}
