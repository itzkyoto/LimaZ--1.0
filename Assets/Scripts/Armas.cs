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
    public float damage;
    public float cooldown;
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
                break;
            case TiposDeArma.OneHand:
                break;
            case TiposDeArma.TwoHand:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject bullet = Instantiate(BulletPreFab, transform.position, Quaternion.identity);
                        bullet.transform.up = direction;
                    }
                }
                break;
            default:
                break;
        }
    }
}
