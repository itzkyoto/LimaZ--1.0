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

    private Animator animator;
    

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
            transform.position += dir * Speed * Time.deltaTime;

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
            Debug.Log("Player is dead");
            Destroy(gameObject);
        }
    }
   

}