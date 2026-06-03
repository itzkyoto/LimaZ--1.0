using UnityEngine;
using UnityEngine.InputSystem.Controls;
public class Player : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;
    public float Health;
    public GameObject BulletPreFab;
    public float MaxTime = 10;
    public float currentTime;

    public bool isAbilityAblive = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        shoot();
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

    public void SimpleAttack()
    {
        if (isAbilityAblive)
        {
            //->hago lo que tenga que hacer
            isAbilityAblive = false;
        }
    }
    public void TimerToDoSmt()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= MaxTime)
        {
            //-> ejecutar algo
            isAbilityAblive = true;

            currentTime = 0;
        }
    }
}