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
			//Checks if the mouse position is "inside" the ball object
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{	
				//Draws line from the ball to the current mouse position
				drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 0.2f, Color.black);
				drawnLine.EnableDrawing(true);
			}
		}
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			//If the mouse button is not held, the drawLine is set to false
			drawnLine.EnableDrawing(false);

			//update the velocity of the white ball.
			//By using the direction of the drawn line as a vector
			HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);
			ball.Velocity = v;

			drawnLine = null; // End line drawing            
		}

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
