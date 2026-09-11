#include <stdio.h>
#include <unistd.h>
#include <string.h>
#include <sys/types.h>

int main()
{
    int fd[2];
    pid_t pid;
    char message[] = "Hello from Parent Process";
    char buffer[100];

    // Create pipe
    pipe(fd);

    // Create child process
    pid = fork();

    if (pid < 0)
    {
        printf("Fork failed\n");
        return 1;
    }

    if (pid > 0)
    {
        // Parent process - writes to pipe
        close(fd[0]);  // Close reading end

        write(fd[1], message, strlen(message) + 1);

        printf("Parent: Message sent to child\n");

        close(fd[1]); // Close writing end
    }
    else
    {
        // Child process - reads from pipe
        close(fd[1]);  // Close writing end

        read(fd[0], buffer, sizeof(buffer));

        printf("Child: Message received: %s\n", buffer);

        close(fd[0]); // Close reading end
    }

    return 0;
}