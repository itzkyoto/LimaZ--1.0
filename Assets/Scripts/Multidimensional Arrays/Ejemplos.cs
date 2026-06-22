using UnityEngine;

public class Ejemplos : MonoBehaviour
{
    public int[,] tablero = new int[10, 10];
    public int[,] notas = new int[3, 4];
    public string[,] TiposPokemon = new string[5, 5];
    void Start()
    {
        TiposPokemon[0, 0] = "1x";
        TiposPokemon[0, 1] = "1x";
        TiposPokemon[0, 2] = "1x";
        TiposPokemon[0, 3] = "1x";
        TiposPokemon[0, 4] = "1x";

        TiposPokemon[1, 0] = "2x";
        TiposPokemon[1, 1] = "1x";
        TiposPokemon[1, 2] = "0.5x";
        TiposPokemon[1, 3] = "0.5x";
        TiposPokemon[1, 4] = "1x";

        TiposPokemon[2, 0] = "1x";
        TiposPokemon[2, 1] = "2x";
        TiposPokemon[2, 2] = "1x";
        TiposPokemon[2, 3] = "1x";
        TiposPokemon[2, 4] = "1x";

        TiposPokemon[3, 0] = "1x";
        TiposPokemon[3, 1] = "1x";
        TiposPokemon[3, 2] = "1x";
        TiposPokemon[3, 3] = "0.5x";
        TiposPokemon[3, 4] = "0.5x";

        TiposPokemon[4, 0] = "1x";
        TiposPokemon[4, 1] = "1x";
        TiposPokemon[4, 2] = "0x";
        TiposPokemon[4, 3] = "2x";
        TiposPokemon[4, 4] = "1x";
        MostrarTabla(TiposPokemon);
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void MostrarTabla(string[,] TiposPokemon)
    {
        string texto = "Tabla de elementos \n";
        texto += " ============== \n";

        for (int fila = 0; fila < TiposPokemon.GetLength(0); fila++)
        {
            texto += "Tipo en la fila : " + fila + ": ";
            for (int col  = 0; col < TiposPokemon.GetLength(1); col++)
            {
                texto += TiposPokemon[fila, col] + " ";
            }
            texto += "\n";
        }
        Debug.Log (texto);
    }

}
