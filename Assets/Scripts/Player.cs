using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
public class Player : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;
    public float Health;
    public GameObject BulletPreFab;

    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        MovementPlayer();
        shoot();
        TakeDamage();
        

       
        
    }
    public void MovementPlayer()
    {
        Debug.Log("player try to move");


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
        {
            animator.SetBool("Abajo", true);
            transform.position += dir * Speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("Abajo", false);
        }


    }
    public void shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
        direction.z = 0;
        direction.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPreFab, transform.position, Quaternion.identity);
            bullet.transform.up = direction;
        }
    }
    public void TakeDamage()
    {
        if (Health <= 0)
        {
            animator.SetBool("Morir", true);
            Debug.Log("Player is dead");
            Destroy(gameObject, 1.5f);
        }
    }
   

}