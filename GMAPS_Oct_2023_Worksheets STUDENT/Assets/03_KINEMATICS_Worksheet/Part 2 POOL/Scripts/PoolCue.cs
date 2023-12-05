using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
	public LineFactory lineFactory;
	public GameObject ballObject;

	private Line drawnLine;
	private Ball2D ball;

	private void Start()
	{
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
			//if (ball != null && ball.IsCollidingWith(startLinePos))
			//{
				//drawnLine = lineFactory.GetLine(ball.transform.position, startLinePos, 0.02f, Color.black);
				//drawnLine.EnableDrawing(true);
			//}
		}
		//else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		//{
			//drawnLine.EnableDrawing(false);

			//update the velocity of the white ball.
			//HVector2D v = new HVector2D(drawnLine.end.x - drawnLine.start.x, drawnLine.end.y - drawnLine.start.y);
			//ball.SetVelocity = v;

			//drawnLine = null; // End line drawing            
		//}

		if (drawnLine != null)
		{
			drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}