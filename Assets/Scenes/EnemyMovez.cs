using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovez : MonoBehaviour
{
    public float minZ, maxZ;
    public float moveSpeed;
    public int sign = -1;
    public static int monsterlife2 = 0;
    public Transform monster_effect;
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * sign);
        //이동처리
        if (transform.position.z <= minZ || transform.position.z >= maxZ)
        {
            this.transform.LookAt(target);
            sign *= -1;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playermove.play_animation == true)
        {
            monsterlife2++;
            if (monsterlife2 == 2)
            {
                Instantiate(monster_effect, this.transform.position, this.transform.rotation);
                Destroy(gameObject);
                monsterlife2 = 0;
            }
        }
    }
}
