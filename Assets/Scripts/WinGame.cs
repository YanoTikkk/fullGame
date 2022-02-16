using TMPro;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMover>())
            {
                text.color = Color.green;
                text.text = "ВЫ ПОБЕДИЛИ!";
            }
        }
    }
}
