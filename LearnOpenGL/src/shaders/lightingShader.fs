#version 330 core
out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float shininess;
}; 

struct Light {
    vec3 position;
  
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 Normal; 
in vec3 FragPos;

uniform Light light; 
uniform Material material;
uniform vec3 viewPos;


void main()
{
	//Ambient
    vec3 ambient = (material.ambient * light.ambient);
	
	//Diffuse
	vec3 norm = normalize(Normal);								//Make normal
	vec3 lightDir = normalize(light.position - FragPos);		//Calculate light direction vector
	float diff = max(dot(norm, lightDir), 0.0);					//angle between normal and light vectors
	vec3 diffuse = light.diffuse * (diff * material.diffuse);	//Actual calculated light vector
	
	//Specular
	vec3 viewDir = normalize(viewPos - FragPos);								//Calculate view direction
	vec3 reflectDir = reflect(-lightDir, norm);									//Calculate reflect direction
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);	//Calculate the angle between the viewdirection and reflect direction
	vec3 specular = light.specular * (spec * material.specular);
	
    vec3 result = (ambient + diffuse + specular);
	FragColor = vec4(result, 1.0);
}  