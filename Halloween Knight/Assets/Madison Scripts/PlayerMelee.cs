using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public bool this_happened = false;
    public bool ability_unlocked = false;
    public bool attacking = false;
    public GameObject melee_tracer;
    public Transform melee_start_position;
    public Transform melee_end_position;
    // Start is called before the first frame update
    void Start()
    {
        melee_tracer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ability_unlocked == true)
                StartCoroutine(startAttack());
        }
    }
    void OnTriggerStay(Collider other) {
        
         if (other.tag == "Enemy") {
             if (attacking == true)
             {
                this_happened = true;
                other.GetComponent<GhostAI>().receiveDamage(30,5f);
                attacking = false;
             }
         }
     }

     IEnumerator startAttack()
     {
         attacking = true;
         GetComponent<AudioSource>().Play(0);
         melee_tracer.SetActive(false);
         melee_tracer.transform.position = melee_start_position.position;
         melee_tracer.SetActive(true);
         yield return new WaitForSeconds(0.1f);
         melee_tracer.transform.position = melee_end_position.position;
         yield return new WaitForSeconds(1);
         melee_tracer.SetActive(false);
         attacking = false;
     }
}
