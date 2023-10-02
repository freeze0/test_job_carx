using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Vector3 endPos;
    [SerializeField] public Transform[] positions;
    [SerializeField] public float speed;
    [SerializeField] public float progress;
    [SerializeField] int i;
    [SerializeField] bool isMoving;

    private void Start()
    {
        isMoving = false;
        endPos = positions[0].position;
        transform.position = positions[0].position;
    }

    private void Update()
    {
        MovementLogic();
        ProgressCut();
    }

    public void Action()
    {
        if (!isMoving)
        {
            LapStep();
        }
    }

    public void LapStep()
    {
        isMoving = true;
        progress = 0;
        i++;

        if (i == positions.Length)
        {
            i = 0;
        }

        startPos = endPos;
        endPos = positions[i].position;
    }

    public void MovementLogic()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(startPos, endPos, progress);
            progress += speed * Time.deltaTime;
        }
    }
    
    public void ProgressCut()
    {
        if (progress >= 1)
        {
            progress = 1;
            isMoving = false;
        }
    }

}
