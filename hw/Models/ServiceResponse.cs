namespace hw.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        // todo: result code
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}