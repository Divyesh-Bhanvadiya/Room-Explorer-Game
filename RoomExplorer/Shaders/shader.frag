#version 330 core

in vec3 FragPos;
in vec3 Normal;
in vec3 vertexColor;
in vec2 texCoord;

out vec4 FragColor;

uniform sampler2D texture1;
uniform bool useTexture;
uniform float glowIntensity;

uniform vec3 lightPos;
uniform vec3 viewPos;
uniform bool lightOn;

void main()
{
    vec3 staticColor;
    vec3 result;
    
    if (useTexture)
        staticColor = texture(texture1, texCoord).rgb;
    else
        staticColor = vertexColor;

    // ambient lighting
    float ambientStrength = 0.2;
    vec3 ambient = ambientStrength * vec3(1.0);
    
    if (lightOn)
    {
        // Diffuse lighting
        vec3 norm = normalize(Normal);
        vec3 lightDir = normalize(lightPos - FragPos);
        float diff = max(dot(norm, lightDir), 0.0);
        vec3 diffuse = diff * vec3(1.0);

        // Specular lighting
        float specularStrength = 0.5;
        vec3 viewDir = normalize(viewPos - FragPos);
        vec3 reflectDir = reflect(-lightDir, norm);
        float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32.0);
        vec3 specular = specularStrength * spec * vec3(1.0);

        // Light fades with distance
        float distance = length(lightPos - FragPos);
        float attenuation = 1.0 / (1.0 + 0.09 * distance + 0.032 * distance * distance);

        diffuse *= attenuation;
        specular *= attenuation;

        result = (ambient + diffuse + specular) * staticColor;
    }
    else
    {
        result = ambient * staticColor;
    }
    
    if (glowIntensity > 0.0)
    {
        vec3 glowColor = vec3(1.0, 0.8, 0.2);  // Gold
        result = mix(result, glowColor, glowIntensity);
    }

    FragColor = vec4(result, 1.0);
    
}