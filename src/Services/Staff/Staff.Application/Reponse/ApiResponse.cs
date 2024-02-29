namespace Staff.Application.Reponse
{
    public class ApiResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Url { get; set; }
        public T Data { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
