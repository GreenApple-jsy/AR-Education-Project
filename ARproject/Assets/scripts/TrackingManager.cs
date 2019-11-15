using UnityEngine;
using Vuforia;

public class TrackingManager : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED 변수 선언
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS
    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }
    #endregion

    #region PUBLIC_METHODS
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            OnTrackingFound();
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
            OnTrackingLost();
        else //previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            OnTrackingLost();
    }

    #endregion

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        Instantiate(Resources.Load(name + "Children"), this.transform); //타겟 이미지를 인식한 경우, 시뮬레이션 실행을 위한 자식 오브젝트 instantiate

        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }
    }


    protected virtual void OnTrackingLost()
    {
        if (transform.childCount > 0) //타겟을 찾을 수 없는 경우 존재하는 자식 오브젝트 destroy
            Destroy(transform.GetChild(0).gameObject);

        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            foreach (var component in rendererComponents)
                component.enabled = false;

            foreach (var component in colliderComponents)
                component.enabled = false;

            foreach (var component in canvasComponents)
                component.enabled = false;
        }
    }
    #endregion // PROTECTED_METHODS
}
