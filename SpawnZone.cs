using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZone : MonoBehaviour
{
    private PlayerControler thePlayer;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    public string placeName;

    public bool needText;
    public string placeNameTitle;
    public GameObject text;
    public Text placeText;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControler>();
        theCamera = FindObjectOfType<CameraFollow>();

        if (!thePlayer.nextPlaceName.Equals(placeName))
        {
            return;
        }

        thePlayer.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y, -13/*theCamera.transform.position.z*/);

        thePlayer.lastMovement = facingDirection;
        StartCoroutine(placaNameCo());
    }

    private IEnumerator placaNameCo()
    {
        text.SetActive(true);
        placeText.text = placeNameTitle;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }


}
