namespace Bot.Parameters
{
    public interface IParametersHandler<TParameters>
    {
        TParameters CreateParameters(string[] value);
    }
}