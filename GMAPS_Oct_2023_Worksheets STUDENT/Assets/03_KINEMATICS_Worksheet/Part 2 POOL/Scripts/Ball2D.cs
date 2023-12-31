using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {   //Calculate distance from the ball to the mouse
        float distance = Util.FindDistance(new HVector2D(x, y), Position);
        return distance <= Radius;  //Checks if distance is less than or = to radius of the ball
    }

    bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x * deltaTime;   //Calculate the new X and Y values
        float displacementY = Velocity.y * deltaTime;

        Position.x += displacementX;    //Updates the X and Y values to the new values
        Position.y += displacementY;

        transform.position = new Vector2(Position.x, Position.y);   //Applies the new X and Y values to the ball
    }
}

