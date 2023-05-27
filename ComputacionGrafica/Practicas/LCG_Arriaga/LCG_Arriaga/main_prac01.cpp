/*---------------------------------------------------------*/
/* ----------------   Práctica 1 --------------------------*/
/*-----------------    2023-1   ---------------------------*/
/*------------- Luis Sergio Valencia Castro ---------------*/
/*----------------- José Carlos Arriaga Mejía --------------------*/
#include <glew.h>
#include <glfw3.h>

#include <iostream>

void resize(GLFWwindow* window, int width, int height);
void my_input(GLFWwindow *window);

// settings
// Window size
int SCR_WIDTH = 800;
int SCR_HEIGHT = 600;

GLFWmonitor *monitors;
GLuint VBO, VAO;
GLuint shaderProgramRed;

static const char* myVertexShader = "										\n\
#version 330																\n\
																			\n\
layout (location = 0) in vec4 pos;											\n\
																			\n\
void main()																	\n\
{																			\n\
    gl_Position = vec4(pos.x, pos.y, pos.z, 1.0);							\n\
}";

// Fragment Shader
static const char* myFragmentShaderRed = "									\n\
#version 330																\n\
																			\n\
out vec3 finalColor;														\n\
																			\n\
void main()																	\n\
{																			\n\
    finalColor = vec3(1.0f, 0.0f, 0.0f);									\n\
}";

void myData(void);
void setupShaders(void);
void getResolution(void);


void getResolution()
{
	const GLFWvidmode * mode = glfwGetVideoMode(glfwGetPrimaryMonitor());

	SCR_WIDTH = mode->width;
	SCR_HEIGHT = (mode->height) - 80;
}

void myData()
{
	//posición x,y,z
	GLfloat vertices[] = {
		
		-0.4f, 0.3f, 0.0f, //0
		-0.1f, 0.3f, 0.0f, //1
		-0.1f, 0.6f, 0.0f, //2
		-0.6f, 0.6f, 0.0f, //3
		-0.6f, -0.6f, 0.0f, //4
		-0.1f, -0.6f, 0.0f, //5
		-0.1f, -0.3f, 0.0f, //6
		-0.4f, -0.3f, 0.0f, //7
		-0.4f, 0.3f, 0.0f, //8
		

		// 1ra Letra Nombre J
		0.3f, 0.3f, 0.0f, //9
		0.1f, 0.3f, 0.0f, //10
		0.1f, 0.6f, 0.0f, //11
		0.7f, 0.6f, 0.0f, //12
		0.7f, 0.3f, 0.0f, //13
		0.5f, 0.3f, 0.0f, //14
		0.5f, -0.6f, 0.0f, //15
		0.1f, -0.6f, 0.0f, //16
		0.1f, -0.3f, 0.0f, //17
		0.3f, -0.3f, 0.0f, //18
		0.3f, 0.3f, 0.0f, //19
		
	};

	//genera/aparta un espacio de memoria de video
	glGenVertexArrays(1, &VAO);//(# de arraglos, identiificador)
	//VAO Vertex Array Objects
	glBindVertexArray(VAO); //Activando el espacio

	glGenBuffers(1, &VBO);//Generando un buffer
	//VBO Vertex Buffer Objects
	glBindBuffer(GL_ARRAY_BUFFER, VBO);//activando el buffer
	//Agregando info
	//( Buffer de arreglos, tamaño, arreglo, )
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);
	glEnableVertexAttribArray(0);

	glBindBuffer(GL_ARRAY_BUFFER, 0);

	glBindVertexArray(0);

}

void setupShaders()
{
	unsigned int vertexShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vertexShader, 1, &myVertexShader, NULL);
	glCompileShader(vertexShader);

	unsigned int fragmentShaderRed = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fragmentShaderRed, 1, &myFragmentShaderRed, NULL);
	glCompileShader(fragmentShaderRed);

	shaderProgramRed = glCreateProgram();
	glAttachShader(shaderProgramRed, vertexShader);
	glAttachShader(shaderProgramRed, fragmentShaderRed);
	glLinkProgram(shaderProgramRed);

	//Check for errors 

	glDeleteShader(vertexShader);
	glDeleteShader(fragmentShaderRed);

}


int main()
{
    // glfw: initialize and configure
    // ------------------------------
    glfwInit();
    /*glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	*/

#ifdef __APPLE__
    glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE); // uncomment this statement to fix compilation on OS X
#endif

    // glfw window creation
    // --------------------
	monitors = glfwGetPrimaryMonitor();
	getResolution();

    GLFWwindow* window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "Practica 1", NULL, NULL);
    if (window == NULL)
    {
        std::cout << "Failed to create GLFW window" << std::endl;
        glfwTerminate();
        return -1;
    }
	glfwSetWindowPos(window, 0, 30);
    glfwMakeContextCurrent(window);
    glfwSetFramebufferSizeCallback(window, resize);

	glewExperimental = GL_TRUE;
	glewInit();

	myData();
	setupShaders();
    

    // render loop
    // While the windows is not closed
    while (!glfwWindowShouldClose(window))
    {
        // input
        // -----
        my_input(window);

        // render
        // Background color
        glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);


		//Display section
	//	glUseProgram(shaderProgramRed);//Cambia el color del relleno, programado por el profe

		glBindVertexArray(VAO);                  
		glBindBuffer(GL_ARRAY_BUFFER, VBO);
		glPointSize(4.0f); //Tamaño
		//Para dibujar los puntos del vector, solamente puntos continuos
		
		//(Lo que dibujara, Elemento Inicial, Num de puntos del arreglo que tomara)
	//	glDrawArrays(GL_POINTS, 0, 6); 

		//Dibuja lineas, reglas de union(une 0 con 1, 2 con 3) no son lineas contiguas
	//	glDrawArrays(GL_LINES, 0, 6); 

		/*Dibuja lineas contiguas pasando por todos los vertices
		Pero no une el vertice final con el inicial, puede repetir el primer vertice al final del
		arreglo, pero no es recomendable conarreglos muy grandes para eso se utiliza el GL_LINE_LOOP*/
	//	glDrawArrays(GL_LINE_STRIP, 0, 6); 

		//Une los todos los vertices
	//	glDrawArrays(GL_LINE_LOOP, 2, 3);

		//POLIGONOS
		//Hace un traingulo usando los 3 vertices apartir del inicial puesto
	//	glDrawArrays(GL_TRIANGLES, 2, 3);

		/*Va haciendo triangulos, iniciando de donde le indiquemos y recorrera el inicial hasta 
		no encontrar mas vertices en el arreglo*/
	//	glDrawArrays(GL_TRIANGLE_STRIP, 0, 6);

		/*Toma como pivote el inicial y va haciendo triangulos con los 2 sig vertices hasta recorrer
		todo el arreglo*/
	//	glDrawArrays(GL_TRIANGLE_FAN, 0, 6);//FAN-Abanico

		//Actividad
		//Diseño
		glDrawArrays(GL_LINE_LOOP, 0, 8);
		glDrawArrays(GL_LINE_LOOP, 9, 10);
		
		//Rellenando letra
		glDrawArrays(GL_TRIANGLE_FAN, 0, 5);
		glDrawArrays(GL_TRIANGLE_FAN, 4, 5);
		glDrawArrays(GL_TRIANGLE_FAN, 9, 7);
		glDrawArrays(GL_TRIANGLE_FAN, 15, 5);
		glBindVertexArray(0);
		

		glUseProgram(0);
		//End of Display Section


        // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
        // -------------------------------------------------------------------------------
        glfwSwapBuffers(window);
        glfwPollEvents();
    }

    // glfw: terminate, clearing all previously allocated GLFW resources.
    // ------------------------------------------------------------------
    glfwTerminate();
    return 0;
}

// process all input: query GLFW whether relevant keys are pressed/released this frame and react accordingly
// ---------------------------------------------------------------------------------------------------------
void my_input(GLFWwindow *window)
{
    if(glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)  //GLFW_RELEASE
        glfwSetWindowShouldClose(window, true);
}

// glfw: whenever the window size changed (by OS or user resize) this callback function executes
// ---------------------------------------------------------------------------------------------
void resize(GLFWwindow* window, int width, int height)
{
    // Set the Viewport to the size of the created window
    glViewport(0, 0, width, height);
}