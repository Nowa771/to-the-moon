



using UnityEngine;

public class ResFix : MonoBehaviour
{
#if UNITY_STANDALONE
    private void Awake()
    {
        Screen.SetResolution(410, 656, false);
    }
#endif
}