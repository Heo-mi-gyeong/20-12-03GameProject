using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float minX, maxX;
    public float moveSpeed;
    public int sign = -1;
    public static int monsterlife = 0;
    public Transform monster_effect;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime*sign, 0, 0);
            //이동처리
            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
            
            sign *= -1;
            this.transform.LookAt(target);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playermove.play_animation == true)
        {
            monsterlife++;
            if (monsterlife == 2)
            {
                Instantiate(monster_effect, this.transform.position, this.transform.rotation);
                Destroy(gameObject);
                monsterlife = 0;
            }
        }
    }
}
