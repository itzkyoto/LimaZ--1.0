using System.Collections;
using UnityEngine;

public class Swiitch : MonoBehaviour
{  
  
   
    public enum zombiesType
    {
        None,
        ManoLarga,
        Amalgama,
        Zombie,
    }
    public zombiesType Zombies;

    public enum Armas
    {
        None,
        Melee,
        OneHand,
        TwoHands,
    }
    public Armas Guns;


    void Start()
    {
        switch (Zombies)
        {
            case zombiesType.None:
                {
                    Debug.Log("nada");
                }
                break;

            case zombiesType.ManoLarga:
                {
                    Debug.Log("manito larga");
                }
                break;

            case zombiesType.Amalgama:
                {
                    Debug.Log("amalgamita");
                }
                break;

            case zombiesType.Zombie:
                {
                    Debug.Log("zombie normalito");
                }
                break;
           
            default:
                break;
        }
        switch (Guns)
        {
            case Armas.None:
                {
                    Debug.Log("Nada");
                }
                break;

            case Armas.Melee:
                {
                    Debug.Log("pumpum golpesito");
                }
                break;

            case Armas.OneHand:
                {
                    Debug.Log("piu piu gringo school");
                }
                break;

            case Armas.TwoHands:
                {
                    Debug.Log("U.S.A");
                }
                break;

            default:
                break;
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
