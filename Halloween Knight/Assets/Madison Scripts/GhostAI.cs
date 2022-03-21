using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int hp;
    //public float force;
    public bool receiving_damage = false;
    public bool this_happened = false;
    public bool dying = false;

    public AudioClip ghost_death;
    public AudioClip slash_hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void receiveDamage(int damage, float force)
    {
        if (dying == false)
        {
            receiving_damage = true;
            GetComponent<AudioSource>().clip = slash_hit;
            GetComponent<AudioSource>().Play(0);
            Vector3 pushDir = target.transform.position;
            GetComponent<Rigidbody>().AddForce(-pushDir * force);
            hp = hp - damage;
        }
        
    }

    public void enemyDeath()
    {

        StartCoroutine(enemyDeathRoutine());
    }

    public IEnumerator enemyDeathRoutine()
    {
        GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(0.25f);
        GetComponent<AudioSource>().clip = ghost_death;
        GetComponent<AudioSource>().volume = 100.0f;
        GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(3.0f);
        foreach(Transform mid_child in this.transform)
        {
            foreach(Transform last_child in mid_child.transform)
            {
                foreach(Transform child in last_child.transform)
                {
                    Debug.Log("COunt");
                    if(child.tag == "Currency")
                    {
                    // this_happened = true;
                        child.gameObject.SetActive(true);
                        //child.gameObject.transform.parent = null;
                    }
                    child.gameObject.transform.parent = null;
                }
            }
        }
  
        //drop currency
        gameObject.SetActive(false);
    }
    void Update()
    {
            if (dying == false)
            {
                transform.LookAt(target);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            if (hp <= 0)
            {
                if (dying == false)
                {
                    enemyDeath();
                    dying = true;
                    GetComponent<Rigidbody>().useGravity = false;
                }
                if(dying == true)
                {
                    Color tempcolor = gameObject.GetComponentInChildren<Renderer>().material.color;
                    tempcolor.a -= 0.6f * Time.deltaTime;
                    gameObject.GetComponentInChildren<Renderer>().material.color = tempcolor;

                    transform.position = new Vector3(transform.position.x,transform.position.y+0.05f,transform.position.z);
                }
                //this_happened = true;
            }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(damagePlayer(collision.gameObject));
        }
        //Destroy(gameObject);
    }

    public IEnumerator damagePlayer(GameObject player)
    {
            player.GetComponent<PlayerUIAndAbilities>().receiveDamage(30);
            Vector3 pushDir = target.transform.position;
            this.GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().AddForce(-pushDir * 80f);
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<BoxCollider>().enabled = true;
    }
}
