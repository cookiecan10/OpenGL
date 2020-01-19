#version 330 core
out vec4 FragColor;

//in vec3 ourColor;
in vec2 TexCoord;

uniform sampler2D minecraft_grass;
uniform sampler2D myDirt;
uniform float visibility;

void main()
{
	//FragColor = texture(ourTexture, TexCoord) * vec4(ourColor, 1.0);//Mix texture + color
	//FragColor = vec4(ourColor, 1.0);//Only color
	FragColor = mix(texture(dirt, TexCoord), texture(myDirt, TexCoord), visibility);// * vec4(ourColor, 1.0);//Mix 2 textures
}