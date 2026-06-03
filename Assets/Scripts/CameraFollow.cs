using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float CameraSpeed;
    public float CameraDistance;

    void Start()
    {
     
    }

    
    void Update()
    {
        CameraMovement();
    }
    public void CameraMovement()
    {
        Vector3 direction = (target.transform.position - transform.position);  
        direction.z = 0;
        direction.Normalize();
        transform.position += direction * CameraSpeed * Time.deltaTime;
      
        

    }





}
