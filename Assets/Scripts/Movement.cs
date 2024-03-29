using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Camera cam;
    public StatusPlate sp;
    public float rotateSpeed;
    public PlayerStats ps;
    public float getdmg;
    public bool CanAtk;
    private EnemyStats es;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerStats>();
        CanAtk = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }
    void Update()
    {
        Rotation();
        Attack();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector2(x*sp.speed,y*sp.speed);


        
    }
    void Rotation()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 lookPos = cam.ScreenToWorldPoint(mousePos);
        lookPos = lookPos -new Vector2(transform.position.x, transform.position.y);
        

        transform.up = lookPos;
    }
    void Attack()
    {

        Vector2 lookPos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(lookPos, Vector2.zero);

        if (Input.GetMouseButton(0) && CanAtk && hit.collider!=null)
        {
            if(hit.collider.gameObject.tag=="Enemy")
            {
                getdmg = ps.AttackCounter();
                es = hit.collider.gameObject.GetComponent<EnemyStats>();
                es.GotHitted(getdmg);
                Debug.Log(getdmg);
                CanAtk = false;
                StartCoroutine(AttackSpeed(ps.GetAttackSpeed()));
            }
            
        }
       
    }
    IEnumerator AttackSpeed(float rate)
    {
        yield return new WaitForSeconds(rate);
        CanAtk = true;
    }
    
}
