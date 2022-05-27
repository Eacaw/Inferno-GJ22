using UnityEngine;
using Interfaces;

public class ButtonDispenser : MonoBehaviour, EventInterface
{

    public GameObject buttonPrefab;
    private GameObject currentInstance;

    public void executeEvent()
    {
        Destroy(currentInstance);
        // spawn new instance
        currentInstance = Instantiate(buttonPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void endExecution()
    {
        // Empty Method, no implementation needed
    }

}
