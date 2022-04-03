namespace User.DDD.Core
{
    public class OperationResult
    {


        public OperationResultType Type { get; set; }
        public string Msg { get; set; }
    }

    public enum OperationResultType
    {

        Succeed,
        Fail
    }

}