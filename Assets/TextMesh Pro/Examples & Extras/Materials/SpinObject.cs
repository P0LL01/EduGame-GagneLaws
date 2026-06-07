using UnityEngine;

public class SpinObject : MonoBehaviour
{
    // Πόσο γρήγορα θέλουμε να γυρίζει
    public float spinSpeed = 100f;

    void Update()
    {
        // Περιστρέφει το αντικείμενο στον άξονα Υ (γύρω από τον εαυτό του)
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.World);
    }
}