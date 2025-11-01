#version 330 core

in vec3 vertexColor;
in vec2 texCoord;

out vec4 FragColor;

uniform sampler2D texture1;
uniform bool useTexture;
uniform float glowIntensity;

void main()
{
    vec4 staticColor;
    
    if (useTexture)
        staticColor = texture(texture1, texCoord);
    else
        staticColor = vec4(vertexColor, 1.0);

    if (glowIntensity > 0.0)
    {
        vec3 glowColor = vec3(1.0, 0.8, 0.2);  // Gold
        staticColor.rgb = mix(staticColor.rgb, glowColor, glowIntensity);
    }

    FragColor = staticColor;
}