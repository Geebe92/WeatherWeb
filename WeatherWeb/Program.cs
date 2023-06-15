using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Net.Http;
using System.Threading.Tasks;

string url = "http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=616b3c6623805f4fd2ef1379813f5678";


using (HttpClient client = new HttpClient())
{
    try
    {
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            // Tutaj mo¿esz przetworzyæ pobrane dane JSON wed³ug potrzeb
            Console.WriteLine(jsonResponse);
        }
        else
        {
            Console.WriteLine("B³¹d w ¿¹daniu: " + response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("B³¹d: " + ex.Message);
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
