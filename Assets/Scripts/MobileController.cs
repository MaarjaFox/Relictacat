using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;
    [SerializeField] Camera MainCam;
    private Transform cameraTransform; 
    private Vector3 moveVector;
    
    
    // Start is called before the first frame update
    void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        cameraTransform = MainCam.transform; 

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);
            

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //Get the camera horizontal rotation
            Vector3 faceVector = new Vector3(cameraTransform.forward.x, 0 , cameraTransform.forward.z);


            //
            //Get the angle between world forward and camera
            float cameraAngle = Vector3.SignedAngle(Vector3.forward, faceVector , Vector3.up);

            //Finally rotate the input direction horizontally by the cameraAngle
            Vector3 moveVector = Quaternion.Euler(0, cameraAngle, 0) * inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
            
        

            
        }
        
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }

    void Update()
    {
        

        
       
    }
}

    