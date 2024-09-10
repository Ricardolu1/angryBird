using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public static SlingShot Instance { get; private set; }
    private LineRenderer leftLineRenderer;
    private LineRenderer rightLineRenderer;
    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;
    private bool isDrawing = false;
    private Transform birdTransform;

    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        leftLineRenderer = transform.Find("LeftLineRender").GetComponent<LineRenderer>();
        rightLineRenderer = transform.Find("RightLineRender").GetComponent<LineRenderer>();
        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
        
    }

    void Start()
    {
        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }

    public void StartDraw(Transform birdTransform)
    {
        isDrawing = true;
        this.birdTransform = birdTransform;
        ShowLine();
    }

    public void EndDraw()
    {
        isDrawing = false;
        HideLine();
    }

    public void Draw()
    {
        Vector3 birdPosition = birdTransform.position;
        birdPosition = (birdPosition - centerPoint.position).normalized * 0.4f + birdPosition;
        leftLineRenderer.SetPosition(0, birdPosition);
        leftLineRenderer.SetPosition(1, leftPoint.position);
        rightLineRenderer.SetPosition(0, birdPosition);
        rightLineRenderer.SetPosition(1, rightPoint.position);
    }

    public Vector3 GetCenterPointPosition()
    {
        return centerPoint.transform.position;
    }

    private void HideLine()
    {
        leftLineRenderer.enabled = false;
        rightLineRenderer.enabled = false;
    }

    private void ShowLine()
    {
        leftLineRenderer.enabled = true;
        rightLineRenderer.enabled = true;
    }
}