using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }
}