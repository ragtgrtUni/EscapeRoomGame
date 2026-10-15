using UnityEngine;
public class PuzzleHint : MonoBehaviour
{
    [SerializeField] private string hint = "Busca los números en el cuadro.";

    public void ShowHint()
    {
        Debug.Log(hint);
    }
}