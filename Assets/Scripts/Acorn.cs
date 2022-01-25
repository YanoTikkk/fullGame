using UnityEngine;
using Random = UnityEngine.Random;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float maxRotationSpeed;

    private Rigidbody rbAcorn;

    private void Start()
    {
        rbAcorn = gameObject.GetComponent<Rigidbody>();
        rbAcorn.AddRelativeForce(velocity,ForceMode.VelocityChange);
        rbAcorn.angularVelocity = new Vector3(
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed), 
            Random.Range(-maxRotationSpeed, maxRotationSpeed));
    }
}
