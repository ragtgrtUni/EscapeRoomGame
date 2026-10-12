using UnityEngine;
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string solution = "4321";
    private int attempts;
    public bool CheckCode(string input)
    {
        attempts++;
        Debug.Log("Intento " + attempts + ": " + input);
        return input == solution;
    }
}