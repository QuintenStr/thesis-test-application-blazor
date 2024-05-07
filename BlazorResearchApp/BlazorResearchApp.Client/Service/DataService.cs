using BlazorResearchApp.Client.Model;

namespace BlazorResearchApp.Client.Service
{
    public class DataService
    {
        private readonly HttpClient httpClient;
        public DataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Person>> LoadDataAsync(string filePath) {
            var csvContent = await httpClient.GetStringAsync(filePath);
            var csvService = new CsvService();
            return await csvService.ReadCsvAsync(csvContent);

        }
    }
}
