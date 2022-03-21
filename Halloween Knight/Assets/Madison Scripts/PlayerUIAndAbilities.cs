using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerUIAndAbilities : MonoBehaviour
{
    public bool this_happened = false;
    public string ability;
    public bool at_station = false;
    private GameObject current_station;

    public TextMeshProUGUI interact;
    public TextMeshProUGUI ability_list;
    public TextMeshProUGUI currency_ui;
    public TextMeshProUGUI health_ui;
    public int currency = 0;
    public int health = 100;

    public Transform death_location;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (at_station == true)
            {
                if (currency >= current_station.GetComponent<BuyStation>().cost) //can afford
                {
                    if (ability == "Jump")
                    {
                        gameObject.GetComponent<FirstPersonController>().can_jump = true;
                        ability_list.text += "\nJump - Spacebar";
                    }
                    
                    if (ability == "Melee")
                    {
                        gameObject.GetComponentInChildren<PlayerMelee>().ability_unlocked = true;
                        ability_list.text += "\nMelee - Left Click";
                    }

                    if (ability == "Ranged")
                    {
                        gameObject.GetComponentInChildren<PlayerRanged>().ability_unlocked = true;
                        ability_list.text += "\nRanged - Right Click";
                    }
                    if (ability == "Grapple")
                    {
                        gameObject.GetComponentInChildren<PlayerGrapple>().ability_unlocked = true;
                        ability_list.text += "\nGrapple - F When Reticle Purple";
                    }
                    currency -= current_station.GetComponent<BuyStation>().cost;
                    current_station.GetComponent<BuyStation>().deactivate();
                    interact.text = "o";
                }
            }
        }
        currency_ui.text = "Currency:" + currency.ToString();
        health_ui.text = "Health:" + health.ToString();
        if (health <= 0)
            playerDeath();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BuyStation")
        {
            at_station = true;
            ability = other.gameObject.GetComponent<BuyStation>().ability;
            current_station = other.gameObject;
            interact.text = "Press E to buy " + ability;

        }
        if (other.gameObject.tag == "Currency")
        {
            currency += 1;
            other.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        at_station = false;
        if (other.gameObject.tag == "BuyStation")
        {
            interact.text = "o";
            current_station = null;
            ability = "";
        }
    }

    public void receiveDamage(int damage)
    {
        health -= damage;
        
    }
    public void playerDeath()
    {
        this.GetComponent<CharacterController>().enabled = false;
        this.transform.position = death_location.position;
        health = 100;
        this.GetComponent<CharacterController>().enabled = true;
    }
    
}
