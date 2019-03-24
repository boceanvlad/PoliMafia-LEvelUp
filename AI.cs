using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    public GameObject gamemaster;

    //Floats
    public float speed = 50f;
    public float jumpPower = 150f;
    public float MaxSpeed = 3;
    public GameObject player;
    public GameObject ai;
    
    //Booleans
    public bool grounded;
    public bool canDoubleJump;

    //Stats
    public int curHealth;
    public int maxHealth = 5;
    public bool nervos = false;
    private Animator anim;
    public float timpnervos = 10;
    private Rigidbody2D rb2D;

    public GameObject tigan;
    public Slider enemySlider1;
    public Slider enemySlider2;
    // Use this for initialization
    void Start () {
        anim= gameObject.GetComponent<Animator>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        ai.GetComponent<atack>().enabled = false;
        curHealth = maxHealth;
        enemySlider1.maxValue = curHealth;
        enemySlider1.value = curHealth;
        enemySlider2.maxValue = curHealth;
        enemySlider2.value = curHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (nervos)
        {
            ai.GetComponent<atack>().enabled = true;
            timpnervos -= Time.deltaTime;
            if (curHealth <= 0)
            {
                gamemaster.GetComponent<upgradeuri>().spawnati += 2;
                player.GetComponent<inventar>().banile += 100;

            if(gamemaster.GetComponent<upgradeuri>().spawnati <= 10)
                {
                    Instantiate(tigan);
                    Instantiate(tigan);
                }
                
                Destroy(this.gameObject);
            }
            if (player.transform.position.x < this.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (player.transform.position.x > this.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Vector3 easeVelocity = rb2D.velocity;
            easeVelocity.y = rb2D.velocity.y;
            easeVelocity.z = 0.0f;
            easeVelocity.x *= 0.75f;

            float h = 0;
            if (player.transform.position.x > this.transform.position.x + 1)
                h = 1;
            if (player.transform.position.x < this.transform.position.x - 1)
                h = -1;

            //fake friction / easing the x speed of our player
            if (grounded)
            {
                rb2D.velocity = easeVelocity;
            }

            // Movin The Player
            rb2D.AddForce((Vector2.right * speed) * h*Time.deltaTime);


            // limiting the speed of the player 
            rb2D.AddForce((Vector2.right * speed) * h*Time.deltaTime);

            if (rb2D.velocity.x > MaxSpeed)
            {
                rb2D.velocity = new Vector2(MaxSpeed, rb2D.velocity.y);
            }
            if (rb2D.velocity.x < -MaxSpeed)
            {
                rb2D.velocity = new Vector2(-MaxSpeed, rb2D.velocity.y);
            }
        }
        if(timpnervos<=0)
        {
            ai.GetComponent<atack>().enabled = false;
            nervos = false;
            timpnervos = 10;
        }
    }
    public void Damage(int dmg)
    {
        gameObject.GetComponent<Animation>().Play("tiganDamage");
        nervos = true;
        curHealth -= dmg;
        enemySlider1.value = curHealth;
        enemySlider2.value = curHealth;
        //

    }
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb2D.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;
    }
}
