namespace velocity.Models
{
    public struct ErrorData
    {
        public int ErrorCode { get;  set; }
        public string ErrorMessage { get; set; }

        public ErrorData(int ErrorCode, string ErrorMessage)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
