using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    float speed = 2.0f;
    public GameObject player;
    bool is_jumping=false;
    public float jumpPower = 3.0f;
    public static float timer = 0;
    public static float timer1 = 0;
    public static float timer2 = 0;
    public static int itemcount;
    Animator animator;
    public static bool play_animation = false;
    public static int playerLife = 5;
    public static int monsterCount=0;

    void Start()
    {
        animator = GetComponent<Animator>();//애니메이션 초기화
    }

    // Update is called once per frame
    void Update()
    {


        float distance_per_frame = speed * Time.deltaTime;
        float vertical_input = Input.GetAxis("Vertical");//방향키로 플레이어를 움직임
        float horizontal_input = Input.GetAxis("Horizontal");
        Vector3 launch_direction = new Vector3(0, 1, 1);

        transform.Translate(Vector3.forward * vertical_input * distance_per_frame);
        transform.Translate(Vector3.right * horizontal_input * distance_per_frame);

     //   timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))//스페이스바를 누르면 점프
        {
            if (!is_jumping)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                is_jumping = true;
                timer = 0;
            }
        }
        if (is_jumping == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                is_jumping = false;
                timer = 0.0f;
            }
        }

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 좌표를 플레이어가 쳐다봄

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))

        {

            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }
        if (Input.GetMouseButton(0))//마우스왼쪽을 클릭하면 공격
        {
            
            animator.SetBool("attack",true);
            play_animation = true;
            timer = 0;

        }
        if (play_animation==true)
        {
            timer1 += Time.deltaTime;
            if (timer1 >= 0.9f)
            {
                animator.SetBool("attack", false);
                play_animation = false;
                timer1 = 0.0f;
            }
        }
        if (transform.localPosition.y <= -6.0f)
        {
            SceneManager.LoadScene(2);
            playerLife = 5;
            itemcount = 0;
            EnemyMove.monsterlife = 0;
            EnemyMove.monsterlife = 0;
            bosssMonster.monsterlife = 0;
        }
        if (playerLife == 0)
        {
            SceneManager.LoadScene(2);
            playerLife = 5;
            itemcount = 0;
            EnemyMove.monsterlife = 0;
            EnemyMove.monsterlife = 0;
            bosssMonster.monsterlife = 0;
        }
        if (bosssMonster.die == true && itemcount == 13)
        {
            SceneManager.LoadScene(3);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            GameObject heart = null;
            if (play_animation == true)
            {
                monsterCount--;
            }
            monsterCount++;
            if (monsterCount == 3)
            {
                playerLife--;
                monsterCount = 0;
            }
            if (playerLife == 4)
            {
                heart = GameObject.FindGameObjectWithTag("life5");
                Destroy(heart);
            }
            if (playerLife == 3)
            {
                heart = GameObject.FindGameObjectWithTag("life4");
                Destroy(heart);
            }
            if (playerLife == 2)
            {
                heart = GameObject.FindGameObjectWithTag("life3");
                Destroy(heart);
            }
            if (playerLife == 1)
            {
                heart = GameObject.FindGameObjectWithTag("life2");
                Destroy(heart);
            }
            

        }
    }

    void OnGUI()
    {
        GUIStyle style = GUI.skin.GetStyle("label");

        //Set the style font size to increase and decrease over time
        style.fontSize = (int)(20.0f + 10.0f);
        GUI.Label(new Rect(150, Screen.height - 390, 128, 32),itemcount.ToString());
        
    }
}


