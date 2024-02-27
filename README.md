## ASP.NET Core with Entity Framework SQLite Project

This README provides instructions on how to run this ASP.NET Core project with SQLite integration. Follow these steps to set up and run the project.

### Prerequisites

Before running the project, ensure that you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Installation Steps

1. **Clone the Repository:**

   Clone the repository to your local machine using the following command:

    ```bash
    git clone <repository-url>
    ```

2. **Navigate to Project Directory:**

   Navigate to the directory of the ASP.NET Core project.

    ```bash
    cd <project-directory>
    ```

3. **Restore Packages:**

   Run the following command to restore the necessary NuGet packages:

    ```bash
    dotnet restore
    ```

4. **Install Entity Framework Core Packages(If not installed with the `dotnet restore` command):**

   Install the required Entity Framework Core packages by running the following commands:

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    ```

5. **Install the Entity Framework Core Command-Line Tool:**

   Install the Entity Framework Core command-line tool globally:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

6. **Apply Database Migrations:**

   Use the Entity Framework Core command-line tool to apply database migrations:

    ```bash
    dotnet ef migrations add InitialCreate
    ```

7. **Update the Database:**

   Once migrations are applied, update the database with the following command:

    ```bash
    dotnet ef database update
    ```

### Running the Application

After completing the installation steps, you can run the ASP.NET Core application using the following command:

```bash
dotnet run
```

The application will start, and you can access it by navigating to the specified URL in your web browser.