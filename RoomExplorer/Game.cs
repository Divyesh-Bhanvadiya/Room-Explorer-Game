using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace RoomExplorer;

public class Game : GameWindow
{
    // CUBE
    private float[] _vertices =
    {
        // positions          // colors
        -0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,
        0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 0.0f,
        0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,
        -0.5f,  0.5f, -0.5f,  1.0f, 1.0f, 0.0f,
        -0.5f, -0.5f,  0.5f,  1.0f, 0.0f, 1.0f,
        0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 1.0f,
        0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 1.0f,
        -0.5f,  0.5f,  0.5f,  0.5f, 0.5f, 0.5f
    };

    private uint[] _indices =
    {
        // Back face
        0, 1, 2, 2, 3, 0,
        // Front face
        4, 5, 6, 6, 7, 4,
        // Left face
        0, 4, 7, 7, 3, 0,
        // Right face
        1, 5, 6, 6, 2, 1,
        // Bottom face
        0, 1, 5, 5, 4, 0,
        // Top face
        3, 2, 6, 6, 7, 3
    };
    
    // Rendering variables
    private int _vbo, _vao, _ebo;
    private Matrix4 _model, _view, _projection;
    private float _time;
    
    private Shader _shader;
    private Camera _camera;
    private bool _firstMove;
    private Vector2 _lastPos;
    private bool _cursorGrabbed = true;
    
    public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) 
    {}

    protected override void OnLoad()
    {
        base.OnLoad();
        
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f); // greenish gray BG
        GL.Enable(EnableCap.DepthTest);
        
        // generate and bind VAO
        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);
        
        // generate and bind VBO
        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        
        // generate and bind EBO
        _ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer,  _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            
        // setup VAO
        // Location = 0
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
        
        // Color = 1
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
        
        // Shader Compilation
        _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        
        // Initialise matrices
        _model = Matrix4.Identity;
        
        // Initialise Camera
        _camera = new Camera(new Vector3(0.0f, 1.5f, -3.0f), Size.X / (float) Size.Y); // 3 units away from origin
        _view = _camera.GetViewMatrix();
        _projection = _camera.GetProjectionMatrix();

        CursorState = CursorState.Grabbed;
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

        _view = _camera.GetViewMatrix();

        // Rotate for test (temp)
        // _model = Matrix4.CreateRotationY(_time) *  Matrix4.CreateRotationX(_time * 0.5f);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        
        GL.Clear(ClearBufferMask.ColorBufferBit |  ClearBufferMask.DepthBufferBit);
        
        // use shaders
        _shader.Use();
        
        // set matrix uniforms
        _shader.SetMatrix4("model", _model);
        _shader.SetMatrix4("view", _view);
        _shader.SetMatrix4("projection", _projection);
        
        // DRAW
        GL.BindVertexArray(_vao);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        
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
            _lastPos = new Vector2(e.X, e.Y);
            _firstMove = false;
        }
        else
        {
            float deltaX = e.X - _lastPos.X;
            float deltaY = _lastPos.Y - e.Y;
            
            _lastPos = new Vector2(e.X, e.Y);
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
        
        GL.DeleteBuffer(_vbo);
        GL.DeleteBuffer(_ebo);
        GL.DeleteVertexArray(_vao);
        _shader.Dispose();
    }
}