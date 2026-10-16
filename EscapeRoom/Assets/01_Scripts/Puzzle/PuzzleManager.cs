using UnityEngine;
 
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string correctCode = "1234";
    [SerializeField] private ChestController chest;
    private int attempts;
 
    public bool ValidateCode(string code)
    {
        attempts++;
        Debug.Log("Intento " + attempts + ": " + code);
 
           bool valid = code.Trim() == correctCode;
 
        if (valid)
        {
            Debug.Log("Código correcto.");
 
            if (chest != null)
            {
                chest.Unlock();
            }
        }
        else
        {
            Debug.Log("Código incorrecto.");
        }
 
        return valid;
    }
}
