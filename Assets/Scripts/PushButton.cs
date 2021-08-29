using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
[RequireComponent(typeof(BoxCollider))]
public class PushButton : XRBaseInteractable
{
  [SerializeField] private float _maximumPushDepth;
  [SerializeField] private float _minimumPushDepth;
  
  private XRBaseInteractor _pushInteractor = null;
  private bool _previouslyPushed;
  private float _oldPushPosition;

  public UnityEvent OnPushed;
  protected override void OnEnable()
  {
    base.OnEnable();
    hoverEntered.AddListener(StartPush);
    hoverExited.AddListener(EndPush);
  }
  
  protected override void OnDisable()
  {
    base.OnDisable();
    hoverEntered.RemoveListener(StartPush);
    hoverExited.RemoveListener(EndPush);
  }

  private void Start()
  {
    BoxCollider boxCollider = GetComponent<BoxCollider>();

    _minimumPushDepth = transform.localPosition.y;
    _maximumPushDepth = _minimumPushDepth - (boxCollider.bounds.size.y * 0.60f);
  }
  private void EndPush(HoverExitEventArgs arg0)
  {
    _pushInteractor = null;
    _oldPushPosition = 0.0f;
    _previouslyPushed = false;
    SetYPosition(_minimumPushDepth);
  }
  private void StartPush(HoverEnterEventArgs arg0)
  {
    _pushInteractor = arg0.interactor;
    _oldPushPosition = GetLocalYPosition(_pushInteractor.transform.position);
  }

  public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
  {
    if (_pushInteractor)
    {
      float newPushPosition = GetLocalYPosition(_pushInteractor.transform.position);
      float pushDifference = _oldPushPosition - newPushPosition;

      _oldPushPosition = newPushPosition;

      SetYPosition(transform.localPosition.y - pushDifference);
      
      CheckPress();
    }
  }

  private float GetLocalYPosition(Vector3 interactorPosition)
  {
    return transform.root.InverseTransformDirection(interactorPosition).y;
  }

  private void SetYPosition(float yPos)
  {
    Vector3 newPosition = transform.localPosition;
    newPosition.y = Mathf.Clamp(yPos, _maximumPushDepth, _minimumPushDepth);

    transform.localPosition = newPosition;
  }

  private void CheckPress()
  {
    float inRange = Mathf.Clamp(transform.localPosition.y, _maximumPushDepth, _maximumPushDepth + 0.01f);
    bool isPushedDown = transform.localPosition.y == inRange;

    if (isPushedDown && !_previouslyPushed)
      OnPushed.Invoke();

    _previouslyPushed = isPushedDown;
  }
}
