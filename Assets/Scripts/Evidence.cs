using UnityEngine;

public class Evidence : MonoBehaviour
{
    public string evidenceName;
    private bool discovered = false;

    public void Inspect()
    {
        if (!discovered)
        {
            discovered = true;
            Debug.Log("Evidence Found: " + evidenceName);
        }
    }
}
