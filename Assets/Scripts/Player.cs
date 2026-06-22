using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
public class Player : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;
    public float Health;
    public Armas currentWeapon;
    

    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        MovementPlayer();
        
        TakeDamage();
        if (currentWeapon.Hand == Armas.TiposDeArma.Melee)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                animator.SetTrigger("Atacar");
                
            }  
           
        }

       
        
    }
    public void MovementPlayer()
    {
        Debug.Log("player try to move");


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();
        float i = transform.position.y;
        float e = transform.position.x;

        transform.position += dir * Speed * Time.deltaTime;

        if (dir != Vector3.zero) {
            print("hi");
            animator.SetBool("Moving", true);

            if (dir.y < 0)
            {
                animator.SetBool("Up_Down", false);
                animator.SetBool("Lateral_Vertical", false);

            }
            else if (dir.y > 0)
            {
                animator.SetBool("Up_Down", true);
                animator.SetBool("Lateral_Vertical", false);
            }

            if (dir.x < 0)
            {
                animator.SetBool("Der_Izq", false);
                animator.SetBool("Lateral_Vertical", true);

            }
            else if (dir.x > 0)
            {
                animator.SetBool("Der_Izq", true);
                animator.SetBool("Lateral_Vertical", true);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }







    }
    
    public void TakeDamage()
    {
        if (Health <= 0)
        {
            animator.SetBool("Morir", true);
            Debug.Log("Player is dead");
            Destroy(gameObject, 1.1f);
        }
    }
   

}