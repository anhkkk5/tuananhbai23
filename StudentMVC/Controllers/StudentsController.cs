using System.Threading.Tasks;  // Cần thiết để sử dụng async/await
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMVC.Models;

public class StudentsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StudentsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var apiUrl = "https://localhost:7269/api/students";
        var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync(apiUrl);
        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Error = $"Lỗi khi gọi API: {response.StatusCode}";
            return View(new List<Student>());
        }

        var jsonData = await response.Content.ReadAsStringAsync();
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonData);

        return View(students);
    }

}
