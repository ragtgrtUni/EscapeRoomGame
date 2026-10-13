using UnityEngine;
public class PuzzleHint : MonoBehaviour
{
    [SerializeField] private string hint = "El código está escrito en la pared.";

    public void ShowHint()
    {
        Debug.Log(hint);
    }
}