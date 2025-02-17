namespace learn_net_core.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}