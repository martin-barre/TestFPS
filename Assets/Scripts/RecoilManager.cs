using UnityEngine;

public class RecoilManager : MonoBehaviour
{
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    [SerializeField] private Transform raycastTransform;
    [SerializeField, Min(0)] private float raycastDecal;
    
    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    private void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
        raycastTransform.localRotation = Quaternion.Euler(currentRotation * raycastDecal);
    }
    
    public void RecoilFire()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
