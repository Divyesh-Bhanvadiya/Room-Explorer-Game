using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace RoomExplorer;

public class Game : GameWindow
{
    // CUBE
    // private float[] _cubeVertices = 
    // {
    //     // positions(3)         // colors (3)           // normals(3)
    //     // Back face
    //     -0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  0.0f,  0.0f, -1.0f,
    //     0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
    //     0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f,  0.0f, -1.0f,
    //     -0.5f,  0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f,  0.0f, -1.0f,
    //     // Front face
    //     -0.5f, -0.5f,  0.5f,  1.0f, 0.0f, 1.0f,  0.0f,  0.0f,  1.0f,
    //     0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 1.0f,  0.0f,  0.0f,  1.0f,
    //     0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 1.0f,  0.0f,  0.0f,  1.0f,
    //     -0.5f,  0.5f,  0.5f,  0.5f, 0.5f, 0.5f,  0.0f,  0.0f,  1.0f,
    //     // Left face
    //     -0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 0.0f, -1.0f,  0.0f,  0.0f,
    //     -0.5f,  0.5f, -0.5f,  0.0f, 1.0f, 0.0f, -1.0f,  0.0f,  0.0f,
    //     -0.5f, -0.5f, -0.5f,  0.0f, 0.0f, 1.0f, -1.0f,  0.0f,  0.0f,
    //     -0.5f, -0.5f,  0.5f,  1.0f, 1.0f, 0.0f, -1.0f,  0.0f,  0.0f,
    //     // Right face
    //     0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 1.0f,  1.0f,  0.0f,  0.0f,
    //     0.5f,  0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  1.0f,  0.0f,  0.0f,
    //     0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 1.0f,  1.0f,  0.0f,  0.0f,
    //     0.5f, -0.5f,  0.5f,  0.5f, 0.5f, 0.5f,  1.0f,  0.0f,  0.0f,
    //     // Bottom face
    //     -0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  0.0f, -1.0f,  0.0f,
    //     0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 0.0f,  0.0f, -1.0f,  0.0f,
    //     0.5f, -0.5f,  0.5f,  0.0f, 0.0f, 1.0f,  0.0f, -1.0f,  0.0f,
    //     -0.5f, -0.5f,  0.5f,  1.0f, 1.0f, 0.0f,  0.0f, -1.0f,  0.0f,
    //     // Top face
    //     -0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  0.0f,  1.0f,  0.0f,
    //     0.5f,  0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  0.0f,  1.0f,  0.0f,
    //     0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 1.0f,  0.0f,  1.0f,  0.0f,
    //     -0.5f,  0.5f,  0.5f,  0.5f, 0.5f, 0.5f,  0.0f,  1.0f,  0.0f
    // };

    private float[] _cubeVertices =
    {
        // positions(3)         // colors (3)            // normals(3)
        // Back face
        -0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f, -1.0f,
        0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f, -1.0f,
        0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f, -1.0f,
        -0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f, -1.0f,

        // Front face
        -0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f,  1.0f,
        0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f,  1.0f,
        0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f,  1.0f,
        -0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  0.0f,  1.0f,

        // Left face
        -0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,  -1.0f,  0.0f,  0.0f,
        -0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,  -1.0f,  0.0f,  0.0f,
        -0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,  -1.0f,  0.0f,  0.0f,
        -0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,  -1.0f,  0.0f,  0.0f,

        // Right face
        0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   1.0f,  0.0f,  0.0f,
        0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   1.0f,  0.0f,  0.0f,
        0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   1.0f,  0.0f,  0.0f,
        0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   1.0f,  0.0f,  0.0f,

        // Bottom face
        -0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f, -1.0f,  0.0f,
        0.5f, -0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f, -1.0f,  0.0f,
        0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f, -1.0f,  0.0f,
        -0.5f, -0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f, -1.0f,  0.0f,

        // Top face
        -0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  1.0f,  0.0f,
        0.5f,  0.5f, -0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  1.0f,  0.0f,
        0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  1.0f,  0.0f,
        -0.5f,  0.5f,  0.5f,  0.0f, 0.8f, 0.7f,   0.0f,  1.0f,  0.0f
    };

    
    // private uint[] _cubeIndices =
    // {
    //     // Back face
    //     0, 1, 2, 2, 3, 0,
    //     // Front face
    //     4, 5, 6, 6, 7, 4,
    //     // Left face
    //     0, 4, 7, 7, 3, 0,
    //     // Right face
    //     1, 5, 6, 6, 2, 1,
    //     // Bottom face
    //     0, 1, 5, 5, 4, 0,
    //     // Top face
    //     3, 2, 6, 6, 7, 3
    // };
    
    private uint[] _cubeIndices =
    {
        // Back face
        0, 1, 2, 2, 3, 0,
        // Front face
        4, 5, 6, 6, 7, 4,
        // Left face
        8, 9, 10, 10, 11, 8,
        // Right face
        12, 13, 14, 14, 15, 12,
        // Bottom face
        16, 17, 18, 18, 19, 16,
        // Top face
        20, 21, 22, 22, 23, 20
    };
    
    // PLANE (floor, wall, ceiling) (1x1)
    private float[] _planeVertices = 
    {
        // positions(3)      // colors(3)       // texture coords(2)  // normals (3)
        -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,  0.0f, 0.0f,  0.0f, 1.0f, 0.0f,
        0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,  5.0f, 0.0f,  0.0f, 1.0f, 0.0f,
        0.5f, 0.0f,  0.5f,  1.0f, 1.0f, 1.0f,  5.0f, 5.0f,  0.0f, 1.0f, 0.0f,
        -0.5f, 0.0f,  0.5f,  1.0f, 1.0f, 1.0f,  0.0f, 5.0f,  0.0f, 1.0f, 0.0f
    };

    private uint[] _planeIndices = 
    {
        0, 1, 2,
        2, 3, 0
    };

    // Buffer objects 
    private int _planeVBO, _planeVAO, _planeEBO;
    private int _cubeVBO, _cubeVAO, _cubeEBO;
    
    private Vector3 _targetCubePosition = new Vector3(4.0f, 0.35f, -3.5f);
    private float _glowIntensity = 0.0f;
    
    private Matrix4 _view, _projection;
    private float _time;
    
    private Shader _shader;
    private Texture _floorTexture, _wallTexture;
    
    private Camera _camera;
    private bool _firstMove;
    private Vector2 _lastPos;
    private bool _cursorGrabbed = true;
    
    private bool _lightOn = true;
    
    public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) 
    {}

    protected override void OnLoad()
    {
        base.OnLoad();
        
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f); // greenish gray BG
        GL.Enable(EnableCap.DepthTest);

        SetupCube();
        SetupPlane();
        
        // Shader Compilation
        _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        
        // Load Texture
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        _floorTexture = new Texture(Path.Combine(baseDir, "Textures", "floorTex.png"));
        _wallTexture = new Texture(Path.Combine(baseDir, "Textures", "wallTex.png"));
        
        // Initialise Camera
        _camera = new Camera(new Vector3(0.0f, 1.5f, 4.0f), Size.X / (float) Size.Y);
        _view = _camera.GetViewMatrix();
        _projection = _camera.GetProjectionMatrix();
        
        CursorState = CursorState.Grabbed;
        _lastPos = new Vector2(MousePosition.X, MousePosition.Y);
        Console.WriteLine("Game Initialized");
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
        // update time
        _time += (float)args.Time;
        
        // ESC to toggle cursor
        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            _cursorGrabbed = !_cursorGrabbed;
            CursorState = _cursorGrabbed ? CursorState.Grabbed : CursorState.Normal;

            if (_cursorGrabbed)
            {
                _firstMove = true;
            }
        }

        // Process movements only if cursor grabbed
        if (!_cursorGrabbed)
            return;

        if (KeyboardState.IsKeyDown(Keys.W))
                _camera.ProcessKeyboard(Camera.CameraMovement.Forward, (float)args.Time);
        if (KeyboardState.IsKeyDown(Keys.S))
            _camera.ProcessKeyboard(Camera.CameraMovement.Backward, (float)args.Time);
        if (KeyboardState.IsKeyDown(Keys.A))
            _camera.ProcessKeyboard(Camera.CameraMovement.Left, (float)args.Time);
        if (KeyboardState.IsKeyDown(Keys.D))
            _camera.ProcessKeyboard(Camera.CameraMovement.Right, (float)args.Time);
        
        if (KeyboardState.IsKeyPressed(Keys.E))
        {
            _lightOn = !_lightOn;
            Console.WriteLine($"Flashlight: {(_lightOn ? "ON" : "OFF")}");
        }
        
        // Check distance to target cube
        float distanceToTarget = Vector3.Distance(
            new Vector3(_camera.Position.X, 0, _camera.Position.Z),  // Player XZ position
            new Vector3(_targetCubePosition.X, 0, _targetCubePosition.Z)  // Target XZ position
        );

        // Update glow intensity based on distance
        if (distanceToTarget < 2.5f)
        {
            _glowIntensity = 0.1f + 0.4f * MathF.Sin(_time * 6.0f); 
        }
        else
        {
            _glowIntensity = 0.0f;  
        }
        
        _camera.Position = ApplyCollision(_camera.Position);
        
        _view = _camera.GetViewMatrix();

    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        
        GL.Clear(ClearBufferMask.ColorBufferBit |  ClearBufferMask.DepthBufferBit);
        
        Vector3 lightPos = _camera.Position;
        Vector3 viewPos = _camera.Position;
        
        // use shaders
        _shader.Use();
        
        // set matrix uniforms
        _shader.SetMatrix4("view", _view);
        _shader.SetMatrix4("projection", _projection);
        
        // lighting setup
        _shader.SetVector3("lightPos", lightPos);
        _shader.SetVector3("viewPos", viewPos);
        _shader.SetInt("lightOn", _lightOn ? 1 : 0);
        
        // DRAW FLOOR
        _floorTexture.Use(TextureUnit.Texture0);
        _shader.SetInt("texture1", 0);
        _shader.SetInt("useTexture", 1);
        
        Matrix4 floorModel = Matrix4.CreateScale(10.0f, 1.0f, 10.0f) * 
                             Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);
        _shader.SetMatrix4("model", floorModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
        _shader.SetInt("useTexture", 0);
        
        // DRAW CEILING
        Matrix4 ceilingModel = Matrix4.CreateScale(10.0f, 1.0f, 10.0f) * 
                             Matrix4.CreateTranslation(0.0f, 5.0f, 0.0f);
        _shader.SetMatrix4("model", ceilingModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
        
        
        // DRAW BACK WALL (+Z)
        _wallTexture.Use(TextureUnit.Texture0);
        _shader.SetInt("useTexture", 1);
        
        Matrix4 backWallModel = Matrix4.CreateScale(10.0f, 1.0f, 5.0f) *
                                 Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90.0f)) *
                                 Matrix4.CreateTranslation(0.0f, 2.5f, 5.0f);
        _shader.SetMatrix4("model", backWallModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
        
        // DRAW FRONT WALL (-Z) 
        Matrix4 frontWallModel = Matrix4.CreateScale(10.0f, 1.0f, 5.0f) *
                                 Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90.0f)) *
                                 Matrix4.CreateTranslation(0.0f, 2.5f, -5.0f);
        _shader.SetMatrix4("model", frontWallModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
        
        // DRAW LEFT WALL (-X)
        Matrix4 leftWallModel = Matrix4.CreateScale(5.0f, 1.0f, 10.0f) *
                                 Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-90.0f)) *
                                 Matrix4.CreateTranslation(-5.0f, 2.5f, 0.0f);
        _shader.SetMatrix4("model", leftWallModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
    
        // DRAW RIGHT WALL (X) 
        Matrix4 rightWallModel = Matrix4.CreateScale(5.0f, 1.0f, 10.0f) *
                                 Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-90.0f)) *
                                 Matrix4.CreateTranslation(5.0f, 2.5f, 0.0f);
        _shader.SetMatrix4("model", rightWallModel);
        GL.BindVertexArray(_planeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _planeIndices.Length, DrawElementsType.UnsignedInt, 0);
        _shader.SetInt("useTexture", 0);
    
        // DRAW CUBES  
        //spinning
        Matrix4 cube1Model =  Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f) * 
                              Matrix4.CreateRotationY(_time);
        _shader.SetMatrix4("model", cube1Model);
        GL.BindVertexArray(_cubeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _cubeIndices.Length, DrawElementsType.UnsignedInt, 0);
    
        Matrix4 cube2Model = Matrix4.CreateScale(0.8f) * Matrix4.CreateTranslation(-3.0f, 0.4f, -2.0f);
        _shader.SetMatrix4("model", cube2Model);
        GL.BindVertexArray(_cubeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _cubeIndices.Length, DrawElementsType.UnsignedInt, 0);
    
        Matrix4 cube3Model = Matrix4.CreateScale(0.6f) *Matrix4.CreateTranslation(3.5f, 0.3f, 1.0f); 
        _shader.SetMatrix4("model", cube3Model);
        GL.BindVertexArray(_cubeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _cubeIndices.Length, DrawElementsType.UnsignedInt, 0);
    
        // winning (target) cube
        // _shader.SetInt("useTexture", 1);
        _shader.SetFloat("glowIntensity", _glowIntensity);
        Matrix4 targetCubeModel = Matrix4.CreateScale(0.7f) * Matrix4.CreateTranslation(_targetCubePosition); 
        _shader.SetMatrix4("model", targetCubeModel);
        GL.BindVertexArray(_cubeVAO);
        GL.DrawElements(PrimitiveType.Triangles, _cubeIndices.Length, DrawElementsType.UnsignedInt, 0);
        _shader.SetFloat("glowIntensity", 0.0f);
        
        SwapBuffers();
    }
 
    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);
        
        // process only if cursor grabber
        if (!_cursorGrabbed)
            return;

        if (_firstMove)
        {
            _lastPos = e.Position;
            _firstMove = false;
        }
        else
        {
            float deltaX = e.Position.X - _lastPos.X;
            float deltaY = _lastPos.Y - e.Position.Y;
            
            _lastPos = e.Position;
            _camera.ProcessMouse(deltaX, deltaY);
        }
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, e.Width, e.Height);

        _camera.AspectRatio = e.Width / (float) e.Height;
        _projection = _camera.GetProjectionMatrix();
    }
    
    protected override void OnUnload()
    {
        base.OnUnload();
        
        GL.DeleteBuffer(_cubeVBO);
        GL.DeleteBuffer(_cubeEBO);
        GL.DeleteVertexArray(_cubeVAO);
        
        GL.DeleteBuffer(_planeVBO);
        GL.DeleteBuffer(_planeEBO);
        GL.DeleteVertexArray(_planeVAO);
        
        _shader.Dispose();
        _floorTexture.Dispose();
        _wallTexture.Dispose();
    }

    private void SetupPlane()
    {
        _planeVAO = GL.GenVertexArray();
        GL.BindVertexArray(_planeVAO);
        
        _planeVBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _planeVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, _planeVertices.Length * sizeof(float), _planeVertices, BufferUsageHint.StaticDraw);
        
        _planeEBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _planeEBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _planeIndices.Length * sizeof(uint), _planeIndices, BufferUsageHint.StaticDraw);
        
        // location = 0
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 11 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    
        // color = 1
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 11 * sizeof(float),3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
        
        // texture = 2
        GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, 11 * sizeof(float), 6 *  sizeof(float));
        GL.EnableVertexAttribArray(2);
        
        // normals - 3
        GL.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, 11 * sizeof(float), 8 * sizeof(float));
        GL.EnableVertexAttribArray(3);
    }
    
    private void SetupCube()
    {
        _cubeVAO = GL.GenVertexArray();
        GL.BindVertexArray(_cubeVAO);
        
        _cubeVBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _cubeVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, _cubeVertices.Length * sizeof(float), _cubeVertices, BufferUsageHint.StaticDraw);
        
        _cubeEBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _cubeEBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _cubeIndices.Length * sizeof(uint), _cubeIndices, BufferUsageHint.StaticDraw);
        
        // location = 0
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    
        // color = 1
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float),3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
        
        // GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float),6 * sizeof(float));
        // GL.EnableVertexAttribArray(2);

        
        // normals - 3
        GL.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 8 * sizeof(float));
        GL.EnableVertexAttribArray(3);
    }
    
    private Vector3 ApplyCollision(Vector3 newPosition)
    {
        // Room boundaries 
        float minX = -4.5f;
        float maxX = 4.5f;
        float minZ = -4.5f;
        float maxZ = 4.5f;
    
        // Clamp position to stay inside room
        newPosition.X = Math.Clamp(newPosition.X, minX, maxX);
        newPosition.Z = Math.Clamp(newPosition.Z, minZ, maxZ);
    
        // Keep Y locked at eye height
        newPosition.Y = 1.5f;
    
        return newPosition;
    }
}