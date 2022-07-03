using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bosssMonster : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public static int monsterlife=0;
    public Transform explosion_effect;
    public static bool die = false;
    
    void Update()
    {
        this.transform.LookAt(target);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playermove.play_animation == true)
        {
            monsterlife++;
            if (monsterlife == 5)
            {
                Instantiate(explosion_effect, this.transform.position, this.transform.rotation);
                Destroy(gameObject);
                monsterlife = 0;
                die = true;
            }
        }
    }
    }

