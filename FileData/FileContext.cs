using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Domain.Models;

namespace FileData;

public class FileContext
{
    private const string filepath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Todo> Todos
    {
        get
        {
            LoadData();
            return dataContainer!.Todos;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (File.Exists(filepath))
        {
            dataContainer = new()
            {
                Todos = new List<Todo>(),
                Users = new List<User>()
            };
            return;
        }

        string content = File.ReadAllText(filepath);
        dataContainer = JsonSerializer
    }
}