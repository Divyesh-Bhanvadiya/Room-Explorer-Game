using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace RoomExplorer;

public class Camera
{
    // camera pos
    public Vector3 Position {get; set;}
    
    // camera axes
    public Vector3 Front {get; set;}
    public Vector3 Right {get; set;}
    public Vector3 Up {get; set;}
    
    // angles
    private float _yaw = -90.0f; // along Y-axis; L-R
    private float _pitch = 0.0f; // along X-axis; U-D

    // options
    public float AspectRatio {get; set;}
    public float Fov { get; set; } = 45.0f;
    public float Speed { get; set; } = 5.0f;
    public float Sensitivity { get; set; } = 0.2f;
    
    public Camera(Vector3 position, float aspectRatio)
    {
        Position = position;
        AspectRatio = aspectRatio;
        UpdateCameraVectors();
    }
    
    public Matrix4 GetViewMatrix()
    {
        return Matrix4.LookAt(
            Position,
            Position + Front,
            Up
        );
    }

    public Matrix4 GetProjectionMatrix()
    {
        return Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.DegreesToRadians(Fov),
            AspectRatio,
            0.1f,
            100.0f
            );
    }

    public void ProcessKeyboard(CameraMovement direction, float deltaTime)
    {
        float velocity = Speed * deltaTime;
        
        switch (direction)
        {
            case CameraMovement.Forward:
                Position += velocity * Front;
                break;
            case CameraMovement.Backward:
                Position -= velocity * Front;
                break;
            case CameraMovement.Left:
                Position -= velocity * Right;
                break;
            case CameraMovement.Right:
                Position += velocity * Right;
                break;
        }

        Position = new Vector3(Position.X, 1.5f, Position.Z); // locked (no vertical movement)
    }

    public void ProcessMouse(float xOffset, float yOffset)
    {
        xOffset *= Sensitivity;
        yOffset *= Sensitivity;
            
        _yaw += xOffset;
        _pitch += yOffset;
            
        // Prevent gimbal lock
        _pitch = Math.Clamp(_pitch, -89.0f, 89.0f);
        
        UpdateCameraVectors();
    }

    private void UpdateCameraVectors()
    {
        Vector3 front;
        front.X = MathF.Cos(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));
        front.Y = MathF.Sin(MathHelper.DegreesToRadians(_pitch));
        front.Z = MathF.Sin(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));
        Front = Vector3.Normalize(front);
        
        Right = Vector3.Normalize(Vector3.Cross(Front, Vector3.UnitY));
        Up = Vector3.Normalize(Vector3.Cross(Right, Front));
    }
    
    // directions for movement
    public enum CameraMovement
    {
        Forward,
        Backward,
        Left,
        Right
    }
}