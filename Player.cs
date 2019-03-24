using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    //Floats
    public Slider xpSlider;
    public float speed = 50f;
    public float jumpPower = 150f;
    public float MaxSpeed = 3;
    public int level=1;
    public float xp = 0;
    public float suma = 100;
    GameObject sabie;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool atac = false;

    //Stats
    public int curHealth;
    public int maxHealth = 5;
    public Text lvl;

    //References
    private Animator anim;
    private Rigidbody2D rb2D;
    // Use this for initialization
    void Start()
    {
        sabie = GameObject.Find("Sabie");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        xpSlider.value = 0;
        
    }
    void Update()
    {
        atac = false;
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        xpSlider.value = xp;
        lvl.text = level + "";

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
          
        

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2D.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }

            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                    rb2D.AddForce(Vector2.up * jumpPower);
                }
            }
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }
        if (Input.GetMouseButton(0) && sabie.GetComponent<AtackPlayer>().atackspeed<0)
        {
            anim.Play("Ataca");
            sabie.GetComponent<AtackPlayer>().atackspeed = sabie.GetComponent<AtackPlayer>().aux;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(xp>=100)
        {
            level++;
            xp = 0;
            suma /= 5;
        }
        Vector3 easeVelocity = rb2D.velocity;
        easeVelocity.y = rb2D.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //fake friction / easing the x speed of our player
        if (grounded)
        {
            rb2D.velocity = easeVelocity;
        }
       

        // Movin The Player
        rb2D.AddForce((Vector2.right * speed) * h);


        // limiting the speed of the player 
        rb2D.AddForce((Vector2.right * speed) * h);

        if (rb2D.velocity.x > MaxSpeed)
        {
            rb2D.velocity = new Vector2(MaxSpeed, rb2D.velocity.y);
        }
        if (rb2D.velocity.x < -MaxSpeed)
        {
            rb2D.velocity = new Vector2(-MaxSpeed, rb2D.velocity.y);
        }
    }
    void Die()
    {
        this.transform.position = new Vector3(-15, 1.25F);
        curHealth = 5;

    }

public void Damage(int dmg)
    {

        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");

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