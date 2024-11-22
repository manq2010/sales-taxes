namespace SalesTaxesApi.Models
{
    public class ResponsePaged<T>
    {
        public ResponsePaged()
        {
        }
        public ResponsePaged(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
