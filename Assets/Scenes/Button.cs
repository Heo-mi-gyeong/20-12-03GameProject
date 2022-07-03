using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
        playermove.itemcount = 0;
        EnemyMove.monsterlife = 0;
        EnemyMove.monsterlife = 0;
        bosssMonster.monsterlife = 0;
        playermove.playerLife = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
