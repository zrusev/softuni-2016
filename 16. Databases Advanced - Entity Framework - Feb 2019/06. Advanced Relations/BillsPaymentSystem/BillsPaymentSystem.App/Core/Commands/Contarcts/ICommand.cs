namespace BillsPaymentSystem.App.Core.Commands.Contarcts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
