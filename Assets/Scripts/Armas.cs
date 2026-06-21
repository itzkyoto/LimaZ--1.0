using UnityEngine;

public class Armas : MonoBehaviour
{
    public enum TiposDeArma
    {
        None,
        Melee,
        OneHand,
        TwoHand,
    }
    public TiposDeArma Hand;
    public float Damage;
    public float Cooldown;
    public float LastShoot; 
    public GameObject BulletPreFab;
    void Start()
    {
        

    }

    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
        direction.z = 0;
        direction.Normalize();

        switch (Hand)
        {
            case TiposDeArma.None:
                break;
            case TiposDeArma.Melee:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                       
                    }


                }
                
                break;
            case TiposDeArma.OneHand:
                {
                    Cooldown = 1f;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Time.time - LastShoot >= Cooldown)
                        {
                            GameObject bullet = Instantiate(BulletPreFab, transform.position, Quaternion.identity);
                            bullet.transform.up = direction;
                            
                            LastShoot = Time.time;
                        }
                    }
                }
                break;
            case TiposDeArma.TwoHand:
                {
                    Cooldown = 0.2f;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Time.time - LastShoot >= Cooldown)
                        {
                            GameObject bullet = Instantiate(BulletPreFab, transform.position, Quaternion.identity);
                            bullet.transform.up = direction;
                            LastShoot = Time.time;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}
